using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.Taxinvoice
{
    
    public class TaxinvoiceInfo
    {
        public int closeDownState;
        public String closeDownStateDate;

        public String itemKey;
        public String taxType;
        public String writeDate;
        public String regDT;

        public String invoicerCorpName;
        public String invoicerCorpNum;
        public String invoicerMgtKey;
        public bool? invoicerPrintYN;
        public String invoiceeCorpName;
        public String invoiceeCorpNum;
        public String invoiceeMgtKey;
        public bool? invoiceePrintYN;
        public String trusteeCorpName;
        public String trusteeCorpNum;
        public String trusteeMgtKey;

        public String supplyCostTotal;
        public String taxTotal;
        public String purposeType;
        public int? modifyCode;
        public String issueType;

        public String issueDT;
        public String preIssueDT;
        public bool? lateIssueYN;

        public int stateCode;
        public String stateDT;

        public bool? openYN;
        public String openDT;
        public String ntsresult;
        public String ntsconfirmNum;
        public String ntssendDT;
        public String ntsresultDT;
        public String ntssendErrCode;

        public String stateMemo;
    }
}
