namespace SettleReport
{
    partial class SettleReportForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettleReportForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fillSettleIdButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.mzSignBtn = new System.Windows.Forms.Button();
            this.mzInbtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mzY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mzX = new System.Windows.Forms.TextBox();
            this.mzCheckBox = new System.Windows.Forms.CheckBox();
            this.mzSearchBtn = new System.Windows.Forms.Button();
            this.mzTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.zySignBtn = new System.Windows.Forms.Button();
            this.zyInbtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zyY = new System.Windows.Forms.TextBox();
            this.zyCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zySearchBtn = new System.Windows.Forms.Button();
            this.zyX = new System.Windows.Forms.TextBox();
            this.zyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SignTextBox = new System.Windows.Forms.TextBox();
            this.signWidth = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fillSettleIdButton);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.mzSignBtn);
            this.groupBox1.Controls.Add(this.mzInbtn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mzY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mzX);
            this.groupBox1.Controls.Add(this.mzCheckBox);
            this.groupBox1.Controls.Add(this.mzSearchBtn);
            this.groupBox1.Controls.Add(this.mzTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "门诊";
            // 
            // fillSettleIdButton
            // 
            this.fillSettleIdButton.Location = new System.Drawing.Point(10, 144);
            this.fillSettleIdButton.Name = "fillSettleIdButton";
            this.fillSettleIdButton.Size = new System.Drawing.Size(75, 23);
            this.fillSettleIdButton.TabIndex = 13;
            this.fillSettleIdButton.Text = "填充结算号";
            this.fillSettleIdButton.UseVisualStyleBackColor = true;
            this.fillSettleIdButton.Click += new System.EventHandler(this.FillSettleIdButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "请确保第一个表有[结算号/姓名]列";
            // 
            // mzSignBtn
            // 
            this.mzSignBtn.Location = new System.Drawing.Point(186, 144);
            this.mzSignBtn.Name = "mzSignBtn";
            this.mzSignBtn.Size = new System.Drawing.Size(75, 23);
            this.mzSignBtn.TabIndex = 11;
            this.mzSignBtn.Text = "批量签章";
            this.mzSignBtn.UseVisualStyleBackColor = true;
            this.mzSignBtn.Click += new System.EventHandler(this.MzSignBtn_Click);
            // 
            // mzInbtn
            // 
            this.mzInbtn.Location = new System.Drawing.Point(98, 144);
            this.mzInbtn.Name = "mzInbtn";
            this.mzInbtn.Size = new System.Drawing.Size(75, 23);
            this.mzInbtn.TabIndex = 10;
            this.mzInbtn.Text = "门诊导入";
            this.mzInbtn.UseVisualStyleBackColor = true;
            this.mzInbtn.Click += new System.EventHandler(this.MzInbtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(7, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "签章位置：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(189, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y：";
            // 
            // mzY
            // 
            this.mzY.Location = new System.Drawing.Point(225, 84);
            this.mzY.Name = "mzY";
            this.mzY.Size = new System.Drawing.Size(33, 21);
            this.mzY.TabIndex = 7;
            this.mzY.Text = "420";
            this.mzY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MzY_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(106, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "X：";
            // 
            // mzX
            // 
            this.mzX.Location = new System.Drawing.Point(142, 84);
            this.mzX.Name = "mzX";
            this.mzX.Size = new System.Drawing.Size(33, 21);
            this.mzX.TabIndex = 5;
            this.mzX.Text = "400";
            this.mzX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MzX_KeyPress);
            // 
            // mzCheckBox
            // 
            this.mzCheckBox.AutoSize = true;
            this.mzCheckBox.Checked = true;
            this.mzCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mzCheckBox.Location = new System.Drawing.Point(10, 59);
            this.mzCheckBox.Name = "mzCheckBox";
            this.mzCheckBox.Size = new System.Drawing.Size(48, 16);
            this.mzCheckBox.TabIndex = 4;
            this.mzCheckBox.Text = "签章";
            this.mzCheckBox.UseVisualStyleBackColor = true;
            // 
            // mzSearchBtn
            // 
            this.mzSearchBtn.Location = new System.Drawing.Point(92, 56);
            this.mzSearchBtn.Name = "mzSearchBtn";
            this.mzSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.mzSearchBtn.TabIndex = 2;
            this.mzSearchBtn.Text = "查询";
            this.mzSearchBtn.UseVisualStyleBackColor = true;
            this.mzSearchBtn.Click += new System.EventHandler(this.MzSearchBtn_Click);
            // 
            // mzTextBox
            // 
            this.mzTextBox.Location = new System.Drawing.Point(92, 19);
            this.mzTextBox.Name = "mzTextBox";
            this.mzTextBox.Size = new System.Drawing.Size(166, 21);
            this.mzTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "结算号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.zySignBtn);
            this.groupBox2.Controls.Add(this.zyInbtn);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.zyY);
            this.groupBox2.Controls.Add(this.zyCheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.zySearchBtn);
            this.groupBox2.Controls.Add(this.zyX);
            this.groupBox2.Controls.Add(this.zyTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(315, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 182);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "住院";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "请确保第一个表有[住院号/姓名]列";
            // 
            // zySignBtn
            // 
            this.zySignBtn.Location = new System.Drawing.Point(109, 144);
            this.zySignBtn.Name = "zySignBtn";
            this.zySignBtn.Size = new System.Drawing.Size(75, 23);
            this.zySignBtn.TabIndex = 13;
            this.zySignBtn.Text = "批量签章";
            this.zySignBtn.UseVisualStyleBackColor = true;
            this.zySignBtn.Click += new System.EventHandler(this.ZySignBtn_Click);
            // 
            // zyInbtn
            // 
            this.zyInbtn.Location = new System.Drawing.Point(11, 144);
            this.zyInbtn.Name = "zyInbtn";
            this.zyInbtn.Size = new System.Drawing.Size(75, 23);
            this.zyInbtn.TabIndex = 12;
            this.zyInbtn.Text = "住院导入";
            this.zyInbtn.UseVisualStyleBackColor = true;
            this.zyInbtn.Click += new System.EventHandler(this.ZyInbtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(8, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "签章位置：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(189, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Y：";
            // 
            // zyY
            // 
            this.zyY.Location = new System.Drawing.Point(225, 81);
            this.zyY.Name = "zyY";
            this.zyY.Size = new System.Drawing.Size(33, 21);
            this.zyY.TabIndex = 11;
            this.zyY.Text = "400";
            this.zyY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZyY_KeyPress);
            // 
            // zyCheckBox
            // 
            this.zyCheckBox.AutoSize = true;
            this.zyCheckBox.Checked = true;
            this.zyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zyCheckBox.Location = new System.Drawing.Point(10, 56);
            this.zyCheckBox.Name = "zyCheckBox";
            this.zyCheckBox.Size = new System.Drawing.Size(48, 16);
            this.zyCheckBox.TabIndex = 3;
            this.zyCheckBox.Text = "签章";
            this.zyCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(106, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "X：";
            // 
            // zySearchBtn
            // 
            this.zySearchBtn.Location = new System.Drawing.Point(92, 49);
            this.zySearchBtn.Name = "zySearchBtn";
            this.zySearchBtn.Size = new System.Drawing.Size(75, 23);
            this.zySearchBtn.TabIndex = 2;
            this.zySearchBtn.Text = "查询";
            this.zySearchBtn.UseVisualStyleBackColor = true;
            this.zySearchBtn.Click += new System.EventHandler(this.ZySearchBtn_Click);
            // 
            // zyX
            // 
            this.zyX.Location = new System.Drawing.Point(142, 81);
            this.zyX.Name = "zyX";
            this.zyX.Size = new System.Drawing.Size(33, 21);
            this.zyX.TabIndex = 9;
            this.zyX.Tag = "200";
            this.zyX.Text = "400";
            this.zyX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZyX_KeyPress);
            // 
            // zyTextBox
            // 
            this.zyTextBox.Location = new System.Drawing.Point(92, 19);
            this.zyTextBox.Name = "zyTextBox";
            this.zyTextBox.Size = new System.Drawing.Size(166, 21);
            this.zyTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "住院号：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "签章图片：";
            this.label11.Click += new System.EventHandler(this.Label11_Click);
            // 
            // SignTextBox
            // 
            this.SignTextBox.Location = new System.Drawing.Point(104, 18);
            this.SignTextBox.Name = "SignTextBox";
            this.SignTextBox.Size = new System.Drawing.Size(100, 21);
            this.SignTextBox.TabIndex = 14;
            this.SignTextBox.Click += new System.EventHandler(this.SignTextBox_Click);
            // 
            // signWidth
            // 
            this.signWidth.Location = new System.Drawing.Point(480, 19);
            this.signWidth.Name = "signWidth";
            this.signWidth.Size = new System.Drawing.Size(100, 21);
            this.signWidth.TabIndex = 16;
            this.signWidth.Text = "100";
            this.signWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SignWidth_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(388, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "签章大小：";
            // 
            // SettleReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 262);
            this.Controls.Add(this.signWidth);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SignTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettleReportForm";
            this.Text = "打印结算清单";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mzTextBox;
        private System.Windows.Forms.Button mzSearchBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button zySearchBtn;
        private System.Windows.Forms.TextBox zyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox mzCheckBox;
        private System.Windows.Forms.CheckBox zyCheckBox;
        private System.Windows.Forms.TextBox mzX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mzY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox zyY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox zyX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button mzInbtn;
        private System.Windows.Forms.Button mzSignBtn;
        private System.Windows.Forms.Button zySignBtn;
        private System.Windows.Forms.Button zyInbtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SignTextBox;
        private System.Windows.Forms.TextBox signWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button fillSettleIdButton;
    }
}

