using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Infrastructure.GlobalSettings
{

    public class VariableItem
    {
        public VariableType Type { get; set; }
        public dynamic Value { get; set; }
        public string Caption { get; set; }

        public bool TryGetNumber(out double number)
        {
            if (Type == VariableType.Number)
            {
                number = double.Parse(Value);
                return true;
            }

            number = 0;
            return false;
        }
    }

    public enum VariableType
    {
        Special,
        Number
    }
}
