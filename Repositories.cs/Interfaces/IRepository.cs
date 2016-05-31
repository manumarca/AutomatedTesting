using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.cs.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        List<T> GetListByKeyAndValue(string key, string val);
        T GetObject(string row);
        void SetObject(T obj);
        void UpdateObject(string firstColumnName, string columnToBeUpdated, string updatedValue);
    }
}
