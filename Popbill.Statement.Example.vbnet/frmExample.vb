Imports Popbill
Imports Popbill.Statement
Imports System.ComponentModel

Public Class frmExample

    '��ũ���̵� 
    Private LinkID As String = "TESTER"

    '���Ű, ���⿡ ����
    Private SecretKey As String = "kf1YBAzWFzu2SAJH/nkSCbAm8SuPmZuvYmDnRY23EK8="

    Private statementService As StatementService

    Private Sub frmExample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        statementService = New StatementService(LinkID, SecretKey)

        '����ȯ�� ������
        '����� ��ȯ�� False�� ����
        statementService.IsTest = True

    End Sub

    Private Function selectedItemCode() As Integer
        selectedItemCode = 121

        If cboItemCode.Text = "�ŷ�����" Then selectedItemCode = 121
        If cboItemCode.Text = "û����" Then selectedItemCode = 122
        If cboItemCode.Text = "������" Then selectedItemCode = 123
        If cboItemCode.Text = "���ּ�" Then selectedItemCode = 124
        If cboItemCode.Text = "�Ա�ǥ" Then selectedItemCode = 125
        If cboItemCode.Text = "������" Then selectedItemCode = 126

    End Function

    'ȸ�����Կ��� Ȯ��
    Private Sub btnCheckIsMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckIsMember.Click
        Try
            Dim response As Response = statementService.CheckIsMember(txtCorpNum.Text, LinkID)

            MsgBox(response.code.ToString() + " | " + response.message)

        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    'ȸ������ ��û
    Private Sub btnJoinMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoinMember.Click
        Dim joinInfo As JoinForm = New JoinForm

        joinInfo.LinkID = LinkID
        joinInfo.CorpNum = "1231212312" '����ڹ�ȣ "-" ����
        joinInfo.CEOName = "��ǥ�ڼ���"
        joinInfo.CorpName = "��ȣ"
        joinInfo.Addr = "�ּ�"
        joinInfo.ZipCode = "500-100"
        joinInfo.BizType = "����"
        joinInfo.BizClass = "����"
        joinInfo.ID = "userid"  '6�� �̻� 20�� �̸�
        joinInfo.PWD = "pwd_must_be_long_enough" '6�� �̻� 20�� �̸�
        joinInfo.ContactName = "����ڸ�"
        joinInfo.ContactTEL = "02-999-9999"
        joinInfo.ContactHP = "010-1234-5678"
        joinInfo.ContactFAX = "02-999-9998"
        joinInfo.ContactEmail = "test@test.com"

        Try
            Dim response As Response = statementService.JoinMember(joinInfo)

            MsgBox(response.message)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '�ܿ� ����Ʈ Ȯ��
    Private Sub btnGetBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBalance.Click
        Try
            Dim remainPoint As Double = statementService.GetBalance(txtCorpNum.Text)


            MsgBox(remainPoint)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '����ܰ� Ȯ��
    Private Sub btnUnitCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitCost.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim unitCost As Single = statementService.GetUnitCost(txtCorpNum.Text, itemCode)


            MsgBox(unitCost)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '��Ʈ�� �ܿ�����Ʈ Ȯ��
    Private Sub btnGetPartnerBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPartnerBalance.Click
        Try
            Dim remainPoint As Double = statementService.GetPartnerBalance(txtCorpNum.Text)


            MsgBox(remainPoint)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '�˺� �α��� URL
    Private Sub btnGetPopbillURL_LOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPopbillURL_LOGIN.Click
        Try
            Dim url As String = statementService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "LOGIN")

            MsgBox(url)

        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '�˺� ����Ʈ���� URL
    Private Sub btnGetPopbillURL_CHRG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPopbillURL_CHRG.Click
        Try
            Dim url As String = statementService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "CHRG")

            MsgBox(url)

        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '����������ȣ ��뿩�� 
    Private Sub btnCheckMgtKeyInUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckMgtKeyInUse.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim InUse As Boolean = statementService.CheckMgtKeyInuse(txtCorpNum.Text, itemCode, txtMgtKey.Text)

            MsgBox(IIf(InUse, "�����", "�̻����"))

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try

    End Sub

    '�ӽ�����
    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Dim Statement As New Statement

        Statement.writeDate = "20150312"             '�ʼ�, ����� �ۼ�����
        Statement.purposeType = "����"               '�ʼ�, {����, û��}
        Statement.taxType = "����"                   '�ʼ�, {����, ����, �鼼}
        Statement.formCode = txtFormCode.Text       '�������ڵ�, �����Է½� �⺻���

        Statement.itemCode = selectedItemCode()     '�����ڵ�

        Statement.mgtKey = txtMgtKey.Text       '����������ȣ

        Statement.senderCorpNum = txtCorpNum.Text
        Statement.senderTaxRegID = "" '������� �ĺ���ȣ. �ʿ�� ����. ������ ���� 4�ڸ�.
        Statement.senderCorpName = "������ ��ȣ"
        Statement.senderCEOName = "������"" ��ǥ�� ����"
        Statement.senderAddr = "������ �ּ�"
        Statement.senderBizClass = "������ ����"
        Statement.senderBizType = "������ ����,����2"
        Statement.senderContactName = "������ ����ڸ�"
        Statement.senderEmail = "test@test.com"
        Statement.senderTEL = "070-7070-0707"
        Statement.senderHP = "010-000-2222"

        Statement.receiverCorpNum = "8888888888"
        Statement.receiverCorpName = "���޹޴��� ��ȣ"
        Statement.receiverCEOName = "���޹޴��� ��ǥ�� ����"
        Statement.receiverAddr = "���޹޴��� �ּ�"
        Statement.receiverBizClass = "���޹޴��� ����"
        Statement.receiverBizType = "���޹޴��� ����"
        Statement.receiverContactName = "���޹޴��� ����ڸ�"
        Statement.receiverEmail = "test@receiver.com"

        Statement.supplyCostTotal = "100000"         '�ʼ� ���ް��� �հ�
        Statement.taxTotal = "10000"                 '�ʼ� ���� �հ�
        Statement.totalAmount = "110000"             '�ʼ� �հ�ݾ�.  ���ް��� + ����

        Statement.serialNum = "123"
        Statement.remark1 = "���1"
        Statement.remark2 = "���2"
        Statement.remark3 = "���3"

        Statement.businessLicenseYN = False '����ڵ���� �̹��� ÷�ν� ����.
        Statement.bankBookYN = False         '����纻 �̹��� ÷�ν� ����.
        Statement.faxsendYN = False          '����� Fax�߼۽� ����.
        Statement.smssendYN = False      '����� ���ڹ߼۱�� ���� Ȱ��


        '���׸� �߰�.
        Statement.detailList = New List(Of StatementDetail)

        Dim newDetail As StatementDetail = New StatementDetail

        newDetail.serialNum = 1             '�Ϸù�ȣ 1���� ���� ����
        newDetail.purchaseDT = "20150310"   '�ŷ�����  yyyyMMdd
        newDetail.itemName = "ǰ��"
        newDetail.spec = "�԰�"
        newDetail.unit = "����"
        newDetail.qty = "1" '����           ' �Ҽ��� 2�ڸ����� ���ڿ��� ���簡��
        newDetail.unitCost = "100000"       ' �Ҽ��� 2�ڸ����� ���ڿ��� ���簡��
        newDetail.supplyCost = "100000"
        newDetail.tax = "10000"
        newDetail.remark = "���"
        newDetail.spare1 = "spare1"
        newDetail.spare2 = "spare2"
        newDetail.spare3 = "spare3"
        newDetail.spare4 = "spare4"
        newDetail.spare5 = "spare5"

        Statement.detailList.Add(newDetail)

        '�߰��Ӽ�, �ڼ��ѻ����� "���ڸ��� API �����Ŵ��� > 5.2�⺻��� �߰��Ӽ� ���̺�" ����

        Statement.propertyBag = New Dictionary(Of String, String)

        Statement.propertyBag.Add("CBalance", "150000") '���ܾ�
        Statement.propertyBag.Add("Deposit", "50000")   '�Աݾ�
        Statement.propertyBag.Add("Balance", "100000")  '���ܾ�

        Try
            Dim response As Response = statementService.Register(txtCorpNum.Text, Statement, txtUserID.Text)

            MsgBox(response.code.ToString() + " | " + response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try


    End Sub

    '����
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim Statement As New Statement

        Statement.writeDate = "20150312"             '�ʼ�, ����� �ۼ�����
        Statement.purposeType = "����"               '�ʼ�, {����, û��}
        Statement.taxType = "����"                   '�ʼ�, {����, ����, �鼼}
        Statement.formCode = txtFormCode.Text       '�������ڵ�, �����Է½� �⺻���

        Statement.itemCode = selectedItemCode()     '�����ڵ�

        Statement.mgtKey = txtMgtKey.Text       '����������ȣ

        Statement.senderCorpNum = txtCorpNum.Text
        Statement.senderTaxRegID = "" '������� �ĺ���ȣ. �ʿ�� ����. ������ ���� 4�ڸ�.
        Statement.senderCorpName = "������ ��ȣ_����"
        Statement.senderCEOName = "������"" ��ǥ�� ����_����"
        Statement.senderAddr = "������ �ּ�"
        Statement.senderBizClass = "������ ����"
        Statement.senderBizType = "������ ����,����2"
        Statement.senderContactName = "������ ����ڸ�"
        Statement.senderEmail = "test@test.com"
        Statement.senderTEL = "070-7070-0707"
        Statement.senderHP = "010-000-2222"

        Statement.receiverCorpNum = "8888888888"
        Statement.receiverCorpName = "���޹޴��� ��ȣ"
        Statement.receiverCEOName = "���޹޴��� ��ǥ�� ����"
        Statement.receiverAddr = "���޹޴��� �ּ�"
        Statement.receiverBizClass = "���޹޴��� ����"
        Statement.receiverBizType = "���޹޴��� ����"
        Statement.receiverContactName = "���޹޴��� ����ڸ�"
        Statement.receiverEmail = "test@receiver.com"

        Statement.supplyCostTotal = "100000"         '�ʼ� ���ް��� �հ�
        Statement.taxTotal = "10000"                 '�ʼ� ���� �հ�
        Statement.totalAmount = "110000"             '�ʼ� �հ�ݾ�.  ���ް��� + ����

        Statement.serialNum = "123"
        Statement.remark1 = "���1"
        Statement.remark2 = "���2"
        Statement.remark3 = "���3"

        Statement.businessLicenseYN = False '����ڵ���� �̹��� ÷�ν� ����.
        Statement.bankBookYN = False         '����纻 �̹��� ÷�ν� ����.
        Statement.faxsendYN = False          '����� Fax�߼۽� ����.
        Statement.smssendYN = False      '����� ���ڹ߼۱�� ���� Ȱ��


        '���׸� �߰�.
        Statement.detailList = New List(Of StatementDetail)

        Dim newDetail As StatementDetail = New StatementDetail

        newDetail.serialNum = 1             '�Ϸù�ȣ 1���� ���� ����
        newDetail.purchaseDT = "20150310"   '�ŷ�����  yyyyMMdd
        newDetail.itemName = "ǰ��"
        newDetail.spec = "�԰�"
        newDetail.unit = "����"
        newDetail.qty = "1" '����           ' �Ҽ��� 2�ڸ����� ���ڿ��� ���簡��
        newDetail.unitCost = "100000"       ' �Ҽ��� 2�ڸ����� ���ڿ��� ���簡��
        newDetail.supplyCost = "100000"
        newDetail.tax = "10000"
        newDetail.remark = "���"
        newDetail.spare1 = "spare1"
        newDetail.spare2 = "spare2"
        newDetail.spare3 = "spare3"
        newDetail.spare4 = "spare4"
        newDetail.spare5 = "spare5"

        Statement.detailList.Add(newDetail)

        '�߰��Ӽ�, �ڼ��ѻ����� "���ڸ��� API �����Ŵ��� > 5.2�⺻��� �߰��Ӽ� ���̺�" ����

        Statement.propertyBag = New Dictionary(Of String, String)

        Statement.propertyBag.Add("CBalance", "150000") '���ܾ�
        Statement.propertyBag.Add("Deposit", "50000")   '�Աݾ�
        Statement.propertyBag.Add("Balance", "100000")  '���ܾ�

        Try
            Dim response As Response = statementService.Update(txtCorpNum.Text, selectedItemCode(), txtMgtKey.Text, Statement, txtUserID.Text)

            MsgBox(response.code.ToString() + " | " + response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '����
    Private Sub btnIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssue.Click

        Dim itemCode As Integer = selectedItemCode()
        Dim memo As String = "���� �޸�"

        Try
            Dim response As Response = statementService.Issue(txtCorpNum.Text, itemCode, txtMgtKey.Text, memo, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '�������
    Private Sub btnCancelIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelIssue.Click

        Dim itemCode As Integer = selectedItemCode()
        Dim memo As String = "������� �޸�"

        Try
            Dim response As Response = statementService.CancelIssue(txtCorpNum.Text, itemCode, txtMgtKey.Text, memo, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '����
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim response As Response = statementService.Delete(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '÷������ �߰� 
    Private Sub btnAttachFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachFile.Click

        Dim itemCode As Integer = selectedItemCode()

        If fileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim strFileName As String = fileDialog.FileName

            Try
                Dim response As Response = statementService.AttachFile(txtCorpNum.Text, itemCode, txtMgtKey.Text, strFileName, txtUserID.Text)

                MsgBox(response.message)
            Catch ex As PopbillException
                MsgBox(ex.code.ToString() + " | " + ex.Message)
            End Try

        End If
    End Sub

    '÷������ ��� Ȯ��
    Private Sub btnGetFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFiles.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim fileList As List(Of AttachedFile) = statementService.GetFiles(txtCorpNum.Text, itemCode, txtMgtKey.Text)


            Dim tmp As String = "�Ϸù�ȣ | ǥ�ø� | ���Ͼ��̵� | �������" + vbCrLf

            For Each file As AttachedFile In fileList
                tmp += file.serialNum.ToString() + " | " + file.displayName + " | " + file.attachedFile + " | " + file.regDT + vbCrLf

            Next
            MsgBox(tmp)


        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '÷������ ����
    Private Sub btnDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFile.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim response As Response = statementService.DeleteFile(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtFileID.Text, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try

    End Sub

    '���� ����/��� ���� ��ȸ
    Private Sub btnGetInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfo.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim statementInfo As StatementInfo = statementService.GetInfo(txtCorpNum.Text, itemCode, txtMgtKey.Text)

            Dim tmp As String = ""

            tmp += "itemKey : " + statementInfo.itemKey + vbCrLf
            tmp += "stateCode : " + CStr(statementInfo.stateCode) + vbCrLf
            tmp += "taxType : " + statementInfo.taxType + vbCrLf
            tmp += "purposeType : " + statementInfo.purposeType + vbCrLf

            tmp += "writeDate : " + statementInfo.writeDate + vbCrLf

            tmp += "senderCorpName : " + statementInfo.senderCorpName + vbCrLf
            tmp += "senderCorpNum : " + statementInfo.senderCorpNum + vbCrLf
            tmp += "receiverCorpName : " + statementInfo.receiverCorpName + vbCrLf
            tmp += "receiverCorpNum : " + statementInfo.receiverCorpNum + vbCrLf

            tmp += "supplyCostTotal : " + statementInfo.supplyCostTotal + vbCrLf
            tmp += "taxTotal : " + statementInfo.taxTotal + vbCrLf

            tmp += "issueDT : " + statementInfo.issueDT + vbCrLf
            tmp += "stateDT : " + statementInfo.stateDT + vbCrLf
            tmp += "openYN : " + CStr(statementInfo.openYN) + vbCrLf
            tmp += "openDT : " + statementInfo.openDT + vbCrLf


            tmp += "stateMemo : " + statementInfo.stateMemo + vbCrLf

            tmp += "regDT : " + statementInfo.regDT + vbCrLf

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '�ٷ� ���� ���/���� ���� ��ȸ
    Private Sub btnGetInfos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfos.Click
        Dim itemCode As Integer = selectedItemCode()

        Dim MgtKeyList As List(Of String) = New List(Of String)

        ''�ִ� 1000��.
        MgtKeyList.Add("20150312-01")
        MgtKeyList.Add("20150312-02")
        MgtKeyList.Add("20150312-03")

        Try
            Dim statementInfoList As List(Of StatementInfo) = statementService.GetInfos(txtCorpNum.Text, itemCode, MgtKeyList)

            Dim info As StatementInfo = New StatementInfo

            Dim tmp As String = ""

            For Each info In statementInfoList
                tmp += "itemKey : " + info.itemKey + vbCrLf
                tmp += "stateCode : " + CStr(info.stateCode) + vbCrLf
                tmp += "taxType : " + info.taxType + vbCrLf
                tmp += "purposeType : " + info.purposeType + vbCrLf

                tmp += "writeDate : " + info.writeDate + vbCrLf

                tmp += "senderCorpName : " + info.senderCorpName + vbCrLf
                tmp += "senderCorpNum : " + info.senderCorpNum + vbCrLf
                tmp += "receiverCorpName : " + info.receiverCorpName + vbCrLf
                tmp += "receiverCorpNum : " + info.receiverCorpNum + vbCrLf

                tmp += "supplyCostTotal : " + info.supplyCostTotal + vbCrLf
                tmp += "taxTotal : " + info.taxTotal + vbCrLf

                tmp += "issueDT : " + info.issueDT + vbCrLf
                tmp += "stateDT : " + info.stateDT + vbCrLf
                tmp += "openYN : " + CStr(info.openYN) + vbCrLf
                tmp += "openDT : " + info.openDT + vbCrLf


                tmp += "stateMemo : " + info.stateMemo + vbCrLf

                tmp += "regDT : " + info.regDT + vbCrLf + vbCrLf
            Next

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '���� ������ ��ȸ
    Private Sub btnGetDetailInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDetailInfo.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim statement As Statement = statementService.GetDetailInfo(txtCorpNum.Text, itemCode, txtMgtKey.Text)

            '�ڼ��� ���������� �ۼ��� �׸��� �����ϰų�, �����޴��� ����.

            Dim tmp As String = ""

            tmp += "writeDate : " + statement.writeDate + vbCrLf

            tmp += "taxType : " + statement.taxType + vbCrLf

            tmp += "senderCorpNum : " + statement.senderCorpNum + vbCrLf
            tmp += "senderTaxRegID : " + statement.senderTaxRegID + vbCrLf
            tmp += "senderCorpName : " + statement.senderCorpName + vbCrLf
            tmp += "senderCEOName : " + statement.senderCEOName + vbCrLf
            tmp += "senderAddr : " + statement.senderAddr + vbCrLf
            tmp += "senderBizClass : " + statement.senderBizClass + vbCrLf
            tmp += "senderBizType : " + statement.senderBizType + vbCrLf
            tmp += "senderContactName : " + statement.senderContactName + vbCrLf
            tmp += "senderDeptName : " + statement.senderDeptName + vbCrLf
            tmp += "senderTEL : " + statement.senderTEL + vbCrLf
            tmp += "senderHP : " + statement.senderHP + vbCrLf
            tmp += "senderEmail : " + statement.senderEmail + vbCrLf


            tmp += "receiverCorpNum : " + statement.receiverCorpNum + vbCrLf
            tmp += "receiverTaxRegID : " + statement.receiverTaxRegID + vbCrLf
            tmp += "receiverCorpName : " + statement.receiverCorpName + vbCrLf
            tmp += "receiverCEOName : " + statement.receiverCEOName + vbCrLf
            tmp += "receiverAddr : " + statement.receiverAddr + vbCrLf
            tmp += "receiverBizClass : " + statement.receiverBizClass + vbCrLf
            tmp += "receiverBizType : " + statement.receiverBizType + vbCrLf
            tmp += "receiverContactName : " + statement.receiverContactName + vbCrLf
            tmp += "receiverDeptName : " + statement.receiverDeptName + vbCrLf
            tmp += "receiverTEL : " + statement.receiverTEL + vbCrLf
            tmp += "receiverHP : " + statement.receiverHP + vbCrLf
            tmp += "receiverEmail : " + statement.receiverEmail + vbCrLf + vbCrLf

            '''  �󼼳��� ���� '''
            tmp += "Properties" + vbCrLf

            Dim key

            For Each key In statement.propertyBag.Keys
                tmp += vbTab + key + " : " + statement.propertyBag.Item(key) + vbCrLf
            Next

            tmp += "detailList" + vbCrLf

            Dim detail As StatementDetail

            For Each detail In statement.detailList
                tmp += vbTab + CStr(detail.serialNum) + " : " + detail.itemName + " | " + detail.supplyCost + vbCrLf
            Next

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '���� �̷� 
    Private Sub btnGetLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetLogs.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim logList As List(Of StatementLog) = statementService.GetLogs(txtCorpNum.Text, itemCode, txtMgtKey.Text)


            Dim tmp As String = ""


            For Each log As StatementLog In logList
                tmp += log.docLogType.ToString + " | " + log.log + " | " + log.procType + " | " + log.procCorpName + " | " + log.procContactName + " | " + log.procMemo + " | " + log.regDT + " | " + log.ip + vbCrLf
            Next

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '�˸� ���� ����
    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click

        Dim itemCode As Integer = selectedItemCode()

        '���Ÿ����ּ�
        Dim receiver As String = "test@test.com"

        Try
            Dim response As Response = statementService.SendEmail(txtCorpNum.Text, itemCode, txtMgtKey.Text, receiver, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '�˸����� ����
    Private Sub btnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendSMS.Click

        Dim itemCode As Integer = selectedItemCode()

        Dim senderNum As String = "07075103710"     '�߽��ڹ�ȣ
        Dim receiverNum As String = "010111222"     '�����ڹ�ȣ
        Dim contents As String = "���ڸ��� ���ھ˸� ����" '�޽��� ����

        Try
            Dim response As Response = statementService.SendSMS(txtCorpNum.Text, itemCode, txtMgtKey.Text, senderNum, receiverNum, contents, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '���ڸ��� �ѽ�����
    Private Sub btnSendFAX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendFAX.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim response As Response = statementService.SendFAX(txtCorpNum.Text, itemCode, txtMgtKey.Text, "1111-2222", "000-2222-4444", txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '���� ���� ���� URL
    Private Sub btnGetPopUpURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPopUpURL.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetPopUpURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try

    End Sub

    '�μ� �˾� URL
    Private Sub btnGetPrintURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPrintURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetPrintURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '���޹޴��� �μ� URL
    Private Sub btnGetEPrintURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetEPrintURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetEPrintURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '���޹޴��� ���� ��ũ URL
    Private Sub btnGetMailURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMailURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetMailURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '�ٷ� �μ� �˾� URL
    Private Sub btnGetMassPrintURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMassPrintURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Dim MgtKeyList As List(Of String) = New List(Of String)

        ''�ִ� 1000��.
        MgtKeyList.Add("20150312-01")
        MgtKeyList.Add("20150312-02")
        MgtKeyList.Add("20150312-03")

        Try
            Dim url As String = statementService.GetMassPrintURL(txtCorpNum.Text, itemCode, MgtKeyList, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '�ӽ� ������ URL
    Private Sub btnGetURL_TBOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetURL_TBOX.Click

        Try
            Dim url As String = statementService.GetURL(txtCorpNum.Text, txtUserID.Text, "TBOX")

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '���� ������ URL
    Private Sub btnGetURL_SBOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetURL_SBOX.Click

        Try
            Dim url As String = statementService.GetURL(txtCorpNum.Text, txtUserID.Text, "SBOX")

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub
End Class
