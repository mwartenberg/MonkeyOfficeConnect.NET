using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyOfficeConnectNet.DataItems
{

    public class ApiInfoItem
    {
        public string App_Name { get; set; }
        public string App_Homepage { get; set; }
        public string App_Email { get; set; }
        public int App_MajorVersion { get; set; }
        public int App_MinorVersion { get; set; }
        public int App_BugVersion { get; set; }
        public int App_APISchemaVersion { get; set; }
        public string App_CopyRight { get; set; }
        public bool App_NewVersion { get; set; }
    }

}
