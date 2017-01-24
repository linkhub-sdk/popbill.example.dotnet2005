﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Popbill;

namespace Popbill.Taxinvoice
{
    public enum MgtKeyType {SELL , BUY , TRUSTEE};

    public class TaxinvoiceService : BaseService
    {
        public TaxinvoiceService(String LinkID, String SecretKey)
            : base(LinkID, SecretKey)
        {
            this.AddScope("110");
        }

        public Single GetUnitCost(String CorpNum)
        {
            UnitCostResponse response = httpget<UnitCostResponse>("/Taxinvoice?cfg=UNITCOST", CorpNum, null);

            return Single.Parse(response.unitCost);
        }

        public DateTime GetCertificateExpireDate(String CorpNum)
        {
            CertResponse response = httpget<CertResponse>("/Taxinvoice?cfg=CERT", CorpNum, null);

            return DateTime.ParseExact( response.certificateExpiration,"yyyyMMddHHmmss",null);
        }

        public String GetURL(String CorpNum, String UserID, String TOGO)
        {
            URLResponse response = httpget<URLResponse>("/Taxinvoice?TG=" + TOGO, CorpNum, UserID);

            return response.url;
        }

        public bool CheckMgtKeyInUse(String CorpNum, MgtKeyType KeyType, String MgtKey)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            try
            {
                TaxinvoiceInfo response = httpget<TaxinvoiceInfo>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, null);

