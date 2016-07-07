using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyOfficeConnectNet.DataItems
{

    public class Firmalistresponse
    {
        public Returndata ReturnData { get; set; }
    }

    public class Returndata
    {
        public Firmalistitem[] FirmaListItem { get; set; }
    }

    public class Firmalistitem
    {
        public string Firma_ID { get; set; }
        public string Bezeichnung { get; set; }
    }

}
