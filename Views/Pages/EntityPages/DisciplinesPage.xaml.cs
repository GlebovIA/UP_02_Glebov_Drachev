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
        private DisciplinesContext DisciplinesContext { get; set; } = new DisciplinesContext();

        public DisciplinesPage(DisciplinesModel disciplinesModel = null)
        {
            InitializeComponent();
            AllDisciplines = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines.Include(d => d.Teacher).ToList());

            if (disciplinesModel != null)
            {
                Model = disciplinesModel;
                IsUpdate = true;
            }
            else
            {
                Model = new DisciplinesModel();
            }

            // Привязка преподавателей через контекст DisciplinesContext
            var teachers = DisciplinesContext.Disciplines.Select(d => d.Teacher).Distinct().ToList();
            Teachers.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = teachers });
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (IsUpdate)
                {
                    DisciplinesContext.SaveChanges();
                }
                else
                {
                    DisciplinesContext.Disciplines.Add(Model);
                    DisciplinesContext.SaveChanges();
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
