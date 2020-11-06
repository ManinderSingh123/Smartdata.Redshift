using System.Collections.Generic;

namespace Redmap.Redshift.DTO
{
    /// <summary>
    /// Table Column Dto
    /// </summary>
    public class TableColumnDto
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Columns List
        /// </summary>
        public List<Columns> ColumnsList { get; set; }
       
    }

    /// <summary>
    /// Columns
    /// </summary>
    public class Columns
    {
        /// <summary>
        /// Column Name
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// Column Value
        /// </summary>
        public string ColumnValue { get; set; }
        /// <summary>
        /// Data Type
        /// </summary>
        public string DataType { get; set; }
    }
}