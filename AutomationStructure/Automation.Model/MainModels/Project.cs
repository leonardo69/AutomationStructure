using System;

namespace Automation.Model.MainModels
{
   [Serializable]
   public class Project
    {
        public CustomerInfo Customer { get; }
        public CategoriesCollection Categories { get; }

        public Project()
        {
            Customer = new CustomerInfo();
            Categories = new CategoriesCollection();
        }

    }
}
