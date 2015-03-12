using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Data;



namespace Popbill.Statement.Example.csharp
{
    public partial class frmExample : Form
    {
        //��ũ���̵�
        private string LinkID = "TESTER";

        //���Ű
        private string Secretkey = "kf1YBAzWFzu2SAJH/nkSCbAm8SuPmZuvYmDnRY23EK8=";

        private StatementService statementService;

        private const string CRLF = "\r\n";

        public frmExample()
        {
            InitializeComponent();

            statementService = new StatementService(LinkID, Secretkey);

            //�׽�Ʈ�� �Ϸ����� �Ʒ� ������ false�� �����ϰų�, �Ʒ����� �����Ͽ� ����� ȯ������ ��ȯ
            statementService.IsTest = true;
        }
        private int selectedItemCode()
        {
            int selectedItemCode = 121;
            if (cboItemCode.Text == "�ŷ�����") selectedItemCode = 121;
            if (cboItemCode.Text == "û����") selectedItemCode = 122;
            if (cboItemCode.Text == "������") selectedItemCode = 123;
            if (cboItemCode.Text == "���ּ�") selectedItemCode = 124;
            if (cboItemCode.Text == "�Ա�ǥ") selectedItemCode = 125;
            if (cboItemCode.Text == "������") selectedItemCode = 126;

            return selectedItemCode;
        }

        private void btnCheckIsMember_Click(object sender, EventArgs e)
        {
            try
            {

                //CheckIsMember(����ڹ�ȣ, ��ũ���̵�)
                Response response = statementService.CheckIsMember(txtCorpNum.Text, LinkID);

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
            joinInfo.CorpNum = "1234567890";          //����ڹ�ȣ "-" ����
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
                Response response = statementService.JoinMember(joinInfo);

                MessageBox.Show(response.message);

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
                double remainPoint = statementService.GetBalance(txtCorpNum.Text);

                MessageBox.Show("�ܿ�����Ʈ : " + remainPoint.ToString());

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);

            }
        }

        private void btnUnitCost_Click(object sender, EventArgs e)
        {
            try
            {
                float unitCost = statementService.GetUnitCost(txtCorpNum.Text, selectedItemCode());

                MessageBox.Show(cboItemCode.Text + " ����ܰ� : " + unitCost.ToString());
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
                double remainPoint = statementService.GetPartnerBalance(txtCorpNum.Text);

                MessageBox.Show("��Ʈ�� �ܿ�����Ʈ : " + remainPoint.ToString());

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
                string url = statementService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "LOGIN");

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
                string url = statementService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "CHRG");

