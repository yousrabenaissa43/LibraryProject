using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using BLsite;
using DALsite;

namespace LibraryProject.ViewModel
{
    public partial class ViewModelAuthors : ObservableObject
    {
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _biography;

        [ObservableProperty]
        private string? _messageError;

        // Collection observable des auteurs
        public ObservableCollection<Author> Authors { get; } = new ObservableCollection<Author>();

        public ViewModelAuthors()
        {
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            var authors = LibraryManager.GetAuthors(); // Récupère les auteurs depuis le gestionnaire
            Authors.Clear();
            foreach (var author in authors)
            {
                Authors.Add(author);
            }
        }

        [RelayCommand]
        private void AddAuthor()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Biography))
            {
                LibraryManager.AddAuthor(Name, Biography);
                MessageError = "Author Added Successfully.";
                LoadAuthors(); // Refresh the list after adding an author
            }
            else
            {
                MessageError = "Invalid input! Please check the fields.";
            }
        }

        [RelayCommand]
        private void DisplayAuthors()
        {
            LoadAuthors(); // Refreshes the author list
        }
    }
}
