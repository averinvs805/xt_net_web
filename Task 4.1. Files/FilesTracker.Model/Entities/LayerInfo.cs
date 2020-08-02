using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace FilesTracker.Model.Entities
{
    /// <summary>
    /// Изменения в слое
    /// </summary>
    public class LayerInfo
    {
        /// <summary>
        /// Дата изменения (служит ключем)
        /// </summary>
        public DateTime EventDate { set; get; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { set; get; }

        /// <summary>
        /// Новое имя файла (только при переименовании)
        /// </summary>
        public string NewName { set; get; }

        /// <summary>
        /// Относительный путь относительно наблюдаемой папки
        /// </summary>
        public string RelativePath { set; get; }

        /// <summary>
        /// Тип изменения
        /// </summary>
        public WatcherChangeTypes ChangeType { set; get; }

        /// <summary>
        /// Набор изменении внутри содержимого файла
        /// </summary>
        public AddOrUpdateData AddOrUpdateData { set; get; }

    }
}
