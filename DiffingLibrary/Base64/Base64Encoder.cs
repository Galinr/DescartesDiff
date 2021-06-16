using System;
using System.Collections.Generic;
using System.Text;

namespace DiffingLibrary.Base64
{
    /// <summary>
    /// Helper class za kodiranje stringa v BASE64
    /// </summary>
    public class Base64Encoder
    {
        public static string Base64Encode(string _base)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes("_base"));
        }
    }
}
