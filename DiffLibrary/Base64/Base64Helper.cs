﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.Base64
{
    /// <summary>
    /// Helper class za kodiranje stringa v BASE64
    /// </summary>
    public class Base64Helper
    {
        public static string Base64Encode(string _base)
        {
            if(_base == "")
            {
                throw new ArgumentException("String je bil prazen");
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(_base));
        }

        public static string Base64Decode(string _base)
        {
            if (_base == "")
            {
                throw new ArgumentException("String je bil prazen");
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(_base));
        }
    }
}
