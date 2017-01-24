using System;
using System.Collections.Generic;

namespace Popbill.Taxinvoice
{
    
    public class Taxinvoice
    {
        public int closeDownState;
        public String closeDownStateDate;

        public String memo;
        public String emailSubject;
        public String dealnvoiceMgtKey;

        public bool? forceIssue;
        public bool? writeSpecification;

        public String writeDate;
        
        public String chargeDirection;
        
        public String issueType;
        
        public String issueTiming;
        public String taxType;
        public String invoicerCorpNum;
        public String invoicerMgtKey;
        public String invoicerTaxRegID;
        public String invoicerCorpName;
        public String invoicerCEOName;
        public String invoicerAddr;
        public String invoicerBizClass;
        public String invoicerBizType;
        public String invoicerContactName;
        public String invoicerDeptName;
        public String invoicerTEL;
        public String invoicerHP;
        public String invoicerEmail;
        public bool? invoicerSMSSendYN;
        public String invoiceeCorpNum;
        public String invoiceeType;
        public String invoiceeMgtKey;
        public String invoiceeTaxRegID;
        public String invoiceeCorpName;
        public String invoiceeCEOName;
        public String invoiceeAddr;
        public String invoiceeBizType;
        public String invoiceeBizClass;
        public String invoiceeContactName1;
        public String invoiceeDeptName1;
        public String invoiceeTEL1;
        public String invoiceeHP1;
        public String invoiceeEmail1;
        public String invoiceeContactName2;
        public String invoiceeDeptName2;
        public String invoiceeTEL2;
        public String invoiceeHP2;
        public String invoiceeEmail2;
        
        public bool? invoiceeSMSSendYN;
        public String trusteeCorpNum;
        public String trusteeMgtKey;
        public String trusteeTaxRegID;
        public String trusteeCorpName;
        public String trusteeCEOName;
        public String trusteeAddr;
        public String trusteeBizType;
        public String trusteeBizClass;
        public String trusteeContactName;
        public String trusteeDeptName;
        public String trusteeTEL;
        public String trusteeHP;
        public String trusteeEmail;
        
        public bool? trusteeSMSSendYN;
        public String taxTotal;
        public String supplyCostTotal;
        public String totalAmount;
        public int? modifyCode;
        public String orgNTSConfirmNum;
        public String purposeType;
        public String serialNum;
        public String cash;
        public String chkBill;
        public String credit;
        public String note;
        public String remark1;
        public String remark2;
        public String remark3;
        
        public int? kwon;
        
        public int? ho;
        
        public bool? businessLicenseYN;
        
        public bool? bankBookYN;
        
        public bool? faxsendYN;
        public String faxreceiveNum;
        public String ntsconfirmNum;
        public List<TaxinvoiceDetail> detailList;
        public List<TaxinvoiceAddContact> addContactList;
        public String originalTaxinvoiceKey;

     
    }
}
