using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.EasyFin
{
    public class EasyFinBankService : BaseService
    {
        public EasyFinBankService(String LinkID, String SecretKey)
            : base(LinkID, SecretKey)
        {
            this.AddScope("180");
        }

        public String GetBankAccountMgtURL(String CorpNum)
        {
            return GetBankAccountMgtURL(CorpNum, null);
        }

        public String GetBankAccountMgtURL(String CorpNum, String UserID)
        {
            URLResponse response = httpget<URLResponse>("/EasyFin/Bank?TG=BankAccount", CorpNum, UserID);

            return response.url;
        }

        public List<EasyFinBankAccount> ListBankAccount(String CorpNum)
        {
            return ListBankAccount(CorpNum, null);
        }

        public List<EasyFinBankAccount> ListBankAccount(String CorpNum, String UserID)
        {
            return httpget<List<EasyFinBankAccount>>("/EasyFin/Bank/ListBankAccount", CorpNum, UserID);
        }

        public String RequestJob(String CorpNum, String BankCode, String AccountNumber, String SDate, String EDate)
        {
            return RequestJob(CorpNum, BankCode, AccountNumber, SDate, EDate, null);
        }

        public String RequestJob(String CorpNum, String BankCode, String AccountNumber, String SDate, String EDate, String UserID)
        {
            if (BankCode == null || BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʽ��ϴ�.");
            if (AccountNumber == null || AccountNumber == "") throw new PopbillException(-99999999, "������¹�ȣ�� �Էµ��� �ʽ��ϴ�.");
            if (SDate == null || SDate == "") throw new PopbillException(-99999999, "�ŷ����� ��ȸ �������ڰ� �Էµ��� �ʽ��ϴ�.");
            if (EDate == null || EDate == "") throw new PopbillException(-99999999, "�ŷ����� ��ȸ �������ڰ� �Էµ� ���ʽ��ϴ�.");


            String uri = "/EasyFin/Bank/BankAccount";
            uri += "?BankCode=" + BankCode;
            uri += "&AccountNumber=" + AccountNumber;
            uri += "&SDate=" + SDate;
            uri += "&EDate=" + EDate;

            return httppost<JobIDResponse>(uri, CorpNum, UserID, null, null).jobID;
        }

        public EasyFinBankJobState GetJobState(String CorpNum, String JobID)
        {
            return GetJobState(CorpNum, JobID, null);
        }

        public EasyFinBankJobState GetJobState(String CorpNum, String JobID, String UserID)
        {
            if (JobID == null || JobID == "") throw new PopbillException(-99999999, "�۾����̵� �Էµ��� �ʽ��ϴ�.");

            return httpget<EasyFinBankJobState>("/EasyFin/Bank/" + JobID + "/State", CorpNum, UserID);
        }

        public List<EasyFinBankJobState> ListACtiveJob(String CorpNum)
        {
            return ListActiveJob(CorpNum, null);
        }

        public List<EasyFinBankJobState> ListActiveJob(String CorpNum, String UserID)
        {
            return httpget<List<EasyFinBankJobState>>("/EasyFin/Bank/JobList", CorpNum, UserID);
        }

        public EasyFinBankSearchResult Search(String CorpNum, String JobID, String[] TradeType, String SearchString, int Page, int PerPage, String Order)
        {
            return Search(CorpNum, JobID, TradeType, SearchString, Page, PerPage, Order, null);
        }

        public EasyFinBankSearchResult Search(String CorpNum, String JobID, String[] TradeType, String SearchString, int Page, int PerPage, String Order, String UserID)
        {
            if (JobID == null || JobID == "") throw new PopbillException(-99999999, "�۾����̵� �Էµ��� �ʽ��ϴ�.");

            String uri = "/EasyFin/Bank/" + JobID;
            uri += "?TrdaeType=" + String.Join(",", TradeType);

            if (SearchString != null && SearchString != "") uri += "&SearchString=" + SearchString;

            uri += "&Page=" + Page.ToString();
            uri += "&PerPage=" + PerPage.ToString();
            uri += "&Order=" + Order;

            return httpget<EasyFinBankSearchResult>(uri, CorpNum, UserID);

        }

        public EasyFinBankSummary Summary(String CorpNum, String JobID, String[] TradeType, String SearchString)
        {
            return Summary(CorpNum, JobID, TradeType, SearchString, null);
        }

        public EasyFinBankSummary Summary(String CorpNum, String JobID, String[] TradeType, String SearchString, String UserID)
        {
            if (JobID == null || JobID == "") throw new PopbillException(-99999999, "�۾����̵� �Էµ��� �ʽ��ϴ�.");

            String uri = "/EasyFin/Bank/" + JobID + "/Summary";
            uri += "?TradeType=" + String.Join(",", TradeType);

            if (SearchString != null && SearchString != "") uri += "&SearchString=" + SearchString;

            return httpget<EasyFinBankSummary>(uri, CorpNum, UserID);
        }

        public Response SaveMemo(String CorpNum, String TID, String Memo)
        {
            return SaveMemo(CorpNum, TID, Memo, null);
        }

        public Response SaveMemo(String CorpNum, String TID, String Memo, String UserID)
        {
            if (TID == null || TID == "") throw new PopbillException(-99999999, "�ŷ����� ���̵� �Էµ��� �ʽ��ϴ�.");


            String uri = "/EasyFin/Bank/SaveMemo";
            uri += "?TID=" + TID;
            uri += "&Memo=" + Memo;

            return httppost<Response>(uri, CorpNum, UserID, null, null);
        }

        public String GetFlatRatePopUpURL(String CorpNum)
        {
            return GetFlatRatePopUpURL(CorpNum, null);
        }

        public String GetFlatRatePopUpURL(String CorpNum, String UserID)
        {
            return httpget<URLResponse>("/EasyFin/Bank?TG=CHRG", CorpNum, UserID).url;
        }

        public EasyFinBankFlatRate GetFlatRateState(String CorpNum, String BankCode, String AccountNumber)
        {
            return GetFlatRateState(CorpNum, BankCode, AccountNumber, null);
        }

        public EasyFinBankFlatRate GetFlatRateState(String CorpNum, String BankCode, String AccountNumber, String UserID)
        {
            if (BankCode == null || BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʽ��ϴ�.");
            if (AccountNumber == null || AccountNumber == "") throw new PopbillException(-99999999, "������¹�ȣ�� �Էµ����ʽ��ϴ�.");

            String uri = "/EasyFin/Bank/Contract/" + BankCode + "/" + AccountNumber;

            return httpget<EasyFinBankFlatRate>(uri, CorpNum, UserID);
        }

        public class JobIDResponse
        {
            public String jobID;
        }
    }
}
