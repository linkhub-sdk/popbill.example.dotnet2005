namespace Popbill.EasyFin.Bank.Example.csharp
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
            this.txtUserId = new System.Windows.Forms.TextBox();
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
            this.txtCorpNum = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobID = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnGetFlatRateState = new System.Windows.Forms.Button();
            this.btnGetFlatRatePopUpURL = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnListBankAccount = new System.Windows.Forms.Button();
            this.btnGetBankAccountMgtURL = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSaveMemo = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnListJobState = new System.Windows.Forms.Button();
            this.btnGetJobState = new System.Windows.Forms.Button();
            this.btnRequestJob = new System.Windows.Forms.Button();
            this.btnRegistBankAccount = new System.Windows.Forms.Button();
            this.btnUpdateBankAccount = new System.Windows.Forms.Button();
            this.btnGetBankAccountInfo = new System.Windows.Forms.Button();
            this.btnCloseBankAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(400, 16);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(143, 21);
            this.txtUserId.TabIndex = 15;
            this.txtUserId.Text = "testkorea";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox6);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Location = new System.Drawing.Point(22, 43);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(948, 108);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "팝빌 기본 API";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.btnGetPartnerBalance);
            this.GroupBox6.Location = new System.Drawing.Point(431, 17);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(131, 86);
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
            this.GroupBox5.Location = new System.Drawing.Point(282, 17);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(143, 86);
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
            this.GroupBox3.Size = new System.Drawing.Size(131, 86);
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
            this.GroupBox2.Size = new System.Drawing.Size(131, 86);
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
            this.Label2.Location = new System.Drawing.Point(323, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 12);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "팝빌아이디 :";
            // 
            // txtCorpNum
            // 
            this.txtCorpNum.Location = new System.Drawing.Point(160, 16);
            this.txtCorpNum.Name = "txtCorpNum";
            this.txtCorpNum.Size = new System.Drawing.Size(143, 21);
            this.txtCorpNum.TabIndex = 13;
            this.txtCorpNum.Text = "1234567890";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(34, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(129, 12);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "팝빌회원 사업자번호 : ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtTID);
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtJobID);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Location = new System.Drawing.Point(22, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(948, 433);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "계좌조회 API";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "거래내역 아이디 : ";
            // 
            // txtTID
            // 
            this.txtTID.Location = new System.Drawing.Point(398, 193);
            this.txtTID.Name = "txtTID";
            this.txtTID.Size = new System.Drawing.Size(264, 21);
            this.txtTID.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(17, 222);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(918, 196);
            this.listBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "작업아이디 : ";
            // 
            // txtJobID
            // 
            this.txtJobID.Location = new System.Drawing.Point(93, 195);
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Size = new System.Drawing.Size(176, 21);
            this.txtJobID.TabIndex = 4;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnGetFlatRateState);
            this.groupBox10.Controls.Add(this.btnGetFlatRatePopUpURL);
            this.groupBox10.Location = new System.Drawing.Point(762, 26);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(173, 157);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "정액제 관리";
            // 
            // btnGetFlatRateState
            // 
            this.btnGetFlatRateState.Location = new System.Drawing.Point(6, 60);
            this.btnGetFlatRateState.Name = "btnGetFlatRateState";
            this.btnGetFlatRateState.Size = new System.Drawing.Size(157, 34);
            this.btnGetFlatRateState.TabIndex = 6;
            this.btnGetFlatRateState.Text = "정액제 서비스 상태 확인";
            this.btnGetFlatRateState.UseVisualStyleBackColor = true;
            this.btnGetFlatRateState.Click += new System.EventHandler(this.btnGetFlatRateState_Click);
            // 
            // btnGetFlatRatePopUpURL
            // 
            this.btnGetFlatRatePopUpURL.Location = new System.Drawing.Point(6, 20);
            this.btnGetFlatRatePopUpURL.Name = "btnGetFlatRatePopUpURL";
            this.btnGetFlatRatePopUpURL.Size = new System.Drawing.Size(157, 34);
            this.btnGetFlatRatePopUpURL.TabIndex = 5;
            this.btnGetFlatRatePopUpURL.Text = "정액제 신청 팝업 URL";
            this.btnGetFlatRatePopUpURL.UseVisualStyleBackColor = true;
            this.btnGetFlatRatePopUpURL.Click += new System.EventHandler(this.btnGetFlatRatePopUpURL_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button1);
            this.groupBox9.Controls.Add(this.btnCloseBankAccount);
            this.groupBox9.Controls.Add(this.btnGetBankAccountInfo);
            this.groupBox9.Controls.Add(this.btnUpdateBankAccount);
            this.groupBox9.Controls.Add(this.btnRegistBankAccount);
            this.groupBox9.Controls.Add(this.btnListBankAccount);
            this.groupBox9.Controls.Add(this.btnGetBankAccountMgtURL);
            this.groupBox9.Location = new System.Drawing.Point(336, 26);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(416, 157);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "계좌 관리";
            // 
            // btnListBankAccount
            // 
            this.btnListBankAccount.Location = new System.Drawing.Point(141, 61);
            this.btnListBankAccount.Name = "btnListBankAccount";
            this.btnListBankAccount.Size = new System.Drawing.Size(121, 34);
            this.btnListBankAccount.TabIndex = 5;
            this.btnListBankAccount.Text = "계좌 목록 확인";
            this.btnListBankAccount.UseVisualStyleBackColor = true;
            this.btnListBankAccount.Click += new System.EventHandler(this.btnListBankAccount_Click);
            // 
            // btnGetBankAccountMgtURL
            // 
            this.btnGetBankAccountMgtURL.Location = new System.Drawing.Point(6, 101);
            this.btnGetBankAccountMgtURL.Name = "btnGetBankAccountMgtURL";
            this.btnGetBankAccountMgtURL.Size = new System.Drawing.Size(129, 34);
            this.btnGetBankAccountMgtURL.TabIndex = 4;
            this.btnGetBankAccountMgtURL.Text = "계좌 관리 팝업 URL";
            this.btnGetBankAccountMgtURL.UseVisualStyleBackColor = true;
            this.btnGetBankAccountMgtURL.Click += new System.EventHandler(this.btnGetBankAccountMgtURL_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnSaveMemo);
            this.groupBox8.Controls.Add(this.btnSummary);
            this.groupBox8.Controls.Add(this.btnSearch);
            this.groupBox8.Location = new System.Drawing.Point(178, 26);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(146, 157);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "계좌 거래내역 조회 ";
            // 
            // btnSaveMemo
            // 
            this.btnSaveMemo.Location = new System.Drawing.Point(7, 101);
            this.btnSaveMemo.Name = "btnSaveMemo";
            this.btnSaveMemo.Size = new System.Drawing.Size(129, 34);
            this.btnSaveMemo.TabIndex = 3;
            this.btnSaveMemo.Text = "거래내역 메모저장";
            this.btnSaveMemo.UseVisualStyleBackColor = true;
            this.btnSaveMemo.Click += new System.EventHandler(this.btnSaveMemo_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(7, 61);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(129, 34);
            this.btnSummary.TabIndex = 2;
            this.btnSummary.Text = "거래내역 요약정보";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(8, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "거래내역 조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnListJobState);
            this.groupBox7.Controls.Add(this.btnGetJobState);
            this.groupBox7.Controls.Add(this.btnRequestJob);
            this.groupBox7.Location = new System.Drawing.Point(17, 26);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(146, 157);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "계좌 거래내역 수집";
            // 
            // btnListJobState
            // 
            this.btnListJobState.Location = new System.Drawing.Point(8, 101);
            this.btnListJobState.Name = "btnListJobState";
            this.btnListJobState.Size = new System.Drawing.Size(129, 34);
            this.btnListJobState.TabIndex = 2;
            this.btnListJobState.Text = "수집 목록 조회";
            this.btnListJobState.UseVisualStyleBackColor = true;
            this.btnListJobState.Click += new System.EventHandler(this.btnListJobState_Click);
            // 
            // btnGetJobState
            // 
            this.btnGetJobState.Location = new System.Drawing.Point(7, 61);
            this.btnGetJobState.Name = "btnGetJobState";
            this.btnGetJobState.Size = new System.Drawing.Size(129, 34);
            this.btnGetJobState.TabIndex = 1;
            this.btnGetJobState.Text = "수집 결과 조회";
            this.btnGetJobState.UseVisualStyleBackColor = true;
            this.btnGetJobState.Click += new System.EventHandler(this.btnGetJobState_Click);
            // 
            // btnRequestJob
            // 
            this.btnRequestJob.Location = new System.Drawing.Point(8, 20);
            this.btnRequestJob.Name = "btnRequestJob";
            this.btnRequestJob.Size = new System.Drawing.Size(129, 34);
            this.btnRequestJob.TabIndex = 0;
            this.btnRequestJob.Text = "수집 요청";
            this.btnRequestJob.UseVisualStyleBackColor = true;
            this.btnRequestJob.Click += new System.EventHandler(this.btnRequestJob_Click);
            // 
            // btnRegistBankAccount
            // 
            this.btnRegistBankAccount.Location = new System.Drawing.Point(6, 20);
            this.btnRegistBankAccount.Name = "btnRegistBankAccount";
            this.btnRegistBankAccount.Size = new System.Drawing.Size(129, 34);
            this.btnRegistBankAccount.TabIndex = 6;
            this.btnRegistBankAccount.Text = "계좌 등록";
            this.btnRegistBankAccount.UseVisualStyleBackColor = true;
            this.btnRegistBankAccount.Click += new System.EventHandler(this.btnRegistBankAccount_Click);
            // 
            // btnUpdateBankAccount
            // 
            this.btnUpdateBankAccount.Location = new System.Drawing.Point(6, 60);
            this.btnUpdateBankAccount.Name = "btnUpdateBankAccount";
            this.btnUpdateBankAccount.Size = new System.Drawing.Size(129, 34);
            this.btnUpdateBankAccount.TabIndex = 7;
            this.btnUpdateBankAccount.Text = "계좌정보 수정";
            this.btnUpdateBankAccount.UseVisualStyleBackColor = true;
            this.btnUpdateBankAccount.Click += new System.EventHandler(this.btnUpdateBankAccount_Click);
            // 
            // btnGetBankAccountInfo
            // 
            this.btnGetBankAccountInfo.Location = new System.Drawing.Point(141, 20);
            this.btnGetBankAccountInfo.Name = "btnGetBankAccountInfo";
            this.btnGetBankAccountInfo.Size = new System.Drawing.Size(121, 34);
            this.btnGetBankAccountInfo.TabIndex = 8;
            this.btnGetBankAccountInfo.Text = "계좌정보 확인";
            this.btnGetBankAccountInfo.UseVisualStyleBackColor = true;
            this.btnGetBankAccountInfo.Click += new System.EventHandler(this.btnGetBankAccountInfo_Click);
            // 
            // btnCloseBankAccount
            // 
            this.btnCloseBankAccount.Location = new System.Drawing.Point(268, 20);
            this.btnCloseBankAccount.Name = "btnCloseBankAccount";
            this.btnCloseBankAccount.Size = new System.Drawing.Size(138, 34);
            this.btnCloseBankAccount.TabIndex = 9;
            this.btnCloseBankAccount.Text = "계좌 정액제 해지요청";
            this.btnCloseBankAccount.UseVisualStyleBackColor = true;
            this.btnCloseBankAccount.Click += new System.EventHandler(this.btnCloseBankAccount_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "정액제 해지요청 취소";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 622);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtCorpNum);
            this.Controls.Add(this.Label1);
            this.Name = "frmExample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "팝빌 계좌조회 API SDK Example";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtUserId;
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
        internal System.Windows.Forms.TextBox txtCorpNum;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnListJobState;
        private System.Windows.Forms.Button btnGetJobState;
        private System.Windows.Forms.Button btnRequestJob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobID;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.Button btnSaveMemo;
        private System.Windows.Forms.Button btnGetBankAccountMgtURL;
        private System.Windows.Forms.Button btnListBankAccount;
        private System.Windows.Forms.Button btnGetFlatRateState;
        private System.Windows.Forms.Button btnGetFlatRatePopUpURL;
        private System.Windows.Forms.Button btnRegistBankAccount;
        private System.Windows.Forms.Button btnUpdateBankAccount;
        private System.Windows.Forms.Button btnGetBankAccountInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCloseBankAccount;
    }
}

