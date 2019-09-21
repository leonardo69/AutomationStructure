using Automation.Infrastructure;
using Automation.Module.KitchenUpOneFacade;

namespace Automation.ModuleFactory
{
    public static class ModuleFactory
    {
        public static BaseModule GetModule(string moduleBuildName, CategoryType type)
        {
            //var test = Activator.CreateInstance("Automation.Module.KitchenUpOneFacade", "KitchenUpOneFacade");
            if (type == CategoryType.KitchenUp)
            {
                switch (moduleBuildName)
                {
                    case "KitchenUpOneFacade": 
                        return new KitchenUpOneFacade();

                }
            }

            if (type == CategoryType.KitchenDown)
            {
                switch (moduleBuildName)
                {
                    case "KitchenDownOneFacade":
                        return null;
                }
            }

            return null;
        }
    }
}