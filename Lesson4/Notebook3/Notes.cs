using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notebook3
{
    class Note
    {
        public string Name;
        public DateTime CreateTime;
        public bool Exists;
        public string Path;
        public string text;

        public string Text
        {
            get
            {
                return text;
            }
            private set
            {
                text = value;
            }
        }

        private FileInfo FileNote;

        public Note(string path)
        {
            Path = path;
            Name = GetName();
            FileNote = new FileInfo(Path + "\\" + Name);
            Exists = FileNote.Exists;
            if (Exists)
            {
                Text = ReadFile();
            }
        }

        public Note(FileInfo file)
        {
            FileNote = file;
            Path = FileNote.DirectoryName;
            Exists = FileNote.Exists;
            Name = FileNote.Name;
            if (Exists)
            {
                Text = ReadFile();
            }
            CreateTime = FileNote.CreationTime;
        }

        public string ReadFile()
        {
            string text;
            using (StreamReader reader = FileNote.OpenText())
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        public void Write(string text, bool append)
        {
            string dateToday = DateTime.Now.ToString();
            string currentText;
            if (append)
            {
                currentText = ReadFile();
                text += "\n";
                text += currentText;
            }
            using (StreamWriter writer = FileNote.CreateText())
            {
                writer.WriteLine(dateToday);
                writer.WriteLine(text);
            }
            Text = text;
        }

        private string GetName()
        {
            int name = CheckNumber();
            return name.ToString();
        }

        private int CheckNumber()
        {
            DirectoryInfo dir = new DirectoryInfo(Path);
            var files = dir.GetFiles();
            int count = 0;
            foreach (var item in files)
            {
                int t = int.Parse(item.Name);
                if (t > count)
                {
                    count = t;
                }
            }
            count++;
            return count;
        }

        public void Delete()
        {
            // Delete File
        }
    }
}
