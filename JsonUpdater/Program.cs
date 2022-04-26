using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

string path = @"C:\Users\vkh28982\source\repos\JsonUpdater\JsonUpdater\Data\";
string[] fileNames = Directory.GetFiles(path);
foreach (var item in fileNames)
{
    UpdateJsonFiles(item);
}
void UpdateJsonFiles(string path)
{
    using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
    {
        byte[] b = new byte[fs.Length];
        UTF8Encoding temp = new UTF8Encoding(true);
        fs.Read(b, 0, b.Length);
        string str = temp.GetString(b);
        int target = str.IndexOf(',');

        str = str.Insert(target + 1, "\n    \"gameName\" : \"default\",");
        Byte[] b2 = new UTF8Encoding(true).GetBytes(str);
        fs.SetLength(0);
        fs.Write(b2, 0, b2.Length);

    }
}
