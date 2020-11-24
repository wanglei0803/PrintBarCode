using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Drawing;


namespace Natty.Utility.ToolBox
{
    public enum ValidateSaveMode
    {
        Session = 1,
        Cookie = 2
    }

    public class ValidateImage
    {
        #region Constructor
        /// <summary>
        /// Create Validate
        /// </summary>
        public ValidateImage()
        {
            CharacterHelper charText = new CharacterHelper();
            this.CreateCheckCodeImage(charText.GenerateCheckCode(4));
        }

        /// <summary>
        /// Create input value to image
        /// </summary>
        /// <param name="checkCode">input value</param>
        public ValidateImage(string checkCode)
        {
            this.CreateCheckCodeImage(checkCode);
        }

        /// <summary>
        ///  Create input value to image
        /// </summary>
        /// <param name="checkCode">input value</param>
        /// <param name="fettle">fettle value(1:no style)</param>
        public ValidateImage(string checkCode, int fettle)
        {
            this.CreateCheckCodeImage(checkCode, fettle);
        }

        public ValidateImage(string checkCode, int fettle, bool OpenSave)
        {
            this.CreateCheckCodeImage(checkCode, fettle, OpenSave);
        }

        public ValidateImage(string checkCode, int fettle, bool OpenSave, double PicLengthRate)
        {
            this.CreateCheckCodeImage(checkCode, fettle, OpenSave);
        }

        public ValidateImage(string checkCode, int fettle, bool OpenSave, int SaveMode)
        {
            this.CreateCheckCodeImage(checkCode, fettle, OpenSave, SaveMode);
        }


        public ValidateImage(string checkCode, int fettle, bool OpenSave, int SaveMode, double PicLengthRate)
        {
            this.CreateCheckCodeImage(checkCode, fettle, OpenSave, SaveMode, PicLengthRate);
        }
        #endregion

        #region Create Check Code Image
        private void CreateCheckCodeImage(string checkCode)
        {
            this.CreateCheckCodeImage(checkCode, 0);
        }

        private void CreateCheckCodeImage(string checkCode, int fettle)
        {
            CreateCheckCodeImage(checkCode, fettle, true);
        }

        private void CreateCheckCodeImage(string checkCode, int fettle, bool OpenSave)
        {
            CreateCheckCodeImage(checkCode, fettle, OpenSave, (int)ValidateSaveMode.Cookie);
        }


        private void CreateCheckCodeImage(string checkCode, int fettle, bool OpenSave, int SaveMode)
        {
            CreateCheckCodeImage(checkCode, fettle, OpenSave, SaveMode, 30);
        }

        private void CreateCheckCodeImage(string checkCode, int fettle, bool OpenSave, int SaveMode, double PicLengthRate)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;

