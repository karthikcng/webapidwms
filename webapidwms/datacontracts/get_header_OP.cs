using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using webapidwms.dataobjects;

namespace webapidwms.datacontracts
{
    public class get_header_OP
    {
        [DataMember]
        public List<tbl> ml_main { get; set; }
        public get_header_OP()
        {
            ml_main = new List<tbl>();
        }
    }
}
