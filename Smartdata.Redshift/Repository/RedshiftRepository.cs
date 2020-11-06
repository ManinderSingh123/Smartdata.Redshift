using Microsoft.Extensions.Options;
using Npgsql;
using NpgsqlTypes;
using Redmap.Events.Common;
using Redmap.Redshift.DTO;
using Redmap.Redshift.Model;
using Redmap.Redshift.Repository.Interface;
using System;

namespace Redmap.Events.Repository
{
    /// <summary>
    /// Redshift Repository
    /// </summary>
    public class RedshiftRepository : IRedshiftRepository
    {
        #region database connection

        private readonly AppSettings _settings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        public RedshiftRepository(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
        #endregion

        #region repository functions

        /// <summary>
        /// Save redshift data 
        /// </summary>
        /// <param name="model"></param>

        public ResponseModelDto SaveRedshiftData(TableColumnModel model)
        {

            ResponseModelDto responsemodel = new ResponseModelDto();

            var qry = String.Format("insert into {0} ({1}) values ({2})", model.TableName, model.ColumnName, model.ColumnValue);

            using (var conn = new NpgsqlConnection(CommonClass.GetConnectionString(_settings.ServerName, _settings.Port, _settings.UserName, _settings.Password, _settings.Database)))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    for (int i = 0; i < model.ColumnsList.Count; i++)
                    {
                        switch (model.ColumnsList[i].DataType.ToString())
                        {
                            case "date":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Date, string.IsNullOrEmpty(model.ColumnValue) ? (DateTime?)null : Convert.ToDateTime(CommonClass.ChangeDateFormat(model.ColumnsList[i].ColumnValue)));
                                break;
                            case "text":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Varchar, model.ColumnsList[i].ColumnValue);
                                break;
                            case "int":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Integer, Convert.ToInt32(model.ColumnsList[i].ColumnValue));
                                break;
                            case "bool":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Boolean, Convert.ToBoolean(model.ColumnsList[i].ColumnValue));
                                break;

                            case "float":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Double, Convert.ToDouble(model.ColumnsList[i].ColumnValue));
                                break;
                        }                   
                }

                cmd.Connection = conn;
                cmd.CommandText = qry;

                if (!CommonClass.VerifyQuery(qry))
                {
                    cmd.ExecuteReader();
                    responsemodel.Message = "Data successfully saved";
                    responsemodel.StatusCode = "200";
                    responsemodel.Status = true;
                }
                else
                {
                    responsemodel.Message = "Characters are not valid in query";
                    responsemodel.StatusCode = "400";
                    responsemodel.Status = false;
                }
            }
        }
            return responsemodel;
        }


    /// <summary>
    /// Delete redshift data
    /// </summary>
    /// <param name="model"></param>
    /// <param name="sqlquery"></param>
    /// <returns></returns>
    public ResponseModelDto DeleteRedshiftData(TableColumnModel model, string sqlquery)
    {
        ResponseModelDto responsemodel = new ResponseModelDto();
        if (model.ColumnsList.Count > 0)
        {

            using (var conn = new NpgsqlConnection(CommonClass.GetConnectionString(_settings.ServerName, _settings.Port, _settings.UserName, _settings.Password, _settings.Database)))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    for (int i = 0; i < model.ColumnsList.Count; i++)
                    {
                        switch (model.ColumnsList[i].DataType.ToString())
                        {
                            case "date":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Date, string.IsNullOrEmpty(model.ColumnValue) ? (DateTime?)null : Convert.ToDateTime(CommonClass.ChangeDateFormat(model.ColumnsList[i].ColumnValue)));
                                break;
                            case "text":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Varchar, model.ColumnsList[i].ColumnValue);
                                break;
                            case "int":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Integer, Convert.ToInt32(model.ColumnsList[i].ColumnValue));
                                break;
                            case "bool":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Boolean, model.ColumnValue);
                                break;

                            case "float":

                                cmd.Parameters.AddWithValue(model.ColumnsList[i].ColumnName, NpgsqlDbType.Double, model.ColumnValue);
                                break;


                        }                        
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sqlquery;
                    cmd.ExecuteReader();
                }
            }

            responsemodel.StatusCode = "200";
            responsemodel.Status = true;
            responsemodel.Message = "Data successfully deleted";
        }
        return responsemodel;
    }

}

    #endregion

}

