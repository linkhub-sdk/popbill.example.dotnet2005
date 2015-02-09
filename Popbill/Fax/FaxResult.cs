using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.Fax
{
    #pragma warning disable 649
    public class FaxResult
    {
        private int? sendState;
        private int? convState;
        private string sendNum;
        private string receiveNum;
        private string receiveName;
        private int? sendPageCnt;
        private int? successPageCnt;
        private int? failPageCnt;
        private int? refundPageCnt;
        private int? cancelPageCnt;
        private String reserveDT;
        private String sendDT;
        private String resultDT;
        private int? sendResult;


        public int? SendState { get { return sendState; } }
        public int? ConvState { get { return convState; } }
        public string SendNum { get { return sendNum; } }
        public string ReceiveNum { get { return receiveNum; } }
        public string ReceiveName { get { return receiveName; } }
        public int? SendPageCnt { get { return sendPageCnt; } }
        public int? CuccessPageCnt { get { return successPageCnt; } }
        public int? FailPageCnt { get { return failPageCnt; } }
        public int? RefundPageCnt { get { return refundPageCnt; } }
        public int? CancelPageCnt { get { return cancelPageCnt; } }
        public string ReserveDT { get { return reserveDT; } }
        public string SendDT { get { return sendDT; } }
        public string ResultDT { get { return resultDT; } }
        public int? SendResult { get { return sendResult; } }
    }
}
