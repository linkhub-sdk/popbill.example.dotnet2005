using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Serialization;
using System.Json;

namespace Popbill.Fax
{
    
    public class FaxReceiver
    {
        [JsonMapFieldName("rcv")]
        public string receiveNum;
        [JsonMapFieldName("rcvnm")]
        public string receiveName;
    }
}
