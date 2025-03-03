using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using BLsite;
using DALsite;

namespace LibraryProject.ViewModel
{
    public partial class ViewModelLibraryMembers : ObservableObject
    {
        [ObservableProperty]
        private string _fullName = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string? _messageError;

        // Collection observable des membres
        public ObservableCollection<LibraryMember> Members { get; } = new ObservableCollection<LibraryMember>();

        public ViewModelLibraryMembers()
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            var members = LibraryManager.GetLibraryMembers();
            Members.Clear();
            foreach (var member in members)
            {
                Members.Add(member);
            }
        }

        [RelayCommand]
        private void AddMember()
        {
            if (!string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(Email))
            {
                LibraryManager.AddLibraryMember(FullName, Email);
                MessageError = "Member added successfully.";
                LoadMembers(); // Refresh the list
            }
            else
            {
                MessageError = "Invalid input! Please check the fields.";
            }
        }

        [RelayCommand]
        private void DisplayMembers()
        {
            LoadMembers(); // Rafraîchir la liste des membres
        }
    }
}
