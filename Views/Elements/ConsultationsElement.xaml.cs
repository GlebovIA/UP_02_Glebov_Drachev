using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class ConsultationsElement : UserControl
    {
        public ConsultationsModel Model { get; set; }
        public ConsultationsContext Context { get; set; }

        public ConsultationsElement(ConsultationsModel model, ConsultationsContext context)
        {
            InitializeComponent();
            Model = model;
            Context = context;
            DataContext = Model;
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            // Передаем контекст и модель консультации в конструктор страницы
            GeneralPage.SwapPages(new ConsultationsPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            Context.Remove(Model);
            GeneralPage.SwapPages(new ConsultationsList());
        }
    }
}
