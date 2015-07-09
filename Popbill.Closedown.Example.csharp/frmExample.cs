using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Popbill.Closedown.Example.csharp
{
    public partial class frmExample : Form
    {

        //����ȸ�� ���� �߱޹��� ��ũ���̵�
        private string LinkID = "TESTER";
        //����ȸ�� ���� �߱޹��� ���Ű
        private string SecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";

        private ClosedownService closedownService;

        private const string CRLF = "\r\n";

        public frmExample()
        {
            InitializeComponent();
            //�ʱ�ȭ
            closedownService = new ClosedownService(LinkID, SecretKey);
            //�׽�Ʈ�� �Ϸ����� �Ʒ� ������ false�� �����ϰų�, �Ʒ����� �����Ͽ� ���� ���� ����.
            closedownService.IsTest = true;
        }

        private void btnUnitCost_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = closedownService.GetUnitCost(txtCorpNum.Text);

                MessageBox.Show(unitCost.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnGetBalance_Click(object sender, EventArgs e)
        {

            try
            {
                double remainPoint = closedownService.GetBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnCheckCorpNum_Click(object sender, EventArgs e)
        {
            try
            {
                String tmp;

                CorpState corpState = closedownService.checkCorpNum(txtCorpNum.Text, txtCheckCorpNum.Text);

                tmp = "corpNum : " + corpState.corpNum + CRLF;
                tmp += "state : " + corpState.state + CRLF;
                tmp += "type : " + corpState.type + CRLF;
                tmp += "stateDate(���������) : " + corpState.stateDate + CRLF;
                tmp += "checkDate(����ûȮ������) : " + corpState.checkDate + CRLF + CRLF;

                tmp += "* state (���������) : null-�˼�����, 0-��ϵ��� ���� ����ڹ�ȣ, 1-�����, 2-���, 3-�޾�" + CRLF;
                tmp += "* type (��� ����) : null-�˼�����, 1-�Ϲݰ�����, 2-�鼼������, 3-���̰�����, 4-�񿵸�����, �������" + CRLF;

                MessageBox.Show(tmp);
            }

            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnCheckCorpNums_Click(object sender, EventArgs e)
        {
            String tmp = "";

            List<String> CorpNumList = new List<string>();

            //��ȸ�� ����ڹ�ȣ �迭, �ִ� 1000��
            CorpNumList.Add("1234567890");
            CorpNumList.Add("4352343543");
            CorpNumList.Add("4108600477");

            try
            {

                List<CorpState> corpStateList = closedownService.checkCorpNums(txtCorpNum.Text, CorpNumList);

                tmp += "* state (���������) : null-�˼�����, 0-��ϵ��� ���� ����ڹ�ȣ, 1-�����, 2-���, 3-�޾�" + CRLF;
                tmp += "* type (��� ����) : null-�˼�����, 1-�Ϲݰ�����, 2-�鼼������, 3-���̰�����, 4-�񿵸�����, �������" + CRLF + CRLF;

                for (int i = 0; i < corpStateList.Count; i++)
                {
                    tmp += "corpNum : " + corpStateList[i].corpNum + CRLF;
                    tmp += "state : " + corpStateList[i].state + CRLF;
                    tmp += "type : " + corpStateList[i].type + CRLF;
                    tmp += "stateDate(�����1����) : " + corpStateList[i].stateDate + CRLF;
                    tmp += "checkDate(����ûȮ������) : " + corpStateList[i].checkDate + CRLF + CRLF;
                }

                MessageBox.Show(tmp);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnCheckIsMember_Click(object sender, EventArgs e)
        {
            try
            {
                Response response = closedownService.CheckIsMember(txtCorpNum.Text, LinkID);

                MessageBox.Show(response.code.ToString() + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnJoinMember_Click(object sender, EventArgs e)
        {
            JoinForm joinInfo = new JoinForm();

            joinInfo.LinkID = LinkID;
            joinInfo.CorpNum = "1231212312";          //����ڹ�ȣ "-" ����
            joinInfo.CEOName = "��ǥ�ڼ���";
            joinInfo.CorpName = "��ȣ";
            joinInfo.Addr = "�ּ�";
            joinInfo.ZipCode = "500-100";
            joinInfo.BizType = "����";
            joinInfo.BizClass = "����";
            joinInfo.ID = "userid";                   //6�� �̻� 20�� �̸�
            joinInfo.PWD = "pwd_must_be_long_enough"; //6�� �̻� 20�� �̸�
            joinInfo.ContactName = "����ڸ�";
            joinInfo.ContactTEL = "02-999-9999";
            joinInfo.ContactHP = "010-1234-5678";
            joinInfo.ContactFAX = "02-999-9998";
            joinInfo.ContactEmail = "test@test.com";

            try
            {
                Response response = closedownService.JoinMember(joinInfo);

                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnGetPopbillURL_LOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                string url = closedownService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "LOGIN");

                MessageBox.Show(url);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnGetPopbillURL_CHRG_Click(object sender, EventArgs e)
        {
            try
            {
                string url = closedownService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "CHRG");

                MessageBox.Show(url);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnGetPartnerBalance_Click(object sender, EventArgs e)
        {
            try
            {
                double remainPoint = closedownService.GetPartnerBalance(txtCorpNum.Text);

                MessageBox.Show(remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void txtCheckCorpNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheckCorpNum.PerformClick();
            }
            else
            {
                return;
            }
        }
    }
}