            //��֤�뱣�淽ʽ
            CodeSaveMode(checkCode, OpenSave, SaveMode);

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * PicLengthRate)),40);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //�������������
                Random random = new Random();

                //���ͼƬ����ɫ
                g.Clear(Color.White);
                
                switch (fettle)
                {
                    case 0:
                        plotDefault(checkCode, image, g, random);
                        break;
                    case 1:
                        plotMethod1(checkCode, image, g, random);
                        break;
                    case 2:
                        plotMethod2(checkCode, image, g, random);
                        break;
                    case 3:
                        plotMethod3(checkCode, image, g, random);
                        break;
                    case 4:
                        plotMethod4(checkCode, image, g, random);
                        break;
                    default:
                        break;
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        #endregion

        #region ��ͼ��ʽ��Ĭ��
        private static void plotDefault(string checkCode, System.Drawing.Bitmap image, Graphics g, Random random)
        {
            //��ͼƬ�ı���������
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            Font font = new System.Drawing.Font("Arial", 22, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);

            g.DrawString(checkCode, font, brush, 20, 5);

            //��ͼƬ��ǰ��������
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //��ͼƬ�ı߿���
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
        }

        private static void plotMethod1(string checkCode, System.Drawing.Bitmap image, Graphics g, Random random)
        {
            //��ͼƬ�ı���������
            for (int i = 0; i < 15; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            //Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular));
            Font font = new System.Drawing.Font("Arial", 20, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);

            g.DrawString(checkCode, font, brush, 2, 2);

            //��ͼƬ��ǰ��������
            for (int i = 0; i < 0; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
        }

        private static void plotMethod2(string checkCode, System.Drawing.Bitmap image, Graphics g, Random random)
        {
            #region
            ////��ͼƬ�ı���������
            //for (int i = 0; i < BackgroundNoiseAmount; i++)
            //{
            //    int x1 = random.Next(image.Width);
            //    int x2 = random.Next(image.Width);
            //    int y1 = random.Next(image.Height);
            //    int y2 = random.Next(image.Height);

            //    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            //}


            //Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));

            //System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);

            //g.DrawString(checkCode, font, brush, 2, 2);

            ////��ͼƬ��ǰ��������
            //for (int i = 0; i < ForegroundNoiseAmount; i++)
            //{
            //    int x = random.Next(image.Width);
            //    int y = random.Next(image.Height);

            //    image.SetPixel(x, y, Color.FromArgb(random.Next()));
            //}

            ////��ͼƬ�ı߿���
            //g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            #endregion
            //������ɫ
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //��������            
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "����" };
            //���������
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            //�����ͬ�������ɫ����֤���ַ�
            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = random.Next(7);
                int findex = random.Next(5);

                Font f = new System.Drawing.Font(font[findex], 20, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
            }
            //��һ���߿�
            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);


        }

        private static void plotMethod3(string checkCode, System.Drawing.Bitmap image, Graphics g, Random random)
        {
            //���ͼƬ����ɫ
            g.Clear(Color.White);

            //������ɫ
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            int[] fintSize = { 14, 15, 17, 16 };
            //��������            
            string[] Arrfont = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "����" };
            ////���������
            //for (int i = 0; i < 50; i++)
            //{
            //    int x = random.Next(image.Width);
            //    int y = random.Next(image.Height);
            //    g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            //}

            string[] arrBlack = { " ", "  ", "   " };


            int cindex = random.Next(7);
            int findex = random.Next(5);
            int fzindex = random.Next(4);
            int Blackindex = random.Next(3);
            int placeindex = random.Next(3);

            string TempCode = checkCode;

            switch (placeindex)
            {
                case 0:
                    break;
                case 1:
                    TempCode += arrBlack[Blackindex];
                    break;
                case 2:
                    TempCode = arrBlack[Blackindex] + TempCode;
                    break;
                default:
                    break;
            }
            checkCode = TempCode;

            Font font = new System.Drawing.Font(Arrfont[findex], fintSize[fzindex], (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);

            g.DrawString(checkCode, font, brush, 2, 2);


            //��ͼƬ��ǰ��������
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }


            ////��ͼƬ�ı߿���
            //g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            //��һ���߿�
            //g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);


        }

        private static void plotMethod4(string checkCode, System.Drawing.Bitmap image, Graphics g, Random random)
        {

            Font font = new System.Drawing.Font("Arial", 20, (System.Drawing.FontStyle.Regular));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);

            g.DrawString(checkCode, font, brush, 2, 2);

        }

        #endregion

        #region ��֤�뱣�淽ʽ
        private void CodeSaveMode(string checkCode, bool OpenSave, int SaveMode)
        {
            if (OpenSave)
            {
                if (ValidateSaveMode.Cookie == (ValidateSaveMode)SaveMode)
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));
                }
                else if (ValidateSaveMode.Session == (ValidateSaveMode)SaveMode)
                {
                    HttpContext.Current.Session["CheckCode"] = checkCode;
                }
            }
        }
        #endregion

        #region ��֤��֤��
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static bool CheckCode(string Code)
        {
            return CheckCode(Code, ValidateSaveMode.Cookie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="validateSaveMode"></param>
        /// <returns></returns>
        public static bool CheckCode(string Code, ValidateSaveMode validateSaveMode)
        {
            if (string.IsNullOrEmpty(Code.Trim()))
            {
                return false;
            }
            string strCode = string.Empty;
            if (validateSaveMode == ValidateSaveMode.Cookie)
            {
                if (HttpContext.Current.Response.Cookies["CheckCode"] != null)
                {
                    strCode = HttpContext.Current.Request.Cookies["CheckCode"].Value.Trim();
                }
            }
            else if(validateSaveMode == ValidateSaveMode.Session)
            {
                if (HttpContext.Current.Session["CheckCode"] != null)
                {
                    strCode = HttpContext.Current.Session["CheckCode"].ToString();
                }
            }
            if (Code.Trim().ToLower() != strCode.Trim().ToLower())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}
    