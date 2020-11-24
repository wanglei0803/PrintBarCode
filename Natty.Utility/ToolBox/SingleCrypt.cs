using System;

namespace Natty.Utility.ToolBox
{
	/// <summary>
	/// SingleCrypt 的摘要说明。
	/// </summary>
	public class SingleCrypt
	{

		//加密
		//参数:strData:要加密的数据
		//返回:加好密的字符串
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
