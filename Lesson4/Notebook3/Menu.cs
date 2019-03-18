using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notebook3
{
    enum Variants
    {
        CreateNew = 1,
        UseOld
    }

    enum OldNote
    {
        Read = 1,
        Write
    }

    class Menu
    {
        public bool Repeat { get; private set; }
        static string path = ".\\Notes";
        static Note[] notes;
        static int notesCount = 0;

        static void Main(string[] args)
        {
            initial();
            Variants variant = new Variants();
            OldNote oldNote = new OldNote();
            bool isExit = false;
            while (!isExit)
            {
                CreateNewOrUseOld(variant, path, notesCount, oldNote);
                isExit = NewNote(isExit);
            }
        }

        static void initial()
        {
            DirectoryInfo rootFolder = new DirectoryInfo(path);

            if (!rootFolder.Exists)
            {
                rootFolder.Create();
            }
            FileInfo[] files = rootFolder.GetFiles();
            notesCount = files.Length;
            notes = new Note[notesCount + 20];
            for (int i = 0; i < notesCount; i++)
            {
                notes[i] = new Note(files[i]);
            }
        }

        static void CreateNewOrUseOld(Variants variant, string path, int notesCount, OldNote oldNote)
        {
            Console.WriteLine("Желаете записать новую записку или работать с уже имеющейся? \n{0} - Записать новую \n" +
            "{1} - Открыть старую", (int)Variants.CreateNew, (int)Variants.UseOld);
            int input = int.Parse(Console.ReadLine());
            variant = (Variants)input;
            Note note;
            switch (variant)
            {
                case Variants.CreateNew:
                    notesCount++;
                    note = new Note(path);
                    notes[notesCount] = note;
                    WriteNote(note, false);
                    break;
                case Variants.UseOld:
                    ShowCountNotes();
                    int choose = ChooseNote();
                    Console.WriteLine("Что сделать с заметкой? \n {0} - Открыть для чтения \n {1} - Дозаписать", (int)OldNote.Read, (int)OldNote.Write);
                    input = int.Parse(Console.ReadLine());
                    oldNote = (OldNote)input;
                    switch (oldNote)
                    {
                        case OldNote.Read:
                            note = notes[choose - 1];
                            Console.WriteLine(note.Text);
                            break;
                        case OldNote.Write:
                            WriteNote(notes[choose - 1], true);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        static void ShowCountNotes()
        {
            Console.WriteLine("У вас {0} заметок", notesCount);
        }

        static void ShowNamesNotes()
        {
            foreach (var note in notes)
            {
                if (note != null)
                    Console.WriteLine("Имя: {0}, Время создания: {1}", note.Name, note.CreateTime);
            }
        }

        static int ChooseNote()
        {
            ShowNamesNotes();
            Console.WriteLine("Пожалуйста выберете: ");
            int choose = int.Parse(Console.ReadLine());
            return choose;
        }

        static void WriteNote(Note note, bool append)
        {
            Console.WriteLine("Введите текст заметки: ");
            string text = Console.ReadLine();
            note.Write(text, append);
        }

        static bool NewNote(bool isExit)
        {
            bool correctInput = false;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (!correctInput)
            {
                Console.WriteLine("Хотите создать еще одну заметку? \n" +
                "Нажмите Y, если да, N - если нет");
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    correctInput = true;
                    return isExit;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    correctInput = true;
                    isExit = true;
                    return isExit;
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                }
            }
            return isExit;
        }
    }
}
