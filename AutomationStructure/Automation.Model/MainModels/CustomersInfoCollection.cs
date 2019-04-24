using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    [Serializable]
    public class CustomersInfoCollection
    {

        private List<CustomerRecord> _records;


        public CustomersInfoCollection()
        {
            _records = new List<CustomerRecord>();
            InitCustomerRecords();
        }

        private void InitCustomerRecords()
        {
            _records.Add(new CustomerRecord { Material = "ЛДСП" });
            _records.Add(new CustomerRecord { Material = "Кромка для ЛДСП" });
            _records.Add(new CustomerRecord { Material = "Задняя панель" });
            _records.Add(new CustomerRecord { Material = "Фасад" });
        }

        public void SetInputData(List<string[]> customerData)
        {
            for (int i = 0; i < customerData.Count; i++)
            {
                _records[i].Material = customerData[i][0].ToString();
                _records[i].Information = customerData[i][1].ToString();
                _records[i].ThicknessMaterial = customerData[i][2].ToString();
            }
        }

        public string GetTotalCustomerRecord()
        {
            return _records.Aggregate(string.Empty,
                (current, t) => current + ("Материал: " + t.Material +
                                           " ,Информация: "+t.Information+
                                           " ,Толщина материала: "+t.ThicknessMaterial+
                                           "\n"));
        }


    }
}
