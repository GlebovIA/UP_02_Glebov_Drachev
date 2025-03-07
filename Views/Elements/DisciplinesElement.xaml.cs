using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class DisciplinesElement : UserControl
    {
        public DisciplinesModel Model { get; set; }
        public DisciplinesContext Context { get; set; }

        // Открытый конструктор без параметров
        public DisciplinesElement()
        {
            InitializeComponent();
        }

        public DisciplinesElement(DisciplinesModel model, DisciplinesContext context)
        {
            InitializeComponent();
            Model = model;
            Context = context;
            DataContext = Model;
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            // Передаем контекст и модель дисциплины в конструктор страницы
            GeneralPage.SwapPages(new DisciplinesPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            Context.Remove(Model);
            GeneralPage.SwapPages(new DisciplinesList());
        }
    }
}
