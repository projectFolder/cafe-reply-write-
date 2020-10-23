namespace aiswing_product.Forms
{
    partial class WriteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.subjectText = new aiswing_product.CustomControl.CustomRichTextBox();
            this.customButton1 = new WindowsFormsApp1.CustomButton();
            this.titleText = new WindowsFormsApp1.CustomControl.CustomTextbox();
            this.pharagraphNum = new WindowsFormsApp1.CustomControl.CustomTextbox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 10323;
            this.label1.Text = "가입 게시글 설정";
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button13.ForeColor = System.Drawing.Color.DarkGray;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(399, 8);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(30, 23);
            this.button13.TabIndex = 10338;
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(24, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 10394;
            this.label4.Text = "게시글 제목";
            // 
            // subjectText
            // 
            this.subjectText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.subjectText.Location = new System.Drawing.Point(27, 78);
            this.subjectText.Name = "subjectText";
            this.subjectText.setValue = "";
            this.subjectText.Size = new System.Drawing.Size(386, 434);
            this.subjectText.TabIndex = 10397;
            // 
            // customButton1
            // 
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.customButton1.Angel = 45F;
            this.customButton1.BorderRadius = 10;
            this.customButton1.btnName = "게시글 목록 추가";
            this.customButton1.Color0 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(83)))));
            this.customButton1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(83)))));
            this.customButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.customButton1.Location = new System.Drawing.Point(27, 524);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(386, 32);
            this.customButton1.TabIndex = 10362;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // titleText
            // 
            this.titleText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.titleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.titleText.hint = "";
            this.titleText.Location = new System.Drawing.Point(97, 47);
            this.titleText.Margin = new System.Windows.Forms.Padding(0);
            this.titleText.MultiLine = false;
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(316, 20);
            this.titleText.TabIndex = 10352;
            this.titleText.usePWchar = false;
            this.titleText.val = "";
            // 
            // pharagraphNum
            // 
            this.pharagraphNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.pharagraphNum.hint = "";
            this.pharagraphNum.Location = new System.Drawing.Point(-380, 305);
            this.pharagraphNum.Margin = new System.Windows.Forms.Padding(0);
            this.pharagraphNum.MultiLine = false;
            this.pharagraphNum.Name = "pharagraphNum";
            this.pharagraphNum.Size = new System.Drawing.Size(124, 19);
            this.pharagraphNum.TabIndex = 10339;
            this.pharagraphNum.usePWchar = false;
            this.pharagraphNum.val = "";
            // 
            // WriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(437, 572);
            this.Controls.Add(this.subjectText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.pharagraphNum);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "replaceView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button button13;
        private WindowsFormsApp1.CustomControl.CustomTextbox pharagraphNum;
        private WindowsFormsApp1.CustomButton customButton1;
        private WindowsFormsApp1.CustomControl.CustomTextbox titleText;
        private System.Windows.Forms.Label label4;
        private aiswing_product.CustomControl.CustomRichTextBox subjectText;
    }
}