using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Storages.Abstract
{
    public interface IStorageService : IStorage
    {
        public string StorageType { get; }
    }
}
