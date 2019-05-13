using System;

namespace Automation.Model.MainModels
{
   [Serializable]
   public class Order
    {
        public CustomerInfo Customer { get; private set; }
        public CategoriesCollection Products { get; private set; }

        public Order()
        {
            Customer = new CustomerInfo();
            Products = new CategoriesCollection();
        }

    }
}
