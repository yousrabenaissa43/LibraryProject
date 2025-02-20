using BLsite;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DALsite;
using System.Collections.ObjectModel;

namespace LibraryProject.ViewModel
{
    public partial class ViewModelBooks : ObservableObject
    {
        // Propriété observée pour le texte saisi
        [ObservableProperty]
        private string? _bookType;
        [ObservableProperty]
        private string? _title;
        [ObservableProperty]
        private string? _serial;
        [ObservableProperty]
        private int _authorId;
        [ObservableProperty]
        private string? _recipeNumber;
        [ObservableProperty]
        private string? _typeOfMagic;
        [ObservableProperty]
        private string? _messageError;

        // Collection observable des noms
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();

        public ObservableCollection<string> BookTypes { get; } = new ObservableCollection<string> { "RecipeBook", "SpellBook" };

        public ObservableCollection<Author> Authors { get; } = new ObservableCollection<Author>(); 
        public ObservableCollection<string> MagicTypes { get; } = new ObservableCollection<string>() {"Enchantment" ,"Transmutation" ,"Cruse"  };
        // Commande pour ajouter un nom à la liste
        [RelayCommand]
        private void AddBook()
        {
            if (
                int.TryParse(Serial, out int serialNumber)/* &&
                int.TryParse(AuthorId, out int authorId)*/ )
            {
                if(BookType == "RecipeBook" && int.TryParse(RecipeNumber, out int recipeNumber)) 
                { 
                  LibraryManager.AddRecipeBook(serialNumber, Title, AuthorId, recipeNumber);
                    MessageError = "Book Added Successfully.";
                }
                else
                {
                    if(TypeOfMagic == "Enchantment") 
                     { LibraryManager.AddSpellBook(serialNumber, Title, MagicType.Enchantment, AuthorId); }
                    if (TypeOfMagic == "Transmutation")
                    { LibraryManager.AddSpellBook(serialNumber, Title, MagicType.Transmutation, AuthorId); }
                    if (TypeOfMagic == "Cruse")
                    { LibraryManager.AddSpellBook(serialNumber, Title, MagicType.Cruse, AuthorId); }
                }
                MessageError = "Book Added Successfully.";
            }
            else
            {
                MessageError = "Invalid input! Please check the fields.";
            }
        }

        [RelayCommand]
        private void DisplayBooks()
        {
            Books.Clear();

            // Get the books from the LibraryManager (assuming it returns a list of Book objects)
            var books = LibraryManager.GetAllBooks();

            // Add books to the ObservableCollection (this will update the UI automatically)
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }



        // Constructor to load authors
        public ViewModelBooks()
        {
            LoadAuthors();
        }

        
        private void LoadAuthors()
        {
            var authors = LibraryManager.GetAuthors(); // Fetch authors
            Authors.Clear(); // Clear existing data
            foreach (var author in authors)
            {
                Authors.Add(author); // Add authors to collection
            }
        }
    }
}
