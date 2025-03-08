using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    /// <summary>
    /// Логика взаимодействия для ConsultationResultsElement.xaml
    /// </summary>
    public partial class ConsultationResultsElement : UserControl
    {
        public ConsultationResultsModel Model { get; set; }
        public ConsultationResultsContext Context { get; set; }
        public ConsultationResultsElement(ConsultationResultsModel model, ConsultationResultsContext context)
        {
            InitializeComponent();
            Model = model;
            Context = context;
            DataContext = Model;
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new ConsultationResultsPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            Context.Remove(Model);
            GeneralPage.SwapPages(new ConsultationResultsList());
        }
    }
}
