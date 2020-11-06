using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Redmap.Redshift.DTO;
using Redmap.Redshift.Model;
using Redmap.Redshift.Repository.Interface;
using Redmap.Redshift.Services.Interface;
using System;

namespace Redmap.Events.Services
{
    /// <summary>
    /// Redshift Service
    /// </summary>
    public class RedshiftService : IRedshiftService
    {
        #region constructor
        private readonly IRedshiftRepository redshiftRepository;
        [Obsolete]
        private readonly IMapper mapper;
        private readonly string errorLogApiUrl;


        /// <summary>
        /// redshift service
        /// </summary>
        /// <param name="redshiftRepository"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="mapper"></param>
        /// <param name="configuration"></param>
        [Obsolete]
        public RedshiftService(IRedshiftRepository redshiftRepository, IHostingEnvironment hostingEnvironment, IMapper mapper, IConfiguration configuration)
        {
            this.redshiftRepository = redshiftRepository;
            this.mapper = mapper;
            this.errorLogApiUrl = configuration.GetValue<string>("SiteInfo:Url");
        }
        #endregion

        #region service functions


        /// <summary>
        /// Save redshift data.
        /// </summary>
        /// <param name="modelDto"></param>
        [Obsolete]
        public ResponseModelDto SaveRedshiftData(TableColumnDto modelDto)
        {
            ResponseModelDto responsemodel = new ResponseModelDto();

            var model = mapper.Map<TableColumnModel>(modelDto);

            // create dynamic query RedshiftDataModel
            var columnNames = "";
            var columnValues = "";

            foreach (var item in model.ColumnsList)
            {
                columnNames += item.ColumnName + ",";

                if (item.DataType == "date")
                {
                    columnValues += string.IsNullOrEmpty(item.ColumnValue) ? "null," : "@" + item.ColumnName + ",";
                }
                else
                {
                    columnValues += "@" + item.ColumnName + ",";
                }               
            }

            model.ColumnValue = columnValues.TrimEnd(',');
            model.ColumnName = columnNames.TrimEnd(',');

            responsemodel = redshiftRepository.SaveRedshiftData(model);

            return responsemodel;
        }

        
        /// <summary>
        /// Delete Redshift Data
        /// </summary>
        /// <param name="dtoModel"></param>        
        [Obsolete]
        public ResponseModelDto DeleteRedshiftData(TableColumnDto dtoModel)
        {

            ResponseModelDto responsemodel = new ResponseModelDto();
            if (dtoModel != null)
            {
                var model = mapper.Map<TableColumnModel>(dtoModel);

                var qry = String.Format("Delete from {0}  where ", model.TableName);
                var compareColumn = "";
                var itemCount = 0;
                foreach (var item in model.ColumnsList)
                {
                    if (itemCount > 0)
                    {
                        compareColumn += " AND " + item.ColumnName + "=@" + item.ColumnName;
                    }
                    else
                    {
                        compareColumn += item.ColumnName + "=@" + item.ColumnName;
                    }

                    itemCount++;
                }

                qry += compareColumn;

                responsemodel = redshiftRepository.DeleteRedshiftData(model,qry);
            }
            return responsemodel;
        }
        #endregion
    }
}