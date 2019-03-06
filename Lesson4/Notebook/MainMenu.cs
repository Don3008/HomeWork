using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    enum ChoiseAct
    {
        Write = 1,
        Read
    }

    public enum HowWrite
    {
        ManyFiles = 1,
        OneFile
    }

    class MainMenu
    {
        static void Main(string[] args)
        {
            WriteOrRead();
        }

        static void WriteOrRead()
        {
            ChoiseAct choiseAct = new ChoiseAct();
            Console.WriteLine($"Выберете действие, которое хотите сделать: \n {(int)ChoiseAct.Write}. Сделать новую заметку. " +
                $"\n {(int)ChoiseAct.Read}. Открыть предыдущие заметки.");
            int userInput = int.Parse(Console.ReadLine());
            choiseAct = (ChoiseAct)userInput;
            switch (choiseAct)
            {
                case ChoiseAct.Write:
                    RecordingMethod();
                    break;
                case ChoiseAct.Read:
                    try
                    {
                        Notes.ReadFromDifferentFiles();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                    }
                    Notes.ReadFromOneFile();
                    break;
            }
        }

        static void RecordingMethod()
        {
            int count = 0;
            bool isExit = false;
            while (!isExit)
            {
                HowWrite howWrite = new HowWrite();
                Console.WriteLine("Выберете, как сохранять данные: \n 1.В отдельных файлах. \n 2.В одном файле.");
                int variant = int.Parse(Console.ReadLine());
                howWrite = (HowWrite)variant;
                count = Notes.Variant(howWrite, count);
                isExit = Notes.NewNote(isExit);
            }
        }
    }
}
