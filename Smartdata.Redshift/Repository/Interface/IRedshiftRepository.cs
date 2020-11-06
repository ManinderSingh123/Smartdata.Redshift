using Redmap.Redshift.DTO;
using Redmap.Redshift.Model;

namespace Redmap.Redshift.Repository.Interface
{
    /// <summary>
    /// Event message repository interface
    /// </summary>
    public interface IRedshiftRepository
    {

        /// <summary>
        /// Save redshift data.
        /// </summary>
        /// <param name="model"></param>

        ResponseModelDto SaveRedshiftData(TableColumnModel model);

        
        /// <summary>
        /// Delete redshift data
        /// </summary>
        /// <param name="model"></param>
        ResponseModelDto DeleteRedshiftData(TableColumnModel model, string sqlquery);
    }
}
