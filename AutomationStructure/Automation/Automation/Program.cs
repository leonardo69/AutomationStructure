using System;
using System.Reflection;
using System.Windows.Forms;
using Automation.Model;
using Automation.View;

namespace Automation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // установка иконки по умолчанию
            typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, Properties.Resources.AppIcon);
            
            // Главная форма
            var view = new MainForm();
            view._presenter = new Presenter(new BlService(), view);
            Application.Run(view);
        }
    }
}
