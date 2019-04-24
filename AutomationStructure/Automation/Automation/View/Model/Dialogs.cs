using System.Windows.Forms;

namespace Automation.View.Model
{
    public static class Dialogs
    {
        public static string GetOpenProjectPath()
        {
            string pathToFile=string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "файл dat (*dat) | *.dat" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathToFile = openFileDialog.FileName;
                }
            }
          
            return pathToFile;
        }

        public static string GetSaveProjectPath()
        {
            string pathToFile = string.Empty;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "файл dat (*dat) | *.dat" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathToFile = saveFileDialog.FileName;
                }
            }
            return pathToFile;

        }
    }
}
