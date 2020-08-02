using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using FilesTracker.Model.Entities;

namespace FilesTracker.Model.BLL
{
    public class LayerApplier
    {

        /// <summary>
        /// Применить изменение на хранилище
        /// </summary>
        public StateStorage Apply(StateStorage storage, LayerInfo layer)
        {
            switch (layer.ChangeType)
            {
                case WatcherChangeTypes.Deleted:
                    storage.FilesData.Remove(Path.Combine(layer.RelativePath, layer.FileName));
                    break;
                case WatcherChangeTypes.Renamed:
                    storage.FilesData.Add(
                        Path.Combine(layer.RelativePath, layer.NewName),
                        storage.FilesData[Path.Combine(layer.RelativePath, layer.FileName)]
                        );
                    storage.FilesData.Remove(Path.Combine(layer.RelativePath, layer.FileName));
                    break;
                case WatcherChangeTypes.Changed:

                    var key = Path.Combine(layer.RelativePath, layer.FileName);

                    if (!storage.FilesData.ContainsKey(key))
                    {
                        storage.FilesData.Add(key, new StorageData()
                        {
                            Name = layer.FileName,
                            Relative = layer.RelativePath,
                            Text = layer.AddOrUpdateData.ChangesRows
                                .Select(e => e.Content)
                                .ToArray()
                        });
                    }
                    else
                    {
                        var item = storage.FilesData[key];
                        var rows = new List<string>(item.Text);

                        foreach (var elem in layer.AddOrUpdateData.ChangesRows)
                        {
                            if (elem.RowNumber < rows.Count - 1)
                            {
                                rows[elem.RowNumber] = elem.Content;
                            }
                            else
                            {
                                rows.Add(elem.Content);
                            }
                        }

                        item.Text = rows
                            .Take(layer.AddOrUpdateData.LastRowNumber)
                            .ToArray();
                    }
                    break;
            }

            return storage;
        }

    }
}
