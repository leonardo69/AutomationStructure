using System;
using System.Data;
using System.IO;
using System.Linq;
using Automation.Infrastructure;
using Xceed.Words.NET;

namespace Automation.Module.KitchenUp.Report
{
    public class Reports
    {
        public void CreateReport(Result source, string fileName)
        {
            var doc = DocX.Create(fileName);
            doc.PageLayout.Orientation = Orientation.Portrait;
            doc.InsertParagraph("Имя модуля: " + source.ModuleName);
            doc.InsertParagraph("");
            var par = InsertImage(source, doc);
            par.Alignment = Alignment.left;
            InsertTable(source.MainInfo, doc);
            InsertTable(source.DetailsInfo, doc);
            InsertTable(source.ShelfInfo, doc);
            InsertTable(source.FurnitureInfo, doc);
            InsertTable(source.LoopsInfo, doc);
            doc.Save();
        }

        public void AddReportContent(DocX doc, Result source)
        {
            doc.PageLayout.Orientation = Orientation.Portrait;
            doc.InsertParagraph("Имя модуля: " + source.ModuleName);
            doc.InsertParagraph("");
            var par = InsertImage(source, doc);
            par.Alignment = Alignment.left;
            InsertTable(source.MainInfo, doc);
            InsertTable(source.DetailsInfo, doc);
            InsertTable(source.ShelfInfo, doc);
            InsertTable(source.FurnitureInfo, doc);
            InsertTable(source.LoopsInfo, doc);
            doc.InsertParagraph();
            doc.InsertParagraph();
        }

        private static Paragraph InsertImage(Result source, DocX doc)
        {
            var imagePath = Path.Combine(Environment.CurrentDirectory, source.ImagePath);
            Image img = doc.AddImage(imagePath);
            Picture p = img.CreatePicture();
            p.Height = 250;
            p.Width = 250;
            Paragraph par = doc.InsertParagraph().AppendPicture(p);
            return par;
        }

        private void InsertTable(DataTable table, DocX doc)
        {
            var columnsCount = table.Columns.Count;
            var rowsCount = table.Rows.Count;
           
            var t = doc.AddTable(rowsCount+1, columnsCount);
            t.Alignment = Alignment.left;
            t.Design = TableDesign.LightGridAccent1;

            for (var i = 0; i<columnsCount; i++)
            {
                t.Rows[0].Cells[i].Paragraphs.First().Append(table.Columns[i].Caption);
            }

            for (var j = 0; j < columnsCount; j++)
            {
                for (var z = 0; z < rowsCount; z++)
                {
                    t.Rows[z + 1].Cells[j].Paragraphs.First().Append(table.Rows[z][j].ToString());
                }
            }

            doc.InsertTable(t);
            doc.InsertParagraph("");
        }
    }
}
