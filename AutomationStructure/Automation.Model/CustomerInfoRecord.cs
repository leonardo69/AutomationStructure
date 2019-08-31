using System;

namespace Automation.Model
{
    [Serializable]
    public class CustomerInfoRecord
    {
 
        public string Material { get; set; }
        public string Information { get; set; }

        /// TODO: ��� ������������?
        public string ThicknessMaterial { get; set; }

       
        public override string ToString()
        {
            return "��������: " + Material +
                   "����������:" + Information +
                   "�������" + ThicknessMaterial;
        }
    }
}