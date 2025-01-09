
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapidwms.bussinesslogic;
using webapidwms.datacontracts;

namespace webapidwms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DWMSController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public DWMSController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("Get_DwmsMenu")]
        public JsonResult Get_DwmsMenu(get_menu_IP ip)
        {
            String connectionString = Configuration["DBConnection"];

            get_menu_OP op = new get_menu_OP();

            MAIN_BL bl = new MAIN_BL();

            bl.Get_DwmsMenu(ref ip, ref op, connectionString);
            return new JsonResult(op);
        }
    }
}
