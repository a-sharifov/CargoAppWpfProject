using System.Security.Cryptography;
using System.Text;

namespace WpfApp6.Service.Classes;
public static class MD5HashService
{
    public static string? GetHash(string? input)
    {
        MD5 mD5Hash = MD5.Create();
        byte[] data = mD5Hash.ComputeHash(Encoding.UTF8.GetBytes(input!));

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }
}