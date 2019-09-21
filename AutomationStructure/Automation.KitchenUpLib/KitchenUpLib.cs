using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Infrastructure;
using Automation.Infrastructure.CreateRequest;

namespace Automation.KitchenUpLib
{
    public static class KitchenUpLib
    {
        private static readonly Dictionary<string, LibModuleInfo> ModulesName;

        static KitchenUpLib()
        {
            ModulesName = new Dictionary<string, LibModuleInfo>
            {
                { "kitchen_up_one_fasade_left", new LibModuleInfo
                    {
                        CategoryType = CategoryType.KitchenUp,
                        BuildType = "KitchenUpOneFacade",
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
