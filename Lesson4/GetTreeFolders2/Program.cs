using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetTreeFolders2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string path = @"C:\Program Files";
            SearchFolder(path, count);
        }
        static void SearchFolder(string path, int count)
        {
            count++;
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] dirs = d.GetDirectories();
            DirectoryInfo f = new DirectoryInfo(path);
            FileInfo[] files = f.GetFiles();
            if (dirs.Length == 0)
            {
                count = 0;
            }
            foreach (FileInfo h in files)
            {
                if (files.Length > 4)
                {
                    Console.WriteLine(h);
                }
            }
            foreach (DirectoryInfo s in dirs)
            {
                string a = @"\";
                if (count >= 3)
                {
                    Console.WriteLine(path + a + s.Name);
                }
                SearchFolder(path + a + s.Name, count);
            }
        }
    }
}
