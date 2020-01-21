using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Popbill.EasyFin.Bank.Example.csharp
{
    public partial class frmExample : Form
    {

        // 링크아이디
        private string LinkID = "TESTER";

        // 비밀키
        private string SecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";

        // 계좌조회 서비스 객체 선언
        private EasyFinBankService easyFinBankService;

        private const string CRLF = "\r\n";


        public frmExample()
        {
            InitializeComponent();

            // 계좌조회 서비스 객체 초기화
            easyFinBankService = new EasyFinBankService(LinkID, SecretKey);

            // 연동환경 설정값, 개발용(true), 상업용(false)
            easyFinBankService.IsTest = true;
        }

        /*
         * 사업자의 파트너 연동회원 가입여부를 확인합니다.
         * - 사업자등록번호는 '-' 제외한 10자리 숫자 문자열입니다.
         * - 링크아이디는 29번라인에 선언되어있는 인증정보(LInkID) 입니다.
         */
        private void btnCheckIsMember_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = easyFinBankService.CheckIsMember(txtCorpNum.Text, LinkID);

                MessageBox.Show(response.code.ToString() + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        /*
         * 연동회원 가입요청을 신청합니다.
         * - 회원가입 전 아이디확인(CheckID API)를 사용하여 아이디 중복여부를 확인할 수 있습니다. 
         */
        private void btnJoinMember_Click(object sender, EventArgs e)
        {
            JoinForm joinInfo = new JoinForm();

            //링크아이디
            joinInfo.LinkID = LinkID;

            //사업자번호 "-" 제외
            joinInfo.CorpNum = "1231212312";

            //대표자명 
            joinInfo.CEOName = "대표자성명";

            //상호
            joinInfo.CorpName = "상호";

            //주소
            joinInfo.Addr = "주소";

            //업태
            joinInfo.BizType = "업태";

            // 종목
            joinInfo.BizClass = "종목";

            // 아이디, 6자이상 20자 미만
            joinInfo.ID = "userid";

            // 비밀번호, 6자이상 20자 미만
            joinInfo.PWD = "pwd_must_be_long_enough";

            // 담당자명
            joinInfo.ContactName = "담당자명";

            // 담당자 연락처
            joinInfo.ContactTEL = "070-4304-2991";

            // 담당자 휴대폰번호
            joinInfo.ContactHP = "010-111-222";

            // 담당자 팩스번호
            joinInfo.ContactFAX = "02-6442-9700";

            // 담당자 메일주소
            joinInfo.ContactEmail = "test@test.com";

            try
            {
                Response response = easyFinBankService.JoinMember(joinInfo);

                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        /*
         * 연동회원 잔여포인트를 확인합니다.
         */
        private void btnGetBalance_Click(object sender, EventArgs e)
        {
            try
            {
                double remainPoint = easyFinBankService.GetBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }


        /*
         * 팝빌 로그인 팝업 URL을 반환합니다.
         * - URL은 보안정책으로 인해 30초의 유효시간을 갖습니다.
         */
        private void btnGetPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            string url = easyFinBankService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "LOGIN");

            MessageBox.Show(url);
        }

        /*
         * 팝빌 포인트충전 팝업 URL을 반환합니다.
         * - 반환된 URL은 보안정책으로 인해 30초의 유효시간을 갖습니다.
         */
        private void btnGetPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            string url = easyFinBankService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CHRG");

            MessageBox.Show(url);
        }

        /*
        * 파트너 잔여포인트를 확인합니다. 
        * - 연동 과금 방식의 경우 연동회원 잔여포인트 조회 (GetBalance API) 기능을 사용하시기 바랍니다.
        */
        private void btnGetPartnerBalance_Click(object sender, EventArgs e)
        {
            try
            {
                double remainPoint = easyFinBankService.GetPartnerBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnRequestJob_Click(object sender, EventArgs e)
        {
            /*
             * 계좌 거래내역 수집을 요청한다
             * - 검색기간은 현재일 기준 90일 이내로만 요청할 수 있다.
             */

            // 은행코드
            String BankCode = "0048";

            // 은행 계좌번호
            String AccountNumber = "131020538645";

            // 시작일자, 표시형식(yyyyMMdd)
            String SDate = "20191023";

            // 종료일자, 표시형식(yyyyMMdd)
            String EDate = "20200120";

            try
            {
                String jobID = easyFinBankService.RequestJob(txtCorpNum.Text, BankCode, AccountNumber, SDate, EDate);

                MessageBox.Show("작업아이디(jobID) : " + jobID, "수집 요청");

                txtJobID.Text = jobID;
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "수집 요청");
            }
        }

        private void btnGetJobState_Click(object sender, EventArgs e)
        {
            /*
             * 계좌조회 수집 상태를 확인한다.
             */
            try
            {
                EasyFinBankJobState jobState = easyFinBankService.GetJobState(txtCorpNum.Text, txtJobID.Text);

                String tmp = "jobID (작업아이디) : " + jobState.jobID + CRLF;
                tmp += "jobState (수집상태) : " + jobState.jobState.ToString() + CRLF;
                tmp += "startDate (시작일자) : " + jobState.startDate + CRLF;
                tmp += "endDate (종료일자) : " + jobState.endDate + CRLF;
                tmp += "errorCode (오류코드) : " + jobState.errorCode.ToString() + CRLF;
                tmp += "errorReason (오류메시지) : " + jobState.errorReason + CRLF;
                tmp += "jobStartDT (작업 시작일시) : " + jobState.jobStartDT + CRLF;
                tmp += "jobEndDT (작업 종료일시) : " + jobState.jobEndDT + CRLF;
                tmp += "regDT (수집 요청일시) : " + jobState.regDT + CRLF;

                MessageBox.Show(tmp, "수집 상태 확인");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "수집 상태 확인");
            }
        }

        private void btnListJobState_Click(object sender, EventArgs e)
        {
            /*
             * 1시간 이내 수집 요청 목록을 반환한다.
             */
            try
            {
                List<EasyFinBankJobState> jobList = easyFinBankService.ListActiveJob(txtCorpNum.Text, txtUserId.Text);

                String tmp = "jobID (작업아이디) | jobState (수집상태) | startDate (시작일자) |";
                tmp += " endDate (종료일자) | errorCode (오류코드) | errorReason (오류메시지) | jobStartDT (수집 시작일시) | jobEndDT (수집 종료일시) |";
                tmp += " regDT (수집 요청일시) " + CRLF;

                for (int i = 0; i < jobList.Count; i++)
                {
                    tmp += jobList[i].jobID + " | ";
                    tmp += jobList[i].jobState.ToString() + " | ";
                    tmp += jobList[i].startDate + " | ";
                    tmp += jobList[i].endDate + " | ";
                    tmp += jobList[i].errorCode.ToString() + " | ";
                    tmp += jobList[i].errorReason + " | ";
                    tmp += jobList[i].jobStartDT + " | ";
                    tmp += jobList[i].jobEndDT + " | ";
                    tmp += jobList[i].regDT;
                    tmp += CRLF;
                }

                if (jobList.Count > 0) txtJobID.Text = jobList[0].jobID;

                MessageBox.Show(tmp, "수집 작업 목록확인");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "수집 요청 목록확인");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*
                         * 계좌 거래내역을 조회한다.
                         */

            // 거래유형 배열
            String[] TradeType = { "I", "O" };

            // 조회 검색어, 입금/출금액, 메모, 적요 like 검색
            String SearchString = "";

            // 페이지번호
            int Page = 1;

            // 페이지당 목록개수, 최대 1000건
            int PerPage = 10;

            // 정렬방향 D-내림차순, A-오름차순
            String Order = "D";

            listBox1.Items.Clear();

            try
            {
                EasyFinBankSearchResult searchInfo = easyFinBankService.Search(txtCorpNum.Text, txtJobID.Text,
                    TradeType, SearchString, Page, PerPage, Order, txtUserId.Text);

                String tmp = "code (응답코드) : " + searchInfo.code.ToString() + CRLF;
                tmp += "message (응답메시지) : " + searchInfo.message + CRLF;
                tmp += "total (총 검색결과 건수) : " + searchInfo.total.ToString() + CRLF;
                tmp += "perPage (페이지당 검색개수) : " + searchInfo.perPage + CRLF;
                tmp += "pageNum (페이지 번호) : " + searchInfo.pageNum + CRLF;
                tmp += "pageCount (페이지 개수) : " + searchInfo.pageCount + CRLF;

                MessageBox.Show(tmp, "수집 결과 조회");

                string rowStr = "tid (거래내역 아이디) | trdate (거래일자) | trserial (거래일련번호) | trdt (거래일시) | accIn (입금액) | accOut (출금액) | balance (잔액) | " + CRLF +
                                "remark1 (비고1) | remark2 (비고2) | remark3 (비고3) | remark4 (비고4) | memo (메모)";

                listBox1.Items.Add(rowStr);

                for (int i = 0; i < searchInfo.list.Count; i++)
                {
                    rowStr = null;
                    rowStr += searchInfo.list[i].tid + " | ";
                    rowStr += searchInfo.list[i].trdate + " | ";
                    rowStr += searchInfo.list[i].trserial.ToString() + " | ";
                    rowStr += searchInfo.list[i].trdt + " | ";
                    rowStr += searchInfo.list[i].accIn + " | ";
                    rowStr += searchInfo.list[i].accOut + " | ";
                    rowStr += searchInfo.list[i].balance + " | ";
                    rowStr += searchInfo.list[i].remark1 + " | ";
                    rowStr += searchInfo.list[i].remark2 + " | ";
                    rowStr += searchInfo.list[i].remark3 + " | ";
                    rowStr += searchInfo.list[i].remark4 + " | ";
                    rowStr += searchInfo.list[i].memo;

                    listBox1.Items.Add(rowStr);
                }
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "수집 결과 조회");
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            /*
             * 거래 내역 요약정보를 조회한다.
             */

            // 거래유형 배열
            String[] TradeType = { "I", "O" };

            // 조회 검색어, 입금/출금액, 메모, 적요 like 검색
            String SearchString = "";

            try
            {
                EasyFinBankSummary searchInfo = easyFinBankService.Summary(txtCorpNum.Text, txtJobID.Text,
                    TradeType, SearchString, txtUserId.Text);

                String tmp = "count (수집결과 건수) : " + searchInfo.count + CRLF;
                tmp += "cntAccIn (입금거래 건수) : " + searchInfo.cntAccIn + CRLF;
                tmp += "cntAccOut (출금거래 건수) : " + searchInfo.cntAccOut + CRLF;
                tmp += "totalAccIn (입금액 합계) : " + searchInfo.totalAccIn + CRLF;
                tmp += "totalAccOut (출금액 합계) : " + searchInfo.totalAccOut + CRLF;

                MessageBox.Show(tmp, "거래내역 요약정보 조회");

            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "거래내역 요약정보 조회");
            }
        }

        private void btnSaveMemo_Click(object sender, EventArgs e)
        {
            /*
             * 계좌 거래내역에 메모를 저장한다.
             */

            // 거래내역 아이디
            String TID = txtTID.Text;

            // 메모
            String Memo = "메모저장-20200121";

            try
            {
                Response response = easyFinBankService.SaveMemo(txtCorpNum.Text, TID, Memo);

                MessageBox.Show("응답코드(code) : " + response.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + response.message, "거래내역 메모저장");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "거래내역 메모저장");
            }
        }

        private void btnGetBankAccountMgtURL_Click(object sender, EventArgs e)
        {
            /*
             * 은행 계좌 관리 팝업 URL을 반환한다.
             */

            try
            {
                String url = easyFinBankService.GetBankAccountMgtURL(txtCorpNum.Text, txtUserId.Text);

                MessageBox.Show(url, "계좌 관리 팝업 URL");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "정액제 서비스 신청 팝업 URL");
            }
        }

        private void btnListBankAccount_Click(object sender, EventArgs e)
        {
            /*
             * 팝빌에 등록된 은행계좌 목록을 반환한다.
             */

            try
            {
                List<EasyFinBankAccount> bankAccountList = easyFinBankService.ListBankAccount(txtCorpNum.Text);

                String tmp = "bankCode (은행코드) | accountNumber (계좌번호) | accountName (계좌별칭) | accountType (계좌유형) | state (정액제 상태) |";
                tmp += " regDT (등록일시) | memo (메모) " + CRLF;

                for (int i = 0; i < bankAccountList.Count; i++)
                {
                    tmp += bankAccountList[i].bankCode + " | ";
                    tmp += bankAccountList[i].accountNumber + " | ";
                    tmp += bankAccountList[i].accountName + " | ";
                    tmp += bankAccountList[i].accountType + " | ";
                    tmp += bankAccountList[i].state.ToString() + " | ";
                    tmp += bankAccountList[i].regDT + " | ";
                    tmp += bankAccountList[i].memo;
                    tmp += CRLF;
                }

                MessageBox.Show(tmp, "계좌 목록 확인");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "계좌 목록 확인");
            }
        }

        private void btnGetFlatRateState_Click(object sender, EventArgs e)
        {

            /*
             * 정액제 서비스 상태를 확인한다
             */

            // 은행코드
            String BankCode = "0048";

            // 은행 계좌번호
            String AccountNumber = "131020538645";

            try
            {
                EasyFinBankFlatRate rateInfo = easyFinBankService.GetFlatRateState(txtCorpNum.Text, BankCode, AccountNumber, txtUserId.Text);

                String tmp = "referenceID (계좌아이디) : " + rateInfo.referenceID + CRLF;
                tmp += "contractDT (정액제 서비스 시작일시) : " + rateInfo.contractDT + CRLF;
                tmp += "useEndDate (정액제 서비스 종료일) : " + rateInfo.useEndDate + CRLF;
                tmp += "baseDate (자동연장 결제일) : " + rateInfo.baseDate.ToString() + CRLF;
                tmp += "state (정액제 서비스 상태) : " + rateInfo.state.ToString() + CRLF;
                tmp += "closeRequestYN (정액제 서비스 해지신청 여부) : " + rateInfo.closeRequestYN.ToString() + CRLF;
                tmp += "useRestrictYN (정액제 서비스 사용제한 여부) : " + rateInfo.useRestrictYN.ToString() + CRLF;
                tmp += "closeOnExpired (정액제 서비스 만료 시 해지 여부) : " + rateInfo.closeOnExpired.ToString() + CRLF;
                tmp += "unPaidYN (미수금 보유 여부) : " + rateInfo.unPaidYN.ToString() + CRLF;

                MessageBox.Show(tmp, "정액제 서비스 상태 확인");

            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "정액제 서비스 상태 확인");
            }
        }

        private void btnGetFlatRatePopUpURL_Click(object sender, EventArgs e)
        {
            /*
             * 정액제 서비스 신청 URL을 반환한다.  
             */

            try
            {
                String url = easyFinBankService.GetFlatRatePopUpURL(txtCorpNum.Text, txtUserId.Text);

                MessageBox.Show(url, "정액제 서비스 신청 팝업 URL");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("응답코드(code) : " + ex.code.ToString() + "\r\n" +
                                "응답메시지(message) : " + ex.Message, "정액제 서비스 신청 팝업 URL");
            }
        }


    }
}