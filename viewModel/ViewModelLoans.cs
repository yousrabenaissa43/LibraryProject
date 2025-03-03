using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using BLsite;
using DALsite;
using Microsoft.VisualBasic;
using System.Net;

namespace LibraryProject.ViewModel
{
    public partial class ViewModelLoans : ObservableObject
    {
        [ObservableProperty]
        private int _bookId;

        [ObservableProperty]
        private int _memberId;

        [ObservableProperty]
        private DateTime _loanDate = DateTime.Now;

        [ObservableProperty]
        private DateTime _dueDate = DateTime.Now.AddDays(14); // Par défaut, 2 semaines après l'emprunt

        [ObservableProperty]
        private string? _messageError;

        // Collection observable des prêts
        public ObservableCollection<Loan> Loans { get; } = new ObservableCollection<Loan>();

        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();
        public ObservableCollection<LibraryMember> Members { get; } = new ObservableCollection<LibraryMember>();

        public ViewModelLoans()
        {
            LoadBooks();
            LoadMembers();
            LoadLoans();
        }

        private void LoadBooks()
        {
            var books = LibraryManager.GetAllBooks();
            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
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

        private void LoadLoans()
        {
            var loans = LibraryManager.GetLoans();
            Loans.Clear();
            foreach (var loan in loans)
            {
                Loans.Add(loan);
            }
        }

        [RelayCommand]
        private void AddLoan()
        {
            if (BookId > 0 && MemberId > 0)
            {
                LibraryManager.AddLoan(BookId, MemberId, LoanDate, DueDate);
                MessageError = "Loan added successfully.";
                LoadLoans(); // Refresh the list
            }
            else
            {
                MessageError = "Invalid input! Please check the fields.";
            }
        }

        [RelayCommand]
        private void DisplayLoans()
        {
            LoadLoans(); // Rafraîchir la liste des prêts
        }
    }
}
