﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1._Files
{
    public class RowInformation
    {
        /// <summary>
        /// Номер строки
        /// </summary>
        public int RowNumber { set; get; }
        /// <summary>
        /// новое содержимое
        /// </summary>
        public string Context { set; get; }
    }

    /// <summary>
    /// Информация об изменении содержимого файла
    /// </summary>
    public class AddOrUpdateData
    {
        /// <summary>
        /// Измененные строки
        /// </summary>
        public List<RowInformation> ChangesRows { set; get; }
        /// <summary>
        /// Кол-во строк
        /// </summary>
        public int LastRowNumber { set; get; }
    }
}
