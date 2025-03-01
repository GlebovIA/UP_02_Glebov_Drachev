using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;

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
            GeneralPage.SwapPages(new ConsultationsPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
