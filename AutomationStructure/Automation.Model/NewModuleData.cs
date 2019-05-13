using System;
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
        public CategoryType Type { get; set; }
    }
}
