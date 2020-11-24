using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Threading;

using Natty.Utility.ToolBox;

namespace Ysdt.BarCodePrint
{
    public partial class BarCodePrint : Form
    {
        public BarCodePrint()
        {
            InitializeComponent();
        }
        private Thread mythread;

        #region 数字text
        private void tBox_KeyPress_double(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }
        private void tBox_KeyPress_int(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if (e.KeyChar > 0x20)
            {
                try
                {
                    int.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }
        #endregion

        private void btPrint_Click(object sender, EventArgs e)
        {
            //ZebraPrintHelper.OpenPrinter(CbPrinter.Text, out outptr, Printdoc);

            if (mythread != null && !mythread.IsAlive)
            {
                //如果进程已存在，且没有在运行，重置进程
                MessageBox.Show("已启动一个进程，请勿重复启动\r\n");
            }
            else if (mythread == null)
            {
                mythread = new Thread(new ThreadStart(PrintBarcode));
                mythread.Start();
            }

            
        }
        private void PrintBarcode()
        {
            string strzpl2 = string.Empty;
            #region 读取模版
            string runfolder = System.Environment.CurrentDirectory;
            StreamReader sr = new StreamReader(runfolder + "\\Model\\" + comboBoxModel.Text);
            string line = "";
            string val = "";
            //int i = 0;
            bool finded = false;
            while ((line = sr.ReadLine()) != null)
            {
                val = val + line + "\r\n";
            }
            strzpl2 = val;
            sr.Close();
            #endregion

            #region 打印条码
            strzpl2 = strzpl2.Replace("$BarCode$", labelBarCode.Text);
            int start = int.Parse(txtstartcount.Text);
            string type = string.Empty;
            for (int i = 0; i < int.Parse(txtcounttype.Text); i++)
            {
                type = type + "0";
            }

            for (int i = start; i < (start + int.Parse(textPrintCount.Text)); i++)
            {
                strzpl2 = replacebarcode(strzpl2,i.ToString());
                txtstartcount.Text = (i + 1).ToString(type);
                ZebraPrintHelper.SendStringToPrinter(CbPrinter.Text, strzpl2);
            }            
            #endregion           
            
            mythread = null; //线程结束
        }

        private void BarCodePrint_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //程序初始化
            #region 打印机列表初始化
            PrintDocument printDoc = new PrintDocument();
            foreach (string one in PrinterSettings.InstalledPrinters)
            {
                CbPrinter.Items.Add(one);
            }
            if (printDoc.PrinterSettings.IsDefaultPrinter)
            {
                CbPrinter.Text = printDoc.PrinterSettings.PrinterName;
            }
            #endregion


            string runfolder = System.Environment.CurrentDirectory;
            #region 读取zpl2模版文件
            DirectoryInfo TheFolderZPL2 = new DirectoryInfo(runfolder + "\\Model");
            foreach (FileInfo onefile in TheFolderZPL2.GetFiles())
            {
                comboBoxModel.Items.Add(onefile.Name);
 
            }
            #endregion

            #region 读取barcode模版
            DirectoryInfo TheFolderBarCode = new DirectoryInfo(runfolder + "\\PrintBarCode");
            foreach (FileInfo onefile in TheFolderBarCode.GetFiles())
            {
                comboBoxBarCode.Items.Add(onefile.Name);
            }
            #endregion

            #region 模版/打印规则默认值
            StreamReader sr = new StreamReader(runfolder+"\\BarCode.ini");
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null && line.Trim() != "")
            {
                switch (line.Split('=')[0])
                {
                    case "Model":
                        comboBoxModel.Text = line.Split('=')[1];
                        break;
                    case "PrintBarCode":
                        comboBoxBarCode.Text = line.Split('=')[1];
                        StreamReader srbc = new StreamReader(TheFolderBarCode.FullName + "\\" + line.Split('=')[1]);
                        string strbc = string.Empty;
                        while ((strbc = srbc.ReadLine()) != null && strbc.Trim() != "")
                        {
                            labelBarCode.Text = strbc;
                        }
                        srbc.Close();
                        break;

                }
            }
            sr.Close();

            #endregion 

        }

        private void comboBoxBarCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string runfolder = System.Environment.CurrentDirectory;
            DirectoryInfo TheFolderBarCode = new DirectoryInfo(runfolder + "\\PrintBarCode");
            StreamReader srbc = new StreamReader(TheFolderBarCode.FullName + "\\" + comboBoxBarCode.Text);
            string strbc = string.Empty;
            while ((strbc = srbc.ReadLine()) != null && strbc.Trim() != "")
            {
                labelBarCode.Text = strbc;
            }
            srbc.Close();

            IniFileHelper ini = new IniFileHelper("BarCode.ini");
            StringBuilder sb = new StringBuilder(100);
            ini.WriteIniString("base", "Model", comboBoxModel.Text);
            labelPreview.Text = replacebarcode(labelBarCode.Text);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniFileHelper ini = new IniFileHelper("BarCode.ini");
            StringBuilder sb = new StringBuilder(100);
            ini.WriteIniString("base", "BarCode", comboBoxBarCode.Text);
        }

        private string replacebarcode(string barcode)
        {
            return replacebarcode(barcode, "0");
        }

        private string replacebarcode(string barcode, string countno)
        {
            string rebarcode = barcode;
            #region 时间格式
            DateTime now = DateTime.Now;
            int start = 0;
            int at = 0;
            int end = rebarcode.Length;
            int count = 0;
            List<string> strdatelist = new List<string>();
            string one = "";

            #region rebarcode时间
            start = 0;
            at = 0;
            end = rebarcode.Length;
            strdatelist = new List<string>();
            while ((start <= end) && (at > -1))
            {
                count = end - start;
                at = rebarcode.IndexOf("$Datetime(", start, count);
                if (at > 0)
                {
                    strdatelist.Add(rebarcode.Substring(at, rebarcode.IndexOf("$", at + 1) - at + 1));
                }
                start = at + 1;
            }
            foreach (string o in strdatelist)
            {
                string format = o.Replace("$Datetime(", "");
                format = format.Replace(")$", "");
                rebarcode = rebarcode.Replace(o, now.ToString(format));
            }



            #endregion

            #endregion


            string type = string.Empty;
            for (int i = 0; i < int.Parse(txtcounttype.Text); i++)
            {
                type = type + "0";
            }
            if (countno == "0")
            {
                rebarcode = rebarcode.Replace("$Count$", int.Parse(txtstartcount.Text).ToString(type));
            }
            else
            {
                rebarcode = rebarcode.Replace("$Count$", int.Parse(countno).ToString(type));
            }
            return rebarcode;
        }

    }
}
