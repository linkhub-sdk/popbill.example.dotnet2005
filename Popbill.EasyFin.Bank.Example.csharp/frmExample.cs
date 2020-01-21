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

        // ��ũ���̵�
        private string LinkID = "TESTER";

        // ���Ű
        private string SecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";

        // ������ȸ ���� ��ü ����
        private EasyFinBankService easyFinBankService;

        private const string CRLF = "\r\n";


        public frmExample()
        {
            InitializeComponent();

            // ������ȸ ���� ��ü �ʱ�ȭ
            easyFinBankService = new EasyFinBankService(LinkID, SecretKey);

            // ����ȯ�� ������, ���߿�(true), �����(false)
            easyFinBankService.IsTest = true;
        }

        /*
         * ������� ��Ʈ�� ����ȸ�� ���Կ��θ� Ȯ���մϴ�.
         * - ����ڵ�Ϲ�ȣ�� '-' ������ 10�ڸ� ���� ���ڿ��Դϴ�.
         * - ��ũ���̵�� 29�����ο� ����Ǿ��ִ� ��������(LInkID) �Դϴ�.
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
         * ����ȸ�� ���Կ�û�� ��û�մϴ�.
         * - ȸ������ �� ���̵�Ȯ��(CheckID API)�� ����Ͽ� ���̵� �ߺ����θ� Ȯ���� �� �ֽ��ϴ�. 
         */
        private void btnJoinMember_Click(object sender, EventArgs e)
        {
            JoinForm joinInfo = new JoinForm();

            //��ũ���̵�
            joinInfo.LinkID = LinkID;

            //����ڹ�ȣ "-" ����
            joinInfo.CorpNum = "1231212312";

            //��ǥ�ڸ� 
            joinInfo.CEOName = "��ǥ�ڼ���";

            //��ȣ
            joinInfo.CorpName = "��ȣ";

            //�ּ�
            joinInfo.Addr = "�ּ�";

            //����
            joinInfo.BizType = "����";

            // ����
            joinInfo.BizClass = "����";

            // ���̵�, 6���̻� 20�� �̸�
            joinInfo.ID = "userid";

            // ��й�ȣ, 6���̻� 20�� �̸�
            joinInfo.PWD = "pwd_must_be_long_enough";

            // ����ڸ�
            joinInfo.ContactName = "����ڸ�";

            // ����� ����ó
            joinInfo.ContactTEL = "070-4304-2991";

            // ����� �޴�����ȣ
            joinInfo.ContactHP = "010-111-222";

            // ����� �ѽ���ȣ
            joinInfo.ContactFAX = "02-6442-9700";

            // ����� �����ּ�
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
         * ����ȸ�� �ܿ�����Ʈ�� Ȯ���մϴ�.
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
         * �˺� �α��� �˾� URL�� ��ȯ�մϴ�.
         * - URL�� ������å���� ���� 30���� ��ȿ�ð��� �����ϴ�.
         */
        private void btnGetPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            string url = easyFinBankService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "LOGIN");

            MessageBox.Show(url);
        }

        /*
         * �˺� ����Ʈ���� �˾� URL�� ��ȯ�մϴ�.
         * - ��ȯ�� URL�� ������å���� ���� 30���� ��ȿ�ð��� �����ϴ�.
         */
        private void btnGetPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            string url = easyFinBankService.GetPopbillURL(txtCorpNum.Text, txtUserId.Text, "CHRG");

            MessageBox.Show(url);
        }

        /*
        * ��Ʈ�� �ܿ�����Ʈ�� Ȯ���մϴ�. 
        * - ���� ���� ����� ��� ����ȸ�� �ܿ�����Ʈ ��ȸ (GetBalance API) ����� ����Ͻñ� �ٶ��ϴ�.
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
             * ���� �ŷ����� ������ ��û�Ѵ�
             * - �˻��Ⱓ�� ������ ���� 90�� �̳��θ� ��û�� �� �ִ�.
             */

            // �����ڵ�
            String BankCode = "0048";

            // ���� ���¹�ȣ
            String AccountNumber = "131020538645";

            // ��������, ǥ������(yyyyMMdd)
            String SDate = "20191023";

            // ��������, ǥ������(yyyyMMdd)
            String EDate = "20200120";

            try
            {
                String jobID = easyFinBankService.RequestJob(txtCorpNum.Text, BankCode, AccountNumber, SDate, EDate);

                MessageBox.Show("�۾����̵�(jobID) : " + jobID, "���� ��û");

                txtJobID.Text = jobID;
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "���� ��û");
            }
        }

        private void btnGetJobState_Click(object sender, EventArgs e)
        {
            /*
             * ������ȸ ���� ���¸� Ȯ���Ѵ�.
             */
            try
            {
                EasyFinBankJobState jobState = easyFinBankService.GetJobState(txtCorpNum.Text, txtJobID.Text);

                String tmp = "jobID (�۾����̵�) : " + jobState.jobID + CRLF;
                tmp += "jobState (��������) : " + jobState.jobState.ToString() + CRLF;
                tmp += "startDate (��������) : " + jobState.startDate + CRLF;
                tmp += "endDate (��������) : " + jobState.endDate + CRLF;
                tmp += "errorCode (�����ڵ�) : " + jobState.errorCode.ToString() + CRLF;
                tmp += "errorReason (�����޽���) : " + jobState.errorReason + CRLF;
                tmp += "jobStartDT (�۾� �����Ͻ�) : " + jobState.jobStartDT + CRLF;
                tmp += "jobEndDT (�۾� �����Ͻ�) : " + jobState.jobEndDT + CRLF;
                tmp += "regDT (���� ��û�Ͻ�) : " + jobState.regDT + CRLF;

                MessageBox.Show(tmp, "���� ���� Ȯ��");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "���� ���� Ȯ��");
            }
        }

        private void btnListJobState_Click(object sender, EventArgs e)
        {
            /*
             * 1�ð� �̳� ���� ��û ����� ��ȯ�Ѵ�.
             */
            try
            {
                List<EasyFinBankJobState> jobList = easyFinBankService.ListActiveJob(txtCorpNum.Text, txtUserId.Text);

                String tmp = "jobID (�۾����̵�) | jobState (��������) | startDate (��������) |";
                tmp += " endDate (��������) | errorCode (�����ڵ�) | errorReason (�����޽���) | jobStartDT (���� �����Ͻ�) | jobEndDT (���� �����Ͻ�) |";
                tmp += " regDT (���� ��û�Ͻ�) " + CRLF;

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

                MessageBox.Show(tmp, "���� �۾� ���Ȯ��");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "���� ��û ���Ȯ��");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*
                         * ���� �ŷ������� ��ȸ�Ѵ�.
                         */

            // �ŷ����� �迭
            String[] TradeType = { "I", "O" };

            // ��ȸ �˻���, �Ա�/��ݾ�, �޸�, ���� like �˻�
            String SearchString = "";

            // ��������ȣ
            int Page = 1;

            // �������� ��ϰ���, �ִ� 1000��
            int PerPage = 10;

            // ���Ĺ��� D-��������, A-��������
            String Order = "D";

            listBox1.Items.Clear();

            try
            {
                EasyFinBankSearchResult searchInfo = easyFinBankService.Search(txtCorpNum.Text, txtJobID.Text,
                    TradeType, SearchString, Page, PerPage, Order, txtUserId.Text);

                String tmp = "code (�����ڵ�) : " + searchInfo.code.ToString() + CRLF;
                tmp += "message (����޽���) : " + searchInfo.message + CRLF;
                tmp += "total (�� �˻���� �Ǽ�) : " + searchInfo.total.ToString() + CRLF;
                tmp += "perPage (�������� �˻�����) : " + searchInfo.perPage + CRLF;
                tmp += "pageNum (������ ��ȣ) : " + searchInfo.pageNum + CRLF;
                tmp += "pageCount (������ ����) : " + searchInfo.pageCount + CRLF;

                MessageBox.Show(tmp, "���� ��� ��ȸ");

                string rowStr = "tid (�ŷ����� ���̵�) | trdate (�ŷ�����) | trserial (�ŷ��Ϸù�ȣ) | trdt (�ŷ��Ͻ�) | accIn (�Աݾ�) | accOut (��ݾ�) | balance (�ܾ�) | " + CRLF +
                                "remark1 (���1) | remark2 (���2) | remark3 (���3) | remark4 (���4) | memo (�޸�)";

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
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "���� ��� ��ȸ");
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            /*
             * �ŷ� ���� ��������� ��ȸ�Ѵ�.
             */

            // �ŷ����� �迭
            String[] TradeType = { "I", "O" };

            // ��ȸ �˻���, �Ա�/��ݾ�, �޸�, ���� like �˻�
            String SearchString = "";

            try
            {
                EasyFinBankSummary searchInfo = easyFinBankService.Summary(txtCorpNum.Text, txtJobID.Text,
                    TradeType, SearchString, txtUserId.Text);

                String tmp = "count (������� �Ǽ�) : " + searchInfo.count + CRLF;
                tmp += "cntAccIn (�Աݰŷ� �Ǽ�) : " + searchInfo.cntAccIn + CRLF;
                tmp += "cntAccOut (��ݰŷ� �Ǽ�) : " + searchInfo.cntAccOut + CRLF;
                tmp += "totalAccIn (�Աݾ� �հ�) : " + searchInfo.totalAccIn + CRLF;
                tmp += "totalAccOut (��ݾ� �հ�) : " + searchInfo.totalAccOut + CRLF;

                MessageBox.Show(tmp, "�ŷ����� ������� ��ȸ");

            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "�ŷ����� ������� ��ȸ");
            }
        }

        private void btnSaveMemo_Click(object sender, EventArgs e)
        {
            /*
             * ���� �ŷ������� �޸� �����Ѵ�.
             */

            // �ŷ����� ���̵�
            String TID = txtTID.Text;

            // �޸�
            String Memo = "�޸�����-20200121";

            try
            {
                Response response = easyFinBankService.SaveMemo(txtCorpNum.Text, TID, Memo);

                MessageBox.Show("�����ڵ�(code) : " + response.code.ToString() + "\r\n" +
                                "����޽���(message) : " + response.message, "�ŷ����� �޸�����");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "�ŷ����� �޸�����");
            }
        }

        private void btnGetBankAccountMgtURL_Click(object sender, EventArgs e)
        {
            /*
             * ���� ���� ���� �˾� URL�� ��ȯ�Ѵ�.
             */

            try
            {
                String url = easyFinBankService.GetBankAccountMgtURL(txtCorpNum.Text, txtUserId.Text);

                MessageBox.Show(url, "���� ���� �˾� URL");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "������ ���� ��û �˾� URL");
            }
        }

        private void btnListBankAccount_Click(object sender, EventArgs e)
        {
            /*
             * �˺��� ��ϵ� ������� ����� ��ȯ�Ѵ�.
             */

            try
            {
                List<EasyFinBankAccount> bankAccountList = easyFinBankService.ListBankAccount(txtCorpNum.Text);

                String tmp = "bankCode (�����ڵ�) | accountNumber (���¹�ȣ) | accountName (���º�Ī) | accountType (��������) | state (������ ����) |";
                tmp += " regDT (����Ͻ�) | memo (�޸�) " + CRLF;

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

                MessageBox.Show(tmp, "���� ��� Ȯ��");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "���� ��� Ȯ��");
            }
        }

        private void btnGetFlatRateState_Click(object sender, EventArgs e)
        {

            /*
             * ������ ���� ���¸� Ȯ���Ѵ�
             */

            // �����ڵ�
            String BankCode = "0048";

            // ���� ���¹�ȣ
            String AccountNumber = "131020538645";

            try
            {
                EasyFinBankFlatRate rateInfo = easyFinBankService.GetFlatRateState(txtCorpNum.Text, BankCode, AccountNumber, txtUserId.Text);

                String tmp = "referenceID (���¾��̵�) : " + rateInfo.referenceID + CRLF;
                tmp += "contractDT (������ ���� �����Ͻ�) : " + rateInfo.contractDT + CRLF;
                tmp += "useEndDate (������ ���� ������) : " + rateInfo.useEndDate + CRLF;
                tmp += "baseDate (�ڵ����� ������) : " + rateInfo.baseDate.ToString() + CRLF;
                tmp += "state (������ ���� ����) : " + rateInfo.state.ToString() + CRLF;
                tmp += "closeRequestYN (������ ���� ������û ����) : " + rateInfo.closeRequestYN.ToString() + CRLF;
                tmp += "useRestrictYN (������ ���� ������� ����) : " + rateInfo.useRestrictYN.ToString() + CRLF;
                tmp += "closeOnExpired (������ ���� ���� �� ���� ����) : " + rateInfo.closeOnExpired.ToString() + CRLF;
                tmp += "unPaidYN (�̼��� ���� ����) : " + rateInfo.unPaidYN.ToString() + CRLF;

                MessageBox.Show(tmp, "������ ���� ���� Ȯ��");

            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "������ ���� ���� Ȯ��");
            }
        }

        private void btnGetFlatRatePopUpURL_Click(object sender, EventArgs e)
        {
            /*
             * ������ ���� ��û URL�� ��ȯ�Ѵ�.  
             */

            try
            {
                String url = easyFinBankService.GetFlatRatePopUpURL(txtCorpNum.Text, txtUserId.Text);

                MessageBox.Show(url, "������ ���� ��û �˾� URL");
            }
            catch (PopbillException ex)
            {
                MessageBox.Show("�����ڵ�(code) : " + ex.code.ToString() + "\r\n" +
                                "����޽���(message) : " + ex.Message, "������ ���� ��û �˾� URL");
            }
        }


    }
}