﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Serialization;

namespace Popbill.Message
{
    public enum MessageType { SMS, LMS, XMS, MMS };

    public class MessageService : BaseService
    {
        public MessageService(String LinkID, String SecretKey)
            : base(LinkID, SecretKey)
        {
            this.AddScope("150");
            this.AddScope("151");
            this.AddScope("152");
        }

        public Single GetUnitCost(String CorpNum,MessageType msgType)
        {
            UnitCostResponse response = httpget<UnitCostResponse>("/Message/UnitCost?Type=" + msgType.ToString(), CorpNum, null);

            return Single.Parse(response.unitCost);
        }

        public String GetURL(String CorpNum, String UserID, String TOGO)
        {
            URLResponse response = httpget<URLResponse>("/Message/?TG=" + TOGO, CorpNum, UserID);

            return response.url;
        }

        public String SendSMS(String CorpNum, string sendNum, String receiveNum, String receiveName, String content, DateTime? reserveDT, String UserID)
        {
            List<Message> messages = new List<Message>();
            Message msg = new Message();
            msg.receiveNum = receiveNum;
            msg.receiveName = receiveName;
            messages.Add(msg);

            return sendMessage(MessageType.SMS, CorpNum, sendNum, null, content, messages, reserveDT, UserID);
        }

        public String SendSMS(String CorpNum, string sendNum, String content, List<Message> messages, DateTime? reserveDT, String UserID)
        {
            return sendMessage(MessageType.SMS, CorpNum, sendNum, null, content, messages, reserveDT, UserID);
        }


        public String SendSMS(String CorpNum, List<Message> messages , DateTime? reserveDT, String UserID)
        {
            return sendMessage(MessageType.SMS, CorpNum, null, null, null, messages, reserveDT, UserID);
        }

        public String SendLMS(String CorpNum, string sendNum, String receiveNum, String receiveName, String subject, String content, DateTime? reserveDT, String UserID)
        {
            List<Message> messages = new List<Message>();
            Message msg = new Message();
            msg.receiveNum = receiveNum;
            msg.receiveName = receiveName;
            messages.Add(msg);

            return sendMessage(MessageType.LMS, CorpNum, sendNum, subject, content, messages, reserveDT, UserID);
        }

        public String SendLMS(String CorpNum, string sendNum, String subject, String content, List<Message> messages, DateTime? reserveDT, String UserID)
        {
            return sendMessage(MessageType.LMS, CorpNum, sendNum, subject, content, messages, reserveDT, UserID);
        }


        public String SendLMS(String CorpNum, List<Message> messages, DateTime? reserveDT, String UserID)
        {
            return sendMessage(MessageType.LMS, CorpNum, null, null, null, messages, reserveDT, UserID);
        }

        public String SendXMS(String CorpNum, string sendNum, String receiveNum, String receiveName, String subject, String content, DateTime? reserveDT, String UserID)
        {
            List<Message> messages = new List<Message>();
            Message msg = new Message();
            msg.receiveNum = receiveNum;
            msg.receiveName = receiveName;
            messages.Add(msg);

            return sendMessage(MessageType.XMS, CorpNum, sendNum, subject, content, messages, reserveDT, UserID);
        }

        public String SendXMS(String CorpNum, string sendNum, String subject, String content, List<Message> messages, DateTime? reserveDT, String UserID)
        {
            return sendMessage(MessageType.XMS, CorpNum, sendNum, subject, content, messages, reserveDT, UserID);
        }


        public String SendXMS(String CorpNum, List<Message> messages, DateTime? reserveDT, String UserID)
        {
            return sendMessage(MessageType.XMS, CorpNum, null, null, null, messages, reserveDT, UserID);
        }

        public List<MessageResult> GetMessageResult(String CorpNum, String receiptNum)
        {
            if (String.IsNullOrEmpty(receiptNum)) throw new PopbillException(-99999999, "접수번호가 입력되지 않았습니다.");

            return httpget<List<MessageResult>>("/Message/" + receiptNum, CorpNum, null);
        }

        public Response CancelReserve(String CorpNum, String receiptNum, String UserID)
        {
            if (String.IsNullOrEmpty(receiptNum)) throw new PopbillException(-99999999, "접수번호가 입력되지 않았습니다.");

            return httpget<Response>("/Message/" + receiptNum + "/Cancel", CorpNum, UserID);
        }

        private String sendMessage(MessageType msgType, String CorpNum, string sender, string subject, string content, List<Message> messages, DateTime? reserveDT, string UserID)
        {
            if (messages == null || messages.Count == 0) throw new PopbillException(-99999999, "전송할 메시지가 입력되지 않았습니다.");

            sendRequest request = new sendRequest();

            request.snd = sender;
            request.subject = subject;
            request.content = content;
            request.sndDT = reserveDT == null ? null : reserveDT.Value.ToString("yyyyMMddHHmmss");

            request.msgs = messages;

            String PostData = toJsonString(request);

            ReceiptResponse response = httppost<ReceiptResponse>("/" + msgType.ToString(), CorpNum, UserID, PostData,null);

            return response.receiptNum;
        }


        
        private class sendRequest
        {
            
            public String snd = null;
            
            public String subject = null;
            
            public String content = null;
            
            public String sndDT = null;
            
            public List<Message> msgs;
        }

        
        public class ReceiptResponse
        {
            
            public String receiptNum;
        }
    }
}
