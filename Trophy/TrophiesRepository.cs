
namespace Trophy;

public class TrophiesRepository
{
    private List<Trophy> _trophies;
    private int _nextId;

    public TrophiesRepository()
    {
        _trophies = new List<Trophy>
        {
            new Trophy { Id = 1, Competition = "Champions League", Year = 2020 },
            new Trophy { Id = 2, Competition = "Europa League", Year = 2019 },
            new Trophy { Id = 3, Competition = "World Cup", Year = 2018 },
            new Trophy { Id = 4, Competition = "Copa America", Year = 2017 },
            new Trophy { Id = 5, Competition = "Premier League", Year = 2021 }
        };

        _nextId = _trophies.Max(t => t.Id) + 1;
    }

    public List<Trophy> Get(int? filterYear = null, string sortBy = null)
    {
        IEnumerable<Trophy> query = _trophies;

        if (filterYear.HasValue)
            query = query.Where(t => t.Year == filterYear.Value);

        if (!string.IsNullOrEmpty(sortBy))
        {
            if (sortBy.Equals("Competition", StringComparison.OrdinalIgnoreCase))
                query = query.OrderBy(t => t.Competition);
            else if (sortBy.Equals("Year", StringComparison.OrdinalIgnoreCase))
                query = query.OrderBy(t => t.Year);
        }

        return query.Select(t => new Trophy(t)).ToList();
    }

    public Trophy GetById(int id)
    {
        var trophy = _trophies.FirstOrDefault(t => t.Id == id);
        return trophy == null ? null : new Trophy(trophy);
    }

    public Trophy Add(Trophy trophy)
    {
        if (trophy == null)
            throw new ArgumentNullException(nameof(trophy));

        trophy.Id = _nextId++;
        _trophies.Add(new Trophy(trophy));
        return new Trophy(trophy);
    }

    public Trophy Remove(int id)
    {
        var trophy = _trophies.FirstOrDefault(t => t.Id == id);
        if (trophy == null)
            return null;
        _trophies.Remove(trophy);
        return new Trophy(trophy);
    }

    public Trophy Update(int id, Trophy values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        var trophy = _trophies.FirstOrDefault(t => t.Id == id);
        if (trophy == null)
            return null;

        trophy.Competition = values.Competition;
        trophy.Year = values.Year;
        return new Trophy(trophy);
    }
}
