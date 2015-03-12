<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExample
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.groupBox11 = New System.Windows.Forms.GroupBox
        Me.btnGetURL_SBOX = New System.Windows.Forms.Button
        Me.btnGetURL_TBOX = New System.Windows.Forms.Button
        Me.groupBox10 = New System.Windows.Forms.GroupBox
        Me.btnGetPrintURL = New System.Windows.Forms.Button
        Me.btnGetEPrintURL = New System.Windows.Forms.Button
        Me.btnGetMassPrintURL = New System.Windows.Forms.Button
        Me.btnGetMailURL = New System.Windows.Forms.Button
        Me.btnGetPopUpURL = New System.Windows.Forms.Button
        Me.groupBox9 = New System.Windows.Forms.GroupBox
        Me.btnSendSMS = New System.Windows.Forms.Button
        Me.btnSendFAX = New System.Windows.Forms.Button
        Me.btnSendEmail = New System.Windows.Forms.Button
        Me.groupBox8 = New System.Windows.Forms.GroupBox
        Me.btnGetDetailInfo = New System.Windows.Forms.Button
        Me.btnGetInfos = New System.Windows.Forms.Button
        Me.btnGetLogs = New System.Windows.Forms.Button
        Me.btnGetInfo = New System.Windows.Forms.Button
        Me.groupBox7 = New System.Windows.Forms.GroupBox
        Me.txtFileID = New System.Windows.Forms.TextBox
        Me.btnDeleteFile = New System.Windows.Forms.Button
        Me.btnGetFiles = New System.Windows.Forms.Button
        Me.btnAttachFile = New System.Windows.Forms.Button
        Me.label = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnCancelIssue = New System.Windows.Forms.Button
        Me.btnIssue = New System.Windows.Forms.Button
        Me.panel1 = New System.Windows.Forms.Panel
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnRegister = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.btnCheckMgtKeyInUse = New System.Windows.Forms.Button
        Me.txtMgtKey = New System.Windows.Forms.TextBox
        Me.txtFormCode = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.cboItemCode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnGetPartnerBalance = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btnGetPopbillURL_CHRG = New System.Windows.Forms.Button
        Me.btnGetPopbillURL_LOGIN = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnUnitCost = New System.Windows.Forms.Button
        Me.btnGetBalance = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnCheckIsMember = New System.Windows.Forms.Button
        Me.btnJoinMember = New System.Windows.Forms.Button
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.txtCorpNum = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.fileDialog = New System.Windows.Forms.OpenFileDialog
        Me.groupBox4.SuspendLayout()
        Me.groupBox11.SuspendLayout()
        Me.groupBox10.SuspendLayout()
        Me.groupBox9.SuspendLayout()
        Me.groupBox8.SuspendLayout()
        Me.groupBox7.SuspendLayout()
        Me.label.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.groupBox11)
        Me.groupBox4.Controls.Add(Me.groupBox10)
        Me.groupBox4.Controls.Add(Me.groupBox9)
        Me.groupBox4.Controls.Add(Me.groupBox8)
        Me.groupBox4.Controls.Add(Me.groupBox7)
        Me.groupBox4.Controls.Add(Me.label)
        Me.groupBox4.Controls.Add(Me.btnCheckMgtKeyInUse)
        Me.groupBox4.Controls.Add(Me.txtMgtKey)
        Me.groupBox4.Controls.Add(Me.txtFormCode)
        Me.groupBox4.Controls.Add(Me.label5)
        Me.groupBox4.Controls.Add(Me.label4)
        Me.groupBox4.Controls.Add(Me.label3)
        Me.groupBox4.Controls.Add(Me.cboItemCode)
        Me.groupBox4.Location = New System.Drawing.Point(18, 150)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(670, 466)
        Me.groupBox4.TabIndex = 19
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "전자명세서 관련 API"
        '
        'groupBox11
        '
        Me.groupBox11.Controls.Add(Me.btnGetURL_SBOX)
        Me.groupBox11.Controls.Add(Me.btnGetURL_TBOX)
        Me.groupBox11.Location = New System.Drawing.Point(515, 268)
        Me.groupBox11.Name = "groupBox11"
        Me.groupBox11.Size = New System.Drawing.Size(107, 86)
        Me.groupBox11.TabIndex = 36
        Me.groupBox11.TabStop = False
        Me.groupBox11.Text = "기타 URL"
        '
        'btnGetURL_SBOX
        '
        Me.btnGetURL_SBOX.Location = New System.Drawing.Point(12, 50)
        Me.btnGetURL_SBOX.Name = "btnGetURL_SBOX"
        Me.btnGetURL_SBOX.Size = New System.Drawing.Size(84, 29)
        Me.btnGetURL_SBOX.TabIndex = 25
        Me.btnGetURL_SBOX.Text = "발행 문서함"
        Me.btnGetURL_SBOX.UseVisualStyleBackColor = True
        '
        'btnGetURL_TBOX
        '
        Me.btnGetURL_TBOX.Location = New System.Drawing.Point(12, 15)
        Me.btnGetURL_TBOX.Name = "btnGetURL_TBOX"
        Me.btnGetURL_TBOX.Size = New System.Drawing.Size(84, 29)
        Me.btnGetURL_TBOX.TabIndex = 9
        Me.btnGetURL_TBOX.Text = "임시 문서함"
        Me.btnGetURL_TBOX.UseVisualStyleBackColor = True
        '
        'groupBox10
        '
        Me.groupBox10.Controls.Add(Me.btnGetPrintURL)
        Me.groupBox10.Controls.Add(Me.btnGetEPrintURL)
        Me.groupBox10.Controls.Add(Me.btnGetMassPrintURL)
        Me.groupBox10.Controls.Add(Me.btnGetMailURL)
        Me.groupBox10.Controls.Add(Me.btnGetPopUpURL)
        Me.groupBox10.Location = New System.Drawing.Point(300, 268)
        Me.groupBox10.Name = "groupBox10"
        Me.groupBox10.Size = New System.Drawing.Size(198, 192)
        Me.groupBox10.TabIndex = 35
        Me.groupBox10.TabStop = False
        Me.groupBox10.Text = "인쇄 URL"
        '
        'btnGetPrintURL
        '
        Me.btnGetPrintURL.Location = New System.Drawing.Point(11, 53)
        Me.btnGetPrintURL.Name = "btnGetPrintURL"
        Me.btnGetPrintURL.Size = New System.Drawing.Size(174, 29)
        Me.btnGetPrintURL.TabIndex = 24
        Me.btnGetPrintURL.Text = "인쇄 팝업 URL"
        Me.btnGetPrintURL.UseVisualStyleBackColor = True
        '
        'btnGetEPrintURL
        '
        Me.btnGetEPrintURL.Location = New System.Drawing.Point(11, 88)
        Me.btnGetEPrintURL.Name = "btnGetEPrintURL"
        Me.btnGetEPrintURL.Size = New System.Drawing.Size(174, 29)
        Me.btnGetEPrintURL.TabIndex = 23
        Me.btnGetEPrintURL.Text = "수신자 인쇄 팝업 URL"
        Me.btnGetEPrintURL.UseVisualStyleBackColor = True
        '
        'btnGetMassPrintURL
        '
        Me.btnGetMassPrintURL.Location = New System.Drawing.Point(11, 123)
        Me.btnGetMassPrintURL.Name = "btnGetMassPrintURL"
        Me.btnGetMassPrintURL.Size = New System.Drawing.Size(174, 29)
        Me.btnGetMassPrintURL.TabIndex = 22
        Me.btnGetMassPrintURL.Text = "다량 인쇄 팝업 URL"
        Me.btnGetMassPrintURL.UseVisualStyleBackColor = True
        '
        'btnGetMailURL
        '
        Me.btnGetMailURL.Location = New System.Drawing.Point(11, 158)
        Me.btnGetMailURL.Name = "btnGetMailURL"
        Me.btnGetMailURL.Size = New System.Drawing.Size(174, 29)
        Me.btnGetMailURL.TabIndex = 21
        Me.btnGetMailURL.Text = "이메일(공급받는자) 링크 URL"
        Me.btnGetMailURL.UseVisualStyleBackColor = True
        '
        'btnGetPopUpURL
        '
        Me.btnGetPopUpURL.Location = New System.Drawing.Point(11, 18)
        Me.btnGetPopUpURL.Name = "btnGetPopUpURL"
        Me.btnGetPopUpURL.Size = New System.Drawing.Size(174, 29)
        Me.btnGetPopUpURL.TabIndex = 5
        Me.btnGetPopUpURL.Text = "문서내용 보기 팝업 URL"
        Me.btnGetPopUpURL.UseVisualStyleBackColor = True
        '
        'groupBox9
        '
        Me.groupBox9.Controls.Add(Me.btnSendSMS)
        Me.groupBox9.Controls.Add(Me.btnSendFAX)
        Me.groupBox9.Controls.Add(Me.btnSendEmail)
        Me.groupBox9.Location = New System.Drawing.Point(156, 268)
        Me.groupBox9.Name = "groupBox9"
        Me.groupBox9.Size = New System.Drawing.Size(126, 120)
        Me.groupBox9.TabIndex = 34
        Me.groupBox9.TabStop = False
        Me.groupBox9.Text = "부가 서비스"
        '
        'btnSendSMS
        '
        Me.btnSendSMS.Location = New System.Drawing.Point(12, 51)
        Me.btnSendSMS.Name = "btnSendSMS"
        Me.btnSendSMS.Size = New System.Drawing.Size(103, 29)
        Me.btnSendSMS.TabIndex = 28
        Me.btnSendSMS.Text = "문자 전송"
        Me.btnSendSMS.UseVisualStyleBackColor = True
        '
        'btnSendFAX
        '
        Me.btnSendFAX.Location = New System.Drawing.Point(12, 86)
        Me.btnSendFAX.Name = "btnSendFAX"
        Me.btnSendFAX.Size = New System.Drawing.Size(103, 29)
        Me.btnSendFAX.TabIndex = 27
        Me.btnSendFAX.Text = "팩스 전송"
        Me.btnSendFAX.UseVisualStyleBackColor = True
        '
        'btnSendEmail
        '
        Me.btnSendEmail.Location = New System.Drawing.Point(12, 16)
        Me.btnSendEmail.Name = "btnSendEmail"
        Me.btnSendEmail.Size = New System.Drawing.Size(103, 29)
        Me.btnSendEmail.TabIndex = 26
        Me.btnSendEmail.Text = "이메일 전송"
        Me.btnSendEmail.UseVisualStyleBackColor = True
        '
        'groupBox8
        '
        Me.groupBox8.Controls.Add(Me.btnGetDetailInfo)
        Me.groupBox8.Controls.Add(Me.btnGetInfos)
        Me.groupBox8.Controls.Add(Me.btnGetLogs)
        Me.groupBox8.Controls.Add(Me.btnGetInfo)
        Me.groupBox8.Location = New System.Drawing.Point(18, 268)
        Me.groupBox8.Name = "groupBox8"
        Me.groupBox8.Size = New System.Drawing.Size(122, 154)
        Me.groupBox8.TabIndex = 33
        Me.groupBox8.TabStop = False
        Me.groupBox8.Text = "문서 정보"
        '
        'btnGetDetailInfo
        '
        Me.btnGetDetailInfo.Location = New System.Drawing.Point(9, 49)
        Me.btnGetDetailInfo.Name = "btnGetDetailInfo"
        Me.btnGetDetailInfo.Size = New System.Drawing.Size(103, 29)
        Me.btnGetDetailInfo.TabIndex = 32
        Me.btnGetDetailInfo.Text = "문서 상세정보"
        Me.btnGetDetailInfo.UseVisualStyleBackColor = True
        '
        'btnGetInfos
        '
        Me.btnGetInfos.Location = New System.Drawing.Point(9, 84)
        Me.btnGetInfos.Name = "btnGetInfos"
        Me.btnGetInfos.Size = New System.Drawing.Size(103, 29)
        Me.btnGetInfos.TabIndex = 31
        Me.btnGetInfos.Text = "문자 전송(대량)"
        Me.btnGetInfos.UseVisualStyleBackColor = True
        '
        'btnGetLogs
        '
        Me.btnGetLogs.Location = New System.Drawing.Point(9, 119)
        Me.btnGetLogs.Name = "btnGetLogs"
        Me.btnGetLogs.Size = New System.Drawing.Size(103, 29)
        Me.btnGetLogs.TabIndex = 30
        Me.btnGetLogs.Text = "문서 이력"
        Me.btnGetLogs.UseVisualStyleBackColor = True
        '
        'btnGetInfo
        '
        Me.btnGetInfo.Location = New System.Drawing.Point(9, 14)
        Me.btnGetInfo.Name = "btnGetInfo"
        Me.btnGetInfo.Size = New System.Drawing.Size(103, 29)
        Me.btnGetInfo.TabIndex = 29
        Me.btnGetInfo.Text = "문서 정보"
        Me.btnGetInfo.UseVisualStyleBackColor = True
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.txtFileID)
        Me.groupBox7.Controls.Add(Me.btnDeleteFile)
        Me.groupBox7.Controls.Add(Me.btnGetFiles)
        Me.groupBox7.Controls.Add(Me.btnAttachFile)
        Me.groupBox7.Location = New System.Drawing.Point(358, 173)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(293, 82)
        Me.groupBox7.TabIndex = 20
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "첨부파일 관련"
        '
        'txtFileID
        '
        Me.txtFileID.Location = New System.Drawing.Point(25, 49)
        Me.txtFileID.Name = "txtFileID"
        Me.txtFileID.Size = New System.Drawing.Size(185, 21)
        Me.txtFileID.TabIndex = 8
        '
        'btnDeleteFile
        '
        Me.btnDeleteFile.Location = New System.Drawing.Point(213, 45)
        Me.btnDeleteFile.Name = "btnDeleteFile"
        Me.btnDeleteFile.Size = New System.Drawing.Size(69, 29)
        Me.btnDeleteFile.TabIndex = 7
        Me.btnDeleteFile.Text = "파일 삭제"
        Me.btnDeleteFile.UseVisualStyleBackColor = True
        '
        'btnGetFiles
        '
        Me.btnGetFiles.Location = New System.Drawing.Point(102, 17)
        Me.btnGetFiles.Name = "btnGetFiles"
        Me.btnGetFiles.Size = New System.Drawing.Size(92, 29)
        Me.btnGetFiles.TabIndex = 6
        Me.btnGetFiles.Text = "첨부파일 목록"
        Me.btnGetFiles.UseVisualStyleBackColor = True
        '
        'btnAttachFile
        '
        Me.btnAttachFile.Location = New System.Drawing.Point(24, 17)
        Me.btnAttachFile.Name = "btnAttachFile"
        Me.btnAttachFile.Size = New System.Drawing.Size(69, 29)
        Me.btnAttachFile.TabIndex = 5
        Me.btnAttachFile.Text = "파일 첨부"
        Me.btnAttachFile.UseVisualStyleBackColor = True
        '
        'label
        '
        Me.label.Controls.Add(Me.btnDelete)
        Me.label.Controls.Add(Me.btnCancelIssue)
        Me.label.Controls.Add(Me.btnIssue)
        Me.label.Controls.Add(Me.panel1)
        Me.label.Location = New System.Drawing.Point(358, 15)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(298, 152)
        Me.label.TabIndex = 19
        Me.label.TabStop = False
        Me.label.Text = "전자명세서 발행 프로세스"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(195, 118)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(69, 29)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "삭제"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancelIssue
        '
        Me.btnCancelIssue.Location = New System.Drawing.Point(80, 118)
        Me.btnCancelIssue.Name = "btnCancelIssue"
        Me.btnCancelIssue.Size = New System.Drawing.Size(69, 29)
        Me.btnCancelIssue.TabIndex = 4
        Me.btnCancelIssue.Text = "발행취소"
        Me.btnCancelIssue.UseVisualStyleBackColor = True
        '
        'btnIssue
        '
        Me.btnIssue.Location = New System.Drawing.Point(80, 76)
        Me.btnIssue.Name = "btnIssue"
        Me.btnIssue.Size = New System.Drawing.Size(69, 29)
        Me.btnIssue.TabIndex = 3
        Me.btnIssue.Text = "발행"
        Me.btnIssue.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.panel1.Controls.Add(Me.btnUpdate)
        Me.panel1.Controls.Add(Me.btnRegister)
        Me.panel1.Controls.Add(Me.label6)
        Me.panel1.Location = New System.Drawing.Point(28, 20)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(252, 40)
        Me.panel1.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(167, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(69, 29)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "수정"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(92, 4)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(69, 29)
        Me.btnRegister.TabIndex = 1
        Me.btnRegister.Text = "등록"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(31, 14)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(53, 12)
        Me.label6.TabIndex = 0
        Me.label6.Text = "임시저장"
        '
        'btnCheckMgtKeyInUse
        '
        Me.btnCheckMgtKeyInUse.Location = New System.Drawing.Point(188, 111)
        Me.btnCheckMgtKeyInUse.Name = "btnCheckMgtKeyInUse"
        Me.btnCheckMgtKeyInUse.Size = New System.Drawing.Size(143, 27)
        Me.btnCheckMgtKeyInUse.TabIndex = 3
        Me.btnCheckMgtKeyInUse.Text = "관리번호 사용여부 확인"
        Me.btnCheckMgtKeyInUse.UseVisualStyleBackColor = True
        '
        'txtMgtKey
        '
        Me.txtMgtKey.Location = New System.Drawing.Point(188, 84)
        Me.txtMgtKey.Name = "txtMgtKey"
        Me.txtMgtKey.Size = New System.Drawing.Size(143, 21)
        Me.txtMgtKey.TabIndex = 18
        Me.txtMgtKey.Text = "20150312-01"
        '
        'txtFormCode
        '
        Me.txtFormCode.Location = New System.Drawing.Point(188, 57)
        Me.txtFormCode.Name = "txtFormCode"
        Me.txtFormCode.Size = New System.Drawing.Size(143, 21)
        Me.txtFormCode.TabIndex = 17
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(44, 84)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(142, 12)
        Me.label5.TabIndex = 16
        Me.label5.Text = "문서관리번호(MgtKey) : "
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(24, 60)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(166, 12)
        Me.label4.TabIndex = 15
        Me.label4.Text = "맞춤 양식코드(FormCode) :  "
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(105, 35)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(81, 12)
        Me.label3.TabIndex = 14
        Me.label3.Text = "명세서 종류 : "
        '
        'cboItemCode
        '
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.Items.AddRange(New Object() {"거래명세서", "청구서", "견적서", "발주서", "입금표", "영수증"})
        Me.cboItemCode.Location = New System.Drawing.Point(188, 32)
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(121, 20)
        Me.cboItemCode.TabIndex = 0
        Me.cboItemCode.Text = "거래명세서"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "회원아이디 : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 104)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "팝빌 기본 API"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnGetPartnerBalance)
        Me.GroupBox6.Location = New System.Drawing.Point(282, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(131, 83)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "파트너 관련"
        '
        'btnGetPartnerBalance
        '
        Me.btnGetPartnerBalance.Location = New System.Drawing.Point(6, 19)
        Me.btnGetPartnerBalance.Name = "btnGetPartnerBalance"
        Me.btnGetPartnerBalance.Size = New System.Drawing.Size(118, 26)
        Me.btnGetPartnerBalance.TabIndex = 3
        Me.btnGetPartnerBalance.Text = "파트너포인트 확인"
        Me.btnGetPartnerBalance.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnGetPopbillURL_CHRG)
        Me.GroupBox5.Controls.Add(Me.btnGetPopbillURL_LOGIN)
        Me.GroupBox5.Location = New System.Drawing.Point(421, 17)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(143, 83)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "기타"
        '
        'btnGetPopbillURL_CHRG
        '
        Me.btnGetPopbillURL_CHRG.Location = New System.Drawing.Point(6, 51)
        Me.btnGetPopbillURL_CHRG.Name = "btnGetPopbillURL_CHRG"
        Me.btnGetPopbillURL_CHRG.Size = New System.Drawing.Size(133, 26)
        Me.btnGetPopbillURL_CHRG.TabIndex = 1
        Me.btnGetPopbillURL_CHRG.Text = "포인트 충전 URL"
        Me.btnGetPopbillURL_CHRG.UseVisualStyleBackColor = True
        '
        'btnGetPopbillURL_LOGIN
        '
        Me.btnGetPopbillURL_LOGIN.Location = New System.Drawing.Point(6, 20)
        Me.btnGetPopbillURL_LOGIN.Name = "btnGetPopbillURL_LOGIN"
        Me.btnGetPopbillURL_LOGIN.Size = New System.Drawing.Size(133, 26)
        Me.btnGetPopbillURL_LOGIN.TabIndex = 0
        Me.btnGetPopbillURL_LOGIN.Text = "팝빌 로그인 URL"
        Me.btnGetPopbillURL_LOGIN.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnUnitCost)
        Me.GroupBox3.Controls.Add(Me.btnGetBalance)
        Me.GroupBox3.Location = New System.Drawing.Point(145, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(131, 83)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "포인트 관련"
        '
        'btnUnitCost
        '
        Me.btnUnitCost.Location = New System.Drawing.Point(6, 51)
        Me.btnUnitCost.Name = "btnUnitCost"
        Me.btnUnitCost.Size = New System.Drawing.Size(118, 26)
        Me.btnUnitCost.TabIndex = 3
        Me.btnUnitCost.Text = "요금 단가 확인"
        Me.btnUnitCost.UseVisualStyleBackColor = True
        '
        'btnGetBalance
        '
        Me.btnGetBalance.Location = New System.Drawing.Point(6, 19)
        Me.btnGetBalance.Name = "btnGetBalance"
        Me.btnGetBalance.Size = New System.Drawing.Size(118, 26)
        Me.btnGetBalance.TabIndex = 2
        Me.btnGetBalance.Text = "잔여포인트 확인"
        Me.btnGetBalance.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCheckIsMember)
        Me.GroupBox2.Controls.Add(Me.btnJoinMember)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(131, 83)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "회원 정보"
        '
        'btnCheckIsMember
        '
        Me.btnCheckIsMember.Location = New System.Drawing.Point(6, 19)
        Me.btnCheckIsMember.Name = "btnCheckIsMember"
        Me.btnCheckIsMember.Size = New System.Drawing.Size(118, 26)
        Me.btnCheckIsMember.TabIndex = 2
        Me.btnCheckIsMember.Text = "가입여부 확인"
        Me.btnCheckIsMember.UseVisualStyleBackColor = True
        '
        'btnJoinMember
        '
        Me.btnJoinMember.Location = New System.Drawing.Point(6, 51)
        Me.btnJoinMember.Name = "btnJoinMember"
        Me.btnJoinMember.Size = New System.Drawing.Size(118, 26)
        Me.btnJoinMember.TabIndex = 1
        Me.btnJoinMember.Text = "회원 가입"
        Me.btnJoinMember.UseVisualStyleBackColor = True
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(292, 6)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 21)
        Me.txtUserID.TabIndex = 16
        Me.txtUserID.Text = "testkorea"
        '
        'txtCorpNum
        '
        Me.txtCorpNum.Location = New System.Drawing.Point(91, 6)
        Me.txtCorpNum.Name = "txtCorpNum"
        Me.txtCorpNum.Size = New System.Drawing.Size(100, 21)
        Me.txtCorpNum.TabIndex = 14
        Me.txtCorpNum.Text = "1234567890"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "사업자번호 : "
        '
        'fileDialog
        '
        Me.fileDialog.FileName = "fileDialog"
        '
        'frmExample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 634)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtCorpNum)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmExample"
        Me.Text = "팝빌 전자명세서 SDK VB.NET Example"
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox11.ResumeLayout(False)
        Me.groupBox10.ResumeLayout(False)
        Me.groupBox9.ResumeLayout(False)
        Me.groupBox8.ResumeLayout(False)
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.label.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox11 As System.Windows.Forms.GroupBox
    Private WithEvents btnGetURL_SBOX As System.Windows.Forms.Button
    Private WithEvents btnGetURL_TBOX As System.Windows.Forms.Button
    Private WithEvents groupBox10 As System.Windows.Forms.GroupBox
    Private WithEvents btnGetPrintURL As System.Windows.Forms.Button
    Private WithEvents btnGetEPrintURL As System.Windows.Forms.Button
    Private WithEvents btnGetMassPrintURL As System.Windows.Forms.Button
    Private WithEvents btnGetMailURL As System.Windows.Forms.Button
    Private WithEvents btnGetPopUpURL As System.Windows.Forms.Button
    Private WithEvents groupBox9 As System.Windows.Forms.GroupBox
    Private WithEvents btnSendSMS As System.Windows.Forms.Button
    Private WithEvents btnSendFAX As System.Windows.Forms.Button
    Private WithEvents btnSendEmail As System.Windows.Forms.Button
    Private WithEvents groupBox8 As System.Windows.Forms.GroupBox
    Private WithEvents btnGetDetailInfo As System.Windows.Forms.Button
    Private WithEvents btnGetInfos As System.Windows.Forms.Button
    Private WithEvents btnGetLogs As System.Windows.Forms.Button
    Private WithEvents btnGetInfo As System.Windows.Forms.Button
    Private WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents txtFileID As System.Windows.Forms.TextBox
    Private WithEvents btnDeleteFile As System.Windows.Forms.Button
    Private WithEvents btnGetFiles As System.Windows.Forms.Button
    Private WithEvents btnAttachFile As System.Windows.Forms.Button
    Private WithEvents label As System.Windows.Forms.GroupBox
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnCancelIssue As System.Windows.Forms.Button
    Private WithEvents btnIssue As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents btnUpdate As System.Windows.Forms.Button
    Private WithEvents btnRegister As System.Windows.Forms.Button
    Private WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents btnCheckMgtKeyInUse As System.Windows.Forms.Button
    Private WithEvents txtMgtKey As System.Windows.Forms.TextBox
    Private WithEvents txtFormCode As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetPartnerBalance As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetPopbillURL_CHRG As System.Windows.Forms.Button
    Friend WithEvents btnGetPopbillURL_LOGIN As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUnitCost As System.Windows.Forms.Button
    Friend WithEvents btnGetBalance As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCheckIsMember As System.Windows.Forms.Button
    Friend WithEvents btnJoinMember As System.Windows.Forms.Button
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtCorpNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fileDialog As System.Windows.Forms.OpenFileDialog

End Class
