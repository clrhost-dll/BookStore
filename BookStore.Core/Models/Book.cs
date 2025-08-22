using System.Security.Cryptography.X509Certificates;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;
        public const decimal MAX_PRICE_VALUE = 1000000;
        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title can not be empty or longer 250 symbols";
            }

            if (string.IsNullOrEmpty(description) || description.Length > MAX_TITLE_LENGTH)
            {
                error = "Description can not be empty or longer 250 symbols";
            }

            if (price <= 0 || price >= MAX_PRICE_VALUE)
            {
                error = "Price must be greater than 0 and less than 1,000,000.";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
