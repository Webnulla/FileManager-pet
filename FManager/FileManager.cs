using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace FManager
{
    public class FileManager
    {
        protected void Message(string message)
        {
            ConsoleLogger messages = new ConsoleLogger();
            messages.Info(message);
        }
        protected void DriveInfos()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Message($"Название: {drive.Name}");
                Message($"Тип: {drive.Name}");
                if (drive.IsReady)
                {
                    Message($"Объем диска: {drive.TotalSize / ( 1024 * 1024)}Mb");
                    Message($"Свободное пространство: {drive.TotalFreeSpace / (1024 * 1024)}Mb");
                }
            }
        }
        protected void MoveDirOrFile()
        {
            Message("Напишите папку/файл которые хотите переместить:");
            string? sourceDir = Console.ReadLine();
            Message("Напишите куда хотите переместить:");
            string? destDir = Console.ReadLine();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDir);
                if (dir.Exists && Directory.Exists(destDir) == false)
                {
                    dir.MoveTo(destDir);
                    Message("Каталог перемещен");
                }
                FileInfo file = new FileInfo(sourceDir);
                if (file.Exists)
                {
                    file.MoveTo(destDir);
                    Message("Файл перемещен");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Такая директория уже существует"));
            }
        }
        protected void CreateDirectory()
        {
            Message("Введите название нового каталога");
            string? path = Console.ReadLine();
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (!directory.Exists)
                {
                    directory.Create();
                    Message("Каталог создан");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Такой каталог уже существует"));
            }
        }
        protected void Delete()
        {
            Message("Напишите папку/файл которые хотите удалить:");
            string? path = Console.ReadLine();
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Delete(true);
                Message("Каталог удален");
                FileInfo file = new FileInfo(path);
                file.Delete();
                Message("Файл удален");
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Такого каталога или файла не существует"));
            }
        }
        protected void CopyFile()
        {
            Message("Напишите файл который хотите скопировать:");
            string? oldPath = Console.ReadLine();
            Message("Напишите куда хотите скопировать:");
            string? newPath = Console.ReadLine();
            try
            {
                FileInfo file = new FileInfo(oldPath);
                if (file.Exists)
                {
                    file.CopyTo(newPath);
                    Message("Файл скопирован");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Такого файла не существует"));
            }
        }
        protected void CreateFile()
        {
            Message("Введите название нового файла");
            string? path = Console.ReadLine();
            try
            {
                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                {
                    file.Create();
                    Message("Файл создан");
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Такой каталог уже существует"));
            }  
        }
    }
}
