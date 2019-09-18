namespace Automation.Module.KitchenUp.Calculation
{
    public class LoopsItem
    {
        public string Name { get; set; }
        public double FirstLoop { get; set; }
        public double SecondLoop { get; set; }
        public double ThirdLoop { get; set; }
        public int? FourthLoop { get; set; }

        public object[] ConvertToDataRow()
        {
            object[] valueObjects = {
                Name,
                FirstLoop,
                SecondLoop,
                ThirdLoop,
                FourthLoop
            };
            return valueObjects;
        }

    }
}
