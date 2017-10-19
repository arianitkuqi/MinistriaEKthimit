using FactoryAdapter.Contract;
using FactoryAdapter.Helpers;
using FactoryAdapter.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAdapter
{
    public class FactoryAdapter
    {
        private static FactoryAdapter instance = null;
        private static IMappingContract _mapper;
        private static string _connectionString = "";



        private FactoryAdapter() {

            _mapper = new MappingPerformer();

        }

        public static FactoryAdapter Initialize(string connectionString) {
            _connectionString = connectionString;
            if (instance is null) {
                instance = new FactoryAdapter();
            }
            return instance;
        }




        #region InsertOrUpdate

        public bool InsertOrUpdate<T>(String queryOrProc, IRequest item) where T : class, new() {
            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (item != null)
                        cmd.Parameters.AddRange(GetParams(item));
                }

                con.Open();
                return cmd.ExecuteNonQuery() >= 1 ? true : false;

            }
        }

        #endregion


        #region GetSingle

        public T GetSingle<T>(String queryOrProc, params dynamic[] parametres) where T : class, new() {

            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametres != null)
                        cmd.Parameters.AddRange(GetParams(parametres));
                }
                con.Open();

                using (var reader = cmd.ExecuteReader()) {
                    return _mapper.MapObject<T>(new SqlDataMapper(reader));
                }
            }
        }


        public T GetSingle<T>(String queryOrProc, IRequest requestedObj) where T : class, new() {

            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (requestedObj != null)
                        cmd.Parameters.AddRange(GetParams(requestedObj));
                }
                con.Open();

                using (var reader = cmd.ExecuteReader()) {
                    return _mapper.MapObject<T>(new SqlDataMapper(reader));
                }
            }
        }

        #endregion


        #region GetAll


        public List<T> GetAll<T>(String queryOrProc, params dynamic[] parametres) where T : class, new() {

            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametres != null)
                        cmd.Parameters.AddRange(GetParams(parametres));
                }

                con.Open();

                using (var reader = cmd.ExecuteReader()) {
                    return _mapper.MapList<T>(new SqlDataMapper(reader));
                }
            }
        }

        public List<T> GetAll<T>(String queryOrProc, IRequest requestedObj) where T : class, new() {

            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (requestedObj != null)
                        cmd.Parameters.AddRange(GetParams(requestedObj));
                }

                con.Open();

                using (var reader = cmd.ExecuteReader()) {
                    return _mapper.MapList<T>(new SqlDataMapper(reader));
                }
            }
        }

        #endregion


        #region DeleteOrDeactive
        public bool DeleteOrDeactivate(string queryOrProc, dynamic parameter) {
            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameter != null)
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }

                con.Open();
                return cmd.ExecuteNonQuery() >= 1 ? true : false;


            }
        }

        public bool DeleteOrDeactivate(string queryOrProc, IRequest requestedObj) {
            using (SqlConnection con = new SqlConnection(_connectionString)) {

                SqlCommand cmd = new SqlCommand(queryOrProc, con);
                if (!IsProcedure(queryOrProc)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (requestedObj != null)
                        cmd.Parameters.AddRange(GetParams(requestedObj));
                }

                con.Open();
                return cmd.ExecuteNonQuery() >= 1 ? true : false;


            }
        }
        #endregion


        #region Helpers
        private bool IsProcedure(string queryOrProc) {
            string qq = queryOrProc.ToLower();

            return qq.Contains("*") | qq.Contains("where") | (qq.Contains("select ") && qq.ToLower().Contains("from"));
        }


        private SqlParameter[] GetParams(IRequest obj) {
            var listParams = new List<SqlParameter>();

            foreach (PropertyInfo item in obj.GetType().GetProperties()) {

                object val = item.GetValue(obj);
                listParams.Add(new SqlParameter(item.Name, val));
            }

            return listParams.ToArray();
        }

        private SqlParameter[] GetParams(dynamic[] dynamicParams) {
            var listParams = new List<SqlParameter>();

            foreach (var item in dynamicParams as dynamic) {                

                listParams.Add(new SqlParameter(GetVal(item,"Key"), GetVal(item,"Value")));
            }

            return listParams.ToArray();
        }

        private string GetVal(object o, string prop) {

            return o.GetType().GetProperty(prop).GetValue(o, null).ToString();        }


        #endregion

    }
}
