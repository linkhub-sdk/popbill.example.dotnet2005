using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Popbill;

namespace Popbill.Statement
{
    public class StatementService : BaseService
    {
        public StatementService(String LinkID, String SecretKey)
            : base(LinkID, SecretKey)
        {
            this.AddScope("121");
            this.AddScope("122");
            this.AddScope("123");
            this.AddScope("124");
            this.AddScope("125");
            this.AddScope("126");
        }

        public Single GetUnitCost(String CorpNum, int itemCode)
        {

            UnitCostResponse response = httpget<UnitCostResponse>("/Statement/" + itemCode.ToString() + "?cfg=UNITCOST", CorpNum, null);
            return Single.Parse(response.unitCost);
        }

        public String GetURL(String CorpNum, String UserID, String TOGO)
        {
            URLResponse response = httpget<URLResponse>("/Statement?TG=" + TOGO, CorpNum, UserID);

            return response.url;
        }

        public bool CheckMgtKeyInuse(String CorpNum, int itemCode, String mgtKey)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            try
            {
                StatementInfo response = httpget<StatementInfo>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, null);


                return string.IsNullOrEmpty(response.itemKey) == false;

            }
            catch (PopbillException pe)
            {
                if (pe.code == -12000004) return false;

                throw pe;
            }

        }

        public Response Register(String CorpNum, Statement statement, String UserID)
        {
            if (statement == null) throw new PopbillException(-99999999, "���� ������ �Էµ��� �ʾҽ��ϴ�.");

            String PostData = toJsonString(statement);
    
            return httppost<Response>("/Statement", CorpNum, UserID, PostData, null);
        }


        public Response Update(String CorpNum, int itemCode, String mgtKey, Statement statement, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            if (statement == null) throw new PopbillException(-99999999, "���� ������ �Էµ��� �ʾҽ��ϴ�.");

            String PostData = toJsonString(statement);

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, UserID, PostData, "PATCH");

        }

        public Response Delete(String CorpNum, int itemCode, String mgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, UserID, null, "DELETE");
        }


        public Response Issue(String CorpNum, int itemCode, String mgtKey, String memo, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            MemoRequest request = new MemoRequest();

            request.memo = memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, UserID, PostData, "ISSUE");
        }

        public Response CancelIssue(String CorpNum, int itemCode, String mgtKey, String memo, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            MemoRequest request = new MemoRequest();

            request.memo = memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, UserID, PostData, "CANCEL");
        }


        public Response SendEmail(String CorpNum, int itemCode, String mgtKey, String Receiver, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            ResendRequest request = new ResendRequest();

            request.receiver = Receiver;

            String PostData = toJsonString(request);

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, UserID, PostData, "EMAIL");
        }

        public Response SendSMS(String CorpNum, int ItemCode, String mgtKey, String Sender, String Receiver, String Contents, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            ResendRequest request = new ResendRequest();

            request.sender = Sender;
            request.receiver = Receiver;
            request.contents = Contents;

            String PostData = toJsonString(request);

            return httppost<Response>("/Statement/" + ItemCode.ToString() + "/" + mgtKey, CorpNum, UserID, PostData, "SMS");
        }


        public Response SendFAX(String CorpNum, int itemCode, String mgtKey, String Sender, String Receiver, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            ResendRequest request = new ResendRequest();

            request.sender = Sender;
            request.receiver = Receiver;

            String PostData = toJsonString(request);

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, UserID, PostData, "FAX");
        }

        public Statement GetDetailInfo(String CorpNum, int itemCode, String mgtKey)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            return httpget<Statement>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "?Detail", CorpNum, null);
        }

        public StatementInfo GetInfo(String CorpNum, int itemCode, String mgtKey)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            return httpget<StatementInfo>("/Statement/" + itemCode.ToString() + "/" + mgtKey, CorpNum, null);
        }



        public List<StatementInfo> GetInfos(String CorpNum, int itemCode, List<String> mgtKeyList)
        {
            if (mgtKeyList == null || mgtKeyList.Count == 0) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            String PostData = toJsonString(mgtKeyList);

            return httppost<List<StatementInfo>>("/Statement/" + itemCode.ToString(), CorpNum, null, PostData, null);
        }

        public String GetPopUpURL(String CorpNum, int itemCode, String mgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            URLResponse response = httpget<URLResponse>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "?TG=POPUP", CorpNum, UserID);

            return response.url;
        }

        public String GetPrintURL(String CorpNum, int itemCode, String mgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            URLResponse response = httpget<URLResponse>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "?TG=PRINT", CorpNum, UserID);

            return response.url;
        }


        public String GetEPrintURL(String CorpNum, int itemCode, String mgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            URLResponse response = httpget<URLResponse>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "?TG=EPRINT", CorpNum, UserID);

            return response.url;
        }



        public String GetMailURL(String CorpNum, int itemCode, String mgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            URLResponse response = httpget<URLResponse>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "?TG=MAIL", CorpNum, UserID);

            return response.url;
        }

        public String GetMassPrintURL(String CorpNum, int itemCode, List<String> mgtKeyList, String UserID)
        {
            if (mgtKeyList == null || mgtKeyList.Count == 0) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            String PostData = toJsonString(mgtKeyList);

            URLResponse response = httppost<URLResponse>("/Statement/" + itemCode.ToString() + "?Print", CorpNum, UserID, PostData, null);

            return response.url;
        }

        public List<StatementLog> GetLogs(String CorpNum, int itemCode, String mgtKey)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            return httpget<List<StatementLog>>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "/Logs", CorpNum, null);
        }

        public Response AttachFile(String CorpNum, int itemCode, String mgtKey, String FilePath, String UserID)
        {
            if (String.IsNullOrEmpty(mgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");
            if (String.IsNullOrEmpty(FilePath)) throw new PopbillException(-99999999, "���ϰ�ΰ� �Էµ��� �ʾҽ��ϴ�.");

            List<UploadFile> files = new List<UploadFile>();

            UploadFile file = new UploadFile();

            file.FieldName = "Filedata";
            file.FileName = System.IO.Path.GetFileName(FilePath);
            file.FileData = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

            files.Add(file);

            return httppostFile<Response>("/Statement/" + itemCode.ToString() + "/" + mgtKey + "/Files", CorpNum, UserID, null, files, null);
        }


        public List<AttachedFile> GetFiles(String CorpNum, int itemCode, String MgtKey)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");

            return httpget<List<AttachedFile>>("/Statement/" + itemCode.ToString() + "/" + MgtKey + "/Files", CorpNum, null);
        }


        public Response DeleteFile(String CorpNum, int itemCode, String MgtKey, String FileID, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "������ȣ�� �Էµ��� �ʾҽ��ϴ�.");
            if (String.IsNullOrEmpty(FileID)) throw new PopbillException(-99999999, "���� ���̵� �Էµ��� �ʾҽ��ϴ�.");

            return httppost<Response>("/Statement/" + itemCode.ToString() + "/" + MgtKey + "/Files/" + FileID, CorpNum, UserID, null, "DELETE");
        }

        private class MemoRequest
        {
            public String memo;

        }

        private class ResendRequest
        {
            public String receiver;
            public String sender = null;
            public String contents = null;
        }

    }
}
