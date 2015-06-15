using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Popbill.Taxinvoice.Example.csharp
{
    public partial class frmExample : Form
    {
        //연동상담시 발급받은 연동아이디
        private string LinkID = "TESTER";
        //연동상담시 발급받은 비밀키
        private string SecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";

        private TaxinvoiceService taxinvoiceService;

        private const string CRLF = "\r\n";

        public frmExample()
        {
            InitializeComponent();
            //초기화
            taxinvoiceService = new TaxinvoiceService(LinkID, SecretKey);
            //테스트를 완료한후 아래 변수를 false로 변경하거나, 아래줄을 삭제하여 상업용 환경으로 전환
            taxinvoiceService.IsTest = true;
        }

        // 팝빌 로그인 URL 
        private void btnGetPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            string url = taxinvoiceService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "LOGIN");

            MessageBox.Show(url);
        }


        // 포인트 충전 팝업 URL
        private void btnGetPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            string url = taxinvoiceService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CHRG");

            MessageBox.Show(url);
        }

        // 공인인증서 등록 팝업 URL
        private void btnGetPopbillURL_CERT_Click(object sender, EventArgs e)
        {
            string url = taxinvoiceService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CERT");

            MessageBox.Show(url);
        }


        // 회원가입요청
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
                Response response = taxinvoiceService.JoinMember(joinInfo);

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
                double remainPoint = taxinvoiceService.GetBalance(txtCorpNum.Text);

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
                double remainPoint = taxinvoiceService.GetPartnerBalance(txtCorpNum.Text);

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
                Response response = taxinvoiceService.CheckIsMember(txtCorpNum.Text, LinkID);

                MessageBox.Show(response.code.ToString() + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 발행단가확인
        private void btnUnitCost_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = taxinvoiceService.GetUnitCost(txtCorpNum.Text);

                MessageBox.Show(unitCost.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        // 공인인증서 만료일자 확인
        private void btnGetCertificateExpireDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime expiration = taxinvoiceService.GetCertificateExpireDate(txtCorpNum.Text);

                MessageBox.Show(expiration.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        //문서관리번호 사용여부 확인
        private void btnCheckMgtKeyInUse_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType) Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                bool InUse = taxinvoiceService.CheckMgtKeyInUse(txtCorpNum.Text, KeyType, txtMgtKey.Text);

                MessageBox.Show((InUse ? "사용중" : "미사용중"));

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 대용량 연계사업자 이메일 목록
        private void btnGetEmailPublicKey_Click(object sender, EventArgs e)
        {
            try
            {
                List<EmailPublicKey> KeyList = taxinvoiceService.GetEmailPublicKeys(txtCorpNum.Text);

                String tmp = "";
                 
                for (int i = 0; i < KeyList.Count; i++)
                {
                    tmp += KeyList[i].email + CRLF;
                }

                MessageBox.Show(tmp);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 임시저장
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Taxinvoice taxinvoice = new Taxinvoice();

            taxinvoice.writeDate = "20150615";                      //필수, 기재상 작성일자
            taxinvoice.chargeDirection = "정과금";                  //필수, {정과금, 역과금}
            taxinvoice.issueType = "정발행";                        //필수, {정발행, 역발행, 위수탁}
            taxinvoice.purposeType = "영수";                        //필수, {영수, 청구}
            taxinvoice.issueTiming = "직접발행";                    //필수, {직접발행, 승인시자동발행}
            taxinvoice.taxType = "과세";                            //필수, {과세, 영세, 면세}


            taxinvoice.invoicerCorpNum = "1234567890";
            taxinvoice.invoicerTaxRegID = "";                       //종사업자 식별번호. 필요시 기재. 형식은 숫자 4자리.
            taxinvoice.invoicerCorpName = "공급자 상호";
            taxinvoice.invoicerMgtKey = txtMgtKey.Text;             //문서관리번호 1~24자리까지 공급자사업자번호별 중복없는 고유번호 할당
            taxinvoice.invoicerCEOName = "공급자 대표자 성명";
            taxinvoice.invoicerAddr = "공급자 주소";
            taxinvoice.invoicerBizClass = "공급자 업종";
            taxinvoice.invoicerBizType = "공급자 업태,업태2";
            taxinvoice.invoicerContactName = "공급자 담당자명";
            taxinvoice.invoicerEmail = "test@test.com";
            taxinvoice.invoicerTEL = "070-7070-0707";
            taxinvoice.invoicerHP = "010-000-2222";
            taxinvoice.invoicerSMSSendYN = false;                    //발행시 문자발송기능 사용시 활용

            taxinvoice.invoiceeType = "사업자";
            taxinvoice.invoiceeCorpNum = "8888888888";
            taxinvoice.invoiceeCorpName = "공급받는자 상호";
            taxinvoice.invoiceeMgtKey = "";
            taxinvoice.invoiceeCEOName = "공급받는자 대표자 성명";
            taxinvoice.invoiceeAddr = "공급받는자 주소";
            taxinvoice.invoiceeBizClass = "공급받는자 업종";
            taxinvoice.invoiceeBizType = "공급받는자 업태";
            taxinvoice.invoiceeContactName1 = "공급받는자 담당자명";
            taxinvoice.invoiceeEmail1 = "test@invoicee.com";
            taxinvoice.invoiceeSMSSendYN = false;                   //발행시 문자발송기능 사용시 활용

            taxinvoice.supplyCostTotal = "100000";                  //필수 공급가액 합계
            taxinvoice.taxTotal = "10000";                          //필수 세액 합계
            taxinvoice.totalAmount = "110000";                      //필수 합계금액.  공급가액 + 세액

            taxinvoice.modifyCode = null;                           //수정세금계산서 작성시 1~6까지 선택기재.
            taxinvoice.originalTaxinvoiceKey = "";                  //수정세금계산서 작성시 원본세금계산서의 ItemKey기재. ItemKey는 문서확인.
            taxinvoice.serialNum = "123";
            taxinvoice.cash = "";                                   //현금
            taxinvoice.chkBill = "";                                //수표
            taxinvoice.note = "";                                   //어음
            taxinvoice.credit = "";                                 //외상미수금
            taxinvoice.remark1 = "비고1";
            taxinvoice.remark2 = "비고2";
            taxinvoice.remark3 = "비고3";
            taxinvoice.kwon = 1;                                    // 기재상 '권' 항목
            taxinvoice.ho = 1;                                      // 기재상 '호' 항목

            taxinvoice.businessLicenseYN = false;                   //사업자등록증 이미지 첨부시 설정.
            taxinvoice.bankBookYN = false;                          //통장사본 이미지 첨부시 설정.
            taxinvoice.faxreceiveNum = "";                          //발행시 Fax발송기능 사용시 수신번호 기재.
            taxinvoice.faxsendYN = false;                           //발행시 Fax발송시 설정.

            taxinvoice.detailList = new List<TaxinvoiceDetail>();

            TaxinvoiceDetail detail = new TaxinvoiceDetail();

            detail.serialNum = 1;                                   //일련번호, 1~99까지 순차기재
            detail.purchaseDT = "20140319";                         //거래일자
            detail.itemName = "품목명";            
            detail.spec = "규격";
            detail.qty = "1";                                       //수량
            detail.unitCost = "100000";                             //단가
            detail.supplyCost = "100000";                           //공급가액
            detail.tax = "10000";                                   //세액
            detail.remark = "품목비고";

            taxinvoice.detailList.Add(detail);

            detail = new TaxinvoiceDetail();

            detail.serialNum = 2;
            detail.itemName = "품목명";

            taxinvoice.detailList.Add(detail);

            taxinvoice.addContactList = new List<TaxinvoiceAddContact>();

            TaxinvoiceAddContact addContact = new TaxinvoiceAddContact();

            addContact.email = "test2@invoicee.com";
            addContact.contactName = "추가담당자명";

            taxinvoice.addContactList.Add(addContact);


            try
            {
                Response response = taxinvoiceService.Register(txtCorpNum.Text, taxinvoice, txtUserId.Text, false);

                MessageBox.Show(response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);


            try
            {
                Response response = taxinvoiceService.Delete(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 발행예정
        private void btnSend_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);
            String Memo = "발행예정시 메모.";
            
            //발행예정 메일 제목, 공백기재시 기본제목으로 전송됨.
            String EmailSubject = ""; 

            try
            {
                Response response = taxinvoiceService.Send(txtCorpNum.Text, KeyType, txtMgtKey.Text, Memo, EmailSubject, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 발행예정 취소
        private void btnCancelSend_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.CancelSend(txtCorpNum.Text, KeyType, txtMgtKey.Text, "발행예정 취소시 메모.", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 상세항목 조회
        private void btnGetDetailInfo_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Taxinvoice taxinvoice = taxinvoiceService.GetDetailInfo(txtCorpNum.Text, KeyType, txtMgtKey.Text);

                //자세한 문세정보는 작성시 항목을 참조하거나, 연동메뉴얼 참조.

                string tmp = null;

                tmp += "writeDate : " + taxinvoice.writeDate + CRLF;
                tmp += "chargeDirection : " + taxinvoice.chargeDirection + CRLF;
                tmp += "issueType : " + taxinvoice.issueType + CRLF;
                tmp += "issueTiming : " + taxinvoice.issueTiming + CRLF;
                tmp += "taxType : " + taxinvoice.taxType + CRLF;
                tmp += "invoicerCorpNum : " + taxinvoice.invoicerCorpNum + CRLF;
                tmp += "invoicerMgtKey : " + taxinvoice.invoicerMgtKey + CRLF;
                tmp += "invoicerCorpName : " + taxinvoice.invoicerCorpName + CRLF;
                tmp += "invoicerCEOName : " + taxinvoice.invoicerCEOName + CRLF;
                tmp += "invoicerAddr : " + taxinvoice.invoicerAddr + CRLF;
                tmp += "invoicerContactName : " + taxinvoice.invoicerContactName + CRLF;
                tmp += "invoicerTEL : " + taxinvoice.invoicerTEL + CRLF;
                tmp += "invoicerHP : " + taxinvoice.invoicerHP + CRLF;
                tmp += "invoicerEmail : " + taxinvoice.invoicerEmail + CRLF;
                tmp += "invoicerSMSSendYN : " + taxinvoice.invoicerSMSSendYN + CRLF;
                tmp += "invoiceeCorpNum : " + taxinvoice.invoiceeCorpNum + CRLF;
                tmp += "invoiceeType : " + taxinvoice.invoiceeType + CRLF;
                tmp += "invoiceeMgtKey : " + taxinvoice.invoiceeMgtKey + CRLF;
                tmp += "invoiceeCorpName : " + taxinvoice.invoiceeCorpName + CRLF;
                tmp += "invoiceeCEOName : " + taxinvoice.invoiceeCEOName + CRLF;
                tmp += "invoiceeAddr : " + taxinvoice.invoiceeAddr + CRLF;
                tmp += "invoiceeTEL1 : " + taxinvoice.invoiceeTEL1 + CRLF;
                tmp += "invoiceeHP1 : " + taxinvoice.invoiceeHP1 + CRLF;
                tmp += "invoiceeEmail1 : " + taxinvoice.invoiceeEmail1 + CRLF;
                tmp += "invoiceeSMSSendYN : " + taxinvoice.invoiceeSMSSendYN + CRLF;
                tmp += "taxTotal : " + taxinvoice.taxTotal + CRLF;
                tmp += "supplyCostTotal : " + taxinvoice.supplyCostTotal + CRLF;
                tmp += "totalAmount : " + taxinvoice.totalAmount + CRLF;
                tmp += "purposeType : " + taxinvoice.purposeType + CRLF;
                tmp += "serialNum : " + taxinvoice.serialNum + CRLF;
                tmp += "remark1 : " + taxinvoice.remark1 + CRLF;
                tmp += "remark2 : " + taxinvoice.remark2 + CRLF;
                tmp += "remark3 : " + taxinvoice.remark3 + CRLF;
                tmp += "kwon : " + taxinvoice.kwon + CRLF;
                tmp += "ho : " + taxinvoice.ho + CRLF;
                tmp += "businessLicenseYN : " + taxinvoice.businessLicenseYN + CRLF;
                tmp += "bankBookYN : " + taxinvoice.bankBookYN + CRLF;
                tmp += "faxsendYN : " + taxinvoice.faxsendYN + CRLF;
                tmp += "ntsconfirmNum : " + taxinvoice.ntsconfirmNum + CRLF;

                MessageBox.Show(tmp);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 전자세금계산서 요약, 상태정보 조회
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                TaxinvoiceInfo taxinvoiceInfo = taxinvoiceService.GetInfo(txtCorpNum.Text, KeyType, txtMgtKey.Text);

                string tmp = null;

                tmp += "itemKey : " + taxinvoiceInfo.itemKey + CRLF;
                tmp += "taxType : " + taxinvoiceInfo.taxType + CRLF;
                tmp += "writeDate : " + taxinvoiceInfo.writeDate + CRLF;
                tmp += "regDT : " + taxinvoiceInfo.regDT + CRLF;

                tmp += "invoicerCorpName : " + taxinvoiceInfo.invoicerCorpName + CRLF;
                tmp += "invoicerCorpNum : " + taxinvoiceInfo.invoicerCorpNum + CRLF;
                tmp += "invoicerMgtKey : " + taxinvoiceInfo.invoicerMgtKey + CRLF;
                tmp += "invoiceeCorpName : " + taxinvoiceInfo.invoiceeCorpName + CRLF;
                tmp += "invoiceeCorpNum : " + taxinvoiceInfo.invoiceeCorpNum + CRLF;
                tmp += "invoiceeMgtKey : " + taxinvoiceInfo.invoiceeMgtKey + CRLF;
                tmp += "trusteeCorpName : " + taxinvoiceInfo.trusteeCorpName + CRLF;
                tmp += "trusteeCorpNum : " + taxinvoiceInfo.trusteeCorpNum + CRLF;
                tmp += "trusteeMgtKey : " + taxinvoiceInfo.trusteeMgtKey + CRLF;

                tmp += "supplyCostTotal : " + taxinvoiceInfo.supplyCostTotal + CRLF;
                tmp += "taxTotal : " + taxinvoiceInfo.taxTotal + CRLF;
                tmp += "purposeType : " + taxinvoiceInfo.purposeType + CRLF;
                tmp += "modifyCode : " + taxinvoiceInfo.modifyCode.ToString() + CRLF;
                tmp += "issueType : " + taxinvoiceInfo.issueType + CRLF;

                tmp += "issueDT : " + taxinvoiceInfo.issueDT + CRLF;
                tmp += "preIssueDT : " + taxinvoiceInfo.preIssueDT + CRLF;

                tmp += "stateCode : " + taxinvoiceInfo.stateCode.ToString() + CRLF;
                tmp += "stateDT : " + taxinvoiceInfo.stateDT + CRLF;

                tmp += "openYN : " + taxinvoiceInfo.openYN.ToString() + CRLF;
                tmp += "openDT : " + taxinvoiceInfo.openDT + CRLF;
                tmp += "ntsresult : " + taxinvoiceInfo.ntsresult + CRLF;
                tmp += "ntsconfirmNum : " + taxinvoiceInfo.ntsconfirmNum + CRLF;
                tmp += "ntssendDT : " + taxinvoiceInfo.ntssendDT + CRLF;
                tmp += "ntsresultDT : " + taxinvoiceInfo.ntsresultDT + CRLF;
                tmp += "ntssendErrCode : " + taxinvoiceInfo.ntssendErrCode + CRLF;
                tmp += "stateMemo : " + taxinvoiceInfo.stateMemo;

                MessageBox.Show(tmp);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 임시저장함 URL
        private void btnGetURL_TBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = taxinvoiceService.GetURL(txtCorpNum.Text, txtUserId.Text, "TBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 매출문서함 URL
        private void btnGetURL_SBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = taxinvoiceService.GetURL(txtCorpNum.Text, txtUserId.Text, "SBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 매입문서함 URL
        private void btnGetURL_PBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = taxinvoiceService.GetURL(txtCorpNum.Text, txtUserId.Text, "PBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 전자세금계산서 작성 URL
        private void btnGetURL_WRITE_Click(object sender, EventArgs e)
        {
            try
            {
                string url = taxinvoiceService.GetURL(txtCorpNum.Text, txtUserId.Text, "WRITE");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 문서 이력확인
        private void btnGetLogs_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                List<TaxinvoiceLog> logList = taxinvoiceService.GetLogs(txtCorpNum.Text, KeyType, txtMgtKey.Text);

                String tmp = "";


                foreach (TaxinvoiceLog log in logList)
                {
                    tmp += log.docLogType + " | " + log.log + " | " + log.procType + " | " + log.procCorpName + " | " + log.procContactName + " | " + log.procMemo + " | " + log.regDT + " | " + log.ip + CRLF;
                }
                
                MessageBox.Show(tmp);



            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 세금계산서 다량 확인
        private void btnGetInfos_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            List<string> MgtKeyList = new List<string>();

            //'최대 1000건.
            MgtKeyList.Add("20150209-02");
            MgtKeyList.Add("20150209-10");

            try
            {
                List<TaxinvoiceInfo> taxinvoiceInfoList = taxinvoiceService.GetInfos(txtCorpNum.Text, KeyType, MgtKeyList);

                string tmp = null;
                
                for (int i = 0; i < taxinvoiceInfoList.Count; i++)
                {
                    if (taxinvoiceInfoList[i].itemKey!=null)
                    {
                        tmp += "itemKey : " + taxinvoiceInfoList[i].itemKey + CRLF;
                        tmp += "taxType : " + taxinvoiceInfoList[i].taxType + CRLF;
                        tmp += "writeDate : " + taxinvoiceInfoList[i].writeDate + CRLF;
                        tmp += "regDT : " + taxinvoiceInfoList[i].regDT + CRLF;

                        tmp += "invoicerCorpName : " + taxinvoiceInfoList[i].invoicerCorpName + CRLF;
                        tmp += "invoicerCorpNum : " + taxinvoiceInfoList[i].invoicerCorpNum + CRLF;
                        tmp += "invoicerMgtKey : " + taxinvoiceInfoList[i].invoicerMgtKey + CRLF;
                        tmp += "invoiceeCorpName : " + taxinvoiceInfoList[i].invoiceeCorpName + CRLF;
                        tmp += "invoiceeCorpNum : " + taxinvoiceInfoList[i].invoiceeCorpNum + CRLF;
                        tmp += "invoiceeMgtKey : " + taxinvoiceInfoList[i].invoiceeMgtKey + CRLF;
                        tmp += "trusteeCorpName : " + taxinvoiceInfoList[i].trusteeCorpName + CRLF;
                        tmp += "trusteeCorpNum : " + taxinvoiceInfoList[i].trusteeCorpNum + CRLF;
                        tmp += "trusteeMgtKey : " + taxinvoiceInfoList[i].trusteeMgtKey + CRLF;

                        tmp += "supplyCostTotal : " + taxinvoiceInfoList[i].supplyCostTotal + CRLF;
                        tmp += "taxTotal : " + taxinvoiceInfoList[i].taxTotal + CRLF;
                        tmp += "purposeType : " + taxinvoiceInfoList[i].purposeType + CRLF;
                        tmp += "modifyCode : " + taxinvoiceInfoList[i].modifyCode.ToString() + CRLF;
                        tmp += "issueType : " + taxinvoiceInfoList[i].issueType + CRLF;

                        tmp += "issueDT : " + taxinvoiceInfoList[i].issueDT + CRLF;
                        tmp += "preIssueDT : " + taxinvoiceInfoList[i].preIssueDT + CRLF;

                        tmp += "stateCode : " + taxinvoiceInfoList[i].stateCode.ToString() + CRLF;
                        tmp += "stateDT : " + taxinvoiceInfoList[i].stateDT + CRLF;

                        tmp += "openYN : " + taxinvoiceInfoList[i].openYN.ToString() + CRLF;
                        tmp += "openDT : " + taxinvoiceInfoList[i].openDT + CRLF;
                        tmp += "ntsresult : " + taxinvoiceInfoList[i].ntsresult + CRLF;
                        tmp += "ntsconfirmNum : " + taxinvoiceInfoList[i].ntsconfirmNum + CRLF;
                        tmp += "ntssendDT : " + taxinvoiceInfoList[i].ntssendDT + CRLF;
                        tmp += "ntsresultDT : " + taxinvoiceInfoList[i].ntsresultDT + CRLF;
                        tmp += "ntssendErrCode : " + taxinvoiceInfoList[i].ntssendErrCode + CRLF;
                        tmp += "stateMemo : " + taxinvoiceInfoList[i].stateMemo+CRLF+CRLF;
                    }
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
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);


            try
            {
                // SendEmail(사업자번호, 발행유형, 문서관리번호, 수신메일주소, 회원아이디)
                Response response = taxinvoiceService.SendEmail(txtCorpNum.Text, KeyType, txtMgtKey.Text, "test@test.com", txtUserId.Text);

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

            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                //알림문자 전송의 경우 메시지 내용이 90Byte를 초과하는 경우 길이가 조정되어 전송됩니다.
                //SendSMS(사업자번호, 발행유형, 문서관리번호, 발신번호, 수신번호, 발신문자내용, 회원아이디)
                Response response = taxinvoiceService.SendSMS(txtCorpNum.Text, KeyType, txtMgtKey.Text, "1111-2222", "111-2222-4444", "발신문자 내용...", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 세금계산서 팩스 전송
        private void btnSendFAX_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                //SendFAX(사업자번호, 발행유형, 문서관리번호, 발신번호, 수신팩스번호, 회원아이디)
                Response response = taxinvoiceService.SendFAX(txtCorpNum.Text, KeyType, txtMgtKey.Text, "1111-2222", "000-2222-4444", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 세금계산서 보기 URL
        private void btnGetPopUpURL_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                string url = taxinvoiceService.GetPopUpURL(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 인쇄 URL
        private void btnGetPrintURL_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                string url = taxinvoiceService.GetPrintURL(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }

        }

        // 인쇄 URL(공급받는자용)
        private void btnEPrintURL_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                string url = taxinvoiceService.GetEPrintURL(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 공급받는자 메일 링크 URL
        private void btnGetEmailURL_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                string url = taxinvoiceService.GetMailURL(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 다량 인쇄 URL
        private void btnGetMassPrintURL_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            List<string> MgtKeyList = new List<string>();

            //'최대 1000건.
            MgtKeyList.Add("20150209-10");
            MgtKeyList.Add("20150209-11");

            try
            {
                string url = taxinvoiceService.GetMassPrintURL(txtCorpNum.Text, KeyType, MgtKeyList, txtUserId.Text);

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 국세청 즉시전송
        private void btnSendToNTS_Click(object sender, EventArgs e)
        {

            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.SendToNTS(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 세금계산서 발행
        private void btnIssue_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.Issue(txtCorpNum.Text, KeyType, txtMgtKey.Text, "발행시 메모", false, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 세금계산서 발행취소
        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.CancelIssue(txtCorpNum.Text, KeyType, txtMgtKey.Text, "발행취소시 메모.", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 발행예정 승인
        private void btnAccept_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.Accept(txtCorpNum.Text, KeyType, txtMgtKey.Text, "승인시 메모.", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 발행예정 거부
        private void btnDeny_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.Deny(txtCorpNum.Text, KeyType, txtMgtKey.Text, "거부시 메모.", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }


        // 역)발행 요청
        private void btnRequest_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.Request(txtCorpNum.Text, KeyType, txtMgtKey.Text, "역발행 요청시 메모", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 역)발행 요청 취소
        private void btnCancelRequest_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.CancelRequest(txtCorpNum.Text, KeyType, txtMgtKey.Text, "역발행 요청 취소시 메모", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 역)발행요청 거부
        private void btnRefuse_Click(object sender, EventArgs e)
        {

            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.Refuse(txtCorpNum.Text, KeyType, txtMgtKey.Text, "역발행 요청 거부시 메모", txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 역)발행 세금계산서 임시저장
        private void btnRegister_Reverse_Click(object sender, EventArgs e)
        {
            Taxinvoice taxinvoice = new Taxinvoice();

            taxinvoice.writeDate = "20150203";                      //필수, 기재상 작성일자
            taxinvoice.chargeDirection = "정과금";                  //필수, {정과금, 역과금}
            taxinvoice.issueType = "역발행";                        //필수, {정발행, 역발행, 위수탁}
            taxinvoice.purposeType = "영수";                        //필수, {영수, 청구}
            taxinvoice.issueTiming = "직접발행";                    //필수, {직접발행, 승인시자동발행}
            taxinvoice.taxType = "과세";                            //필수, {과세, 영세, 면세}


            taxinvoice.invoicerCorpNum = "8888888888";
            taxinvoice.invoicerTaxRegID = "";                       //종사업자 식별번호. 필요시 기재. 형식은 숫자 4자리.
            taxinvoice.invoicerCorpName = "공급자 상호";
            taxinvoice.invoicerMgtKey = "";                         //공급자 발행까지 API로 발행하고자 할경우 정발행과 동일한 형태로 추가 기재.
            taxinvoice.invoicerCEOName = "공급자 대표자 성명";
            taxinvoice.invoicerAddr = "공급자 주소";
            taxinvoice.invoicerBizClass = "공급자 업종";
            taxinvoice.invoicerBizType = "공급자 업태,업태2";
            taxinvoice.invoicerContactName = "공급자 담당자명";
            taxinvoice.invoicerEmail = "test@test.com";
            taxinvoice.invoicerTEL = "070-7070-0707";
            taxinvoice.invoicerHP = "010-000-2222";
            taxinvoice.invoicerSMSSendYN = true;                    //발행시 문자발송기능 사용시 활용

            taxinvoice.invoiceeType = "사업자";
            taxinvoice.invoiceeCorpNum = "1231212312";
            taxinvoice.invoiceeCorpName = "공급받는자 상호";
            taxinvoice.invoiceeMgtKey = txtMgtKey.Text;            //문서관리번호 1~24자리까지 공급받는자 사업자번호별 중복없는 고유번호 할당
            taxinvoice.invoiceeCEOName = "공급받는자 대표자 성명";
            taxinvoice.invoiceeAddr = "공급받는자 주소";
            taxinvoice.invoiceeBizClass = "공급받는자 업종";
            taxinvoice.invoiceeBizType = "공급받는자 업태";
            taxinvoice.invoiceeContactName1 = "공급받는자 담당자명";
            taxinvoice.invoiceeEmail1 = "test@invoicee.com";

            taxinvoice.supplyCostTotal = "100000";                  //필수 공급가액 합계"
            taxinvoice.taxTotal = "10000";                          //필수 세액 합계
            taxinvoice.totalAmount = "110000";                      //필수 합계금액.  공급가액 + 세액

            taxinvoice.modifyCode = null;                           //수정세금계산서 작성시 1~6까지 선택기재.
            taxinvoice.originalTaxinvoiceKey = "";                  //수정세금계산서 작성시 원본세금계산서의 ItemKey기재. ItemKey는 문서확인.
            taxinvoice.serialNum = "123";
            taxinvoice.cash = "";                                   //현금
            taxinvoice.chkBill = "";                                //수표
            taxinvoice.note = "";                                   //어음
            taxinvoice.credit = "";                                 //외상미수금
            taxinvoice.remark1 = "비고1";
            taxinvoice.remark2 = "비고2";
            taxinvoice.remark3 = "비고3";
            taxinvoice.kwon = 1;
            taxinvoice.ho = 1;

            taxinvoice.businessLicenseYN = false;                   //사업자등록증 이미지 첨부시 설정.
            taxinvoice.bankBookYN = false;                          //통장사본 이미지 첨부시 설정.
            taxinvoice.faxreceiveNum = "";                          //발행시 Fax발송기능 사용시 수신번호 기재.
            taxinvoice.faxsendYN = false;                           //발행시 Fax발송시 설정.

            taxinvoice.detailList = new List<TaxinvoiceDetail>();

            TaxinvoiceDetail detail = new TaxinvoiceDetail();

            detail.serialNum = 1;                                   //일련번호
            detail.purchaseDT = "20140319";                         //거래일자
            detail.itemName = "품목명";
            detail.spec = "규격";
            detail.qty = "1";                                       //수량
            detail.unitCost = "100000";                             //단가
            detail.supplyCost = "100000";                           //공급가액
            detail.tax = "10000";                                   //세액
            detail.remark = "품목비고";

            taxinvoice.detailList.Add(detail);

            detail = new TaxinvoiceDetail();

            detail.serialNum = 2;
            detail.itemName = "품목명";

            taxinvoice.detailList.Add(detail);

            try
            {
                Response response = taxinvoiceService.Register(txtCorpNum.Text, taxinvoice, txtUserId.Text);

                MessageBox.Show(response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 역)발행 세금계산서 수정
        private void btnUpdate_Reverse_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            Taxinvoice taxinvoice = new Taxinvoice();

            taxinvoice.writeDate = "20150204";                      //필수, 기재상 작성일자
            taxinvoice.chargeDirection = "정과금";                  //필수, {정과금, 역과금}
            taxinvoice.issueType = "역발행";                        //필수, {정발행, 역발행, 위수탁}
            taxinvoice.purposeType = "영수";                        //필수, {영수, 청구}
            taxinvoice.issueTiming = "직접발행";                    //필수, {직접발행, 승인시자동발행}
            taxinvoice.taxType = "과세";                            //필수, {과세, 영세, 면세}


            taxinvoice.invoicerCorpNum = "8888888888";
            taxinvoice.invoicerTaxRegID = "";                       //종사업자 식별번호. 필요시 기재. 형식은 숫자 4자리.
            taxinvoice.invoicerCorpName = "공급자 상호 수정";
            taxinvoice.invoicerMgtKey = "";                         //공급자 발행까지 API로 발행하고자 할경우 정발행과 동일한 형태로 추가 기재.
            taxinvoice.invoicerCEOName = "공급자 대표자 성명";
            taxinvoice.invoicerAddr = "공급자 주소";
            taxinvoice.invoicerBizClass = "공급자 업종";
            taxinvoice.invoicerBizType = "공급자 업태,업태2";
            taxinvoice.invoicerContactName = "공급자 담당자명";
            taxinvoice.invoicerEmail = "test@test.com";
            taxinvoice.invoicerTEL = "070-7070-0707";
            taxinvoice.invoicerHP = "010-000-2222";
            taxinvoice.invoicerSMSSendYN = true;                    //발행시 문자발송기능 사용시 활용

            taxinvoice.invoiceeType = "사업자";
            taxinvoice.invoiceeCorpNum = "1231212312";
            taxinvoice.invoiceeCorpName = "공급받는자 상호";
            taxinvoice.invoiceeMgtKey = txtMgtKey.Text;             //문서관리번호 1~24자리까지 공급받는자 사업자번호별 중복없는 고유번호 할당
            taxinvoice.invoiceeCEOName = "공급받는자 대표자 성명";
            taxinvoice.invoiceeAddr = "공급받는자 주소";
            taxinvoice.invoiceeBizClass = "공급받는자 업종";
            taxinvoice.invoiceeBizType = "공급받는자 업태";
            taxinvoice.invoiceeContactName1 = "공급받는자 담당자명";
            taxinvoice.invoiceeEmail1 = "test@invoicee.com";

            taxinvoice.supplyCostTotal = "100000";                  //필수 공급가액 합계"
            taxinvoice.taxTotal = "10000";                          //필수 세액 합계
            taxinvoice.totalAmount = "110000";                      //필수 합계금액.  공급가액 + 세액

            taxinvoice.modifyCode = null;                           //수정세금계산서 작성시 1~6까지 선택기재.
            taxinvoice.originalTaxinvoiceKey = "";                  //수정세금계산서 작성시 원본세금계산서의 ItemKey기재. ItemKey는 문서확인.
            taxinvoice.serialNum = "123";
            taxinvoice.cash = "";                                   //현금
            taxinvoice.chkBill = "";                                //수표
            taxinvoice.note = "";                                   //어음
            taxinvoice.credit = "";                                 //외상미수금
            taxinvoice.remark1 = "비고1";
            taxinvoice.remark2 = "비고2";
            taxinvoice.remark3 = "비고3";
            taxinvoice.kwon = 1;
            taxinvoice.ho = 1;

            taxinvoice.businessLicenseYN = false;                   //사업자등록증 이미지 첨부시 설정.
            taxinvoice.bankBookYN = false;                          //통장사본 이미지 첨부시 설정.
            taxinvoice.faxreceiveNum = "";                          //발행시 Fax발송기능 사용시 수신번호 기재.
            taxinvoice.faxsendYN = false;                           //발행시 Fax발송시 설정.

            taxinvoice.detailList = new List<TaxinvoiceDetail>();

            TaxinvoiceDetail detail = new TaxinvoiceDetail();

            detail.serialNum = 1;                                   //일련번호
            detail.purchaseDT = "20140319";                         //거래일자
            detail.itemName = "품목명";
            detail.spec = "규격";
            detail.qty = "1";                                       //수량
            detail.unitCost = "100000";                             //단가
            detail.supplyCost = "100000";                           //공급가액
            detail.tax = "10000";                                   //세액
            detail.remark = "품목비고";

            taxinvoice.detailList.Add(detail);

            detail = new TaxinvoiceDetail();

            detail.serialNum = 2;
            detail.itemName = "품목명";

            taxinvoice.detailList.Add(detail);

            try
            {
                Response response = taxinvoiceService.Update(txtCorpNum.Text, KeyType, txtMgtKey.Text, taxinvoice, txtUserId.Text);

                MessageBox.Show(response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 첨부파일 추가
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);


            if (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string strFileName = fileDialog.FileName;


                try
                {
                    Response response = taxinvoiceService.AttachFile(txtCorpNum.Text, KeyType, txtMgtKey.Text, strFileName, txtUserId.Text);

                    MessageBox.Show(response.message);
                }
                catch (PopbillException ex)
                {
                    MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
                }

            }
        }

        // 첨부파일목록
        private void gtnGetFiles_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                List<AttachedFile> fileList = taxinvoiceService.GetFiles(txtCorpNum.Text, KeyType, txtMgtKey.Text);


                string tmp = "일련번호 | 표시명 | 파일아이디 | 등록일자" + CRLF;

                foreach (AttachedFile file in fileList)
                {
                    tmp += file.serialNum.ToString() + " | " + file.displayName + " | " + file.attachedFile + " | " + file.regDT + CRLF;

                }
                MessageBox.Show(tmp);



            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        // 첨부파일 삭제
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            try
            {
                Response response = taxinvoiceService.DeleteFile(txtCorpNum.Text, KeyType, txtMgtKey.Text, txtFileID.Text, txtUserId.Text);

                MessageBox.Show(response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }

        }

        // 세금계산서 수정
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MgtKeyType KeyType = (MgtKeyType)Enum.Parse(typeof(MgtKeyType), cboMgtKeyType.Text);

            Taxinvoice taxinvoice = new Taxinvoice();

            taxinvoice.writeDate = "20150204";                      //필수, 기재상 작성일자
            taxinvoice.chargeDirection = "정과금";                  //필수, {정과금, 역과금}
            taxinvoice.issueType = "정발행";                        //필수, {정발행, 역발행, 위수탁}
            taxinvoice.purposeType = "영수";                        //필수, {영수, 청구}
            taxinvoice.issueTiming = "직접발행";                    //필수, {직접발행, 승인시자동발행}
            taxinvoice.taxType = "과세";                            //필수, {과세, 영세, 면세}


            taxinvoice.invoicerCorpNum = "1234567890";
            taxinvoice.invoicerTaxRegID = "";                       //종사업자 식별번호. 필요시 기재. 형식은 숫자 4자리.
            taxinvoice.invoicerCorpName = "공급자 상호 수정";
            taxinvoice.invoicerMgtKey = txtMgtKey.Text;             //문서관리번호 1~24자리까지 공급자사업자번호별 중복없는 고유번호 할당
            taxinvoice.invoicerCEOName = "공급자 대표자 성명";
            taxinvoice.invoicerAddr = "공급자 주소";
            taxinvoice.invoicerBizClass = "공급자 업종";
            taxinvoice.invoicerBizType = "공급자 업태,업태2";
            taxinvoice.invoicerContactName = "공급자 담당자명";
            taxinvoice.invoicerEmail = "test@test.com";
            taxinvoice.invoicerTEL = "070-7070-0707";
            taxinvoice.invoicerHP = "010-000-2222";
            taxinvoice.invoicerSMSSendYN = true;                    //발행시 문자발송기능 사용시 활용

            taxinvoice.invoiceeType = "사업자";
            taxinvoice.invoiceeCorpNum = "8888888888";
            taxinvoice.invoiceeCorpName = "공급받는자 상호";
            taxinvoice.invoiceeMgtKey = "";
            taxinvoice.invoiceeCEOName = "공급받는자 대표자 성명";
            taxinvoice.invoiceeAddr = "공급받는자 주소";
            taxinvoice.invoiceeBizClass = "공급받는자 업종";
            taxinvoice.invoiceeBizType = "공급받는자 업태";
            taxinvoice.invoiceeContactName1 = "공급받는자 담당자명";
            taxinvoice.invoiceeEmail1 = "test@invoicee.com";

            taxinvoice.supplyCostTotal = "100000";                  //필수 공급가액 합계"
            taxinvoice.taxTotal = "10000";                          //필수 세액 합계
            taxinvoice.totalAmount = "110000";                      //필수 합계금액.  공급가액 + 세액

            taxinvoice.modifyCode = null;                           //수정세금계산서 작성시 1~6까지 선택기재.
            taxinvoice.originalTaxinvoiceKey = "";                  //수정세금계산서 작성시 원본세금계산서의 ItemKey기재. ItemKey는 문서확인.
            taxinvoice.serialNum = "123";
            taxinvoice.cash = "";                                   //현금
            taxinvoice.chkBill = "";                                //수표
            taxinvoice.note = "";                                   //어음
            taxinvoice.credit = "";                                 //외상미수금
            taxinvoice.remark1 = "비고1";
            taxinvoice.remark2 = "비고2";
            taxinvoice.remark3 = "비고3";
            taxinvoice.kwon = 1;
            taxinvoice.ho = 1;

            taxinvoice.businessLicenseYN = false;                   //사업자등록증 이미지 첨부시 설정.
            taxinvoice.bankBookYN = false;                          //통장사본 이미지 첨부시 설정.
            taxinvoice.faxreceiveNum = "";                          //발행시 Fax발송기능 사용시 수신번호 기재.
            taxinvoice.faxsendYN = false;                           //발행시 Fax발송시 설정.

            taxinvoice.detailList = new List<TaxinvoiceDetail>();

            TaxinvoiceDetail detail = new TaxinvoiceDetail();

            detail.serialNum = 1;                                   //일련번호
            detail.purchaseDT = "20140319";                         //거래일자
            detail.itemName = "품목명";
            detail.spec = "규격";
            detail.qty = "1";                                       //수량
            detail.unitCost = "100000";                             //단가
            detail.supplyCost = "100000";                           //공급가액
            detail.tax = "10000";                                   //세액
            detail.remark = "품목비고";

            taxinvoice.detailList.Add(detail);

            detail = new TaxinvoiceDetail();

            detail.serialNum = 2;
            detail.itemName = "품목명";

            taxinvoice.detailList.Add(detail);

            taxinvoice.addContactList = new List<TaxinvoiceAddContact>();

            TaxinvoiceAddContact addContact = new TaxinvoiceAddContact();

            addContact.email = "test2@invoicee.com";
            addContact.contactName = "추가담당자명";

            taxinvoice.addContactList.Add(addContact);


            try
            {
                Response response = taxinvoiceService.Update(txtCorpNum.Text, KeyType, txtMgtKey.Text, taxinvoice, txtUserId.Text);

                MessageBox.Show(response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }
    }
}
