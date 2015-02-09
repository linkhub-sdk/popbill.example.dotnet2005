using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Popbill.Cashbill;

namespace Popbill.Cashbill.Example.csharp
{
    public partial class frmExample : Form
    {
        //연동회원 상담시 발급받은 연동아이디
        private string LinkID = "TESTER";
        //연동회원 상담시 발급받은 비밀키
        private string SecretKey = "OTbVGsQdnLrc8kmmyIXr8W+nX+vDH6tAERiM+DNPFXo=";

        private CashbillService cashbillService;

        private const string CRLF = "\r\n";

        public frmExample()
        {
            InitializeComponent();
            //초기화
            cashbillService = new CashbillService(LinkID, SecretKey);
            //테스트를 완료한후 아래 변수를 false로 변경하거나, 아래줄을 삭제하여 실제 서비스 연결.
            cashbillService.IsTest = true;
        }


        // 팝빌 로그인 URL
        private void btnGetPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "LOGIN");

                MessageBox.Show(url);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }      

        // 포인트충전 팝업 URL
        private void btnGetPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CHRG");

                MessageBox.Show(url);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
       }

        // 연동회원가입
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
                Response response = cashbillService.JoinMember(joinInfo);

                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 잔여포인트 조회
        private void btnGetBalance_Click(object sender, EventArgs e)
        {

            try
            {
                double remainPoint = cashbillService.GetBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 파트너 잔여포인트 조회
        private void btnGetPartnerBalance_Click(object sender, EventArgs e)
        {
            try
            {
                double remainPoint = cashbillService.GetPartnerBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        // 회원가입여부확인
        private void btnCheckIsMember_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = cashbillService.CheckIsMember(txtCorpNum.Text, LinkID);

                MessageBox.Show(response.code.ToString() + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 발행단가 확인
        private void btnUnitCost_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = cashbillService.GetUnitCost(txtCorpNum.Text);

                MessageBox.Show(unitCost.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 문서관리번호 사용유무 확인
        private void btnCheckMgtKeyInUse_Click(object sender, EventArgs e)
        {
            try
            {
                bool InUse = cashbillService.CheckMgtKeyInUse(txtCorpNum.Text, txtMgtKey.Text);

                MessageBox.Show((InUse ? "사용중" : "미사용중"));

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 현금영수증 임시저장
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Cashbill cashbill = new Cashbill();

            cashbill.mgtKey = txtMgtKey.Text;            // 문서관리번호, 발행자별 고유번호 할당, 1~24자리 영문,숫자조합으로 중복없이 구성.
            cashbill.tradeType = "승인거래";             // 승인거래 or 취소거래
            cashbill.franchiseCorpNum = txtCorpNum.Text; // 가맹점 사업자번호
            cashbill.franchiseCorpName = "발행자 상호";
            cashbill.franchiseCEOName = "발행자 대표자";
            cashbill.franchiseAddr = "발행자 주소";
            cashbill.franchiseTEL = "070-1234-1234";
            cashbill.identityNum = "01041680206";      // 거래처 식별번호
            cashbill.customerName = "고객명";
            cashbill.itemName = "상품명";
            cashbill.orderNumber = "주문번호";
            cashbill.email = "test@test.com";
            cashbill.hp = "111-1234-1234";
            cashbill.fax = "777-444-3333";
            cashbill.serviceFee = "0";              // 봉사료
            cashbill.supplyCost = "10000";          // 공급가액
            cashbill.tax = "1000";                  // 세액
            cashbill.totalAmount = "11000";         // 합계금액
            cashbill.tradeUsage = "소득공제용";     // 소득공제용 or 지출증빙용
            cashbill.taxationType = "과세";         // 세 or 비과세

            cashbill.smssendYN =  false;
          
            try
            {
                Response response = cashbillService.Register(txtCorpNum.Text, cashbill, txtUserId.Text);

                MessageBox.Show(response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
         
            try
            {
                Response response = cashbillService.Delete(txtCorpNum.Text,  txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 현금영수증 상세항목 확인
        private void btnGetDetailInfo_Click(object sender, EventArgs e)
        {

            try
            {
                Cashbill cashbill = cashbillService.GetDetailInfo(txtCorpNum.Text,  txtMgtKey.Text);

                //자세한 문세정보는 작성시 항목을 참조하거나, 연동메뉴얼 참조.

                string tmp = null;
                tmp += "mgtKey: " + cashbill.mgtKey + CRLF;
                tmp += "tradeDate : " + cashbill.tradeDate  + CRLF;
                tmp += "tradeUsage : " + cashbill.tradeUsage  + CRLF;
                tmp += "tradeType : " + cashbill.tradeType  + CRLF;
                tmp += "taxationType : " + cashbill.taxationType  + CRLF;
                tmp += "supplyCost : " + cashbill.supplyCost  + CRLF;
                tmp += "tax : " + cashbill.tax  + CRLF;
                tmp += "serviceFee : " + cashbill.serviceFee  + CRLF;
                tmp += "totalAmount : " + cashbill.totalAmount  + CRLF;

                tmp += "franchiseCorpNum : " + cashbill.franchiseCorpNum  + CRLF;
                tmp += "franchiseCorpName : " + cashbill.franchiseCorpName  + CRLF;
                tmp += "franchiseCEOName : " + cashbill.franchiseCEOName  + CRLF;
                tmp += "franchiseAddr : " + cashbill.franchiseAddr  + CRLF;
                tmp += "franchiseTEL : " + cashbill.franchiseTEL  + CRLF;
                
                tmp += "identityNum : " + cashbill.identityNum  + CRLF;
                tmp += "customerName : " + cashbill.customerName  + CRLF;
                tmp += "itemName : " + cashbill.itemName  + CRLF;
                tmp += "orderNumber : " + cashbill.orderNumber  + CRLF;
                tmp += "email : " + cashbill.email  + CRLF;
                tmp += "hp : " + cashbill.hp  + CRLF;
                
                tmp += "smssendYN : " + cashbill.smssendYN  + CRLF;
                tmp += "faxsendYN : " + cashbill.faxsendYN  + CRLF;
                
                MessageBox.Show(tmp);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 요약,상태정보 확인
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
         
            try
            {
                CashbillInfo cashbillInfo = cashbillService.GetInfo(txtCorpNum.Text, txtMgtKey.Text);

                string tmp = null;

                tmp += "itemKey : " + cashbillInfo.itemKey + CRLF;
                tmp += "mgtKey : " + cashbillInfo.mgtKey + CRLF;
                tmp += "tradeDate : " + cashbillInfo.tradeDate + CRLF;
                tmp += "issueDT : " + cashbillInfo.issueDT + CRLF;
                tmp += "customerName : " + cashbillInfo.customerName + CRLF;
                tmp += "itemName : " + cashbillInfo.itemName + CRLF;
                tmp += "identityNum : " + cashbillInfo.identityNum + CRLF;
                tmp += "taxationType : " + cashbillInfo.taxationType + CRLF;
               
                tmp += "totalAmount : " + cashbillInfo.totalAmount + CRLF;
                tmp += "tradeUsage : " + cashbillInfo.tradeUsage + CRLF;
                tmp += "tradeType : " + cashbillInfo.tradeType + CRLF;
                tmp += "stateCode : " + cashbillInfo.stateCode + CRLF;
                tmp += "stateDT : " + cashbillInfo.stateDT + CRLF;
                tmp += "printYN : " + cashbillInfo.printYN + CRLF;

                tmp += "confirmNum : " + cashbillInfo.confirmNum + CRLF;
                tmp += "orgTradeDate : " + cashbillInfo.orgTradeDate + CRLF;
                tmp += "orgConfirmNum : " + cashbillInfo.orgConfirmNum + CRLF;

                tmp += "ntssendDT : " + cashbillInfo.ntssendDT + CRLF;
                tmp += "ntsresult : " + cashbillInfo.ntsresult + CRLF;
                tmp += "ntsresultDT : " + cashbillInfo.ntsresultDT + CRLF;
                tmp += "ntsresultCode : " + cashbillInfo.ntsresultCode + CRLF;
                tmp += "ntsresultMessage : " + cashbillInfo.ntsresultMessage + CRLF;

                tmp += "regDT : " + cashbillInfo.regDT;

                MessageBox.Show(tmp);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 임시문서함 URL
        private void btnGetURL_TBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetURL(txtCorpNum.Text, txtUserId.Text, "TBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 발행문서함 URL
        private void btnGetURL_SBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetURL(txtCorpNum.Text, txtUserId.Text, "PBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }
        
        // 현금영수증 작성 URL
        private void btnGetURL_WRITE_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetURL(txtCorpNum.Text, txtUserId.Text, "WRITE");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 이력확인
        private void btnGetLogs_Click(object sender, EventArgs e)
        {
        
            try
            {
                List<CashbillLog> logList = cashbillService.GetLogs(txtCorpNum.Text, txtMgtKey.Text);

                String tmp = "";


                foreach (CashbillLog log in logList)
                {
                    tmp += log.docLogType + " | " + log.log + " | " + log.procType + " | " + log.procMemo + " | " + log.regDT + " | " + log.ip + CRLF;
                }
                
                MessageBox.Show(tmp);



            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 다량 현금영수증 조회
        private void btnGetInfos_Click(object sender, EventArgs e)
        {
        
            List<string> MgtKeyList = new List<string>();

            //'최대 1000건.
            MgtKeyList.Add("20150209-01");
            MgtKeyList.Add("20150209-02");
            MgtKeyList.Add("20150209-03");
            MgtKeyList.Add("20150209-10");

            try
            {
                List<CashbillInfo> cashbillInfoList = cashbillService.GetInfos(txtCorpNum.Text, MgtKeyList);

                string tmp = null;
                for (int i = 0; i < cashbillInfoList.Count; i++)
                {
                    tmp += "itemKey : " + cashbillInfoList[i].itemKey + CRLF;
                    tmp += "mgtKey : " + cashbillInfoList[i].mgtKey + CRLF;
                    tmp += "tradeDate : " + cashbillInfoList[i].tradeDate + CRLF;
                    tmp += "issueDT : " + cashbillInfoList[i].issueDT + CRLF;
                    tmp += "customerName : " + cashbillInfoList[i].customerName + CRLF;
                    tmp += "itemName : " + cashbillInfoList[i].itemName + CRLF;
                    tmp += "identityNum : " + cashbillInfoList[i].identityNum + CRLF;
                    tmp += "taxationType : " + cashbillInfoList[i].taxationType + CRLF;

                    tmp += "totalAmount : " + cashbillInfoList[i].totalAmount + CRLF;
                    tmp += "tradeUsage : " + cashbillInfoList[i].tradeUsage + CRLF;
                    tmp += "tradeType : " + cashbillInfoList[i].tradeType + CRLF;
                    tmp += "stateCode : " + cashbillInfoList[i].stateCode + CRLF;
                    tmp += "stateDT : " + cashbillInfoList[i].stateDT + CRLF;
                    tmp += "printYN : " + cashbillInfoList[i].printYN + CRLF;

                    tmp += "confirmNum : " + cashbillInfoList[i].confirmNum + CRLF;
                    tmp += "orgTradeDate : " + cashbillInfoList[i].orgTradeDate + CRLF;
                    tmp += "orgConfirmNum : " + cashbillInfoList[i].orgConfirmNum + CRLF;

                    tmp += "ntssendDT : " + cashbillInfoList[i].ntssendDT + CRLF;
                    tmp += "ntsresult : " + cashbillInfoList[i].ntsresult + CRLF;
                    tmp += "ntsresultDT : " + cashbillInfoList[i].ntsresultDT + CRLF;
                    tmp += "ntsresultCode : " + cashbillInfoList[i].ntsresultCode + CRLF;
                    tmp += "ntsresultMessage : " + cashbillInfoList[i].ntsresultMessage + CRLF;

                    tmp += "regDT : " + cashbillInfoList[i].regDT+CRLF+CRLF;
                }

                MessageBox.Show(tmp);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }

        }


        // 알림메일 재전송
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
          
            try
            {
                //SendEmail(사업자번호, 문서관리번호, 수신이메일주소, 회원아이디)
                Response response = cashbillService.SendEmail(txtCorpNum.Text, txtMgtKey.Text, "test@test.com", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 알림문자 재전송
        private void btnSendSMS_Click(object sender, EventArgs e)
        {

            try
            {
                //SendSMS(사업자번호, 문서관리번호, 발신번호, 수신번호, 메시지내용, 회원아이디)
                //메시지내용이 90Byte이상인경우 메시지의 길이가 조정되어 전송됩니다.
                Response response = cashbillService.SendSMS(txtCorpNum.Text, txtMgtKey.Text, "1111-2222", "010-111-222", "발신문자 내용...", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 팩스 전송
        private void btnSendFAX_Click(object sender, EventArgs e)
        {
            try
            {
                //SendFAX(사업자번호, 문서관리번호, 발신번호, 수신팩스번호, 회원아이디)
                Response response = cashbillService.SendFAX(txtCorpNum.Text, txtMgtKey.Text, "1111-2222", "000-1111-2222", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 현금영수증 보기 URL
        private void btnGetPopUpURL_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetPopUpURL(txtCorpNum.Text, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 프린트 URL
        private void btnGetPrintURL_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetPrintURL(txtCorpNum.Text, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }

        }

        // 현금영수증 프린트 URL(공급받는자용)
        private void btnEPrintURL_Click(object sender, EventArgs e)
        {
          
            try
            {
                string url = cashbillService.GetEPrintURL(txtCorpNum.Text,  txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 현금영수증 메일 링크 URL
        private void btnGetEmailURL_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cashbillService.GetMailURL(txtCorpNum.Text,  txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 다량 현금영수증 인쇄 URL
        private void btnGetMassPrintURL_Click(object sender, EventArgs e)
        {
          
            List<string> MgtKeyList = new List<string>();

            //'최대 1000건.
            MgtKeyList.Add("20150209-14");
            MgtKeyList.Add("20150209-03");

            try
            {
                string url = cashbillService.GetMassPrintURL(txtCorpNum.Text, MgtKeyList, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 발행
        private void btnIssue_Click(object sender, EventArgs e)
        {
          
            try
            {
                Response response = cashbillService.Issue(txtCorpNum.Text,  txtMgtKey.Text, "발행시 메모",  txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 발행취소
        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
          
            try
            {
                Response response = cashbillService.CancelIssue(txtCorpNum.Text, txtMgtKey.Text, "발행취소시 메모.", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Cashbill cashbill = new Cashbill();

            cashbill.mgtKey = txtMgtKey.Text;        //발행자별 고유번호 할당, 1~24자리 영문,숫자조합으로 중복없이 구성.
            cashbill.tradeType = "승인거래";         //승인거래 or 취소거래
            cashbill.franchiseCorpNum = txtCorpNum.Text;
            cashbill.franchiseCorpName = "발행자 상호_수정";
            cashbill.franchiseCEOName = "발행자 대표자";
            cashbill.franchiseAddr = "발행자 주소";
            cashbill.franchiseTEL = "070-1234-1234";
            cashbill.identityNum = "01041680206";
            cashbill.customerName = "고객명";
            cashbill.itemName = "상품명";
            cashbill.orderNumber = "주문번호";
            cashbill.email = "test@test.com";
            cashbill.hp = "111-1234-1234";
            cashbill.fax = "777-444-3333";
            cashbill.serviceFee = "0";
            cashbill.supplyCost = "10000";
            cashbill.tax = "1000";
            cashbill.totalAmount = "11000";
            cashbill.tradeUsage = "소득공제용";      //소득공제용 or 지출증빙용
            cashbill.taxationType = "과세";          //과세 or 비과세

            cashbill.smssendYN = false;


            try
            {
                Response response = cashbillService.Update(txtCorpNum.Text, txtMgtKey.Text, cashbill, txtUserId.Text);

                MessageBox.Show(response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }
    }
}
