using System.Windows;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class AbsencesPage : Page
    {
        public IEnumerable<AbsencesModel> AbsencesData { get; set; }
        public AbsencesContext AbsencesContext = new AbsencesContext();
        private AbsencesModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public AbsencesPage(AbsencesModel absencesModel = null)
        {
            InitializeComponent();
            if (absencesModel != null)
            {
                Model = AbsencesContext.Absences.FirstOrDefault(x => x.Id == absencesModel.Id);
                IsUpdate = true;
            }
            else Model = new AbsencesModel();
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (IsUpdate)
                {
                    AbsencesModel absence = AbsencesContext.Absences.FirstOrDefault(x => x.Id == Model.Id);
                    absence = Model;
                    AbsencesContext.SaveChanges();
                }
                else
                {
                    AbsencesContext.Absences.Add(Model);
                    AbsencesContext.SaveChanges();
                }
                GeneralPage.SwapPages(new AbsencesList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new AbsencesList());
        }
    }
}
