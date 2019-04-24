using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Infrastructure;

namespace Automation.Model
{
    [Serializable]
    public class NewModuleData
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Scheme { get; set; }
        public string SubScheme { get; set; }
        public string SubSchemeIconPath { get; set; }
        public ProductType Type { get; set; }
    }
}
