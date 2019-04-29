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
        private string _calcMode;
        private readonly Dimensions _dimensions;
        private readonly Facade _facade;
        private string _moduleAssembly;
        private string _shelfAssembly;
        private string _shelfsCount;
        private string _dishDrayer;
        private string _canopies;

        public KitchenUp()
        {
            _facade = new Facade();
            var countRows = GetCountRows();
            _facade.InitFacadeRecords(countRows);
            _dimensions = new Dimensions();
            _shelfsCount = "";
        }

        public override void AddFacade()
        {
            if (_facade.Records.Count == 4)
                throw new ArgumentException("Количество фасадов не может быть больше четырёх");
            var facade = new FacadeRecord
            {
                NumberOnScheme = _facade.Records.Count + 1
            };
            _facade.Records.Add(facade);
        }

        public override void DeleteFacade()
        {
            if (_facade.Records.Count == 0)
                throw new ArgumentException("Количество фасадов не может быть меньше нуля");
            _facade.Records.RemoveAt(_facade.Records.Count - 1);
        }


        public override void SetupModule(DataTable changedInfo)
        {
            var row = changedInfo.Rows[0];
            Number = row["Номер модуля"].ToString();
            IconPath = row["Изображение"].ToString();
            Scheme = row["Форма модуля"].ToString();
            if (!double.TryParse(row["Высота модуля (мм)"].ToString(), out var height))
                throw new ArgumentException("Высота модуля должна быть числом");
            if (height < 0)
                throw new ArgumentException("Высота модуля не может быть отрицательной");
            _dimensions.Height = height;
            if (!double.TryParse(row["Ширина модуля (мм)"].ToString(), out var width))
                throw new ArgumentException("Ширина модуля должна быть числом");
            if (width < 0)
                throw new ArgumentException("Ширина модуля не может быть отрицательной");
            _dimensions.Width = width;


            if (!int.TryParse(row["№ схемы фасада"].ToString(), out var facadeNumber))
                throw new ArgumentException("№ схемы фасада должен быть целым числом");
            _calcMode = row["Режим расчёта"].ToString();
            var formula = IconPath.Split('_')[1];
            if (facadeNumber > 0 && _calcMode == "авт. мод.")
            {
                _facade.Records[0].HorizontalDimension = double.Parse(row["Ширина"].ToString());
                _facade.Records[0].VerticalDimension = double.Parse(row["Высота"].ToString());
                var calculator = new KitchenUpFacadeCalculator();
                calculator.CalculateModuleDimensions(_facade, _dimensions, formula);
            }

            if (!double.TryParse(row["Глубина модуля (мм)"].ToString(), out var depth))
                throw new ArgumentException("Глубина модуля должна быть числом");
            if (depth < 0)
                throw new ArgumentException("Глубина модуля не может быть отрицательной");
            _dimensions.Depth = depth;
            if (!double.TryParse(row["A размер (мм)"].ToString(), out var a))
                throw new ArgumentException("A размер должен быть числом");
            if (a < 0)
                throw new ArgumentException("A размер не может быть отрицательным");
            _dimensions.A = a;
            if (!double.TryParse(row["B размер (мм)"].ToString(), out var b))
                throw new ArgumentException("B размер должен быть числом");
            if (b < 0)
                throw new ArgumentException("B размер не может быть отрицательным");
            _dimensions.B = b;
            if (!double.TryParse(row["C размер (мм)"].ToString(), out var c))
                throw new ArgumentException("C размер должен быть числом");
            if (c < 0)
                throw new ArgumentException("C размер не может быть отрицательным");
            _dimensions.C = c;
            if (!double.TryParse(row["D размер (мм)"].ToString(), out var d))
                throw new ArgumentException("D размер должен быть числом");
            if (d < 0)
                throw new ArgumentException("D размер не может быть отрицательным");
            _dimensions.D = d;
            _moduleAssembly = row["Сборка модуля"].ToString();
            BackPanelAssembly = row["Задняя стенка"].ToString();
            _shelfAssembly = row["Крепление полки"].ToString();
            _shelfsCount = row["Кол-во полок"].ToString();

            if (facadeNumber <= 0)
                return;
            _facade.Records[0].NumberOnScheme = facadeNumber;
            _facade.Records[0].Type = row["Тип фасада"].ToString();
            _facade.Records[0].Material = row["Материал фасада"].ToString();

            for (var i = 0; i < changedInfo.Rows.Count; i++)
            {
                row = changedInfo.Rows[i];
                if (_calcMode == "авт. фас.")
                {
                    var calculator = new KitchenUpFacadeCalculator();
                    calculator.CalculateFacadeDimensions(_facade, _dimensions, formula, i);
                }
                else
                {
                    _facade.Records[i].HorizontalDimension = double.Parse(row["Ширина"].ToString());
                    _facade.Records[i].VerticalDimension = double.Parse(row["Высота"].ToString());
                }
            }


            _dishDrayer = row["ПОСУДОСУШИЛКА"].ToString();
            _canopies = row["Навесы на стену"].ToString(); 
        }

        public override void GetInfoRows(DataTable table)
        {
            var row = table.NewRow();
            row["Номер модуля"] = Number;
            row["Форма модуля"] = Scheme;
            row["Изображение"] = IconPath;
            row["Высота модуля (мм)"] = _dimensions.Height;
            row["Ширина модуля (мм)"] = _dimensions.Width;
            row["Глубина модуля (мм)"] = _dimensions.Depth;
            row["A размер (мм)"] = _dimensions.A;
            row["B размер (мм)"] = _dimensions.B;
            row["C размер (мм)"] = _dimensions.C;
            row["D размер (мм)"] = _dimensions.D;
            row["Сборка модуля"] = _moduleAssembly;
            row["Задняя стенка"] = BackPanelAssembly;
            row["Крепление полки"] = _shelfAssembly;
            row["Кол-во полок"] = _shelfsCount;

            if (_facade.Records.Count != 0)
            {
                row["№ схемы фасада"] = _facade.Records[0].NumberOnScheme;
                row["Тип фасада"] = _facade.Records[0].Type;
                row["Режим расчёта"] = _calcMode;
                row["Высота"] = _facade.Records[0].VerticalDimension;
                row["Ширина"] = _facade.Records[0].HorizontalDimension;
                row["Материал фасада"] = _facade.Records[0].Material;
            }
            else
            {
                row["№ схемы фасада"] = 0;
            }

            table.Rows.Add(row);

            for (var i = 1; i < _facade.Records.Count; i++)
            {
                var anotherRow = table.NewRow();
                anotherRow["№ схемы фасада"] = _facade.Records[i].NumberOnScheme;
                anotherRow["Высота"] = _facade.Records[i].VerticalDimension;
                anotherRow["Ширина"] = _facade.Records[i].HorizontalDimension;
                table.Rows.Add(anotherRow);
            }
            
            row["ПОСУДОСУШИЛКА"] = _dishDrayer;
            row["Навесы на стену"] = _canopies;

        }

        private int GetCountRows()
        {
            var count = 1;

            switch (Scheme)
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
            var table = GetEmptyTable();
            GetInfoRows(table);
            return table;
        }

        public override DataTable GetEmptyTable()
        {
            var table = new DataTable();
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
            table.Columns.Add("ПОСУДОСУШИЛКА");
            table.Columns.Add("Навесы на стену");
            return table;
        }

        public override object Clone()
        {
            using (var stream = new MemoryStream())
            {
                if (!GetType().IsSerializable) return new object();

                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }

        public override Result Calculate()
        {
            var calculator = new KitchenUpCalculator
            {
                Name = Name,
                Scheme = Scheme,
                IconPath = IconPath,
                BackPanelAssembly = BackPanelAssembly,
                Number = Number,
                SubScheme = SubScheme,
                Dimensions = _dimensions,
                Facade = _facade,
                ShelfAssembly = _shelfAssembly,
                ShelvesCount = _shelfsCount
            };

            var result = new Result
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