using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using webapidwms.dataobjects;

namespace webapidwms.datacontracts
{
    public class get_menu_OP
    {
        [DataMember]
        public List<vw_user_role_main_menu> ml_dwms { get; set; }
        public get_menu_OP()
        {
            ml_dwms = new List<vw_user_role_main_menu>();
        }
    }
}
