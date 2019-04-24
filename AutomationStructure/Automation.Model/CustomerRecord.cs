using System;
using System.Globalization;

namespace Automation.Model
{
    [Serializable]
    public class CustomerRecord
    {
 
        public string Material { get; set; }
        public string Information { get; set; }
        public string ThicknessMaterial { get; set; }
        public bool HaveSpecificThickness { get; set; }


        public ThicknessSpecificData GetSpecificData()
        {
           
            return null;
        }

       
        public override string ToString()
        {
            return "Материал: " + Material +
                   "Информация:" + Information +
                   "Толщина" + ThicknessMaterial;
        }
    }
}