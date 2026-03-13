using System;
using System.Windows.Forms;
using LibrarySystem.Core.Facade;
using LibrarySystem.Data;
using LibrarySystem.UI.Presenters;
using LibrarySystem.UI.Views;

namespace LibrarySystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var repository = new SQLiteRepository("library.db");

            var libraryManager = new LibraryManager(repository);

            var mainForm = new MainForm();

            var presenter = new MainPresenter(mainForm, libraryManager);

            Application.Run(mainForm);
        }
    }
}