                return string.IsNullOrEmpty(response.itemKey) == false;
            }
            catch (PopbillException pe)
            {
                if (pe.code == -11000005) return false;

                throw pe;
            }

        }

        public List<EmailPublicKey> GetEmailPublicKeys(String CorpNum)
        {
            return httpget<List<EmailPublicKey>>("/Taxinvoice/EmailPublicKeys", CorpNum, null);
        }

        public Response Register(String CorpNum, Taxinvoice taxinvoice)
        {
            return Register(CorpNum, taxinvoice, null);
        }
        public Response Register(String CorpNum, Taxinvoice taxinvoice, String UserID)
        {
            return Register(CorpNum, taxinvoice, null, false);
        }

        public Response Register(String CorpNum, Taxinvoice taxinvoice, String UserID  , bool writeSpecification )
        {
            if (taxinvoice == null) throw new PopbillException(-99999999, "세금계산서 정보가 입력되지 않았습니다.");

            String PostData = toJsonString(taxinvoice);

            if (writeSpecification)
            {
                PostData = "{\"writeSpecification\":true," + PostData.Substring(1);
            }

            return httppost<Response>("/Taxinvoice", CorpNum, UserID, PostData, null);
        }

        public Response Update(String CorpNum, MgtKeyType KeyType, String MgtKey, Taxinvoice taxinvoice, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            if (taxinvoice == null) throw new PopbillException(-99999999, "세금계산서 정보가 입력되지 않았습니다.");

            String PostData = toJsonString(taxinvoice);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey , CorpNum, UserID, PostData, "PATCH");
        }
        public Response Delete(String CorpNum, MgtKeyType KeyType, String MgtKey)
        {
            return Delete(CorpNum, KeyType, MgtKey, "");
        }


        public Response Delete(String CorpNum, MgtKeyType KeyType, String MgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, null, "DELETE");
        }

        public Response Send(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String EmailSubject, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;
            request.emailSubject = EmailSubject;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "SEND");
        }

        public Response CancelSend(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "CANCELSEND");
        }

        public Response Accept(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "ACCEPT");
        }

        public Response Deny(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "DENY");
        }
        public Response Issue(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            return Issue(CorpNum, KeyType, MgtKey, Memo, null, false, UserID);
        }

        public Response Issue(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, bool ForceIssue, String UserID)
        {
            return Issue(CorpNum, KeyType, MgtKey, Memo, null, ForceIssue, UserID);
        }

        public Response Issue(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String EmailSubject, bool ForceIssue, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            IssueRequest request = new IssueRequest();

            request.memo = Memo;
            request.emailSubject = EmailSubject;
            request.forceIssue = ForceIssue;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "ISSUE");
        }

        public Response RegistIssue(String CorpNum, Taxinvoice taxinvoice, bool ForceIssue, String Memo)
        {
            return RegistIssue(CorpNum, taxinvoice, ForceIssue, Memo, false, null, null, null);
        }
        public Response RegistIssue(String CorpNum, Taxinvoice taxinvoice, bool ForceIssue, String Memo, bool WriteSpecification, String DealinvoiceMgtKey, String EmailSubject)
        {
            return RegistIssue(CorpNum, taxinvoice, ForceIssue, Memo, WriteSpecification, DealinvoiceMgtKey, EmailSubject, null);
        }

        public Response RegistIssue(String CorpNum, Taxinvoice taxinvoice, bool ForceIssue, String Memo, bool WriteSpecification, String DealinvoiceMgtKey, String EmailSubject, String UserID)
        {
            taxinvoice.writeSpecification = WriteSpecification;
            taxinvoice.forceIssue = ForceIssue;
            taxinvoice.dealnvoiceMgtKey = DealinvoiceMgtKey;
            taxinvoice.memo = Memo;
            taxinvoice.emailSubject = EmailSubject;

            String PostData = toJsonString(taxinvoice);

            return httppost<Response>("/Taxinvoice", CorpNum, UserID, PostData, "ISSUE");
        }


        public Response CancelIssue(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "CANCELISSUE");
        }

        public Response Request(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "REQUEST");
        }

        public Response Refuse(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "REFUSE");
        }

        public Response CancelRequest(String CorpNum, MgtKeyType KeyType, String MgtKey, String Memo, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            MemoRequest request = new MemoRequest();

            request.memo = Memo;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "CANCELREQUEST");
        }

        public Response SendToNTS(String CorpNum, MgtKeyType KeyType, String MgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

          
            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, null, "NTS");
        }

        public Response SendEmail(String CorpNum, MgtKeyType KeyType, String MgtKey, String Receiver, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            ResendRequest request = new ResendRequest();

            request.receiver = Receiver;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "EMAIL");
        }

        public Response SendSMS(String CorpNum, MgtKeyType KeyType, String MgtKey,String Sender, String Receiver, String Contents, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            ResendRequest request = new ResendRequest();

            request.sender = Sender;
            request.receiver = Receiver;
            request.contents = Contents;

            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "SMS");
        }

        public Response SendFAX(String CorpNum, MgtKeyType KeyType, String MgtKey, String Sender, String Receiver, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            ResendRequest request = new ResendRequest();

            request.sender = Sender;
            request.receiver = Receiver;
         
            String PostData = toJsonString(request);

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, UserID, PostData, "FAX");
        }

        public Taxinvoice GetDetailInfo(String CorpNum, MgtKeyType KeyType, String MgtKey)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            return httpget<Taxinvoice>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "?Detail", CorpNum,null);
        }

        public TaxinvoiceInfo GetInfo(String CorpNum, MgtKeyType KeyType, String MgtKey)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            return httpget<TaxinvoiceInfo>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey, CorpNum, null);
        }

        public List<TaxinvoiceInfo> GetInfos(String CorpNum, MgtKeyType KeyType , List<String> MgtKeyList)
        {
            if(MgtKeyList == null || MgtKeyList.Count == 0) throw new PopbillException(-99999999,"관리번호 목록이 입력되지 않았습니다.");

            String PostData = toJsonString(MgtKeyList);

            return httppost<List<TaxinvoiceInfo>>("/Taxinvoice/" +  KeyType.ToString(),CorpNum,null,PostData,null);
        }
        public List<TaxinvoiceLog> GetLogs(String CorpNum, MgtKeyType KeyType ,String MgtKey)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            return httpget< List<TaxinvoiceLog>>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "/Logs", CorpNum, null);
        }
        public String GetPopUpURL(String CorpNum, MgtKeyType KeyType, String MgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            URLResponse response = httpget<URLResponse>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "?TG=POPUP", CorpNum, UserID);

            return response.url;
        }
        public TISearchResult Search(String CorpNum, MgtKeyType KeyType, String DType, String SDate, String EDate, String[] State, String[] Type, String[] TaxType, bool? LateOnly, String Order, int Page, int PerPage)
        {
            return Search(CorpNum, KeyType, DType, SDate, EDate, State, Type, TaxType, LateOnly, null, null, null, Order, Page, PerPage, null);
        }

        public TISearchResult Search(String CorpNum, MgtKeyType KeyType, String DType, String SDate, String EDate, String[] State, String[] Type, String[] TaxType, bool? LateOnly, String Order, int Page, int PerPage, String UserID)
        {
            return Search(CorpNum, KeyType, DType, SDate, EDate, State, Type, TaxType, LateOnly, null, null, null, Order, Page, PerPage, UserID);
        }

        public TISearchResult Search(String CorpNum, MgtKeyType KeyType, String DType, String SDate, String EDate, String[] State, String[] Type, String[] TaxType, bool? LateOnly, String TaxRegIDYN, String TaxRegIDType, String TaxRegID, String Order, int Page, int PerPage)
        {
            return Search(CorpNum, KeyType, DType, SDate, EDate, State, Type, TaxType, LateOnly, TaxRegIDYN, TaxRegIDType, TaxRegID, Order, Page, PerPage, null);
        }


        public TISearchResult Search(String CorpNum, MgtKeyType KeyType, String DType, String SDate, String EDate, String[] State, String[] Type, String[] TaxType, bool? LateOnly, String TaxRegIDYN, String TaxRegIDType, String TaxRegID, String Order, int Page, int PerPage, String UserID)
        {
            return Search(CorpNum, KeyType, DType, SDate, EDate, State, Type, TaxType, LateOnly, TaxRegIDYN, TaxRegIDType, TaxRegID, "", Order, Page, PerPage, null);
        }

        public TISearchResult Search(String CorpNum, MgtKeyType KeyType, String DType, String SDate, String EDate, String[] State, String[] Type, String[] TaxType, bool? LateOnly, String TaxRegIDYN, String TaxRegIDType, String TaxRegID, String QString, String Order, int Page, int PerPage, String UserID)
        {
            if (String.IsNullOrEmpty(DType)) throw new PopbillException(-99999999, "검색일자 유형이 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(SDate)) throw new PopbillException(-99999999, "시작일자가 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(EDate)) throw new PopbillException(-99999999, "종료일자가 입력되지 않았습니다.");

            String uri = "/Taxinvoice/" + KeyType;
            uri += "?DType=" + DType;
            uri += "&SDate=" + SDate;
            uri += "&EDate=" + EDate;
            uri += "&State=" + String.Join(",", State);
            uri += "&Type=" + String.Join(",", Type);
            uri += "&TaxType=" + String.Join(",", TaxType);

            if (LateOnly != null)
            {
                if ((bool)LateOnly)
                {
                    uri += "&LateOnly=1";
                }
                else
                {
                    uri += "&LateOnly=0";
                }
            }


            if (TaxRegIDYN != "") uri += "&TaxRegIDYN=" + TaxRegIDYN;

            uri += "&TaxRegIDType=" + TaxRegIDType;
            uri += "&TaxRegID=" + TaxRegID;
            uri += "&QString=" + QString;
            uri += "&Order=" + Order;
            uri += "&Page=" + Page.ToString();
            uri += "&PerPage=" + PerPage.ToString();

            return httpget<TISearchResult>(uri, CorpNum, UserID);
        }
        public String GetMailURL(String CorpNum, MgtKeyType KeyType, String MgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            URLResponse response = httpget<URLResponse>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "?TG=MAIL", CorpNum, UserID);

            return response.url;

        }
        public String GetPrintURL(String CorpNum, MgtKeyType KeyType, String MgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            URLResponse response = httpget<URLResponse>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "?TG=PRINT", CorpNum, UserID);

            return response.url;

        }
        public String GetEPrintURL(String CorpNum, MgtKeyType KeyType, String MgtKey, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            URLResponse response = httpget<URLResponse>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "?TG=EPRINT", CorpNum, UserID);

            return response.url;

        }
        public String GetMassPrintURL(String CorpNum, MgtKeyType KeyType, List<String> MgtKeyList, String UserID)
        {
            if (MgtKeyList == null || MgtKeyList.Count == 0) throw new PopbillException(-99999999, "관리번호 목록이 입력되지 않았습니다.");

            String PostData = toJsonString(MgtKeyList);

            URLResponse response = httppost<URLResponse>("/Taxinvoice/" + KeyType.ToString() + "?Print", CorpNum, UserID,PostData,null);

            return response.url;
        }

        public Response AttachFile(String CorpNum, MgtKeyType KeyType, String MgtKey, String FilePath, String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(FilePath)) throw new PopbillException(-99999999, "파일경로가 입력되지 않았습니다.");

            List<UploadFile> files = new List<UploadFile>();

            UploadFile file = new UploadFile();

            file.FieldName = "Filedata";
            file.FileName = System.IO.Path.GetFileName(FilePath);
            file.FileData = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

            files.Add(file);

            return httppostFile<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "/Files", CorpNum, UserID, null, files, null);
        }

        public List<AttachedFile> GetFiles(String CorpNum, MgtKeyType KeyType, String MgtKey)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");

            return httpget<List<AttachedFile>>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "/Files", CorpNum, null);
        }

        public Response DeleteFile(String CorpNum, MgtKeyType KeyType, String MgtKey,String FileID , String UserID)
        {
            if (String.IsNullOrEmpty(MgtKey)) throw new PopbillException(-99999999, "관리번호가 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(FileID)) throw new PopbillException(-99999999, "파일 아이디가 입력되지 않았습니다.");

            return httppost<Response>("/Taxinvoice/" + KeyType.ToString() + "/" + MgtKey + "/Files/" + FileID, CorpNum, UserID, null, "DELETE");
        }


        
        public class CertResponse
        {
            
            public String certificateExpiration;
        }

        
        private class MemoRequest
        {
            
            public String memo;
            public String emailSubject;
        }

        
        private class IssueRequest
        {
            
            public String memo;
            
            public String emailSubject;
            
            public bool forceIssue = false;
        }

        
        private class ResendRequest
        {
            
            public String receiver;
            
            public String sender = null;
            
            public String contents = null;
        }

    }

}
