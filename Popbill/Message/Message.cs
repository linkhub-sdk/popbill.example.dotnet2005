using System;
using System.Collections.Generic;
using System.Text;
using System.Json;

namespace Popbill.Message
{
    
    public class Message
    {
        [JsonMapFieldName("snd")]
        public string sendNum;
        [JsonMapFieldName("rcv")]
        public string receiveNum;
        [JsonMapFieldName("rcvnm")]
        public string receiveName;
        [JsonMapFieldName("sjt")]
        public string subject;
        [JsonMapFieldName("msg")]
        public string content;
    }
}
