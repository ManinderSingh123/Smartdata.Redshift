using Microsoft.AspNetCore.Mvc;
using Redmap.Redshift.DTO;
using Redmap.Redshift.Services.Interface;


namespace Redmap.Redshift.Controllers
{
    /// <summary>
    /// Log Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RedshiftController: ControllerBase
    {

        private readonly IRedshiftService redshiftService;
        /// <summary>
        /// Redshift Controller Constructer
        /// </summary>
        /// <param name="redshiftService"></param>
        public RedshiftController(IRedshiftService redshiftService)
        {
            this.redshiftService = redshiftService;
        }

        /// <summary>
        /// Post data on redshift database
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]       
        public ActionResult PostDataOnRedshift([FromBody] TableColumnDto model)
        {
            var response = redshiftService.SaveRedshiftData(model);
            return Ok(response);
        }

        /// <summary>
        /// Delete redshift record by dynamic parameter.
        /// </summary>
        /// <param name="model"></param>
        [HttpDelete]
        [Produces("application/json")]        
        public ActionResult DeleteRedshiftData([FromBody] TableColumnDto model)
        {
            var response = redshiftService.DeleteRedshiftData(model);
            return Ok(response);
        }
    }
}