﻿using System;
using System.IO;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Serialization;

namespace Popbill.Fax
{
    public class FaxService : BaseService
    {
        public FaxService(String LinkID, String SecretKey)
            : base(LinkID, SecretKey)
        {
            this.AddScope("160");
        }

        public Single GetUnitCost(String CorpNum)
        {
            UnitCostResponse response = httpget<UnitCostResponse>("/FAX/UnitCost", CorpNum, null);

            return Single.Parse(response.unitCost);
        }

        public String GetURL(String CorpNum, String UserID, String TOGO)
        {
            URLResponse response = httpget<URLResponse>("/FAX/?TG=" + TOGO, CorpNum, UserID);

            return response.url;
        }

        public string SendFAX(String CorpNum, String sendNum,string receiveNum,string receiveName, String filePath, DateTime? reserveDT, String UserID)
        {
            List<String> filePaths = new List<string>();
            filePaths.Add(filePath);
            return SendFAX(CorpNum, sendNum, receiveNum, receiveName, filePaths, reserveDT, UserID);
        }

        public string SendFAX(String CorpNum, String sendNum, List<FaxReceiver> receivers, String filePath, DateTime? reserveDT, String UserID)
        {
            List<String> filePaths = new List<string>();
            filePaths.Add(filePath);

            return SendFAX(CorpNum, sendNum, receivers, filePaths, reserveDT, UserID);
        }

        public string SendFAX(String CorpNum, String sendNum, string receiveNum, string receiveName, List<String> filePaths, DateTime? reserveDT, String UserID)
        {
            List<FaxReceiver> receivers = new List<FaxReceiver>();
            FaxReceiver receiver = new FaxReceiver();
            receiver.receiveName = receiveName;
            receiver.receiveNum = receiveNum;
            receivers.Add(receiver);

            return SendFAX(CorpNum, sendNum, receivers, filePaths, reserveDT, UserID);
        }

        public string SendFAX(String CorpNum, String sendNum, List<FaxReceiver> receivers, List<String> filePaths, DateTime? reserveDT, String UserID)
        {
            if (filePaths == null || filePaths.Count == 0) throw new PopbillException(-99999999, "전송할 파일정보가 입력되지 않았습니다.");
            if (receivers == null || receivers.Count == 0) throw new PopbillException(-99999999, "수신처 정보가 입력되지 않았습니다.");

            List<UploadFile> UploadFiles = new List<UploadFile>();

            foreach(String filePath in filePaths)
            {
                UploadFile uf = new UploadFile();

                uf.FieldName = "file";
                uf.FileName = System.IO.Path.GetFileName(filePath);
                uf.FileData = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                UploadFiles.Add(uf);
            }
            sendRequest request = new sendRequest();

            request.snd = sendNum;
            request.fCnt = filePaths.Count;
            request.sndDT = reserveDT == null ? null : reserveDT.Value.ToString("yyyyMMddHHmmss");
            request.rcvs = receivers;

            String PostData = toJsonString(request);

            ReceiptResponse response;
            response = httppostFile<ReceiptResponse>("/FAX", CorpNum, UserID, PostData, UploadFiles, null);

            return response.receiptNum;
        }

        public List<FaxResult> GetFaxResult(String CorpNum, String receiptNum)
        {
            if (String.IsNullOrEmpty(receiptNum)) throw new PopbillException(-99999999, "접수번호가 입력되지 않았습니다.");

            return httpget<List<FaxResult>>("/FAX/" + receiptNum, CorpNum, null);
        }

        public Response CancelReserve(String CorpNum, String receiptNum, String UserID)
        {
            if (String.IsNullOrEmpty(receiptNum)) throw new PopbillException(-99999999, "접수번호가 입력되지 않았습니다.");

            return httpget<Response>("/FAX/" + receiptNum + "/Cancel", CorpNum, UserID);
        }

        
        private class sendRequest
        {
            public String snd = null;
            public String sndDT = null;
            public int fCnt = 0;
            public List<FaxReceiver> rcvs = null;
        }

        
        public class ReceiptResponse
        {
            public String receiptNum;
        }
    }
}
