﻿namespace Popbill.Message.Example.csharp
{
    partial class frmExample
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.getPopbillURL_CHRG = new System.Windows.Forms.Button();
            this.getPopbillURL_LOGIN = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUnitCost_LMS = new System.Windows.Forms.Button();
            this.btnGetPartnerBalance = new System.Windows.Forms.Button();
            this.btnUnitCost = new System.Windows.Forms.Button();
            this.btnGetBalance = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckIsMember = new System.Windows.Forms.Button();
            this.btnJoinMember = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCorpNum = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCancelReserve = new System.Windows.Forms.Button();
            this.btnGetMessageResult = new System.Windows.Forms.Button();
            this.btnGetURL = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSendXMS_same = new System.Windows.Forms.Button();
            this.btnSendXMS_hund = new System.Windows.Forms.Button();
            this.btnSendXMS_one = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnSendLMS_same = new System.Windows.Forms.Button();
            this.btnSendLMS_hund = new System.Windows.Forms.Button();
            this.btnSendLMS_one = new System.Windows.Forms.Button();
            this.txtReceiptNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSendSMS_Same = new System.Windows.Forms.Button();
            this.btn_SendSMS_hund = new System.Windows.Forms.Button();
            this.btnSendSMS_one = new System.Windows.Forms.Button();
            this.txtReserveDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(320, 4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(143, 21);
            this.txtUserId.TabIndex = 15;
            this.txtUserId.Text = "testkorea";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Location = new System.Drawing.Point(6, 31);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(566, 106);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "팝빌 기본 API";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.getPopbillURL_CHRG);
            this.GroupBox5.Controls.Add(this.getPopbillURL_LOGIN);
            this.GroupBox5.Location = new System.Drawing.Point(423, 17);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(131, 83);
            this.GroupBox5.TabIndex = 2;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "기타";
            // 
            // getPopbillURL_CHRG
            // 
            this.getPopbillURL_CHRG.Location = new System.Drawing.Point(6, 48);
            this.getPopbillURL_CHRG.Name = "getPopbillURL_CHRG";
            this.getPopbillURL_CHRG.Size = new System.Drawing.Size(118, 26);
            this.getPopbillURL_CHRG.TabIndex = 2;
            this.getPopbillURL_CHRG.Text = "포인트 충전 URL";
            this.getPopbillURL_CHRG.UseVisualStyleBackColor = true;
            this.getPopbillURL_CHRG.Click += new System.EventHandler(this.getPopbillURL_CHRG_Click);
            // 
            // getPopbillURL_LOGIN
            // 
            this.getPopbillURL_LOGIN.Location = new System.Drawing.Point(6, 16);
            this.getPopbillURL_LOGIN.Name = "getPopbillURL_LOGIN";
            this.getPopbillURL_LOGIN.Size = new System.Drawing.Size(118, 26);
            this.getPopbillURL_LOGIN.TabIndex = 0;
            this.getPopbillURL_LOGIN.Text = "팝빌 로그인 URL";
            this.getPopbillURL_LOGIN.UseVisualStyleBackColor = true;
            this.getPopbillURL_LOGIN.Click += new System.EventHandler(this.getPopbillURL_LOGIN_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnUnitCost_LMS);
            this.GroupBox3.Controls.Add(this.btnGetPartnerBalance);
            this.GroupBox3.Controls.Add(this.btnUnitCost);
            this.GroupBox3.Controls.Add(this.btnGetBalance);
            this.GroupBox3.Location = new System.Drawing.Point(145, 17);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(272, 83);
            this.GroupBox3.TabIndex = 1;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "포인트 관련";
            // 
            // btnUnitCost_LMS
            // 
            this.btnUnitCost_LMS.Location = new System.Drawing.Point(15, 48);
            this.btnUnitCost_LMS.Name = "btnUnitCost_LMS";
            this.btnUnitCost_LMS.Size = new System.Drawing.Size(118, 26);
            this.btnUnitCost_LMS.TabIndex = 4;
            this.btnUnitCost_LMS.Text = "장문 단가 확인";
            this.btnUnitCost_LMS.UseVisualStyleBackColor = true;
            this.btnUnitCost_LMS.Click += new System.EventHandler(this.btnUnitCost_LMS_Click);
            // 
            // btnGetPartnerBalance
            // 
            this.btnGetPartnerBalance.Location = new System.Drawing.Point(143, 48);
            this.btnGetPartnerBalance.Name = "btnGetPartnerBalance";
            this.btnGetPartnerBalance.Size = new System.Drawing.Size(118, 26);
            this.btnGetPartnerBalance.TabIndex = 3;
            this.btnGetPartnerBalance.Text = "파트너포인트 확인";
            this.btnGetPartnerBalance.UseVisualStyleBackColor = true;
            this.btnGetPartnerBalance.Click += new System.EventHandler(this.btnGetPartnerBalance_Click);
            // 
            // btnUnitCost
            // 
            this.btnUnitCost.Location = new System.Drawing.Point(15, 16);
            this.btnUnitCost.Name = "btnUnitCost";
            this.btnUnitCost.Size = new System.Drawing.Size(118, 26);
            this.btnUnitCost.TabIndex = 3;
            this.btnUnitCost.Text = "단문 단가 확인";
            this.btnUnitCost.UseVisualStyleBackColor = true;
            this.btnUnitCost.Click += new System.EventHandler(this.btnUnitCost_Click);
            // 
            // btnGetBalance
            // 
            this.btnGetBalance.Location = new System.Drawing.Point(143, 16);
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
            this.Label2.Location = new System.Drawing.Point(241, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 12);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "팝빌아이디 :";
            // 
            // txtCorpNum
            // 
            this.txtCorpNum.Location = new System.Drawing.Point(79, 4);
            this.txtCorpNum.Name = "txtCorpNum";
            this.txtCorpNum.Size = new System.Drawing.Size(143, 21);
            this.txtCorpNum.TabIndex = 13;
            this.txtCorpNum.Text = "1234568790";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 12);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "사업자번호 : ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.btnCancelReserve);
            this.groupBox4.Controls.Add(this.btnGetMessageResult);
            this.groupBox4.Controls.Add(this.btnGetURL);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.txtReceiptNum);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.txtReserveDT);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(6, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(565, 347);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "메시지 관련 기능";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(539, 203);
            this.dataGridView1.TabIndex = 23;
            // 
            // btnCancelReserve
            // 
            this.btnCancelReserve.Location = new System.Drawing.Point(429, 102);
            this.btnCancelReserve.Name = "btnCancelReserve";
            this.btnCancelReserve.Size = new System.Drawing.Size(121, 24);
            this.btnCancelReserve.TabIndex = 22;
            this.btnCancelReserve.Text = "예약 전송 취소";
            this.btnCancelReserve.UseVisualStyleBackColor = true;
            this.btnCancelReserve.Click += new System.EventHandler(this.btnCancelReserve_Click);
            // 
            // btnGetMessageResult
            // 
            this.btnGetMessageResult.Location = new System.Drawing.Point(302, 102);
            this.btnGetMessageResult.Name = "btnGetMessageResult";
            this.btnGetMessageResult.Size = new System.Drawing.Size(121, 24);
            this.btnGetMessageResult.TabIndex = 21;
            this.btnGetMessageResult.Text = "전송상태확인";
            this.btnGetMessageResult.UseVisualStyleBackColor = true;
            this.btnGetMessageResult.Click += new System.EventHandler(this.btnGetMessageResult_Click);
            // 
            // btnGetURL
            // 
            this.btnGetURL.Location = new System.Drawing.Point(429, 11);
            this.btnGetURL.Name = "btnGetURL";
            this.btnGetURL.Size = new System.Drawing.Size(121, 24);
            this.btnGetURL.TabIndex = 20;
            this.btnGetURL.Text = "전송내역조회 팝업";
            this.btnGetURL.UseVisualStyleBackColor = true;
            this.btnGetURL.Click += new System.EventHandler(this.btnGetURL_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnSendXMS_same);
            this.groupBox8.Controls.Add(this.btnSendXMS_hund);
            this.groupBox8.Controls.Add(this.btnSendXMS_one);
            this.groupBox8.Location = new System.Drawing.Point(378, 41);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(172, 55);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "SMS/LMS 자동인식 전송";
            // 
            // btnSendXMS_same
            // 
            this.btnSendXMS_same.Location = new System.Drawing.Point(115, 20);
            this.btnSendXMS_same.Name = "btnSendXMS_same";
            this.btnSendXMS_same.Size = new System.Drawing.Size(47, 27);
            this.btnSendXMS_same.TabIndex = 2;
            this.btnSendXMS_same.Text = "동보";
            this.btnSendXMS_same.UseVisualStyleBackColor = true;
            this.btnSendXMS_same.Click += new System.EventHandler(this.btnSendXMS_same_Click);
            // 
            // btnSendXMS_hund
            // 
            this.btnSendXMS_hund.Location = new System.Drawing.Point(62, 20);
            this.btnSendXMS_hund.Name = "btnSendXMS_hund";
            this.btnSendXMS_hund.Size = new System.Drawing.Size(47, 27);
            this.btnSendXMS_hund.TabIndex = 1;
            this.btnSendXMS_hund.Text = "100건";
            this.btnSendXMS_hund.UseVisualStyleBackColor = true;
            this.btnSendXMS_hund.Click += new System.EventHandler(this.btnSendXMS_hund_Click);
            // 
            // btnSendXMS_one
            // 
            this.btnSendXMS_one.Location = new System.Drawing.Point(9, 20);
            this.btnSendXMS_one.Name = "btnSendXMS_one";
            this.btnSendXMS_one.Size = new System.Drawing.Size(47, 27);
            this.btnSendXMS_one.TabIndex = 0;
            this.btnSendXMS_one.Text = "1건";
            this.btnSendXMS_one.UseVisualStyleBackColor = true;
            this.btnSendXMS_one.Click += new System.EventHandler(this.btnSendXMS_one_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnSendLMS_same);
            this.groupBox7.Controls.Add(this.btnSendLMS_hund);
            this.groupBox7.Controls.Add(this.btnSendLMS_one);
            this.groupBox7.Location = new System.Drawing.Point(199, 41);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(172, 55);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "LMS 문자 전송";
            // 
            // btnSendLMS_same
            // 
            this.btnSendLMS_same.Location = new System.Drawing.Point(115, 20);
            this.btnSendLMS_same.Name = "btnSendLMS_same";
            this.btnSendLMS_same.Size = new System.Drawing.Size(47, 27);
            this.btnSendLMS_same.TabIndex = 2;
            this.btnSendLMS_same.Text = "동보";
            this.btnSendLMS_same.UseVisualStyleBackColor = true;
            this.btnSendLMS_same.Click += new System.EventHandler(this.btnSendLMS_same_Click);
            // 
            // btnSendLMS_hund
            // 
            this.btnSendLMS_hund.Location = new System.Drawing.Point(62, 20);
            this.btnSendLMS_hund.Name = "btnSendLMS_hund";
            this.btnSendLMS_hund.Size = new System.Drawing.Size(47, 27);
            this.btnSendLMS_hund.TabIndex = 1;
            this.btnSendLMS_hund.Text = "100건";
            this.btnSendLMS_hund.UseVisualStyleBackColor = true;
            this.btnSendLMS_hund.Click += new System.EventHandler(this.btnSendLMS_hund_Click);
            // 
            // btnSendLMS_one
            // 
            this.btnSendLMS_one.Location = new System.Drawing.Point(9, 20);
            this.btnSendLMS_one.Name = "btnSendLMS_one";
            this.btnSendLMS_one.Size = new System.Drawing.Size(47, 27);
            this.btnSendLMS_one.TabIndex = 0;
            this.btnSendLMS_one.Text = "1건";
            this.btnSendLMS_one.UseVisualStyleBackColor = true;
            this.btnSendLMS_one.Click += new System.EventHandler(this.btnSendLMS_one_Click);
            // 
            // txtReceiptNum
            // 
            this.txtReceiptNum.Location = new System.Drawing.Point(73, 105);
            this.txtReceiptNum.Name = "txtReceiptNum";
            this.txtReceiptNum.Size = new System.Drawing.Size(143, 21);
            this.txtReceiptNum.TabIndex = 17;
            this.txtReceiptNum.Text = "014102315000000005";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "접수번호 : ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSendSMS_Same);
            this.groupBox6.Controls.Add(this.btn_SendSMS_hund);
            this.groupBox6.Controls.Add(this.btnSendSMS_one);
            this.groupBox6.Location = new System.Drawing.Point(18, 41);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(172, 55);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "SMS 문자 전송";
            // 
            // btnSendSMS_Same
            // 
            this.btnSendSMS_Same.Location = new System.Drawing.Point(115, 20);
            this.btnSendSMS_Same.Name = "btnSendSMS_Same";
            this.btnSendSMS_Same.Size = new System.Drawing.Size(47, 27);
            this.btnSendSMS_Same.TabIndex = 2;
            this.btnSendSMS_Same.Text = "동보";
            this.btnSendSMS_Same.UseVisualStyleBackColor = true;
            this.btnSendSMS_Same.Click += new System.EventHandler(this.btnSendSMS_Same_Click);
            // 
            // btn_SendSMS_hund
            // 
            this.btn_SendSMS_hund.Location = new System.Drawing.Point(62, 20);
            this.btn_SendSMS_hund.Name = "btn_SendSMS_hund";
            this.btn_SendSMS_hund.Size = new System.Drawing.Size(47, 27);
            this.btn_SendSMS_hund.TabIndex = 1;
            this.btn_SendSMS_hund.Text = "100건";
            this.btn_SendSMS_hund.UseVisualStyleBackColor = true;
            this.btn_SendSMS_hund.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSendSMS_one
            // 
            this.btnSendSMS_one.Location = new System.Drawing.Point(9, 20);
            this.btnSendSMS_one.Name = "btnSendSMS_one";
            this.btnSendSMS_one.Size = new System.Drawing.Size(47, 27);
            this.btnSendSMS_one.TabIndex = 0;
            this.btnSendSMS_one.Text = "1건";
            this.btnSendSMS_one.UseVisualStyleBackColor = true;
            this.btnSendSMS_one.Click += new System.EventHandler(this.btnSendSMS_one_Click);
            // 
            // txtReserveDT
            // 
            this.txtReserveDT.Location = new System.Drawing.Point(196, 11);
            this.txtReserveDT.Name = "txtReserveDT";
            this.txtReserveDT.Size = new System.Drawing.Size(168, 21);
            this.txtReserveDT.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "예약시간(yyyyMMddHHmmss) : ";
            // 
            // frmExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 501);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtCorpNum);
            this.Controls.Add(this.Label1);
            this.Name = "frmExample";
            this.Text = "팝빌 문자메시지  SDK C# Example";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtUserId;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnGetPartnerBalance;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button getPopbillURL_LOGIN;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnUnitCost;
        internal System.Windows.Forms.Button btnGetBalance;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnCheckIsMember;
        internal System.Windows.Forms.Button btnJoinMember;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCorpNum;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnUnitCost_LMS;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSendSMS_one;
        internal System.Windows.Forms.TextBox txtReserveDT;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtReceiptNum;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_SendSMS_hund;
        private System.Windows.Forms.Button btnSendSMS_Same;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnSendLMS_same;
        private System.Windows.Forms.Button btnSendLMS_hund;
        private System.Windows.Forms.Button btnSendLMS_one;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnSendXMS_same;
        private System.Windows.Forms.Button btnSendXMS_hund;
        private System.Windows.Forms.Button btnSendXMS_one;
        private System.Windows.Forms.Button btnGetURL;
        private System.Windows.Forms.Button btnCancelReserve;
        private System.Windows.Forms.Button btnGetMessageResult;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Button getPopbillURL_CHRG;
    }
}

