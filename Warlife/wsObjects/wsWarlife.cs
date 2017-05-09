using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Warlife.wsObjects
{


    #region DataBase

    public class DataBase
    {

        #region Attributes

        /// <summary>
        ///connection string
        /// </summary>
        public string sConnStr = "Data Source=SQL5033.SmarterASP.NET;Initial Catalog=DB_A1F73F_WarLife;User Id=DB_A1F73F_WarLife_admin;Password=autosnack1;";

        #endregion

        #region Methods


        /// <summary>
        /// Load the DB answer and fill a Dataset
        /// </summary>
        /// <param name="aParams"></param>
        /// <param name="sSql"></param>
        /// <param name="dsDatos"></param>
        /// <param name="sMenErr"></param>
        /// <returns></returns>
        public bool LoadQueryintoDataSet(SqlParameter[] aParams, string sSql, DataSet dsDatos, out string sMenErr)
        {
            sMenErr = "";
            try
            {
                SqlConnection sqlConn;
                SqlDataAdapter sqlDataAdapter;
                sqlConn = new SqlConnection(sConnStr);
                try
                {
                    sqlDataAdapter = new SqlDataAdapter(sSql, sqlConn);
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(aParams);
                    sqlDataAdapter.Fill(dsDatos);
                }
                finally
                {
                    sqlConn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                sMenErr = "ERSQL00012" + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Execute a single command in the database
        /// </summary>
        /// <param name="sSql">Sql sentence</param>
        /// <param name="sErrMess">Error message if exists</param>
        /// <returns>True if is succesfull</returns>
        /// 
        public bool ExecuteSql(string sSql, out string sErrMess)
        {
            sErrMess = "";
            try
            {
                SqlConnection sqlConn;
                SqlCommand sqlComm;
                sqlConn = new SqlConnection(sConnStr);
                sqlComm = new SqlCommand();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandText = sSql;
                try
                {
                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                }
                finally
                {
                    sqlConn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                sErrMess = "ERSQL00002" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Methot that execute the SQL string
        /// </summary>
        /// <param name="sqlComm"></param>
        /// <param name="sSql"></param>
        /// <param name="sErrMess"></param>
        /// <returns></returns>
        public bool ExecuteSql(SqlCommand sqlComm, string sSql, out string sErrMess)
        {
            sErrMess = "";
            try
            {
                SqlConnection sqlConn;
                sqlConn = new SqlConnection(sConnStr);
                sqlComm.Connection = sqlConn;
                sqlComm.CommandText = sSql;
                try
                {
                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                }
                finally
                {
                    sqlConn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                sErrMess = "ERSQL00003" + ex.Message;
                return false;
            }
        }

        #endregion
    }
    #endregion

    #region Utils

    public class Utils
    {

        #region Methods

        public object ConvertIfNull(object Value)
        {
            if (Value == null)
                return DBNull.Value;
            else
                return Value;
        }

        #endregion

    }
    #endregion

    #region User

    public class User
    {
        #region Attributes

        #endregion

        #region Methods

        public bool SetNewUser(string sUserName, string sPassword, DateTime dtCreationDate, out string sResponseMessage)
        {
            try
            {
                DataBase DataBase = new DataBase();

                Utils utils = new Utils();

                SqlCommand sqlComm = new SqlCommand();

                SqlParameter[] aParams = new SqlParameter[2];

                aParams[0] = new SqlParameter("@sUserName", utils.ConvertIfNull(sUserName));
                aParams[1] = new SqlParameter("@sPassword", utils.ConvertIfNull(sPassword));
                aParams[2] = new SqlParameter("@dtCreationDate", utils.ConvertIfNull(dtCreationDate));

                string sSql;

                sqlComm.Parameters.AddRange(aParams);

                sSql = "INSERT INTO Usuario([username],[password],[creation_date]) VALUES(@sUserName, @sPassword, @dtCreationDate)";

                return DataBase.ExecuteSql(sqlComm, sSql, out sResponseMessage);
            }
            catch (Exception e)
            {
                sResponseMessage = e.Message;
                return false;
            }



        }

        #endregion
    }
    #endregion
}