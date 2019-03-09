using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notebook2
{
    class Note
    {
        public string Name { get; private set; }
        public DateTime CreateTime { get; private set; }
        public bool Exists { get; private set; }
        public string Path { get; private set; }
        public string Text { get; private set; }

        private FileInfo FileNote;
        private int count = 0;

        public Note(string path)
        {
            Name = count.ToString();
            Path = path + Name + ".txt";
            FileNote = new FileInfo(Path);
            Exists = FileNote.Exists;
            CreateTime = DateTime.Now;
            count++;
            //Text = ReadFile();
        }

        private string ReadFile()
        {
            string text;
            using (StreamReader reader = new StreamReader(Path, Encoding.Default))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        public void Write(string text)
        {
            // Проверка
            if (!Exists)
            {
                FileNote.Create();
                CreateTime = DateTime.Now;
            }
            //Записали
            string dateToday = CreateTime.ToString();
            using (StreamWriter writer = new StreamWriter(Path, false, Encoding.Default))
            {
                writer.WriteLine(dateToday);
                writer.WriteLine(text);
            }
            //Считали
            Text = ReadFile();
        }

        public void Delete()
        {
            // Delete File
        }
    }




    
}

