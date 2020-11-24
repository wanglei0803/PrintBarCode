namespace Ysdt.BarCodePrint
{
    partial class BarCodePrint
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnresetCount = new System.Windows.Forms.Button();
            this.txtcounttype = new System.Windows.Forms.TextBox();
            this.txtstartcount = new System.Windows.Forms.TextBox();
            this.CbPrinter = new System.Windows.Forms.ComboBox();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.comboBoxBarCode = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.labelBarCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPrintCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelPreview = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 628);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnresetCount);
            this.tabPage1.Controls.Add(this.txtcounttype);
            this.tabPage1.Controls.Add(this.txtstartcount);
            this.tabPage1.Controls.Add(this.CbPrinter);
            this.tabPage1.Controls.Add(this.comboBoxModel);
            this.tabPage1.Controls.Add(this.comboBoxBarCode);
            this.tabPage1.Controls.Add(this.monthCalendar1);
            this.tabPage1.Controls.Add(this.labelPreview);
            this.tabPage1.Controls.Add(this.labelBarCode);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textPrintCount);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btPrint);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(797, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "条码打印";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnresetCount
            // 
            this.btnresetCount.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnresetCount.Location = new System.Drawing.Point(670, 136);
            this.btnresetCount.Name = "btnresetCount";
            this.btnresetCount.Size = new System.Drawing.Size(102, 46);
            this.btnresetCount.TabIndex = 38;
            this.btnresetCount.Text = "重置";
            this.btnresetCount.UseVisualStyleBackColor = true;
            // 
            // txtcounttype
            // 
            this.txtcounttype.Font = new System.Drawing.Font("宋体", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcounttype.Location = new System.Drawing.Point(576, 146);
            this.txtcounttype.Name = "txtcounttype";
            this.txtcounttype.Size = new System.Drawing.Size(73, 36);
            this.txtcounttype.TabIndex = 37;
            this.txtcounttype.Text = "4";
            this.txtcounttype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_KeyPress_int);
            // 
            // txtstartcount
            // 
            this.txtstartcount.Font = new System.Drawing.Font("宋体", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtstartcount.Location = new System.Drawing.Point(140, 146);
            this.txtstartcount.Name = "txtstartcount";
            this.txtstartcount.Size = new System.Drawing.Size(299, 36);
            this.txtstartcount.TabIndex = 37;
            this.txtstartcount.Text = "0001";
            this.txtstartcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_KeyPress_int);
            // 
            // CbPrinter
            // 
            this.CbPrinter.Font = new System.Drawing.Font("宋体", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbPrinter.FormattingEnabled = true;
            this.CbPrinter.Location = new System.Drawing.Point(140, 338);
            this.CbPrinter.Name = "CbPrinter";
            this.CbPrinter.Size = new System.Drawing.Size(632, 33);
            this.CbPrinter.TabIndex = 34;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.Font = new System.Drawing.Font("宋体", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(140, 276);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(632, 33);
            this.comboBoxModel.TabIndex = 34;
            this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
            // 
            // comboBoxBarCode
            // 
            this.comboBoxBarCode.Font = new System.Drawing.Font("宋体", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxBarCode.FormattingEnabled = true;
            this.comboBoxBarCode.Location = new System.Drawing.Point(140, 28);
            this.comboBoxBarCode.Name = "comboBoxBarCode";
            this.comboBoxBarCode.Size = new System.Drawing.Size(632, 33);
            this.comboBoxBarCode.TabIndex = 35;
            this.comboBoxBarCode.SelectedIndexChanged += new System.EventHandler(this.comboBoxBarCode_SelectedIndexChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(130, 395);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 33;
            // 
            // labelBarCode
            // 
            this.labelBarCode.AutoSize = true;
            this.labelBarCode.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBarCode.Location = new System.Drawing.Point(140, 90);
            this.labelBarCode.Name = "labelBarCode";
            this.labelBarCode.Size = new System.Drawing.Size(138, 27);
            this.labelBarCode.TabIndex = 32;
            this.labelBarCode.Text = "$BarCode$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(65, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 27);
            this.label6.TabIndex = 32;
            this.label6.Text = "条码";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(450, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 27);
            this.label9.TabIndex = 32;
            this.label9.Text = "编号位数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 32;
            this.label2.Text = "起始编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(38, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 27);
            this.label8.TabIndex = 29;
            this.label8.Text = "打印机";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(65, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 27);
            this.label4.TabIndex = 29;
            this.label4.Text = "模版";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(38, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 27);
            this.label3.TabIndex = 30;
            this.label3.Text = "预览值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 31;
            this.label1.Text = "条码规则";
            // 
            // textPrintCount
            // 
            this.textPrintCount.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPrintCount.Location = new System.Drawing.Point(455, 524);
            this.textPrintCount.Name = "textPrintCount";
            this.textPrintCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textPrintCount.Size = new System.Drawing.Size(98, 38);
            this.textPrintCount.TabIndex = 28;
            this.textPrintCount.Text = "1";
            this.textPrintCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_KeyPress_int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(377, 524);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 27;
            this.label5.Text = "数量";
            // 
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.Location = new System.Drawing.Point(586, 460);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(186, 115);
            this.btPrint.TabIndex = 26;
            this.btPrint.Text = "打印";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(797, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "使用说明";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPreview.Location = new System.Drawing.Point(140, 214);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(138, 27);
            this.labelPreview.TabIndex = 32;
            this.labelPreview.Text = "$BarCode$";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(797, 584);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "1.条码设计模版使用ZebraDesigner 3 for Developers.到Zebra官网下载。\r\n2.条码值使用：$BarCode$\r\n3.条码支持计数" +
                " $Count$\r\n4.条码支持日期 $Datetime(yyMMdd)$\r\n\r\n如有问题，请返馈给：IT@itstandard.cn\r\nQQ:3517333\r" +
                "\n";
            // 
            // BarCodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 653);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BarCodePrint";
            this.Text = "斑马条码打印程序";
            this.Load += new System.EventHandler(this.BarCodePrint_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtstartcount;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.ComboBox comboBoxBarCode;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPrintCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelBarCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbPrinter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtcounttype;
        private System.Windows.Forms.Button btnresetCount;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.TextBox textBox1;

    }
}

