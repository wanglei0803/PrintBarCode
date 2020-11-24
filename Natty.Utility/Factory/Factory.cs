using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Threading;


namespace Natty.Utility.Factory {
    public  class Factory
    {
        private static string strType = string.Empty;
        private static Dictionary<string, Assembly> Assemblys = new Dictionary<string, Assembly>();
        private static ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();
        
        public static  T CreateInstance<T> (string assemblyName, string moudleName)
        {
            //判断是否为接口
            if (!typeof(T).IsInterface)
            {
                throw new NotSupportedException("this T only support interface!");
            }

            //不做缓存也不做读写锁，怕万一出问题！！麻烦！！
            ////程序集是否加载,
            if (!Assemblys.ContainsKey(assemblyName))
            {
                try
                {
                    rwl.EnterWriteLock();
                    if (!Assemblys.ContainsKey(assemblyName))
                    {
                        Assembly asm = Assembly.Load(assemblyName);
                        Assemblys.Add(assemblyName, asm);
                    }
                }
                finally
                {
                    rwl.ExitWriteLock();
                }
            }
           
            //创建实例
            return (T)Assemblys[assemblyName].CreateInstance(moudleName, true) ;
        }
    }
}
