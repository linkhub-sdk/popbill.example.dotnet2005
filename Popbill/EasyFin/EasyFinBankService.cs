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

        public Response RegistBankAccount(String CorpNum, EasyFinBankAccountForm info)
        {
            return RegistBankAccount(CorpNum, info, null);
        }

        public Response RegistBankAccount(String CorpNum, EasyFinBankAccountForm info, String UserID)
        {
            if (info == null) throw new PopbillException(-99999999, "���� ���������� �Էµ��� �ʾҽ��ϴ�.");
            if (info.BankCode == null || info.BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʾҽ��ϴ�.");
            if (info.BankCode.Length != 4) throw new PopbillException(-99999999, "�����ڵ尡 �ùٸ��� �ʽ��ϴ�.");
            if (info.AccountNumber == null || info.AccountNumber == "") throw new PopbillException(-99999999, "���� ���¹�ȣ�� �Էµ��� �ʾҽ��ϴ�.");
            if (info.AccountPWD == null || info.AccountPWD == "") throw new PopbillException(-99999999, "���� ��й�ȣ�� �Էµ��� �ʾҽ��ϴ�.");
            if (info.AccountType == null || info.AccountType == "") throw new PopbillException(-99999999, "���������� �Էµ��� �ʾҽ��ϴ�.");
            if (info.AccountType != "����" && info.AccountType != "����") throw new PopbillException(-99999999, "���������� �ùٸ��� �ʽ��ϴ�.");
            if (info.IdentityNumber == null || info.IdentityNumber == "") throw new PopbillException(-99999999, "������ �ĺ������� �Էµ��� �ʾҽ��ϴ�.");

            String PostData = toJsonString(info);

            String uri = "/EasyFin/Bank/BankAccount/Regist";

            if (info.UsePeriod != null) uri += "?UsePeriod=" + info.UsePeriod;

            return httppost<Response>(uri, CorpNum, UserID, PostData, null);
        }

        public Response UpdateBankAccount(String CorpNum, EasyFinBankAccountForm info)
        {
            return UpdateBankAccount(CorpNum, info, null);
        }

        public Response UpdateBankAccount(String CorpNum, EasyFinBankAccountForm info, String UserID)
        {
            if (info == null) throw new PopbillException(-99999999, "���� ���������� �Էµ��� �ʾҽ��ϴ�.");
            if (info.BankCode == null || info.BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʾҽ��ϴ�.");
            if (info.BankCode.Length != 4) throw new PopbillException(-99999999, "�����ڵ尡 �ùٸ��� �ʽ��ϴ�.");
            if (info.AccountNumber == null || info.AccountNumber == "") throw new PopbillException(-99999999, "���� ���¹�ȣ�� �Էµ��� �ʾҽ��ϴ�.");
            if (info.AccountPWD == null || info.AccountPWD == "") throw new PopbillException(-99999999, "���� ��й�ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            String uri = "/EasyFin/Bank/BankAccount/" + info.BankCode + "/" + info.AccountNumber + "/Update";

            String PostData = toJsonString(info);

            return httppost<Response>(uri, CorpNum, UserID, PostData, null);
        }


        public Response RevokeCloseBankAccount(String CorpNum, String BankCode, String AccountNumber)
        {
            return RevokeCloseBankAccount(CorpNum, BankCode, AccountNumber, null);
        }
        public Response RevokeCloseBankAccount(String CorpNum, String BankCode, String AccountNumber, String UserID)
        {
            if (BankCode == null || BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʾҽ��ϴ�.");
            if (BankCode.Length != 4) throw new PopbillException(-99999999, "�����ڵ尡 �ùٸ��� �ʽ��ϴ�.");
            if (AccountNumber == null || AccountNumber == "") throw new PopbillException(-99999999, "���� ���¹�ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            String uri = "/EasyFin/Bank/BankAccount/RevokeClose";
            uri += "?BankCode=" + BankCode;
            uri += "&AccountNumber=" + AccountNumber;

            return httppost<Response>(uri, CorpNum, UserID, "", null);
        }

        public Response CloseBankAccount(String CorpNum, String BankCode, String AccountNumber, String CloseType)
        {
            return CloseBankAccount(CorpNum, BankCode, AccountNumber, CloseType, null);
        }

        public Response CloseBankAccount(String CorpNum, String BankCode, String AccountNumber, String CloseType, String UserID)
        {
            if (BankCode == null || BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʾҽ��ϴ�.");
            if (BankCode.Length != 4) throw new PopbillException(-99999999, "�����ڵ尡 �ùٸ��� �ʽ��ϴ�.");
            if (AccountNumber == null || AccountNumber == "") throw new PopbillException(-99999999, "���� ���¹�ȣ�� �Էµ��� �ʾҽ��ϴ�.");
            if (CloseType == null || CloseType == "") throw new PopbillException(-99999999, "������ ���������� �Էµ��� �ʾҽ��ϴ�.");
            if (CloseType != "�ߵ�" && CloseType != "�Ϲ�") throw new PopbillException(-99999999, "������ ���������� �ùٸ��� �ʽ��ϴ�.");

            String uri = "/EasyFin/Bank/BankAccount/Close";
            uri += "?BankCode=" + BankCode;
            uri += "&AccountNumber=" + AccountNumber;
            uri += "&CloseType=" + CloseType;

            return httppost<Response>(uri, CorpNum, UserID, "", null);
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

        public EasyFinBankAccount GetBankAccountInfo(String CorpNum, String BankCode, String AccountNumber)
        {
            return GetBankAccountInfo(CorpNum, BankCode, AccountNumber, null);
        }

        public EasyFinBankAccount GetBankAccountInfo(String CorpNum, String BankCode, String AccountNumber, String UserID)
        {
            if (BankCode == null || BankCode == "") throw new PopbillException(-99999999, "�����ڵ尡 �Էµ��� �ʾҽ��ϴ�.");
            if (BankCode.Length != 4) throw new PopbillException(-99999999, "�����ڵ尡 �ùٸ��� �ʽ��ϴ�.");
            if (AccountNumber == null || AccountNumber == "") throw new PopbillException(-99999999, "���� ���¹�ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            String uri = "/EasyFin/Bank/BankAccount/" + BankCode + "/" + AccountNumber;

            return httpget<EasyFinBankAccount>(uri, CorpNum, UserID);
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
