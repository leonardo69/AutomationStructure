using System;

namespace Automation.Model.MainModels
{
   [Serializable]
   public class Order
    {
        public CustomersInfoCollection Customer { get; private set; }
        public ProductsInfoCollection Products { get; private set; }

        public Order()
        {
            Customer = new CustomersInfoCollection();
            Products = new ProductsInfoCollection();
        }

    }
}
