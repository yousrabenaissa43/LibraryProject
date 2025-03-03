using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibraryProject.view;
using System.Windows;

namespace LibraryProject.ViewModel
{
    public partial class ViewModelHome : ObservableObject
    {
        [RelayCommand]
        private void OpenBooks()
        {
            var booksWindow = new ViewBooks();
            booksWindow.Show();

        }

        [RelayCommand]
        private void OpenAuthors()
        {
            var authorsWindow = new ViewAuthors();
            authorsWindow.DataContext = new ViewModelAuthors();
            authorsWindow.Show();
        }

        [RelayCommand]
        private void OpenLoans()
        {
            var loansWindow = new ViewLoans();
            loansWindow.DataContext = new ViewModelLoans();
            loansWindow.Show();
        }

        [RelayCommand]
        private void OpenMembers()
        {
            var membersWindow = new ViewLibraryMembers();
            membersWindow.DataContext = new ViewModelLibraryMembers();
            membersWindow.Show();
        }
    }
}
