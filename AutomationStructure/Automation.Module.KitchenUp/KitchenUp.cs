using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Automation.Infrastructure;


namespace Automation.Module.KitchenUp
{
    [Serializable]
    public class KitchenUp : BaseModule
    {
        public KitchenUp()
        {
            _facade = new Facade();
            int countRows = GetCountRows();
            _facade.InitFacadeRecords(countRows);
            _dimentions = new Dimensions();
            _shelfsCount = "";
        }


        private Dimensions _dimentions;
        private Facade _facade;
        private string _shelfAssembly;
        private string _shelfsCount;
        private string _calcMode;
        private string _moduleAssembly;

        public override void AddFacade()
        {
            if (_facade._records.Count == 4)
                throw new ArgumentException("Количество фасадов не может быть больше четырёх");
            FacadeRecord facade = new FacadeRecord()
            {
                NumberOnScheme = _facade._records.Count + 1
            };
            _facade._records.Add(facade);
        }
        public override void DeleteFacade()
        {
            if (_facade._records.Count == 0)
                throw new ArgumentException("Количество фасадов не может быть меньше нуля");
            _facade._records.RemoveAt(_facade._records.Count - 1);
        }


        public override void SetupModule(DataTable changedInfo)
        {
            int countRows = changedInfo.Rows.Count;
            DataRow row = changedInfo.Rows[0];
            Number = row["Номер модуля"].ToString();
            IconPath = row["Изображение"].ToString();
            Sсheme = row["Форма модуля"].ToString();
            if (!double.TryParse(row["Высота модуля (мм)"].ToString(), out double height))
                throw new ArgumentException("Высота модуля должна быть числом");
            if (height < 0)
                throw new ArgumentException("Высота модуля не может быть отрицательной");
            _dimentions.Height = height;
            if (!double.TryParse(row["Ширина модуля (мм)"].ToString(), out double width))
                throw new ArgumentException("Ширина модуля должна быть числом");
            if (width < 0)
                throw new ArgumentException("Ширина модуля не может быть отрицательной");
            _dimentions.Width = width;


            if (!int.TryParse(row["№ схемы фасада"].ToString(), out int facadeNumber))
                throw new ArgumentException("№ схемы фасада должен быть целым числом");
            _calcMode = row["Режим расчёта"].ToString();
            var formula = IconPath.Split('_')[1];
            if ((facadeNumber > 0) && (_calcMode == "авт. мод."))
            {
                _facade._records[0].HorisontalDimension = double.Parse(row["Ширина"].ToString());
                _facade._records[0].VerticalDimension = double.Parse(row["Высота"].ToString());
                KitchenUpFacadeCalculator calculator = new KitchenUpFacadeCalculator();
                calculator.CalculateModuleDimentions(_facade, _dimentions, formula);
            }

            if (!double.TryParse(row["Глубина модуля (мм)"].ToString(), out double depth))
                throw new ArgumentException("Глубина модуля должна быть числом"); ;
            if (depth < 0)
                throw new ArgumentException("Глубина модуля не может быть отрицательной");
            _dimentions.Depth = depth;
            if (!double.TryParse(row["A размер (мм)"].ToString(), out double a))
                throw new ArgumentException("A размер должен быть числом");
            if (a < 0)
                throw new ArgumentException("A размер не может быть отрицательным");
            _dimentions.A = a;
            if (!double.TryParse(row["B размер (мм)"].ToString(), out double b))
                throw new ArgumentException("B размер должен быть числом");
            if (b < 0)
                throw new ArgumentException("B размер не может быть отрицательным");
            _dimentions.B = b;
            if (!double.TryParse(row["C размер (мм)"].ToString(), out double c))
                throw new ArgumentException("C размер должен быть числом");
            if (c < 0)
                throw new ArgumentException("C размер не может быть отрицательным");
            _dimentions.C = c;
            if (!double.TryParse(row["D размер (мм)"].ToString(), out double d))
                throw new ArgumentException("D размер должен быть числом");
            if (d < 0)
                throw new ArgumentException("D размер не может быть отрицательным");
            _dimentions.D = d;
            _moduleAssembly = row["Сборка модуля"].ToString();
            BackPanelAssembly = row["Задняя стенка"].ToString();
            _shelfAssembly = row["Крепление полки"].ToString();
            _shelfsCount = row["Кол-во полок"].ToString();

            if (facadeNumber <= 0)
                return;
            _facade._records[0].NumberOnScheme = facadeNumber;
            _facade._records[0].Type = row["Тип фасада"].ToString();
            _facade._records[0].Material = row["Материал фасада"].ToString();

            for (int i = 0; i < changedInfo.Rows.Count; i++)
            {
                row = changedInfo.Rows[i];
                if (_calcMode == "авт. фас.")
                {
                    KitchenUpFacadeCalculator calculator = new KitchenUpFacadeCalculator();
                    calculator.CalculateFacadeDimentions(_facade, _dimentions, formula, i);
                }
                else
                {
                    _facade._records[i].HorisontalDimension = double.Parse(row["Ширина"].ToString());
                    _facade._records[i].VerticalDimension = double.Parse(row["Высота"].ToString());
                }
            }

        }

