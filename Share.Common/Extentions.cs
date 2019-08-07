using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Share.Common
{
    public static class Extentions
    {
        ///<summary>
        ///给一个字符串进行MD5加密
        ///</summary>
        ///<param   name="strText">待加密字符串</param>
        ///<returns>加密后的字符串</returns>
        public static string MD5Encrypt(this string strText)
        {
            if (string.IsNullOrEmpty(strText))
            {
                throw new ArgumentNullException(nameof(strText));
            }

            MD5 md5 = new MD5CryptoServiceProvider();
            var result = md5.ComputeHash(Encoding.Default.GetBytes(strText));
            return Encoding.Default.GetString(result);
        }
    }
}
