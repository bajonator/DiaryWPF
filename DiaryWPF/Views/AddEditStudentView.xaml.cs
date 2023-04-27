using DiaryWPF.Models.Wrappers;
using DiaryWPF.ViewModels;
using MahApps.Metro.Controls;

namespace DiaryWPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditStudentView.xaml
    /// </summary>
    public partial class AddEditStudentView : MetroWindow
    {
        public AddEditStudentView(StudentWrapper student = null)
        {
            InitializeComponent();
            DataContext = new AddEditStudentViewModel(student);
        }
    }
}
