using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.EasyFin
{
    #pragma warning disable 649
    public class EasyFinBankJobState
    {
        public string jobID;

        public int? jobState;
        
        public string startDate;
        
        public string endDate;
        
        public long errorCode;
        
        public string errorReason;
        
        public string jobStartDT;

        public string jobEndDT;

        public string regDT;
    }
}
