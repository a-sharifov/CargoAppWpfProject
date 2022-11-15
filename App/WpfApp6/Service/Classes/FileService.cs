using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6.Service.Classes
{
    public static class FileService
    {
        public static void SaveAs(string ToSave, string Where)
        {
            using (FileStream fs = new FileStream(Where, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(ToSave);
            }
        }
        public static string? ReadAs(string Where)
        {
            using (FileStream fs = new FileStream(Where, FileMode.OpenOrCreate))
            using (StreamReader sw = new StreamReader(fs))
            {
                return sw.ReadLine();
            }
        }

    }
}
