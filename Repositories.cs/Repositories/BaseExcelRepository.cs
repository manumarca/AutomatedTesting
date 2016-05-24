using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.cs.Interfaces;
using Repositories.cs.Helpers;

namespace Repositories.cs.Repositories
{
    public class BaseExcelRepository<T> : IRepository<T> where T : class
    {
        DataHelper dataHelper = new DataHelper();

        public List<T> GetList()
        {
            dataHelper.Open();

            try
            {
                List<T> list = new List<T>();
                Type type = typeof(T);
                var sheetName = type.Name;
                dataHelper.SelectSheetByName(sheetName);
                var listPropData = dataHelper.GetFirstRowNamesList();
                for (var i = 2; i <= dataHelper.GetActualSheetRowsCount(); i++)
                {
                    object obj = Activator.CreateInstance(type);
                    foreach (string propName in listPropData)
                    {
                        var prop = type.GetField(propName);
                        prop.SetValue(obj, dataHelper.Read(dataHelper.GetColumnbyName(propName) + i));
                    }
                    list.Add((T)obj);
                }
                dataHelper.Close();
                return list;
            }
            catch(Exception e)
            {
                dataHelper.Close();
                throw new Exception("Fail due to: " + e.Message);
            }
        }

        public List<T> GetListByKeyAndValue(string keyName, string keyValue)
        {
            dataHelper.Open();

            try
            {
                List<T> results = new List<T>();
                Type type = typeof(T);
                var sheetName = type.Name;
                dataHelper.SelectSheetByName(sheetName);
                var listPropData = dataHelper.GetFirstRowNamesList();
                foreach (int i in dataHelper.GetRowsByColumnAndValue(keyName, keyValue))
                {
                    object obj = Activator.CreateInstance(type);
                    foreach (string propName in listPropData)
                    {
                        var prop = type.GetField(propName);
                        prop.SetValue(obj, dataHelper.Read(dataHelper.GetColumnbyName(propName) + i));
                    }
                    results.Add((T)obj);
                }
                dataHelper.Close();
                return results;
            }
            catch (Exception e)
            {
                dataHelper.Close();
                throw new Exception("Fail due to: " + e.Message);
            }
        }

        public T GetObject(string row)
        {
            dataHelper.Open();
            try
            {
                Type type = typeof(T);
                var sheetName = type.Name;
                dataHelper.SelectSheetByName(sheetName);
                var listPropData = dataHelper.GetFirstRowNamesList();
                object obj = Activator.CreateInstance(type);
                foreach (string propName in listPropData)
                {
                    var prop = type.GetField(propName);
                    prop.SetValue(obj, dataHelper.Read(dataHelper.GetColumnbyName(propName) + row));
                }
                dataHelper.Close();
                return (T)obj;
            }
            catch (Exception e)
            {
                dataHelper.Close();
                throw new Exception("Fail due to: " + e.Message);
            }
        }

        public void SetObject(T obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
