using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Automation.Infrastructure;
using Automation.Infrastructure.CreateRequest;

namespace Automation.KitchenDownLib
{
    public static class KitchenDownLib
    {
        private static readonly Dictionary<string, LibModuleInfo> ModulesName;

        static KitchenDownLib()
        {
            ModulesName = new Dictionary<string, LibModuleInfo>
            {
                { "kitchen_down_one_fasade_left", new LibModuleInfo
                    {
                        CategoryType = CategoryType.KitchenDown,
                        BuildType = "KitchenDownOneFacade",
                        Name = "Один фасад",
                        Scheme = "kitchen_up_one_fasade_left"
                    }
                }
            };
        }


        public static List<LibItem> GetAllModules()
        {
            var schemeModules = Properties.Resources.ResourceManager
                .GetResourceSet(CultureInfo.CurrentCulture, true, true)
                .Cast<DictionaryEntry>()
                .Select(x => new LibItem
                {
                    Name = ModulesName[x.Key.ToString()].Name,
                    ModuleInfo = ModulesName[x.Key.ToString()],
                    Image = (Bitmap)x.Value
                }).ToList();


            return schemeModules;
        }
    }
}
