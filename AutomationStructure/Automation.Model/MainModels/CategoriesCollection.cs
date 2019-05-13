using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Infrastructure;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class CategoriesCollection
    {
        private List<Category> _categories;

        public CategoriesCollection()
        {
            _categories = new List<Category>();
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        } 

        public void AddCategory(string nameProduct)
        {
            var product = new Category(nameProduct);
            if(_categories.Any(x=>x.Type==product.Type))
                throw new Exception($"Данный тип изделия \"{nameProduct}\" уже добавлен");
            _categories.Add(product);
        }

        public void DeleteCategory(string nameProduct)
        {
            var category = _categories.First(x => x.Type == x.GetType(nameProduct));
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        public int GetCountModules(string nameProduct)
        {
            var category = _categories.First(x => x.Type ==x.GetType(nameProduct));
            return category.GetCountModules();
        }

        public Category GetProduct(NewModuleData data)
        {
            return _categories.First(x => x.Type == data.Type);
        }

        public Category GetProduct(ProductType type)
        {
            return _categories.First(x => x.Type == type);
        }
    }

}
