using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Popbill.Message.Example.csharp
{
    public partial class frmExample : Form
    {
        //연동상담시 발급받은 연동아이디
        private string LinkID = "TESTER";
        //연동상담시 발급받은 비밀키
        private string SecretKey = "OTbVGsQdnLrc8kmmyIXr8W+nX+vDH6tAERiM+DNPFXo=";

        private MessageService messageService;

        private const string CRLF = "\r\n";

        public frmExample()
        {
            InitializeComponent();

            //초기화
            messageService = new MessageService(LinkID, SecretKey);
            //테스트를 완료한후 상업용 환경으로 전환하기 위해서는 아래 변수를 false로 변경하거나, 아래줄을 삭제하여 상업용으로 전환.
            messageService.IsTest = true;
        }


        // 팝빌 로그인 URL
        private void getPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                string url = messageService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "LOGIN");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 포인트 충전 팝업 URL
        private void getPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            try
            {
                string url = messageService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CHRG");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }

        }


        // 연동회원가입요청
        private void btnJoinMember_Click(object sender, EventArgs e)
        {
            JoinForm joinInfo = new JoinForm();

            joinInfo.LinkID = LinkID;
            joinInfo.CorpNum = "1231212312";          //사업자번호 "-" 제외
            joinInfo.CEOName = "대표자성명";
            joinInfo.CorpName = "상호";
            joinInfo.Addr = "주소";
            joinInfo.ZipCode = "500-100";
            joinInfo.BizType = "업태";
            joinInfo.BizClass = "업종";
            joinInfo.ID = "userid";                   //6자 이상 20자 미만
            joinInfo.PWD = "pwd_must_be_long_enough"; //6자 이상 20자 미만
            joinInfo.ContactName = "담당자명";
            joinInfo.ContactTEL = "02-999-9999";
            joinInfo.ContactHP = "010-1234-5678";
            joinInfo.ContactFAX = "02-999-9998";
            joinInfo.ContactEmail = "test@test.com";

            try
            {
                Response response = messageService.JoinMember(joinInfo);

                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 잔여포인트 확인
        private void btnGetBalance_Click(object sender, EventArgs e)
        {

            try
            {
                double remainPoint = messageService.GetBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 파트너 잔여포인트 확인
        private void btnGetPartnerBalance_Click(object sender, EventArgs e)
        {
            try
            {
                double remainPoint = messageService.GetPartnerBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        //회원가입여부 확인
        private void btnCheckIsMember_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = messageService.CheckIsMember(txtCorpNum.Text, LinkID);

                MessageBox.Show(response.code.ToString() + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        //문자 전송단가 확인(SMS)
        private void btnUnitCost_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = messageService.GetUnitCost(txtCorpNum.Text,MessageType.SMS);

                MessageBox.Show(unitCost.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }
       
        // 문자 전송단가 확인(LMS)
        private void btnUnitCost_LMS_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = messageService.GetUnitCost(txtCorpNum.Text, MessageType.LMS);

                MessageBox.Show(unitCost.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private DateTime? getReserveDT()
        {
            DateTime? reserveDT = null;
            if (String.IsNullOrEmpty(txtReserveDT.Text) == false)
            {

                reserveDT = DateTime.ParseExact(txtReserveDT.Text, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            }
            return reserveDT;
        }


        // SMS(단문) 1건 전송
        private void btnSendSMS_one_Click(object sender, EventArgs e)
        {
            try
            {
                //SendSMS(사업자번호, 발신번호, 수신번호, 수신자명, 메시지내용, 예약전송시간, 회원아이디)
                string receiptNum = messageService.SendSMS(txtCorpNum.Text, "07075106766", "111112222333", "수신자명칭", "단문 문자 메시지 내용. 90Byte", getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // SMS(단문) 100건전송
        private void button1_Click(object sender, EventArgs e)
        {
            List<Message> messages = new List<Message>();

            for (int i = 0; i < 100; i++)
            {
                Message msg = new Message();

                msg.sendNum = "07075106766";
                msg.receiveNum = "11122223333";
                msg.receiveName = "수신자명칭_" + i;
                msg.content = "단문 문자메시지 내용, 각 메시지마다 개별설정 가능." + i;

                messages.Add(msg);
            }
            try
            {
                //SendSMS(사업자번호, 전송정보배열, 전송예약시간, 회원아이디)
                string receiptNum = messageService.SendSMS(txtCorpNum.Text,messages, getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // SMS(단문) 동보전송
        private void btnSendSMS_Same_Click(object sender, EventArgs e)
        {
            List<Message> messages = new List<Message>();

            for (int i = 0; i < 100; i++)
            {
                Message msg = new Message();

                msg.receiveNum = "11122223333";
                msg.receiveName = "수신자명칭_" + i;
            
                messages.Add(msg);
            }
            try
            {
                // 전송정보배열(msg)에 메시지 내용(msg.content)이 없는경우 동보메시지 내용이 전송됩니다.
                // SendSMS(사업자번호, 동보전송번호, 동보전송내용, 전송정보배열, 예약전송일시, 회원아이디)
                string receiptNum = messageService.SendSMS(txtCorpNum.Text,"07075106766","동보 단문문자 메시지 내용", messages, getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // LMS(장문) 1건전송
        private void btnSendLMS_one_Click(object sender, EventArgs e)
        {
            try
            {
                //SendLMS(사업자번호, 발신번호, 수신번호, 수신자명, 메시지제목, 메시지내용, 예약일시, 회원아이디)
                string receiptNum = messageService.SendLMS(
                                        txtCorpNum.Text,        
                                        "07075106766",          
                                        "11122223333",          
                                        "수신자명칭",           
                                        "장문문자 메시지 제목", 
                                        "장문 문자 메시지 내용. 2000Byte", 
                                        getReserveDT(),     
                                        txtUserId.Text      
                                        );

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // LMS(장문) 100건 전송
        private void btnSendLMS_hund_Click(object sender, EventArgs e)
        {
            List<Message> messages = new List<Message>();

            for (int i = 0; i < 100; i++)
            {
                Message msg = new Message();

                msg.sendNum = "07075106766";
                msg.receiveNum = "11122223333";
                msg.receiveName = "수신자명칭_" + i;
                msg.subject = "장문 문자메시지 제목";
                msg.content = "장문 문자메시지 내용, 각 메시지마다 개별설정 가능." + i;

                messages.Add(msg);
            }
            try
            {
                // SendLMS(사업자번호, 전송정보배열, 예약전송일시, 회원아이디)
                string receiptNum = messageService.SendLMS(txtCorpNum.Text, messages, getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // LMS(장문) 동보전송
        private void btnSendLMS_same_Click(object sender, EventArgs e)
        {
            List<Message> messages = new List<Message>();

            for (int i = 0; i < 100; i++)
            {
                Message msg = new Message();

                msg.receiveNum = "11122223333";
                msg.receiveName = "수신자명칭_" + i;

                messages.Add(msg);
            }
            try
            {
                // 전송정보배열(msg)에 메시지 내용(msg.content)이 없는경우 동보메시지 내용이 전송됩니다.
                // SendLMS(사업자번호, 동보발신번호,동보메시지제목, 동보메시지내용, 전송정보배열, 예약전송일시, 회원아이디)
                string receiptNum = messageService.SendLMS(txtCorpNum.Text, "07075106766","동보 메시지 제목", "동보 단문문자 메시지 내용", messages, getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // XMS(단/장문 자동인식) 1건 전송
        private void btnSendXMS_one_Click(object sender, EventArgs e)
        {
            try
            {
                // SendXMS(사업자번호, 발신번호, 수신번호, 수신자명칭, 메시지제목, 메시지내용, 예약전송일시, 회원아이디)
                string receiptNum = messageService.SendXMS(
                                        txtCorpNum.Text,
                                        "07075106766",
                                        "11122223333",
                                        "수신자명칭",
                                        "장문문자 메시지 제목",
                                        "문자 메시지 내용. 메시지의 길이에 따라 90Byte를 기준으로 SMS/LMS를 선택전송",
                                        getReserveDT(),
                                        txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // XML(단/장문 자동인식) 100건 전송
        private void btnSendXMS_hund_Click(object sender, EventArgs e)
        {
            List<Message> messages = new List<Message>();

            for (int i = 0; i < 100; i++)
            {
                Message msg = new Message();

                msg.sendNum = "07075106766";
                msg.receiveNum = "11122223333";
                msg.receiveName = "수신자명칭_" + i;
                msg.subject = "문자메시지 제목";
                msg.content = "문자메시지 내용, 각 메시지마다 개별설정 가능. 자동인식 전송의 경우 메시지의 길이에 따라 90Byte를 기준으로 단/장문을 자동인식하여 전송합니다." + i;

                messages.Add(msg);
            }


            try
            {
                // SendXMS(사업자번호, 전송정보배열, 예약전송일시, 회원아이디)
                string receiptNum = messageService.SendXMS(txtCorpNum.Text, messages, getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // XML(단/장문 자동인식) 동보 전송
        private void btnSendXMS_same_Click(object sender, EventArgs e)
        {
            List<Message> messages = new List<Message>();

            for (int i = 0; i < 100; i++)
            {
                Message msg = new Message();

                msg.receiveNum = "11122223333";
                msg.receiveName = "수신자명칭_" + i;

                messages.Add(msg);
            }
            try
            {
                // 전송정보배열(msg)에 메시지 내용(msg.content)이 없는경우 동보메시지 내용이 전송됩니다.
                // SendXMS(사업자번호, 동보발신번호,동보메시지제목, 동보메시지내용, 전송정보배열, 예약전송일시, 회원아이디)
                string receiptNum = messageService.SendXMS(txtCorpNum.Text, "07075106766", "동보 메시지 제목", "동보 단문문자 메시지 내용", messages, getReserveDT(), txtUserId.Text);

                MessageBox.Show("접수번호 : " + receiptNum);
                txtReceiptNum.Text = receiptNum;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // 문자 전송내역 조회 팝업 URL
        private void btnGetURL_Click(object sender, EventArgs e)
        {
            try
            {
                string url = messageService.GetURL(txtCorpNum.Text, txtUserId.Text, "BOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 예약전송문자 취소, 예약전송시간 10분전까지만 취소 가능
        private void btnCancelReserve_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = messageService.CancelReserve(txtCorpNum.Text,txtReceiptNum.Text,txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 문자 전송결과 확인
        private void btnGetMessageResult_Click(object sender, EventArgs e)
        {
            try
            {
                List<MessageResult> ResultList = messageService.GetMessageResult(txtCorpNum.Text, txtReceiptNum.Text);

                dataGridView1.DataSource = ResultList;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }
    }
}