        public override void GetInfoRows(DataTable table)
        {
            DataRow row = table.NewRow();
            row["Номер модуля"] = Number;
            row["Форма модуля"] = Sсheme;
            row["Изображение"] = IconPath;
            row["Высота модуля (мм)"] = _dimentions.Height;
            row["Ширина модуля (мм)"] = _dimentions.Width;
            row["Глубина модуля (мм)"] = _dimentions.Depth;
            row["A размер (мм)"] = _dimentions.A;
            row["B размер (мм)"] = _dimentions.B;
            row["C размер (мм)"] = _dimentions.C;
            row["D размер (мм)"] = _dimentions.D;
            row["Сборка модуля"] = _moduleAssembly;
            row["Задняя стенка"] = BackPanelAssembly;
            row["Крепление полки"] = _shelfAssembly;
            row["Кол-во полок"] = _shelfsCount;

            if (_facade._records.Count != 0)
            {
                row["№ схемы фасада"] = _facade._records[0].NumberOnScheme;
                row["Тип фасада"] = _facade._records[0].Type;
                row["Режим расчёта"] = _calcMode;
                row["Высота"] = _facade._records[0].VerticalDimension;
                row["Ширина"] = _facade._records[0].HorisontalDimension;
                row["Материал фасада"] = _facade._records[0].Material;
            }
            else
                row["№ схемы фасада"] = 0;
            table.Rows.Add(row);

            for (int i = 1; i < _facade._records.Count; i++)
            {
                DataRow anotherRow = table.NewRow();
                anotherRow["№ схемы фасада"] = _facade._records[i].NumberOnScheme;
                anotherRow["Высота"] = _facade._records[i].VerticalDimension;
                anotherRow["Ширина"] = _facade._records[i].HorisontalDimension;
                table.Rows.Add(anotherRow);
            }


        }

        private int GetCountRows()
        {
            int count = 1;

            switch (Sсheme)
            {
                case "1.jpg":
                    count = 1;
                    break;
                case "2+B.jpg":
                    count = 2;
                    break;

            }

            return count;
        }

        public override DataTable GetInfoTable()
        {
            DataTable table = GetEmptyTable();
            GetInfoRows(table);
            return table;
        }

        public override DataTable GetEmptyTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Номер модуля");
            table.Columns.Add("Форма модуля");
            table.Columns.Add("Изображение");
            table.Columns.Add("Высота модуля (мм)");
            table.Columns.Add("Ширина модуля (мм)");
            table.Columns.Add("Глубина модуля (мм)");
            table.Columns.Add("A размер (мм)");
            table.Columns.Add("B размер (мм)");
            table.Columns.Add("C размер (мм)");
            table.Columns.Add("D размер (мм)");
            table.Columns.Add("Сборка модуля");
            table.Columns.Add("Задняя стенка");
            table.Columns.Add("Крепление полки");
            table.Columns.Add("Кол-во полок");
            table.Columns.Add("№ схемы фасада");
            table.Columns.Add("Тип фасада");
            table.Columns.Add("Режим расчёта");
            table.Columns.Add("Высота");
            table.Columns.Add("Ширина");
            table.Columns.Add("Материал фасада");
            return table;
        }

        public override object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }

        public override Result Calculate()
        {
            KitchenUpCalculator calculator = new KitchenUpCalculator
            {
                Name = Name,
                Sсheme = Sсheme,
                IconPath = IconPath,
                BackPanelAssembly = BackPanelAssembly,
                Number = Number,
                SubScheme = SubScheme,
                _dimentions = _dimentions,
                _facade = _facade,
                _shelfAssembly = _shelfAssembly,
                _shelfsCount = _shelfsCount
            };

            Result result = new Result
            {
                ModuleName = calculator.GetModuleName(),
                ImagePath = calculator.GetImagePath(),
                MainInfo = calculator.GetMainInfo(),
                DetailsInfo = calculator.GetDetailsInfo(),
                FurnitureInfo = calculator.GetFurnitureInfo(),
                ShelfInfo = calculator.GetShelfInfo(),
                LoopsInfo = calculator.GetLoopsInfo()
            };

            return result;

        }
    }
}
