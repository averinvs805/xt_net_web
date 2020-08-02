using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1._Files
{
    /// <summary>
    /// Хранит состояние файлов
    /// </summary>
    class StateStorage
    {
        public Dictionary<string, StorageData> FilesData { private set; get; }
            = new Dictionary<string, StorageData>();
    }

    /// <summary>
    /// Состояние одного файла
    /// </summary>
    class StorageData
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Имя и путь
        /// </summary>
        public string FullName { set; get; }
        /// <summary>
        /// Относительный путь
        /// </summary>
        public string Relative { set; get; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public string[] Text { set; get; }
    }
}
