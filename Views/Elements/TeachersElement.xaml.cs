using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class TeachersElement : UserControl
    {
        public TeachersModel Model { get; set; }
        public TeachersContext Context { get; set; }

        public TeachersElement(TeachersModel model, TeachersContext context)
        {
            InitializeComponent();
            Model = model;
            Context = context;
            DataContext = Model;
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new TeachersPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Context.Remove(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new TeachersList());
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is MySqlException mysqlEx && mysqlEx.Number == 1451) // 1451 — код ошибки MySQL для нарушения внешнего ключа
                {
                    MessageBox.Show("Невозможно удалить преподавателя, так как он связан с дисциплинами. Сначала удалите или переназначьте связанные дисциплины.");
                }
                else
                {
                    MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}