using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWManagerDAL
{
    public class DbHelp
    {
        static string str = System.Configuration.ConfigurationManager
            .ConnectionStrings["AWManager"].ToString();


        # region 普通增,删，改
        /// <summary>
        /// 普通增,删，改
        /// </summary>
        /// <param name="sql">增,删，改语句</param>
        /// <returns></returns>
        public static int CUD(string sql)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int index = cmd.ExecuteNonQuery();
                return index;

            }
            catch (Exception ex)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        # region 普通增,删，改(带参数)
        /// <summary>
        /// 普通增,删，改(带参数)
        /// </summary>
        /// <param name="sql">增,删，改语句</param>
        /// <returns></returns>
        public static int CUD(string sql, List<SqlParameter> sqlParameters)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(sqlParameters.ToArray());
                int index = cmd.ExecuteNonQuery();
                return index;

            }
            catch (Exception ex)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
            
        }
        #endregion

        #region 执行查询语句，返回sqldatereader对象
        /// <summary>
        /// 执行查询语句，返回sqldatereader对象
        /// </summary>
        /// <param name="sql">普通SQL语句</param>
        /// <returns>SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr
                    = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                return sdr;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region 执行查询语句，返回sqldatereader对象，参数化的sql语句
        /// <summary>
        /// 执行查询语句，返回sqldatereader对象，参数化的sql语句
        /// </summary>
        /// <param name="sql">参数化的sql语句</param>
        /// <returns>SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string sql, List<SqlParameter> sqlParameters)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(sqlParameters.ToArray());
                SqlDataReader sdr
                    = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                return sdr;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region 执行查询语句，返回DataTable对象(普通SQL语句)
        /// <summary>
        /// 执行查询语句，返回DataTable对象(普通SQL语句)
        /// </summary>
        /// <param name="sql">普通的sql语句</param>
        /// <returns>DataTable对象</returns>
        public static DataTable GetDateTable(string sql)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 执行查询语句，返回DataTable对象(参数化的SQL语句)
        /// <summary>
        /// 执行查询语句，返回DataTable对象(参数化的SQL语句)
        /// </summary>
        /// <param name="sql">参数化的sql语句</param>
        /// <returns>DataTable对象</returns>
        public static DataTable GetDateTable(string sql, List<SqlParameter> sqlParameters)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(sqlParameters.ToArray());
                sqlData.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 执行查询语句，返回object对象(普通的SQL语句)
        /// <summary>
        /// 执行查询语句，返回object对象(普通的SQL语句)
        /// </summary>
        /// <param name="sql">普通的sql语句</param>
        /// <returns>object对象</returns>
        public static object GetScalar(string sql)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                object result = cmd.ExecuteScalar();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion  

        #region 执行查询语句，返回object对象(参数化的SQL语句)
        /// <summary>
        /// 执行查询语句，返回object对象(参数化的SQL语句)
        /// </summary>
        /// <param name="sql">参数化的sql语句</param>
        /// <returns>object对象</returns>
        public static object GetScalar(string sql, List<SqlParameter> sqlParameters)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(sqlParameters.ToArray());
                object result = cmd.ExecuteScalar();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion  

    }
}
