using Automation.Infrastructure;
using Automation.Module.KitchenDown;
using Automation.Module.KitchenUp;

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
                    module = new KitchenUp();
                    break;
                case CategoryType.KitchenDown:
                    module = new KitchenDown();
                    break;
            }
            return module;
        }
    }
}