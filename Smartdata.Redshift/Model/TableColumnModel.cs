using Redmap.Redshift.DTO;
using System.Collections.Generic;

namespace Redmap.Redshift.Model
{
    /// <summary>
    /// Table Column 
    /// </summary>
    public class TableColumnModel
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Columns List
        /// </summary>
        public List<Columns> ColumnsList { get; set; }

        /// <summary>
        /// Column Name
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// Column Value
        /// </summary>
        public string ColumnValue { get; set; }

    }

   
}