using System.IO;

namespace WpfApp6.Service.Classes;
public static class FileService
{
    public static void SaveAs(string toSave, string where)
    {
        using (FileStream fs = new FileStream(where, FileMode.Create)) //с (;) не работал
        using (StreamWriter sw = new StreamWriter(fs))
            sw.Write(toSave);
    }
    public static string ReadAs(string where)
    {
        using (FileStream fs = new FileStream(where, FileMode.OpenOrCreate))
        using (StreamReader sw = new StreamReader(fs))
            return sw.ReadLine() ?? ""; //возвращает null так что решил тк сделать
    }
}