using System;
using System.Collections.Generic;
using System.Linq;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class CustomerInfo
    {
        private readonly List<CustomerInfoRecord> _records;


        public CustomerInfo()
        {
            _records = new List<CustomerInfoRecord>();
            InitCustomerRecords();
        }

        private void InitCustomerRecords()
        {
            _records.Add(new CustomerInfoRecord {Material = "ЛДСП"});
            _records.Add(new CustomerInfoRecord {Material = "Кромка для ЛДСП"});
            _records.Add(new CustomerInfoRecord {Material = "Задняя панель"});
            _records.Add(new CustomerInfoRecord {Material = "Фасад"});
        }

        public void SetInputData(List<string[]> customerData)
        {
            for (var i = 0; i < customerData.Count; i++)
            {
                _records[i].Material = customerData[i][0];
                _records[i].Information = customerData[i][1];
                _records[i].ThicknessMaterial = customerData[i][2];
            }
        }

        public string GetTotalCustomerInfoRecord()
        {
            return _records.Aggregate(string.Empty,
                (current, t) => current + "Материал: " + t.Material + " ,Информация: " + t.Information +
                                " ,Толщина материала: " + t.ThicknessMaterial + "\n");
        }
    }
}