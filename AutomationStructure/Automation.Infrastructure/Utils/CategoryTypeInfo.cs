using System.Collections.Generic;

namespace Automation.Infrastructure.Utils
{
    public static class CategoryTypeInfo
    {
        private static readonly Dictionary<CategoryType, string> CategoryToName;
        private static readonly Dictionary<string, CategoryType> NameToCategory;

        static CategoryTypeInfo()
        {
            CategoryToName = new Dictionary<CategoryType, string>
            {
                {CategoryType.KitchenUp, "Кухня верхние модули" },
                {CategoryType.KitchenDown, "Кухня нижние модули" }
            };

            NameToCategory = new Dictionary<string, CategoryType>
            {
                { "Кухня верхние модули", CategoryType.KitchenUp},
                { "Кухня нижние модули", CategoryType.KitchenDown }
            };
        }

        public static string Name(CategoryType type)
        {
            return CategoryToName[type];
        }

        public static CategoryType Category(string name)
        {
            return NameToCategory[name];
        }

    }
}
