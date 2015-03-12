using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.Statement
{
    public class StatementInfo
    {
        public int? itemCode;
        public String itemKey;
        public String invoiceNum;
        public String mgtKey;

        public int? stateCode;
        public String taxType;
        public String purposeType;

        public String writeDate;

        public String senderCorpName;
        public String senderCorpNum;
        public String receiverCorpName;
        public String receiverCorpNum;

        public String supplyCostTotal;
        public String taxTotal;

        public String issueDT;
        public String stateDT;
        public bool? openYN;
        public String openDT;
        public String stateMemo;
        public String regDT;

    }
}