                MessageBox.Show(url);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnCheckMgtKeyInUse_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {


                bool InUse = statementService.CheckMgtKeyInuse(txtCorpNum.Text, itemCode, txtMgtKey.Text);

                MessageBox.Show(InUse ? "�����" : "�̻����");

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Statement statement = new Statement();

            statement.writeDate = "20150312";             //�ʼ�, ����� �ۼ����� (yyyyMMdd)
            statement.purposeType = "����";               //�ʼ�, {����, û��}
            statement.taxType = "����";                   //�ʼ�, {����, ����, �鼼}
            statement.formCode = txtFormCode.Text;        //�������ڵ�, �⺻���� ����('')���� ó���ϸ� �⺻������� ó��.

            statement.itemCode = selectedItemCode();      //�����ڵ�

            statement.mgtKey = txtMgtKey.Text;            //����������ȣ

            statement.senderCorpNum = txtCorpNum.Text;
            statement.senderTaxRegID = "";                //������� �ĺ���ȣ. �ʿ�� ����. ������ ���� 4�ڸ�.
            statement.senderCorpName = "������ ��ȣ";
            statement.senderCEOName = "������ ��ǥ�� ����";
            statement.senderAddr = "������ �ּ�";
            statement.senderBizClass = "������ ����";
            statement.senderBizType = "������ ����,����2";
            statement.senderContactName = "������ ����ڸ�";
            statement.senderEmail = "test@test.com";
            statement.senderTEL = "070-7070-0707";
            statement.senderHP = "010-000-2222";
            statement.receiverCorpNum = "8888888888";
            statement.receiverCorpName = "���޹޴��� ��ȣ";
            statement.receiverCEOName = "���޹޴��� ��ǥ�� ����";
            statement.receiverAddr = "���޹޴��� �ּ�";
            statement.receiverBizClass = "���޹޴��� ����";
            statement.receiverBizType = "���޹޴��� ����";
            statement.receiverContactName = "���޹޴��� ����ڸ�";
            statement.receiverEmail = "test@receiver.com";

            statement.supplyCostTotal = "200000";         //�ʼ� ���ް��� �հ�
            statement.taxTotal = "20000";                 //�ʼ� ���� �հ�
            statement.totalAmount = "220000";             //�ʼ� �հ�ݾ�.  ���ް��� + ����

            statement.serialNum = "123";                 //����� �Ϸù�ȣ �׸�
            statement.remark1 = "���1";
            statement.remark2 = "���2";
            statement.remark3 = "���3";

            statement.businessLicenseYN = false; //����ڵ���� �̹��� ÷�ν� ����.
            statement.bankBookYN = false;         //����纻 �̹��� ÷�ν� ����.

            statement.detailList = new List<StatementDetail>();

            StatementDetail detail = new StatementDetail();

            detail.serialNum = 1;                                   //�Ϸù�ȣ, 1~99���� ��������
            detail.purchaseDT = "20150309";                         //�ŷ�����
            detail.itemName = "ǰ���";
            detail.spec = "�԰�";
            detail.qty = "1";                                       //����
            detail.unitCost = "100000";                             //�ܰ�
            detail.supplyCost = "100000";                           //���ް���
            detail.tax = "10000";                                   //����
            detail.remark = "ǰ����";
            detail.spare1 = "spare1";
            detail.spare1 = "spare2";
            detail.spare1 = "spare3";
            detail.spare1 = "spare4";
            detail.spare1 = "spare5";

            statement.detailList.Add(detail);

            detail = new StatementDetail();

            detail.serialNum = 2;                                   //�Ϸù�ȣ, 1~99���� ��������
            detail.purchaseDT = "20150309";                         //�ŷ�����
            detail.itemName = "ǰ���";
            detail.spec = "�԰�";
            detail.qty = "1";                                       //����
            detail.unitCost = "100000";                             //�ܰ�
            detail.supplyCost = "100000";                           //���ް���
            detail.tax = "10000";                                   //����
            detail.remark = "ǰ����";
            detail.spare1 = "spare1";
            detail.spare1 = "spare2";
            detail.spare1 = "spare3";
            detail.spare1 = "spare4";
            detail.spare1 = "spare5";

            statement.detailList.Add(detail);

            // �߰��Ӽ��׸�, �ڼ��� ������ "���ڸ��� API ���� �Ŵ��� > 5.2 �⺻��� �߰��Ӽ� ���̺� " ����
            statement.propertyBag = new Dictionary<string, string>();
            statement.propertyBag.Add("Balance", "15000");
            statement.propertyBag.Add("Deposit", "5000");
            statement.propertyBag.Add("CBalance", "20000");



            try
            {
                Response response = statementService.Register(txtCorpNum.Text, statement, txtUserID.Text);

                MessageBox.Show(response.code + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Statement statement = new Statement();

            statement.writeDate = "20150312";             //�ʼ�, ����� �ۼ����� (yyyyMMdd)
            statement.purposeType = "����";               //�ʼ�, {����, û��}
            statement.taxType = "����";                   //�ʼ�, {����, ����, �鼼}
            statement.formCode = txtFormCode.Text;        //�������ڵ�, �⺻���� ����('')���� ó���ϸ� �⺻������� ó��.

            statement.itemCode = selectedItemCode();      //�����ڵ�

            statement.mgtKey = txtMgtKey.Text;            //����������ȣ

            statement.senderCorpNum = txtCorpNum.Text;
            statement.senderTaxRegID = "";                //������� �ĺ���ȣ. �ʿ�� ����. ������ ���� 4�ڸ�.
            statement.senderCorpName = "������ ��ȣ_����";
            statement.senderCEOName = "������ ��ǥ�� ����_����";
            statement.senderAddr = "������ �ּ�";
            statement.senderBizClass = "������ ����";
            statement.senderBizType = "������ ����,����2";
            statement.senderContactName = "������ ����ڸ�";
            statement.senderEmail = "test@test.com";
            statement.senderTEL = "070-7070-0707";
            statement.senderHP = "010-000-2222";
            statement.receiverCorpNum = "8888888888";
            statement.receiverCorpName = "���޹޴��� ��ȣ";
            statement.receiverCEOName = "���޹޴��� ��ǥ�� ����";
            statement.receiverAddr = "���޹޴��� �ּ�";
            statement.receiverBizClass = "���޹޴��� ����";
            statement.receiverBizType = "���޹޴��� ����";
            statement.receiverContactName = "���޹޴��� ����ڸ�";
            statement.receiverEmail = "test@receiver.com";

            statement.supplyCostTotal = "200000";         //�ʼ� ���ް��� �հ�
            statement.taxTotal = "20000";                 //�ʼ� ���� �հ�
            statement.totalAmount = "220000";             //�ʼ� �հ�ݾ�.  ���ް��� + ����

            statement.serialNum = "123";                 //����� �Ϸù�ȣ �׸�
            statement.remark1 = "���1";
            statement.remark2 = "���2";
            statement.remark3 = "���3";

            statement.businessLicenseYN = false; //����ڵ���� �̹��� ÷�ν� ����.
            statement.bankBookYN = false;         //����纻 �̹��� ÷�ν� ����.

            statement.detailList = new List<StatementDetail>();

            StatementDetail detail = new StatementDetail();

            detail.serialNum = 1;                                   //�Ϸù�ȣ, 1~99���� ��������
            detail.purchaseDT = "20150309";                         //�ŷ�����
            detail.itemName = "ǰ���";
            detail.spec = "�԰�";
            detail.qty = "1";                                       //����
            detail.unitCost = "100000";                             //�ܰ�
            detail.supplyCost = "100000";                           //���ް���
            detail.tax = "10000";                                   //����
            detail.remark = "ǰ����";
            detail.spare1 = "spare1";
            detail.spare1 = "spare2";
            detail.spare1 = "spare3";
            detail.spare1 = "spare4";
            detail.spare1 = "spare5";

            statement.detailList.Add(detail);

            detail = new StatementDetail();

            detail.serialNum = 2;                                   //�Ϸù�ȣ, 1~99���� ��������
            detail.purchaseDT = "20150309";                         //�ŷ�����
            detail.itemName = "ǰ���";
            detail.spec = "�԰�";
            detail.qty = "1";                                       //����
            detail.unitCost = "100000";                             //�ܰ�
            detail.supplyCost = "100000";                           //���ް���
            detail.tax = "10000";                                   //����
            detail.remark = "ǰ����";
            detail.spare1 = "spare1";
            detail.spare1 = "spare2";
            detail.spare1 = "spare3";
            detail.spare1 = "spare4";
            detail.spare1 = "spare5";

            statement.detailList.Add(detail);
            statement.propertyBag = new Dictionary<string, string>();

            statement.propertyBag.Add("Balance", "15000");

            try
            {
                Response response = statementService.Update(txtCorpNum.Text, selectedItemCode(), txtMgtKey.Text, statement, txtUserID.Text);

                MessageBox.Show(response.code + " | " + response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                Response response = statementService.Issue(txtCorpNum.Text, itemCode, txtMgtKey.Text, "����޸�", txtUserID.Text);

                MessageBox.Show(response.code + " | " + response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                Response response = statementService.CancelIssue(txtCorpNum.Text, itemCode, txtMgtKey.Text, "������� �޸�", txtUserID.Text);

                MessageBox.Show(response.code + " | " + response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                Response response = statementService.Delete(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text);

                MessageBox.Show(response.code + " | " + response.message);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();


            if (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string strFileName = fileDialog.FileName;


                try
                {
                    Response response = statementService.AttachFile(txtCorpNum.Text, itemCode, txtMgtKey.Text, strFileName, txtUserID.Text);

                    MessageBox.Show(response.code + " | " + response.message);
                }
                catch (PopbillException ex)
                {
                    MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
                }

            }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                List<AttachedFile> fileList = statementService.GetFiles(txtCorpNum.Text, itemCode, txtMgtKey.Text);


                string tmp = "�Ϸù�ȣ | ǥ�ø� | ���Ͼ��̵� | �������" + CRLF;

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

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                Response response = statementService.DeleteFile(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtFileID.Text, txtUserID.Text);

                MessageBox.Show(response.code + " | " + response.message);


            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                StatementInfo statementInfo = statementService.GetInfo(txtCorpNum.Text, itemCode, txtMgtKey.Text);

                string tmp = null;

                tmp += "itemCode : " + statementInfo.itemCode.ToString() + CRLF;
                tmp += "itemKey : " + statementInfo.itemKey + CRLF;
                tmp += "invoiceNum : " + statementInfo.invoiceNum + CRLF;
                tmp += "mgtKey : " + statementInfo.mgtKey + CRLF;
                tmp += "stateCode : " + statementInfo.stateCode.ToString() + CRLF;
                tmp += "taxType : " + statementInfo.taxType + CRLF;
                tmp += "purposeType : " + statementInfo.purposeType + CRLF;
                tmp += "writeDate : " + statementInfo.writeDate + CRLF;
                tmp += "senderCorpName : " + statementInfo.senderCorpName + CRLF;
                tmp += "senderCorpNum : " + statementInfo.senderCorpNum + CRLF;
                tmp += "receiverCorpName : " + statementInfo.receiverCorpName + CRLF;
                tmp += "receiverCorpNum : " + statementInfo.receiverCorpNum + CRLF;
                tmp += "supplyCostTotal : " + statementInfo.supplyCostTotal + CRLF;
                tmp += "taxTotal : " + statementInfo.taxTotal + CRLF;
                tmp += "issueDT : " + statementInfo.issueDT + CRLF;
                tmp += "stateDT : " + statementInfo.stateDT + CRLF;
                tmp += "openYN : " + statementInfo.openYN.ToString() + CRLF;
                tmp += "openDT : " + statementInfo.openDT + CRLF;
                tmp += "stateMemo : " + statementInfo.stateMemo + CRLF;
                tmp += "regDT : " + statementInfo.regDT + CRLF;

                MessageBox.Show(tmp);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetDetailInfo_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                Statement statement = statementService.GetDetailInfo(txtCorpNum.Text, itemCode, txtMgtKey.Text);

                string tmp = null;

                tmp += "itemCode : " + statement.itemCode.ToString() + CRLF;
                tmp += "invoiceNum : " + statement.invoiceNum + CRLF;
                tmp += "formCode : " + statement.formCode + CRLF;
                tmp += "writeDate : " + statement.writeDate + CRLF;
                tmp += "taxType : " + statement.taxType + CRLF + CRLF;


                tmp += "senderCorpNum : " + statement.senderCorpNum + CRLF;
                tmp += "senderTaxRegID : " + statement.senderTaxRegID + CRLF;
                tmp += "senderCorpName : " + statement.senderCorpName + CRLF;
                tmp += "senderCEOName : " + statement.senderCEOName + CRLF;
                tmp += "senderAddr : " + statement.senderAddr + CRLF;
                tmp += "senderBizClass : " + statement.senderBizClass + CRLF;
                tmp += "senderBizType : " + statement.senderBizType + CRLF;
                tmp += "senderContactName : " + statement.senderContactName + CRLF;
                tmp += "senderDeptName : " + statement.senderDeptName + CRLF;
                tmp += "senderTEL : " + statement.senderTEL + CRLF;
                tmp += "senderHP : " + statement.senderHP + CRLF;
                tmp += "senderEmail : " + statement.senderEmail + CRLF;
                tmp += "senderFAX : " + statement.senderFAX + CRLF + CRLF;

                tmp += "receiverCorpNum : " + statement.receiverCorpNum + CRLF;
                tmp += "receiverTaxRegID : " + statement.receiverTaxRegID + CRLF;
                tmp += "receiverCorpName : " + statement.receiverCorpName + CRLF;
                tmp += "receiverCEOName : " + statement.receiverCEOName + CRLF;
                tmp += "receiverAddr : " + statement.receiverAddr + CRLF;
                tmp += "receiverBizClass : " + statement.receiverBizClass + CRLF;
                tmp += "receiverBizType : " + statement.receiverBizType + CRLF;
                tmp += "receiverContactName : " + statement.receiverContactName + CRLF;
                tmp += "receiverDeptName : " + statement.receiverDeptName + CRLF;
                tmp += "receiverTEL : " + statement.receiverTEL + CRLF;
                tmp += "receiverHP : " + statement.receiverHP + CRLF;
                tmp += "receiverEmail : " + statement.receiverEmail + CRLF;
                tmp += "receiverFAX : " + statement.receiverFAX + CRLF + CRLF;

                tmp += "taxTotal : " + statement.taxTotal + CRLF;
                tmp += "supplyCostTotal : " + statement.supplyCostTotal + CRLF;
                tmp += "totalAmount : " + statement.totalAmount + CRLF;
                tmp += "purposeType : " + statement.purposeType + CRLF;
                tmp += "serialNum : " + statement.serialNum + CRLF;
                tmp += "remark1 : " + statement.remark1 + CRLF;
                tmp += "remark2 : " + statement.remark2 + CRLF;
                tmp += "remark3 : " + statement.remark3 + CRLF;
                tmp += "businessLicenseYN : " + statement.businessLicenseYN + CRLF;
                tmp += "bankBookYN : " + statement.bankBookYN + CRLF;
                tmp += "faxsendYN : " + statement.faxsendYN + CRLF;
                tmp += "smssendYN : " + statement.smssendYN + CRLF;
                tmp += "autoacceptYN : " + statement.autoacceptYN + CRLF + CRLF;

                if (!statement.detailList.Equals(null))
                {

                    tmp += "[detailList]" + CRLF;
                    for (int i = 0; i < statement.detailList.Count; i++)
                    {
                        tmp += "serialNum : " + statement.detailList[i].serialNum.ToString() + CRLF;
                        //tmp += "itemName : " + statement.detailList[i].itemName + CRLF;
                        //tmp += "purchaseDT : " + statement.detailList[i].purchaseDT + CRLF;
                        //tmp += "qty : " + statement.detailList[i].qty + CRLF;
                        //tmp += "spec : " + statement.detailList[i].spec + CRLF;
                        //tmp += "supplyCost : " + statement.detailList[i].supplyCost+CRLF;
                        //tmp += "tax : " + statement.detailList[i].tax + CRLF;
                        //tmp += "unit : " + statement.detailList[i].unit + CRLF;
                        //tmp += "unitCost : " + statement.detailList[i].unitCost + CRLF;
                        //tmp += "reamark : " + statement.detailList[i].remark + CRLF + CRLF;
                    }
                    tmp += CRLF;
                }
                if (!statement.propertyBag.Equals(null))
                {
                    tmp += "[propertyBag]" + CRLF;
                    foreach (string key in statement.propertyBag.Keys)
                    {
                        tmp += key + " : " + statement.propertyBag[key] + CRLF;
                    }
                }
                MessageBox.Show(tmp);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetInfos_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            List<string> MgtKeyList = new List<string>();

            //�ִ� 1000��
            MgtKeyList.Add("20150310-01");
            MgtKeyList.Add("20150310-02");


            try
            {
                List<StatementInfo> statementInfoList = statementService.GetInfos(txtCorpNum.Text, itemCode, MgtKeyList);

                string tmp = null;

                for (int i = 0; i < statementInfoList.Count; i++)
                {
                    if (statementInfoList[i].itemKey != null)
                    {

                        tmp += "itemCode : " + statementInfoList[i].itemCode.ToString() + CRLF;
                        tmp += "itemKey : " + statementInfoList[i].itemKey + CRLF;
                        tmp += "invoiceNum : " + statementInfoList[i].invoiceNum + CRLF;
                        tmp += "mgtKey : " + statementInfoList[i].mgtKey + CRLF;
                        tmp += "stateCode : " + statementInfoList[i].stateCode.ToString() + CRLF;
                        tmp += "taxType : " + statementInfoList[i].taxType + CRLF;
                        tmp += "purposeType : " + statementInfoList[i].purposeType + CRLF;
                        tmp += "writeDate : " + statementInfoList[i].writeDate + CRLF;
                        tmp += "senderCorpName : " + statementInfoList[i].senderCorpName + CRLF;
                        tmp += "senderCorpNum : " + statementInfoList[i].senderCorpNum + CRLF;
                        tmp += "receiverCorpName : " + statementInfoList[i].receiverCorpName + CRLF;
                        tmp += "receiverCorpNum : " + statementInfoList[i].receiverCorpNum + CRLF;
                        tmp += "supplyCostTotal : " + statementInfoList[i].supplyCostTotal + CRLF;
                        tmp += "taxTotal : " + statementInfoList[i].taxTotal + CRLF;
                        tmp += "issueDT : " + statementInfoList[i].issueDT + CRLF;
                        tmp += "stateDT : " + statementInfoList[i].stateDT + CRLF;
                        tmp += "openYN : " + statementInfoList[i].openYN.ToString() + CRLF;
                        tmp += "openDT : " + statementInfoList[i].openDT + CRLF;
                        tmp += "stateMemo : " + statementInfoList[i].stateMemo + CRLF;
                        tmp += "regDT : " + statementInfoList[i].regDT + CRLF + CRLF;
                    }
                }

                MessageBox.Show(tmp);
            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetLogs_Click(object sender, EventArgs e)
        {
            int itemcode = selectedItemCode();

            try
            {
                List<StatementLog> logList = statementService.GetLogs(txtCorpNum.Text, itemcode, txtMgtKey.Text);

                string tmp = "";

                foreach (StatementLog log in logList)
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

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            int itemcode = selectedItemCode();
            String ReceiverEmail = "test@test.com";

            try
            {
                Response response = statementService.SendEmail(txtCorpNum.Text, itemcode, txtMgtKey.Text, ReceiverEmail, txtUserID.Text);

                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            int itemcode = selectedItemCode();

            string senderNum = "07075103710";
            string receiverNum = "010111222";
            string msgContents = "dotnet ���ڸ��� �������� �׽�Ʈ";
            try
            {
                Response response = statementService.SendSMS(txtCorpNum.Text, itemcode, txtMgtKey.Text, senderNum, receiverNum, msgContents, txtUserID.Text);
                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnSendFAX_Click(object sender, EventArgs e)
        {
            int itemcode = selectedItemCode();

            string senderNum = "07075103710";
            string receiverNum = "000111222";

            try
            {
                Response response = statementService.SendFAX(txtCorpNum.Text, itemcode, txtMgtKey.Text, senderNum, receiverNum, txtUserID.Text);
                MessageBox.Show(response.message);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetPopUpURL_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                string url = statementService.GetPopUpURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text);
                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetPrintURL_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                string url = statementService.GetPrintURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text);
                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetEPrintURL_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                string url = statementService.GetEPrintURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text);
                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetMassPrintURL_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            List<string> mgtKeyList = new List<string>();

            mgtKeyList.Add("20150311-01");
            mgtKeyList.Add("20150311-02");
            mgtKeyList.Add("20150311-03");


            try
            {
                string url = statementService.GetMassPrintURL(txtCorpNum.Text, itemCode, mgtKeyList, txtUserID.Text);
                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetMailURL_Click(object sender, EventArgs e)
        {
            int itemCode = selectedItemCode();

            try
            {
                string url = statementService.GetMailURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text);
                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetURL_TBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = statementService.GetURL(txtCorpNum.Text, txtUserID.Text, "TBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }

        private void btnGetURL_SBOX_Click(object sender, EventArgs e)
        {
            try
            {
                string url = statementService.GetURL(txtCorpNum.Text, txtUserID.Text, "SBOX");

                MessageBox.Show(url);

            }
            catch (PopbillException ex)
            {
                MessageBox.Show(ex.code.ToString() + " | " + ex.Message);
            }
        }




    }
}