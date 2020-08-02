using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

namespace FilesTracker.Model.DAL
{
    public class FileProvider
    {
        public string[] TryReadAllLines(string file)
        {
            return TryFile(() =>
            {
                return File.ReadAllLines(file);
            });
        }


        public T TryFile<T>(Func<T> action)
        {
            while (true)
            {
                try
                {
                    return action();
                }
                catch
                {
                    Thread.Sleep(10);
                }
            }
        }
        public void TryFile(Action action)
        {
            while (true)
            {
                try
                {
                    action();
                    return;
                }
                catch
                {
                    Thread.Sleep(10);
                }
            }
        }


        public void CreateWithDirectory(string filePath, Action action)
        {
            var dir = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (var s = File.Create(filePath))
            { }

            if (action == null)
            {
                return;
            }

            TryFile(action);
        }


    }
}
