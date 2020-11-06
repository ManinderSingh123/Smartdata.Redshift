using Redmap.Redshift.DTO;
using Redmap.Redshift.Model;

namespace Redmap.Redshift.Services.Interface
{
    /// <summary>
    ///Event message service interface.
    /// </summary>
    public interface IRedshiftService
    {
        /// <summary>
        /// Save Redshift Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseModelDto SaveRedshiftData(TableColumnDto model);

        
        /// <summary> 
        /// Delete redshift data
        /// </summary>
        /// <param name="model"></param>
        ResponseModelDto DeleteRedshiftData(TableColumnDto model);
    }
}
