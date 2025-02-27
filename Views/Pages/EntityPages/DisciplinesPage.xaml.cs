using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class DisciplinesPage : Page
    {
        public ObservableCollection<DisciplinesModel> AllDisciplines { get; set; }
        private DisciplinesModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public DisciplinesPage(DisciplinesModel disciplinesModel = null)
        {
            InitializeComponent();
            AllDisciplines = new ObservableCollection<DisciplinesModel>(new DisciplinesContext().Disciplines.Include(d => d.Teacher).ToList());

            if (disciplinesModel != null)
            {
                Model = disciplinesModel;
                IsUpdate = true;
            }
            else
            {
                Model = new DisciplinesModel();
            }

            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (IsUpdate)
                {
                    // Обновление существующей дисциплины
                    new DisciplinesContext().SaveChanges();
                }
                else
                {
                    // Добавление новой дисциплины
                    new DisciplinesContext().Disciplines.Add(Model);
                    new DisciplinesContext().SaveChanges();
                }
                GeneralPage.SwapPages(new DisciplinesList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new DisciplinesList());
        }
    }
}
