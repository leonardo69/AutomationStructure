namespace Automation.Module.KitchenUpOneFacade.Calculation
{
    public class FurnitureItem
    {
        public int LoopsCount { get; set; }
        public int ModuleCount { get; set; }
        public int ShelfsCount { get; set; }
        /// <summary>
        /// Количество ручек
        /// </summary>
        public int HandlesCount { get; set; }

        /// <summary>
        /// Количество навесов
        /// </summary>
        public int CanopyCount { get; set; }
        public double Plate { get; set; }

        /// <summary>
        /// Кромка
        /// </summary>
        public int Kant { get; set; }
        public double BackPanel { get; set; }


        public object[] ConvertToDataRow()
        {
            object[] valueObjects = {
                LoopsCount,
                ModuleCount,
                ShelfsCount,
                HandlesCount,
                CanopyCount,
                Plate,
                Kant,
                BackPanel
            };
            return valueObjects;
        }
    }
}
