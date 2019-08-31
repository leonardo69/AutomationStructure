using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Module.KitchenUp.Details
{
    public class DetailsItem
    {
        /// <summary>
        /// Номер детали
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Название детали
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ширина детали
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Кромка по ширине
        /// </summary>
        public Kant KantByWidth { get; set; }

        /// <summary>
        /// Длина детали
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Кромка по длине
        /// </summary>
        public Kant KantByLength { get; set; }

        /// <summary>
        /// Количество деталей
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Примечание детали
        /// </summary>
        public string Note { get; set; }

        public object[] ConvertToDataRow()
        {
            object[] valueObjects = {
                Number,
                Name,
                Length,
                GetKantPairString(KantByLength.Width,KantByLength.Length),
                Width,
                GetKantPairString(KantByWidth.Width, KantByWidth.Length),
                Count,
                Note
            };
            return valueObjects;
        }

        public string GetKantPairString(double width, double length)
        {
            var widthKant = width < 0.1 ? "" : width.ToString(CultureInfo.InvariantCulture);
            var lengthKant = length < 0.1 ? "" : length.ToString(CultureInfo.InvariantCulture);
            return $"{widthKant}       {lengthKant}";
        }
    }

    public class Kant
    {
        /// <summary>
        /// Ширина кромки
        /// </summary>
        public double Width { get; set; }
        
        /// <summary>
        /// Длина кромки
        /// </summary>
        public double Length { get; set; }
    }
}
