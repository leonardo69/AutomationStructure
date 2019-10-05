using Automation.Infrastructure;
using Automation.Module.KitchenUpOneFacade;

namespace Automation.ModuleFactory
{
    public static class ModuleFactory
    {
        public static BaseModule GetModule(string moduleBuildName, CategoryType type, string moduleName, string schemeName)
        {
            if (type == CategoryType.KitchenUp)
            {
                switch (moduleBuildName)
                {
                    case "KitchenUpOneFacade": 
                        return new KitchenUpOneFacade(moduleName, schemeName);

                }
            }

            if (type == CategoryType.KitchenDown)
            {
                switch (moduleBuildName)
                {
                    case "KitchenDownOneFacade":
                        break;
                }
            }

            return null;
        }
    }
}