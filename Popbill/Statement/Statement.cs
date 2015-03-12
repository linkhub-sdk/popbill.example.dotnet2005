using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Popbill.Statement
{

    public class Statement
    {

        public int? itemCode;
        public String mgtKey;
        public String invoiceNum;
        public String formCode;
        public String writeDate;
        public String taxType;

        public String senderCorpNum;
        public String senderTaxRegID;
        public String senderCorpName;
        public String senderCEOName;
        public String senderAddr;
        public String senderBizClass;
        public String senderBizType;
        public String senderContactName;
        public String senderDeptName;
        public String senderTEL;
        public String senderHP;
        public String senderEmail;
        public String senderFAX;

        public String receiverCorpNum;
        public String receiverTaxRegID;
        public String receiverCorpName;
        public String receiverCEOName;
        public String receiverAddr;
        public String receiverBizClass;
        public String receiverBizType;
        public String receiverContactName;
        public String receiverDeptName;
        public String receiverTEL;
        public String receiverHP;
        public String receiverEmail;
        public String receiverFAX;

        public String taxTotal;
        public String supplyCostTotal;
        public String totalAmount;
        public String purposeType;
        public String serialNum;
        public String remark1;
        public String remark2;
        public String remark3;
        public bool? businessLicenseYN;
        public bool? bankBookYN;
        public bool? faxsendYN;
        public bool? smssendYN;
        public bool? autoacceptYN;

        public List<StatementDetail> detailList;
        public Dictionary<string, string> propertyBag;
    }
}
