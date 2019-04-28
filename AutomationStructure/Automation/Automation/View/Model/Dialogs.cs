using System.Windows.Forms;

namespace Automation.View.Model
{
    public static class Dialogs
    {
        public static string GetOpenProjectPath()
        {
            var pathToFile=string.Empty;
            using (var openFileDialog = new OpenFileDialog { Filter = @"файл dat (*dat) | *.dat" })
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
            var pathToFile = string.Empty;
            using (var saveFileDialog = new SaveFileDialog { Filter = @"файл dat (*dat) | *.dat" })
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
