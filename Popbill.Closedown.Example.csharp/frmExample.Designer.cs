namespace Popbill.Closedown.Example.csharp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCorpNum = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnUnitCost = new System.Windows.Forms.Button();
            this.btnGetBalance = new System.Windows.Forms.Button();
            this.btnCheckIsMember = new System.Windows.Forms.Button();
            this.btnJoinMember = new System.Windows.Forms.Button();
            this.btnGetPopbillURL_CHRG = new System.Windows.Forms.Button();
            this.btnGetPopbillURL_LOGIN = new System.Windows.Forms.Button();
            this.btnGetPartnerBalance = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheckCorpNum = new System.Windows.Forms.TextBox();
            this.btnCheckCorpNum = new System.Windows.Forms.Button();
            this.btnCheckCorpNums = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "팝빌 사업자번호 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "팝빌 아이디 : ";
            // 
            // txtCorpNum
            // 
            this.txtCorpNum.Location = new System.Drawing.Point(135, 15);
            this.txtCorpNum.Name = "txtCorpNum";
            this.txtCorpNum.Size = new System.Drawing.Size(110, 21);
            this.txtCorpNum.TabIndex = 2;
            this.txtCorpNum.Text = "1234567890";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(361, 15);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 3;
            this.txtUserID.Text = "testkorea";
            // 
            // btnUnitCost
            // 
            this.btnUnitCost.Location = new System.Drawing.Point(172, 96);
            this.btnUnitCost.Name = "btnUnitCost";
            this.btnUnitCost.Size = new System.Drawing.Size(106, 26);
            this.btnUnitCost.TabIndex = 4;
            this.btnUnitCost.Text = "조회단가 확인";
            this.btnUnitCost.UseVisualStyleBackColor = true;
            this.btnUnitCost.Click += new System.EventHandler(this.btnUnitCost_Click);
            // 
            // btnGetBalance
            // 
            this.btnGetBalance.Location = new System.Drawing.Point(172, 64);
            this.btnGetBalance.Name = "btnGetBalance";
            this.btnGetBalance.Size = new System.Drawing.Size(106, 26);
            this.btnGetBalance.TabIndex = 5;
            this.btnGetBalance.Text = "잔여포인트 확인";
            this.btnGetBalance.UseVisualStyleBackColor = true;
            this.btnGetBalance.Click += new System.EventHandler(this.btnGetBalance_Click);
            // 
            // btnCheckIsMember
            // 
            this.btnCheckIsMember.Location = new System.Drawing.Point(38, 62);
            this.btnCheckIsMember.Name = "btnCheckIsMember";
            this.btnCheckIsMember.Size = new System.Drawing.Size(104, 26);
            this.btnCheckIsMember.TabIndex = 6;
            this.btnCheckIsMember.Text = "가입여부 확인";
            this.btnCheckIsMember.UseVisualStyleBackColor = true;
            this.btnCheckIsMember.Click += new System.EventHandler(this.btnCheckIsMember_Click);
            // 
            // btnJoinMember
            // 
            this.btnJoinMember.Location = new System.Drawing.Point(38, 94);
            this.btnJoinMember.Name = "btnJoinMember";
            this.btnJoinMember.Size = new System.Drawing.Size(104, 26);
            this.btnJoinMember.TabIndex = 7;
            this.btnJoinMember.Text = "회원가입";
            this.btnJoinMember.UseVisualStyleBackColor = true;
            this.btnJoinMember.Click += new System.EventHandler(this.btnJoinMember_Click);
            // 
            // btnGetPopbillURL_CHRG
            // 
            this.btnGetPopbillURL_CHRG.Location = new System.Drawing.Point(311, 93);
            this.btnGetPopbillURL_CHRG.Name = "btnGetPopbillURL_CHRG";
            this.btnGetPopbillURL_CHRG.Size = new System.Drawing.Size(108, 26);
            this.btnGetPopbillURL_CHRG.TabIndex = 9;
            this.btnGetPopbillURL_CHRG.Text = "포인트 충전 URL";
            this.btnGetPopbillURL_CHRG.UseVisualStyleBackColor = true;
            this.btnGetPopbillURL_CHRG.Click += new System.EventHandler(this.btnGetPopbillURL_CHRG_Click);
            // 
            // btnGetPopbillURL_LOGIN
            // 
            this.btnGetPopbillURL_LOGIN.Location = new System.Drawing.Point(311, 61);
            this.btnGetPopbillURL_LOGIN.Name = "btnGetPopbillURL_LOGIN";
            this.btnGetPopbillURL_LOGIN.Size = new System.Drawing.Size(108, 26);
            this.btnGetPopbillURL_LOGIN.TabIndex = 8;
            this.btnGetPopbillURL_LOGIN.Text = "팝빌 로그인 URL";
            this.btnGetPopbillURL_LOGIN.UseVisualStyleBackColor = true;
            this.btnGetPopbillURL_LOGIN.Click += new System.EventHandler(this.btnGetPopbillURL_LOGIN_Click);
            // 
            // btnGetPartnerBalance
            // 
            this.btnGetPartnerBalance.Location = new System.Drawing.Point(449, 63);
            this.btnGetPartnerBalance.Name = "btnGetPartnerBalance";
            this.btnGetPartnerBalance.Size = new System.Drawing.Size(123, 26);
            this.btnGetPartnerBalance.TabIndex = 10;
            this.btnGetPartnerBalance.Text = "파트너포인트 확인";
            this.btnGetPartnerBalance.UseVisualStyleBackColor = true;
            this.btnGetPartnerBalance.Click += new System.EventHandler(this.btnGetPartnerBalance_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "조회 사업자번호 : ";
            // 
            // txtCheckCorpNum
            // 
            this.txtCheckCorpNum.Location = new System.Drawing.Point(140, 163);
            this.txtCheckCorpNum.Name = "txtCheckCorpNum";
            this.txtCheckCorpNum.Size = new System.Drawing.Size(100, 21);
            this.txtCheckCorpNum.TabIndex = 12;
            this.txtCheckCorpNum.Text = "4108600477";
            this.txtCheckCorpNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheckCorpNum_KeyDown);
            // 
            // btnCheckCorpNum
            // 
            this.btnCheckCorpNum.Location = new System.Drawing.Point(249, 158);
            this.btnCheckCorpNum.Name = "btnCheckCorpNum";
            this.btnCheckCorpNum.Size = new System.Drawing.Size(79, 28);
            this.btnCheckCorpNum.TabIndex = 13;
            this.btnCheckCorpNum.Text = "단건조회";
            this.btnCheckCorpNum.UseVisualStyleBackColor = true;
            this.btnCheckCorpNum.Click += new System.EventHandler(this.btnCheckCorpNum_Click);
            // 
            // btnCheckCorpNums
            // 
            this.btnCheckCorpNums.Location = new System.Drawing.Point(334, 158);
            this.btnCheckCorpNums.Name = "btnCheckCorpNums";
            this.btnCheckCorpNums.Size = new System.Drawing.Size(79, 28);
            this.btnCheckCorpNums.TabIndex = 14;
            this.btnCheckCorpNums.Text = "대량조회";
            this.btnCheckCorpNums.UseVisualStyleBackColor = true;
            this.btnCheckCorpNums.Click += new System.EventHandler(this.btnCheckCorpNums_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(29, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 59);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "휴폐업조회 API ";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(30, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 84);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "회원정보";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(164, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 86);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "포인트 관련";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(301, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 88);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "팝업 URL";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(442, 41);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(140, 87);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "파트너 관련";
            // 
            // frmExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 222);
            this.Controls.Add(this.btnCheckCorpNums);
            this.Controls.Add(this.btnCheckCorpNum);
            this.Controls.Add(this.txtCheckCorpNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetPartnerBalance);
            this.Controls.Add(this.btnGetPopbillURL_CHRG);
            this.Controls.Add(this.btnGetPopbillURL_LOGIN);
            this.Controls.Add(this.btnJoinMember);
            this.Controls.Add(this.btnCheckIsMember);
            this.Controls.Add(this.btnGetBalance);
            this.Controls.Add(this.btnUnitCost);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtCorpNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Name = "frmExample";
            this.Text = "팝빌 휴폐업조회 API SDK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCorpNum;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnUnitCost;
        private System.Windows.Forms.Button btnGetBalance;
        private System.Windows.Forms.Button btnCheckIsMember;
        private System.Windows.Forms.Button btnJoinMember;
        private System.Windows.Forms.Button btnGetPopbillURL_CHRG;
        private System.Windows.Forms.Button btnGetPopbillURL_LOGIN;
        private System.Windows.Forms.Button btnGetPartnerBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheckCorpNum;
        private System.Windows.Forms.Button btnCheckCorpNum;
        private System.Windows.Forms.Button btnCheckCorpNums;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

