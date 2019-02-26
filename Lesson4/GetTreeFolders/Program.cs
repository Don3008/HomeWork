using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetTreeFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Program Files\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string s in dirs)
                {
                    string[] dirs2 = Directory.GetDirectories(s);
                    foreach (string s2 in dirs2)
                    {
                        DirectoryInfo test2 = new DirectoryInfo(s2);
                        DirectoryInfo[] dirs3 = test2.GetDirectories();
                        foreach (DirectoryInfo s3 in dirs3)
                        {
                            FileInfo[] files = s3.GetFiles();
                            foreach (FileInfo fi in files)
                            {
                                Console.WriteLine(fi.FullName);
                            }
                        }
                    }
                }
            }
        }
    }
}
