using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTracker.Model.Entities
{
    /// <summary>
    /// Хранит состояние файлов
    /// </summary>
    public class StateStorage
    {
        /// <summary>
        /// Key - RelativePath\FileName
        /// </summary>
        public Dictionary<string, StorageData> FilesData { private set; get; }
            = new Dictionary<string, StorageData>();
    }

    /// <summary>
    /// Состояние одного файла
    /// </summary>
    public class StorageData
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Имя и путь
        /// </summary>
        //public string FullName { set; get; }
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
