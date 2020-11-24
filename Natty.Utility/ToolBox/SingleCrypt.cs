using System;

namespace Natty.Utility.ToolBox
{
	/// <summary>
	/// SingleCrypt ��ժҪ˵����
	/// </summary>
	public class SingleCrypt
	{

		//����
		//����:strData:Ҫ���ܵ�����
		//����:�Ӻ��ܵ��ַ���
		public static string Encrypt(string strData,long lKey) 
		{
			string strRtn="";
			byte[] bData = System.Text.Encoding.Unicode.GetBytes(strData);
			char[] cData =	System.Text.Encoding.Unicode.GetChars(bData);
			for(int i=0;i<cData.Length;i++)
			{
				//strRtn+=(char)(((int)cData[i])+iKey);
				strRtn+=(char)Encode((long)cData[i],lKey);
			}
			return strRtn;
			
		}

		public static string Decrypt(string strData,long lKey) 
		{
			string strRtn="";
			byte[] bData = System.Text.Encoding.Unicode.GetBytes(strData);
			char[] cData =	System.Text.Encoding.Unicode.GetChars(bData);
			for(int i=0;i<cData.Length;i++)
			{
				//strRtn+=(char)(((int)cData[i])-iKey);
				strRtn+=(char)Decode((long)cData[i],lKey);
			}
			return strRtn;
		}

		private static long Encode(long lData,long lKey)
		{
			return ((lData-32+(lKey+13675)*(lKey+8735))%95+32);
		}

		private static long Decode(long lData,long lKey)
		{
			return ((lData-32-(lKey+13675)*(lKey+8735)+9999999*95)%95+32);
		}
	}
}
