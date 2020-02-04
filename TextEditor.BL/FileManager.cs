using System.IO;
using System.Text;

namespace TextEditor.BL
{
    public interface IFileManager<T>
    {
        string GetContent(T filePath);
        string GetContent(T filePath, Encoding encoding);
        void SaveContent(string content, T filePath);
        void SaveContent(string content, T filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExist(T filePath);
    }

    public class FileManager : IFileManager<string> //класс реализовывает все методы, которые будут работать в exe файле
        //здесь их надо описать, затем подключить библиотеку к основному проекту, там будут релизованны кнопки и поля
        //из набора инструментов WinForms. Задача заключается в подключении всех методов здесь реализованных к 
        //кнопкам и полям, реализованным в TextEditor
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);    //кодировка по умолчанию то есть кодировку Windows
        public bool IsExist (string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }
        public string GetContent(string filePath)   //перегруженный метод, принимающий только один параметр - путь к файлу
            //суть метода в том, что он вызывает ранее объявленный метод GetContent, в который передает заданную кодировку по умолчанию
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public string GetContent(string filePath, Encoding encoding)
        //метод открывает текстовый файл 
        //первым параметорм получает путь к файлу
        //вторым параметром получает кодировку, потому что текстовый файл может быть в различной кодировке
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        //организуем сохраниение файла
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        //метод реализующий подсчет количества символов
        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

    }
}
