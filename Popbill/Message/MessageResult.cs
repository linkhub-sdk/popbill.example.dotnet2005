using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.Message
{
    #pragma warning disable 649
    public class MessageResult
    {
        private int? state;
        private string subject;
        private string type;
        private string content;
        private string sendNum;
        private string receiveNum;
        private string receiveName;
        private string reserveDT;
        private string sendDT;
        private string resultDT;
        private string sendResult;

        public int? State { get { return state; } }
        public string Subject { get { return subject; } }
        public MessageType Type { get { return (MessageType)Enum.Parse(typeof(MessageType), type); } }
        public string Content { get { return content; } }
        public string SendNum { get { return sendNum; } }
        public string ReceiveNum { get { return receiveNum; } }
        public string ReceiveName { get { return receiveName; } }
        public string ReserveDT { get { return reserveDT; } }
        public string SendDT { get { return sendDT; } }
        public string ResultDT { get { return resultDT; } }
        public string SendResult { get { return sendResult; } }
    }
}
