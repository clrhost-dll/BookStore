namespace BookStore.APl.Contracts
{
    public record BooksRequest(
      string Title,
      string Description,
      decimal Price);
}
