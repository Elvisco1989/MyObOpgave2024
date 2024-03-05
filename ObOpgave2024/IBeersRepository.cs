namespace ObOpgave2024
{
    public interface IBeersRepository
    {
        Beer AddBeer(Beer beer);
        Beer? GetBeerById(int id);
        IEnumerable<Beer> GetBeers(double? Abv = null, string? SorteName = null);
        Beer RemoveBeer(int id);
        Beer? UpdateBeer(int id, Beer Data);
    }
}