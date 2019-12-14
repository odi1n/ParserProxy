using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenSaveTxtFile
{
    class OpenSave_Files
    {
        /// <summary>
        /// Открытие файла по пути
        /// </summary>
        /// <param name="Path">Путь для сохранения файла, указывать путь именно к самому файлу с .txt</param>
        /// <returns></returns>
        public static string Open_File_Path(string Path)
        {
            return Path = System.IO.File.ReadAllText(Path);
        }

        /// <summary>
        /// Сохранение txt файла по указанному пути с указанным именем
        /// </summary>
        /// <param name="Path">Путь для сохранения файла</param>
        /// <param name="NameFile">Название с которым сохраниться наш файл</param>
        /// <param name="Content">Что  сохранить</param>
        public static void Save_File_Path(string Path, string NameFile, string Content)
        {
            System.IO.File.WriteAllText(Path + @"\" + NameFile + ".txt", Content);
        }

        /// <summary>
        /// Выбор файла пользователем для открытия
        /// </summary>
        /// <param name="Content">Переменная в которую записать открытый файл</param>
        public static void Open_Vibor_Polzovatelya(ref string Content)
        {
            OpenFileDialog OpFile = new OpenFileDialog();
            if (OpFile.ShowDialog() == DialogResult.OK)
            {
                Content = System.IO.File.ReadAllText(OpFile.FileName);
            }
        }

        /// <summary>
        /// Выбор пользователем куда сохранить файл
        /// </summary>
        /// <param name="Content_Save">Переменная которую мы сохраним</param>
        public static void Save_Vibor_Polzovatelya(string Content_Save)
        {
            SaveFileDialog SaFile = new SaveFileDialog();
            if (SaFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(SaFile.FileName + ".txt", Content_Save);
            }
        }

        /// <summary>
        /// Получить путь к папке
        /// </summary>
        /// <param name="Path"></param>
        public static void Path_Papki(ref string Path)
        {
            FolderBrowserDialog FoBrowser = new FolderBrowserDialog();
            if (FoBrowser.ShowDialog() == DialogResult.OK)
            {
                Path = FoBrowser.SelectedPath;
            }
        }


        /// <summary>
        /// Сохранить массив
        /// </summary>
        /// <param name="Save_Arr">Массив который мы сохраняем</param>
        /// <param name="NameFile">Название файла</param>
        public static void Arr_Save(string[] Save_Arr, string NameFile)
        {
            System.IO.File.Create(NameFile + ".txt").Close();
            System.IO.File.WriteAllLines(NameFile + ".txt", Save_Arr);
        }

        /// <summary>
        /// Открыть массив
        /// </summary>
        /// <param name="NameFile">Название файла в котором находится массив</param>
        /// <returns></returns>
        public static string[] Arr_Open(string NameFile)
        {
            string[] Arr;
            return Arr = System.IO.File.ReadAllLines(NameFile + ".txt");
        }
    }
}
