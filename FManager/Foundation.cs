using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FManager
{
    public class Foundation : FileManager
    {
        private void Cursor()
        {
            Message("Выберите диск: ");
            int top = Console.CursorTop;
            int y = top;

            Message("C: ");
            Message("D: ");

            int down = Console.CursorTop;
            Console.CursorTop = top;

            ConsoleKey key;
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.UpArrow)
                {
                    if (y > top)
                    {
                        y--;
                        Console.CursorTop = y;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (y < down - 1)
                    {
                        y++;
                        Console.CursorTop = y;
                    }
                }
            }
            Console.CursorTop = down;
            if (y == top)
            {
                foreach (var file in Directory.GetFileSystemEntries("C:\\"))
                {
                    Message(file);
                }
            }
            else if (y == top + 1)
            {
                foreach (var file2 in Directory.GetFileSystemEntries("D:\\"))
                {
                    Message(file2);
                }
            }
        }
        public void Navigation()
        {
            DriveInfos();
            Message("");
            Cursor();
            KeysInfo();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F2:
                        var dir = Directory.GetFileSystemEntries(Console.ReadLine());
                        foreach (var file in dir)
                        {
                            Message(file);
                        }
                        break;
                    case ConsoleKey.F3:
                        CopyFile();
                        break;
                    case ConsoleKey.F4:
                        MoveDirOrFile();
                        break;
                    case ConsoleKey.F5:
                        Delete();
                        break;
                    case ConsoleKey.F6:
                        CreateDirectory();
                        break;
                    case ConsoleKey.F7:
                        CreateFile();
                        break;
                    case ConsoleKey.Escape:
                        Cursor();
                        break;
                    default:
                        break;
                }  
            }
        }  
        private void KeysInfo()
        {
            string[] info = { "F2: Зайти в папку, ", "F3: Копировать файл, ", "F4: Переместить папку/файл, ", "F5: Удалить, ", 
                "F6: Создать папку, ", "F7: Создать файл, ", "Esc: Возвращение к дискам" };
            foreach (var key in info)
            {
                Console.Write(key);               
            }
            Message("");
        }
    }
}
