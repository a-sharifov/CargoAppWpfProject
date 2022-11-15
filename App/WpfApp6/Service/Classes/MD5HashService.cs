using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp6.Service.Classes
{
    public static class MD5HashService
    {
        public static string? GetHash(string? input)
        {
            if (input == null)
            {
                return null;
            }

            MD5 mD5Hash = MD5.Create();
            byte[] data =  mD5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2")); 
            }
            
            return builder.ToString();
        }
    }
}
