﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;

namespace Rock.Helpers
{
    public class HtmlHelper
    {

        /// <summary>
        /// Formats a string for use as a CCS class or id value
        /// </summary>
        /// <param name="value">String to format</param>
        /// <returns></returns>
        public static string CssClassFormat( string value )
        {
            value = value.ToLower();
            value = value.Replace( ' ', '-' );

            return value;
        }

        /// <summary>
        /// Hashes a string using MD5
        /// </summary>
        /// <param name="value">String to format</param>
        /// <returns></returns>
        public static string CalculateMD5Hash( string input )
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes( input );
            byte[] hash = md5.ComputeHash( inputBytes );

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for ( int i = 0; i < hash.Length; i++ )
            {
                sb.Append( hash[i].ToString( "X2" ) );
            }
            return sb.ToString().ToLower();
        }
    }
}