using FactoryAdapter.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAdapter.Implementation
{
    internal class SqlDataMapper:IRetriveData
    {
        SqlDataReader _dataReader;
        public SqlDataMapper(SqlDataReader dataReader) {
            _dataReader = dataReader;
        }

        public DateTime GetAsDate(string columnName) {
            return Convert.ToDateTime(_dataReader[columnName]);
        }

        public decimal GetAsDecimal(string columnName) {
            return Convert.ToDecimal(_dataReader[columnName]);
        }

        public double GetAsDouble(string columnName) {
            return Convert.ToDouble(_dataReader[columnName]);
        }

        public int GetAsInt(string columnName) {
            return Convert.ToInt32(_dataReader[columnName]);
        }

        public string GetAsString(string columnName) {
            return Convert.ToString(_dataReader[columnName]);
        }

        public Boolean Read() {
            return _dataReader.Read();
        }
    }
}
