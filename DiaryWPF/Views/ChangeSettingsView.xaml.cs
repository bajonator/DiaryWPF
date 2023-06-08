using DiaryWPF.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Security;
using System.Windows.Controls;

namespace DiaryWPF.Views
{
    /// <summary>
    /// Interaction logic for ChangeSettingsView.xaml
    /// </summary>
    public partial class ChangeSettingsView : MetroWindow
    {
        public ChangeSettingsView(bool closeWindow)
        {
            InitializeComponent();
            DataContext = new ChangeSettingsViewModel(closeWindow);
        }
    }
}
