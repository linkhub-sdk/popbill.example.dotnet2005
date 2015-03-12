namespace Popbill.Statement.Example.csharp
{
    partial class frmExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.btnGetPartnerBalance = new System.Windows.Forms.Button();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGetPopbillURL_CHRG = new System.Windows.Forms.Button();
            this.btnGetPopbillURL_LOGIN = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUnitCost = new System.Windows.Forms.Button();
            this.btnGetBalance = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckIsMember = new System.Windows.Forms.Button();
            this.btnJoinMember = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCorpNum = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnGetURL_SBOX = new System.Windows.Forms.Button();
            this.btnGetURL_TBOX = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnGetPrintURL = new System.Windows.Forms.Button();
            this.btnGetEPrintURL = new System.Windows.Forms.Button();
            this.btnGetMassPrintURL = new System.Windows.Forms.Button();
            this.btnGetMailURL = new System.Windows.Forms.Button();
            this.btnGetPopUpURL = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnSendFAX = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnGetDetailInfo = new System.Windows.Forms.Button();
            this.btnGetInfos = new System.Windows.Forms.Button();
            this.btnGetLogs = new System.Windows.Forms.Button();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtFileID = new System.Windows.Forms.TextBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancelIssue = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCheckMgtKeyInUse = new System.Windows.Forms.Button();
            this.txtMgtKey = new System.Windows.Forms.TextBox();
            this.txtFormCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.label.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox6);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Location = new System.Drawing.Point(13, 46);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(587, 104);
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "팝빌 기본 API";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.btnGetPartnerBalance);
            this.GroupBox6.Location = new System.Drawing.Point(282, 16);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(131, 83);
            this.GroupBox6.TabIndex = 3;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "파트너 관련";
            // 
            // btnGetPartnerBalance
            // 
            this.btnGetPartnerBalance.Location = new System.Drawing.Point(6, 19);
            this.btnGetPartnerBalance.Name = "btnGetPartnerBalance";
            this.btnGetPartnerBalance.Size = new System.Drawing.Size(118, 26);
            this.btnGetPartnerBalance.TabIndex = 3;
            this.btnGetPartnerBalance.Text = "파트너포인트 확인";
            this.btnGetPartnerBalance.UseVisualStyleBackColor = true;
            this.btnGetPartnerBalance.Click += new System.EventHandler(this.btnGetPartnerBalance_Click);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.btnGetPopbillURL_CHRG);
            this.GroupBox5.Controls.Add(this.btnGetPopbillURL_LOGIN);
            this.GroupBox5.Location = new System.Drawing.Point(421, 17);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(143, 83);
            this.GroupBox5.TabIndex = 2;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "기타";
            // 
            // btnGetPopbillURL_CHRG
            // 
            this.btnGetPopbillURL_CHRG.Location = new System.Drawing.Point(6, 51);
            this.btnGetPopbillURL_CHRG.Name = "btnGetPopbillURL_CHRG";
            this.btnGetPopbillURL_CHRG.Size = new System.Drawing.Size(133, 26);
            this.btnGetPopbillURL_CHRG.TabIndex = 1;
            this.btnGetPopbillURL_CHRG.Text = "포인트 충전 URL";
            this.btnGetPopbillURL_CHRG.UseVisualStyleBackColor = true;
            this.btnGetPopbillURL_CHRG.Click += new System.EventHandler(this.btnGetPopbillURL_CHRG_Click);
            // 
            // btnGetPopbillURL_LOGIN
            // 
            this.btnGetPopbillURL_LOGIN.Location = new System.Drawing.Point(6, 20);
            this.btnGetPopbillURL_LOGIN.Name = "btnGetPopbillURL_LOGIN";
            this.btnGetPopbillURL_LOGIN.Size = new System.Drawing.Size(133, 26);
            this.btnGetPopbillURL_LOGIN.TabIndex = 0;
            this.btnGetPopbillURL_LOGIN.Text = "팝빌 로그인 URL";
            this.btnGetPopbillURL_LOGIN.UseVisualStyleBackColor = true;
            this.btnGetPopbillURL_LOGIN.Click += new System.EventHandler(this.btnGetPopbillURL_LOGIN_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnUnitCost);
            this.GroupBox3.Controls.Add(this.btnGetBalance);
            this.GroupBox3.Location = new System.Drawing.Point(145, 17);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(131, 83);
            this.GroupBox3.TabIndex = 1;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "포인트 관련";
            // 
            // btnUnitCost
            // 
            this.btnUnitCost.Location = new System.Drawing.Point(6, 51);
            this.btnUnitCost.Name = "btnUnitCost";
            this.btnUnitCost.Size = new System.Drawing.Size(118, 26);
            this.btnUnitCost.TabIndex = 3;
            this.btnUnitCost.Text = "요금 단가 확인";
            this.btnUnitCost.UseVisualStyleBackColor = true;
            this.btnUnitCost.Click += new System.EventHandler(this.btnUnitCost_Click);
            // 
            // btnGetBalance
            // 
            this.btnGetBalance.Location = new System.Drawing.Point(6, 19);
            this.btnGetBalance.Name = "btnGetBalance";
            this.btnGetBalance.Size = new System.Drawing.Size(118, 26);
            this.btnGetBalance.TabIndex = 2;
            this.btnGetBalance.Text = "잔여포인트 확인";
            this.btnGetBalance.UseVisualStyleBackColor = true;
            this.btnGetBalance.Click += new System.EventHandler(this.btnGetBalance_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnCheckIsMember);
            this.GroupBox2.Controls.Add(this.btnJoinMember);
            this.GroupBox2.Location = new System.Drawing.Point(6, 17);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(131, 83);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "회원 정보";
            // 
            // btnCheckIsMember
            // 
            this.btnCheckIsMember.Location = new System.Drawing.Point(6, 19);
            this.btnCheckIsMember.Name = "btnCheckIsMember";
            this.btnCheckIsMember.Size = new System.Drawing.Size(118, 26);
            this.btnCheckIsMember.TabIndex = 2;
            this.btnCheckIsMember.Text = "가입여부 확인";
            this.btnCheckIsMember.UseVisualStyleBackColor = true;
            this.btnCheckIsMember.Click += new System.EventHandler(this.btnCheckIsMember_Click);
            // 
            // btnJoinMember
            // 
            this.btnJoinMember.Location = new System.Drawing.Point(6, 51);
            this.btnJoinMember.Name = "btnJoinMember";
            this.btnJoinMember.Size = new System.Drawing.Size(118, 26);
            this.btnJoinMember.TabIndex = 1;
            this.btnJoinMember.Text = "회원 가입";
            this.btnJoinMember.UseVisualStyleBackColor = true;
            this.btnJoinMember.Click += new System.EventHandler(this.btnJoinMember_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(210, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(77, 12);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "회원아이디 : ";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(293, 12);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 6;
            this.txtUserID.Text = "testkorea";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 12);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "사업자번호 : ";
            // 
            // txtCorpNum
            // 
            this.txtCorpNum.Location = new System.Drawing.Point(92, 12);
            this.txtCorpNum.Name = "txtCorpNum";
            this.txtCorpNum.Size = new System.Drawing.Size(100, 21);
            this.txtCorpNum.TabIndex = 4;
            this.txtCorpNum.Text = "1234567890";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox11);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.label);
            this.groupBox4.Controls.Add(this.btnCheckMgtKeyInUse);
            this.groupBox4.Controls.Add(this.txtMgtKey);
            this.groupBox4.Controls.Add(this.txtFormCode);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cboItemCode);
            this.groupBox4.Location = new System.Drawing.Point(19, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(670, 466);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "전자명세서 관련 API";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnGetURL_SBOX);
            this.groupBox11.Controls.Add(this.btnGetURL_TBOX);
            this.groupBox11.Location = new System.Drawing.Point(515, 268);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(107, 86);
            this.groupBox11.TabIndex = 36;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "기타 URL";
            // 
            // btnGetURL_SBOX
            // 
            this.btnGetURL_SBOX.Location = new System.Drawing.Point(12, 50);
            this.btnGetURL_SBOX.Name = "btnGetURL_SBOX";
            this.btnGetURL_SBOX.Size = new System.Drawing.Size(84, 29);
            this.btnGetURL_SBOX.TabIndex = 25;
            this.btnGetURL_SBOX.Text = "발행 문서함";
            this.btnGetURL_SBOX.UseVisualStyleBackColor = true;
            this.btnGetURL_SBOX.Click += new System.EventHandler(this.btnGetURL_SBOX_Click);
            // 
            // btnGetURL_TBOX
            // 
            this.btnGetURL_TBOX.Location = new System.Drawing.Point(12, 15);
            this.btnGetURL_TBOX.Name = "btnGetURL_TBOX";
            this.btnGetURL_TBOX.Size = new System.Drawing.Size(84, 29);
            this.btnGetURL_TBOX.TabIndex = 9;
            this.btnGetURL_TBOX.Text = "임시 문서함";
            this.btnGetURL_TBOX.UseVisualStyleBackColor = true;
            this.btnGetURL_TBOX.Click += new System.EventHandler(this.btnGetURL_TBOX_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnGetPrintURL);
            this.groupBox10.Controls.Add(this.btnGetEPrintURL);
            this.groupBox10.Controls.Add(this.btnGetMassPrintURL);
            this.groupBox10.Controls.Add(this.btnGetMailURL);
            this.groupBox10.Controls.Add(this.btnGetPopUpURL);
            this.groupBox10.Location = new System.Drawing.Point(300, 268);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(198, 192);
            this.groupBox10.TabIndex = 35;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "인쇄 URL";
            // 
            // btnGetPrintURL
            // 
            this.btnGetPrintURL.Location = new System.Drawing.Point(11, 53);
            this.btnGetPrintURL.Name = "btnGetPrintURL";
            this.btnGetPrintURL.Size = new System.Drawing.Size(174, 29);
            this.btnGetPrintURL.TabIndex = 24;
            this.btnGetPrintURL.Text = "인쇄 팝업 URL";
            this.btnGetPrintURL.UseVisualStyleBackColor = true;
            this.btnGetPrintURL.Click += new System.EventHandler(this.btnGetPrintURL_Click);
            // 
            // btnGetEPrintURL
            // 
            this.btnGetEPrintURL.Location = new System.Drawing.Point(11, 88);
            this.btnGetEPrintURL.Name = "btnGetEPrintURL";
            this.btnGetEPrintURL.Size = new System.Drawing.Size(174, 29);
            this.btnGetEPrintURL.TabIndex = 23;
            this.btnGetEPrintURL.Text = "수신자 인쇄 팝업 URL";
            this.btnGetEPrintURL.UseVisualStyleBackColor = true;
            this.btnGetEPrintURL.Click += new System.EventHandler(this.btnGetEPrintURL_Click);
            // 
            // btnGetMassPrintURL
            // 
            this.btnGetMassPrintURL.Location = new System.Drawing.Point(11, 123);
            this.btnGetMassPrintURL.Name = "btnGetMassPrintURL";
            this.btnGetMassPrintURL.Size = new System.Drawing.Size(174, 29);
            this.btnGetMassPrintURL.TabIndex = 22;
            this.btnGetMassPrintURL.Text = "다량 인쇄 팝업 URL";
            this.btnGetMassPrintURL.UseVisualStyleBackColor = true;
            this.btnGetMassPrintURL.Click += new System.EventHandler(this.btnGetMassPrintURL_Click);
            // 
            // btnGetMailURL
            // 
            this.btnGetMailURL.Location = new System.Drawing.Point(11, 158);
            this.btnGetMailURL.Name = "btnGetMailURL";
            this.btnGetMailURL.Size = new System.Drawing.Size(174, 29);
            this.btnGetMailURL.TabIndex = 21;
            this.btnGetMailURL.Text = "이메일(공급받는자) 링크 URL";
            this.btnGetMailURL.UseVisualStyleBackColor = true;
            this.btnGetMailURL.Click += new System.EventHandler(this.btnGetMailURL_Click);
            // 
            // btnGetPopUpURL
            // 
            this.btnGetPopUpURL.Location = new System.Drawing.Point(11, 18);
            this.btnGetPopUpURL.Name = "btnGetPopUpURL";
            this.btnGetPopUpURL.Size = new System.Drawing.Size(174, 29);
            this.btnGetPopUpURL.TabIndex = 5;
            this.btnGetPopUpURL.Text = "문서내용 보기 팝업 URL";
            this.btnGetPopUpURL.UseVisualStyleBackColor = true;
            this.btnGetPopUpURL.Click += new System.EventHandler(this.btnGetPopUpURL_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnSendSMS);
            this.groupBox9.Controls.Add(this.btnSendFAX);
            this.groupBox9.Controls.Add(this.btnSendEmail);
            this.groupBox9.Location = new System.Drawing.Point(156, 268);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(126, 120);
            this.groupBox9.TabIndex = 34;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "부가 서비스";
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Location = new System.Drawing.Point(12, 51);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(103, 29);
            this.btnSendSMS.TabIndex = 28;
            this.btnSendSMS.Text = "문자 전송";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnSendFAX
            // 
            this.btnSendFAX.Location = new System.Drawing.Point(12, 86);
            this.btnSendFAX.Name = "btnSendFAX";
            this.btnSendFAX.Size = new System.Drawing.Size(103, 29);
            this.btnSendFAX.TabIndex = 27;
            this.btnSendFAX.Text = "팩스 전송";
            this.btnSendFAX.UseVisualStyleBackColor = true;
            this.btnSendFAX.Click += new System.EventHandler(this.btnSendFAX_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(12, 16);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(103, 29);
            this.btnSendEmail.TabIndex = 26;
            this.btnSendEmail.Text = "이메일 전송";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnGetDetailInfo);
            this.groupBox8.Controls.Add(this.btnGetInfos);
            this.groupBox8.Controls.Add(this.btnGetLogs);
            this.groupBox8.Controls.Add(this.btnGetInfo);
            this.groupBox8.Location = new System.Drawing.Point(18, 268);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(122, 154);
            this.groupBox8.TabIndex = 33;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "문서 정보";
            // 
            // btnGetDetailInfo
            // 
            this.btnGetDetailInfo.Location = new System.Drawing.Point(9, 49);
            this.btnGetDetailInfo.Name = "btnGetDetailInfo";
            this.btnGetDetailInfo.Size = new System.Drawing.Size(103, 29);
            this.btnGetDetailInfo.TabIndex = 32;
            this.btnGetDetailInfo.Text = "문서 상세정보";
            this.btnGetDetailInfo.UseVisualStyleBackColor = true;
            this.btnGetDetailInfo.Click += new System.EventHandler(this.btnGetDetailInfo_Click);
            // 
            // btnGetInfos
            // 
            this.btnGetInfos.Location = new System.Drawing.Point(9, 84);
            this.btnGetInfos.Name = "btnGetInfos";
            this.btnGetInfos.Size = new System.Drawing.Size(103, 29);
            this.btnGetInfos.TabIndex = 31;
            this.btnGetInfos.Text = "문자 전송(대량)";
            this.btnGetInfos.UseVisualStyleBackColor = true;
            this.btnGetInfos.Click += new System.EventHandler(this.btnGetInfos_Click);
            // 
            // btnGetLogs
            // 
            this.btnGetLogs.Location = new System.Drawing.Point(9, 119);
            this.btnGetLogs.Name = "btnGetLogs";
            this.btnGetLogs.Size = new System.Drawing.Size(103, 29);
            this.btnGetLogs.TabIndex = 30;
            this.btnGetLogs.Text = "문서 이력";
            this.btnGetLogs.UseVisualStyleBackColor = true;
            this.btnGetLogs.Click += new System.EventHandler(this.btnGetLogs_Click);
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(9, 14);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(103, 29);
            this.btnGetInfo.TabIndex = 29;
            this.btnGetInfo.Text = "문서 정보";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtFileID);
            this.groupBox7.Controls.Add(this.btnDeleteFile);
            this.groupBox7.Controls.Add(this.btnGetFiles);
            this.groupBox7.Controls.Add(this.btnAttachFile);
            this.groupBox7.Location = new System.Drawing.Point(358, 173);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(293, 82);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "첨부파일 관련";
            // 
            // txtFileID
            // 
            this.txtFileID.Location = new System.Drawing.Point(25, 49);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.Size = new System.Drawing.Size(185, 21);
            this.txtFileID.TabIndex = 8;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(213, 45);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(69, 29);
            this.btnDeleteFile.TabIndex = 7;
            this.btnDeleteFile.Text = "파일 삭제";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(102, 17);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(92, 29);
            this.btnGetFiles.TabIndex = 6;
            this.btnGetFiles.Text = "첨부파일 목록";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Location = new System.Drawing.Point(24, 17);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(69, 29);
            this.btnAttachFile.TabIndex = 5;
            this.btnAttachFile.Text = "파일 첨부";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // label
            // 
            this.label.Controls.Add(this.btnDelete);
            this.label.Controls.Add(this.btnCancelIssue);
            this.label.Controls.Add(this.btnIssue);
            this.label.Controls.Add(this.panel1);
            this.label.Location = new System.Drawing.Point(358, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(298, 152);
            this.label.TabIndex = 19;
            this.label.TabStop = false;
            this.label.Text = "전자명세서 발행 프로세스";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(195, 118);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancelIssue
            // 
            this.btnCancelIssue.Location = new System.Drawing.Point(80, 118);
            this.btnCancelIssue.Name = "btnCancelIssue";
            this.btnCancelIssue.Size = new System.Drawing.Size(69, 29);
            this.btnCancelIssue.TabIndex = 4;
            this.btnCancelIssue.Text = "발행취소";
            this.btnCancelIssue.UseVisualStyleBackColor = true;
            this.btnCancelIssue.Click += new System.EventHandler(this.btnCancelIssue_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(80, 76);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(69, 29);
            this.btnIssue.TabIndex = 3;
            this.btnIssue.Text = "발행";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(28, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 40);
            this.panel1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(167, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(69, 29);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(92, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(69, 29);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "등록";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "임시저장";
            // 
            // btnCheckMgtKeyInUse
            // 
            this.btnCheckMgtKeyInUse.Location = new System.Drawing.Point(188, 111);
            this.btnCheckMgtKeyInUse.Name = "btnCheckMgtKeyInUse";
            this.btnCheckMgtKeyInUse.Size = new System.Drawing.Size(143, 27);
            this.btnCheckMgtKeyInUse.TabIndex = 3;
            this.btnCheckMgtKeyInUse.Text = "관리번호 사용여부 확인";
            this.btnCheckMgtKeyInUse.UseVisualStyleBackColor = true;
            this.btnCheckMgtKeyInUse.Click += new System.EventHandler(this.btnCheckMgtKeyInUse_Click);
            // 
            // txtMgtKey
            // 
            this.txtMgtKey.Location = new System.Drawing.Point(188, 84);
            this.txtMgtKey.Name = "txtMgtKey";
            this.txtMgtKey.Size = new System.Drawing.Size(143, 21);
            this.txtMgtKey.TabIndex = 18;
            this.txtMgtKey.Text = "20150312-01";
            // 
            // txtFormCode
            // 
            this.txtFormCode.Location = new System.Drawing.Point(188, 57);
            this.txtFormCode.Name = "txtFormCode";
            this.txtFormCode.Size = new System.Drawing.Size(143, 21);
            this.txtFormCode.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "문서관리번호(MgtKey) : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "맞춤 양식코드(FormCode) :  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "명세서 종류 : ";
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Items.AddRange(new object[] {
            "거래명세서",
            "청구서",
            "견적서",
            "발주서",
            "입금표",
            "영수증"});
            this.cboItemCode.Location = new System.Drawing.Point(188, 32);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(121, 20);
            this.cboItemCode.TabIndex = 0;
            this.cboItemCode.Text = "거래명세서";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "fileDialog";
            // 
            // frmExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 631);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtCorpNum);
            this.Controls.Add(this.Label1);
            this.Name = "frmExample";
            this.Text = "팝빌 전자명세서 SDK C# Example";            
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.label.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button btnGetPartnerBalance;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button btnGetPopbillURL_CHRG;
        internal System.Windows.Forms.Button btnGetPopbillURL_LOGIN;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnUnitCost;
        internal System.Windows.Forms.Button btnGetBalance;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnCheckIsMember;
        internal System.Windows.Forms.Button btnJoinMember;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtCorpNum;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboItemCode;
        internal System.Windows.Forms.Button btnCheckMgtKeyInUse;
        private System.Windows.Forms.TextBox txtMgtKey;
        private System.Windows.Forms.TextBox txtFormCode;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancelIssue;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.TextBox txtFileID;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.Button btnGetPrintURL;
        private System.Windows.Forms.Button btnGetEPrintURL;
        private System.Windows.Forms.Button btnGetMassPrintURL;
        private System.Windows.Forms.Button btnGetMailURL;
        private System.Windows.Forms.Button btnGetPopUpURL;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnGetDetailInfo;
        private System.Windows.Forms.Button btnGetInfos;
        private System.Windows.Forms.Button btnGetLogs;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Button btnSendFAX;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnGetURL_SBOX;
        private System.Windows.Forms.Button btnGetURL_TBOX;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;

    }
}

