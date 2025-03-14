using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class AbsencesElement : UserControl
    {
        public AbsencesModel Model { get; set; }
        public AbsencesContext Context { get; set; }

        public AbsencesElement(AbsencesModel model, AbsencesContext context)
        {
            InitializeComponent();
            Model = model;
            Context = context;
            DataContext = Model;
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new Pages.EntityPages.EditPages.AbsencesPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            Context.Remove(Model);
            GeneralPage.SwapPages(new AbsencesList());
        }
    }
}