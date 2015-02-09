using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Popbill.Fax.Example.csharp
{
    public partial class frmExample : Form
    {
        //연동상담시 발급받은 연동아이디
        private string LinkID = "TESTER";
        //연동상담시 발급받은 비밀키
        private string SecretKey = "OTbVGsQdnLrc8kmmyIXr8W+nX+vDH6tAERiM+DNPFXo=";

        private FaxService faxService;

        private const string CRLF = "\r\n";

        public frmExample()
        {
            InitializeComponent();

            //초기화
            faxService = new FaxService(LinkID, SecretKey);
            //테스트를 완료한후 아래 변수를 false로 변경하거나, 아래줄을 삭제하여 상업용 환경으로 전환.
            faxService.IsTest = true;
        }

        //팝빌 로그인 URL 확인
        private void getPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                string url = faxService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "LOGIN");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }

        }

        //팝빌 포인트충전 팝업 URL 확인
        private void getPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            try
            {
                string url = faxService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CHRG");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 연동회원 가입요청
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
                Response response = faxService.JoinMember(joinInfo);

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
                double remainPoint = faxService.GetBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        
        //파트너 잔여포인트 확인
        private void btnGetPartnerBalance_Click(object sender, EventArgs e)
        {
            try
            {
                double remainPoint = faxService.GetPartnerBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 연동회원 가입여부 확인
        private void btnCheckIsMember_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = faxService.CheckIsMember(txtCorpNum.Text, LinkID);

                MessageBox.Show(response.code.ToString() + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // 팩스 전송단가확인
        private void btnUnitCost_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = faxService.GetUnitCost(txtCorpNum.Text);

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


        //팩스 전송내역 조회 URL 
        private void btnGetURL_Click(object sender, EventArgs e)
        {
            try
            {
                string url = faxService.GetURL(txtCorpNum.Text, txtUserId.Text, "BOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 팩스전송예약 취소 (예약전송시간 10분전까지 가능)
        private void btnCancelReserve_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = faxService.CancelReserve(txtCorpNum.Text, txtReceiptNum.Text, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 팩스전송결과확인
        private void btnGetFaxResult_Click(object sender, EventArgs e)
        {
            try
            {
                List<FaxResult> ResultList = faxService.GetFaxResult(txtCorpNum.Text, txtReceiptNum.Text);

                dataGridView1.DataSource = ResultList;

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        //팩스 전송
        private void button1_Click(object sender, EventArgs e)
        {

            if (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string strFileName = fileDialog.FileName;


                try
                {
                    //SendFAX(사업자번호, 발신자번호, 수신팩스번호, 수신자명, 파일경로, 예약전송일시, 회원아이디)
                    String receiptNum = faxService.SendFAX(txtCorpNum.Text, "070-7510-6766", "02-6442-9700", "수신자 명칭", strFileName, getReserveDT(), txtUserId.Text);

                    MessageBox.Show("접수번호 : " + receiptNum);
                    txtReceiptNum.Text = receiptNum;
                }
                catch (PopbillException ex)
                {
                    MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
                }

            }
        }

        // 팩스 동보전송
        private void button2_Click(object sender, EventArgs e)
        {

            if (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string strFileName = fileDialog.FileName;

                List<FaxReceiver> receivers = new List<FaxReceiver>();

                for (int i = 0; i < 100; i++)
                {
                    FaxReceiver receiver = new FaxReceiver();
                    receiver.receiveNum = "111-2222-3333";
                    receiver.receiveName = "수신자명칭_" + i;
                    receivers.Add(receiver);
                }

                try
                {
                    //SendFAX(사업자번호, 발신자번호, 수신정보배열, 파일경로, 예약전송일시, 회원아이디)
                    String receiptNum = faxService.SendFAX(txtCorpNum.Text, "070-7510-6766", receivers, strFileName, getReserveDT(), txtUserId.Text);

                    MessageBox.Show("접수번호 : " + receiptNum);
                    txtReceiptNum.Text = receiptNum;
                }
                catch (PopbillException ex)
                {
                    MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
                }

            }
        }


        // 다수파일전송

        private void button3_Click(object sender, EventArgs e)
        {
            List<String> filePaths = new List<string>();

            while (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
               filePaths.Add( fileDialog.FileName);

            }

            if(filePaths.Count > 0)
            {
                try
                {
                    //SendFAX(사업자번호, 발신자번호, 수신팩스번호, 수신자명, 파일경로, 예약전송일시, 회원아이디)
                    String receiptNum = faxService.SendFAX(txtCorpNum.Text, "070-7510-6766", "111-2222-3333", "수신자 명칭", filePaths, getReserveDT(), txtUserId.Text);

                    MessageBox.Show("접수번호 : " + receiptNum);
                    txtReceiptNum.Text = receiptNum;
                }
                catch (PopbillException ex)
                {
                    MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
                }

            }
        }

        // 다수파일 동보전송

        private void button4_Click(object sender, EventArgs e)
        {
            List<String> filePaths = new List<string>();

            while (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                filePaths.Add(fileDialog.FileName);

            }

            if (filePaths.Count > 0)
            {
                List<FaxReceiver> receivers = new List<FaxReceiver>();

                for (int i = 0; i < 100; i++)
                {
                    FaxReceiver receiver = new FaxReceiver();
                    receiver.receiveNum = "111-2222-3333";
                    receiver.receiveName = "수신자명칭_" + i;
                    receivers.Add(receiver);
                }


                try
                {
                    //SendFAX(사업자번호, 발신자번호, 수신자정보배열, 파일경로, 예약전송일시, 회원아이디)
                    String receiptNum = faxService.SendFAX(txtCorpNum.Text, "070-7510-6766", receivers, filePaths, getReserveDT(), txtUserId.Text);

                    MessageBox.Show("접수번호 : " + receiptNum);
                    txtReceiptNum.Text = receiptNum;
                }
                catch (PopbillException ex)
                {
                    MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
                }

            }
        }
    }
}
