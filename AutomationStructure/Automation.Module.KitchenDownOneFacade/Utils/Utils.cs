using System;

namespace Automation.Module.KitchenDownOneFacade.Utils
{
    public static class Utils
    {
        public static int RoundToInt(this double value)
        {
            return (int) Math.Round(value, MidpointRounding.AwayFromZero);
        }

    }
}
