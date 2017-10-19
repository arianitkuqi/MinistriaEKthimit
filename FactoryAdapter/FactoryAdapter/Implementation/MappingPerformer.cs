using FactoryAdapter.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAdapter.Implementation
{
    internal class MappingPerformer : IMappingContract
    {
        public T MapObject<T>(IRetriveData data) where T : class, new()
        {
            T obj = new T();
            while (data.Read())
                MapValues(data, typeof(T).GetProperties(), obj);
            return obj;
        }


        public List<T> MapList<T>(IRetriveData data) where T : class, new()
        {
            var list = new List<T>();

            while (data.Read())
            {
                var item = new T();
                MapValues(data, typeof(T).GetProperties(), item);
                list.Add(item);
            }
            return list;
        }


        #region Method Helpers
        private void MapValues<T>(IRetriveData data, PropertyInfo[] properties, T obj)
        {

            if ((object)obj != DBNull.Value)
                foreach (PropertyInfo property in properties)
                {
                    if (GetType(property) == "System.Int32")
                        property.SetValue(obj, data.GetAsInt(property.Name));

                    if (GetType(property) == "System.String")
                        property.SetValue(obj, data.GetAsString(property.Name));

                    if (GetType(property) == "System.Decimal")
                        property.SetValue(obj, data.GetAsDecimal(property.Name));

                    if (GetType(property) == "System.Double")
                        property.SetValue(obj, data.GetAsDouble(property.Name));

                    if (GetType(property) == "System.DateTime")
                        property.SetValue(obj, data.GetAsDate(property.Name));
                }
        }

        private string GetType(PropertyInfo property)
        {
            return property.PropertyType.ToString();
        }

        #endregion
    }
}
