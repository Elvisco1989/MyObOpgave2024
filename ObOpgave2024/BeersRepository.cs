using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObOpgave2024
{
    public class BeersRepository : IBeersRepository
    {
        private int _nextId = 1;
        private List<Beer> beers;

        public BeersRepository()
        {
            beers = new List<Beer>()
            {
                new Beer(){ID=1, Name="Turborg", Abv= 13.5},
                new Beer(){ID=2, Name="Calsberg", Abv= 9.4},
                new Beer(){ID=3, Name="Pinsen", Abv= 10.4},
                new Beer(){ID=4, Name="Stuttgartter", Abv= 13.4},

                new Beer(){ID=5, Name="Export", Abv= 16.4},

            };
        }
        public IEnumerable<Beer> GetBeers(double? Abv = null, string? SorteName = null)
        {
            IEnumerable<Beer> result = new List<Beer>(beers);
            //Filtering
            if (Abv != null)
            {
                result = result.Where(b => b.Abv > Abv);
            }

            if (SorteName != null)
            {
                result = result.Where(n => n.Name.StartsWith(SorteName));
            }

            return result;
        }

        public Beer? GetBeerById(int id)


        {
            return beers.Find(b => b.ID == id);

        }

        public Beer AddBeer(Beer beer)
        {
            beer.Validate();
            beer.ID = _nextId++;
            beers.Add(beer);
            return beer;

        }
        public Beer? UpdateBeer(int id, Beer Data)
        {
            Data.Validate();
            Beer? Exixtingbeer = GetBeerById(id);
            if (Exixtingbeer == null)
            {
                return null;
            }
            Exixtingbeer.Name = Data.Name;
            Exixtingbeer.Abv = Data.Abv;

            return Exixtingbeer;


        }
        public Beer RemoveBeer(int id)
        {
            Beer? beer = GetBeerById(id);
            if (beer == null)
            {
                return null;
            }
            beers.Remove(beer);
            return beer;


        }
    }
}
