using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All extensions: ");
            string path = "C:/Users/user/Desktop/Lab/Lab/Lab/TNSShort_1535040109";

            //Getting extensions of all files
            var t = GetFiles(path);

            //Offer to user choose necessary format
            foreach (var item in t)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine("Choose extension: ");
            string value = Console.ReadLine();

            List<FileInfo> ReturnExtensions = ExtensionChoice(path, value);
            Console.WriteLine("Count = {0}",ReturnExtensions.Count);

            Console.WriteLine("Do you want to edit files y/n?");
            char edit = Console.ReadLine()[0];

            if (edit == 'y')
            {
                Console.WriteLine("Working with files...");

                var KeysToModify = new Dictionary<char, string>();
                Dictionary<char, string> _getNameOfFiles = GetNameOfFiles(ReturnExtensions);
                KeysToModify = _getNameOfFiles;

                foreach (var item in KeysToModify)
                {
                    string newKey = item + "";
                    Console.Write("{0} - ", item.Key);

                    _getNameOfFiles.Remove(item.Key);
                    _getNameOfFiles.Add('a', newKey);
                    //string naShto = Console.ReadLine();

                    //_getNameOfFiles[item.Key] = naShto;
                }
            }

        }

        //Getting extensions of all files
        public static Dictionary<string, int> GetFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (FileInfo item in di.GetFiles())
                if (!dict.ContainsKey(item.Extension))
                    dict.Add(item.Extension, 0);

            return dict;
        }

        public static List<FileInfo> ExtensionChoice(string path, string ext)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fi = di.GetFiles();
            List<FileInfo> TempFi = new List<FileInfo>();

            foreach (FileInfo item in fi)
            {
                if (item.Extension == ext)
                    TempFi.Add(item);
            }
            return TempFi;
        }

        public static Dictionary<char, string> GetNameOfFiles(List<FileInfo> collection)
        {
            Dictionary<char, string> chars = new Dictionary<char, string>();

            foreach (FileInfo item in collection)
                foreach (char ch in item.Name)
                    if (!char.IsLetter(ch) && !chars.ContainsKey(ch))
                        chars.Add(ch, "");

            return chars;
        }
    }
}