using Automation.Infrastructure;
using Automation.Module.KitchenUp;
using Automation.Module.KitchenUpOneFacade;

namespace Automation.ModuleFactory
{
    public static class ModuleFactory
    {
        public static BaseModule GetModule(CategoryType type)
        {
            BaseModule module = null;
            switch (type)
            {
                case CategoryType.KitchenUp:
                    module = new KitchenUpOneFacade();
                    break;
            }
            return module;
        }
    }
}