
namespace Trophy;

public class Trophy
{
    private int id;
    private string competition;
    private int year;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Competition
    {
        get { return competition; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Competition), "Competition må ikke være null");
            if (value.Length < 3)
                throw new ArgumentException("Competition skal være mindst 3 tegn", nameof(Competition));
            competition = value;
        }
    }

    public int Year
    {
        get { return year; }
        set
        {
            if (value < 1970 || value > 2025)
                throw new ArgumentOutOfRangeException(nameof(Year), "Year skal være mellem 1970 og 2025");
            year = value;
        }
    }
    
    public Trophy() { }

    // Copy constructor
    public Trophy(Trophy other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));
        Id = other.Id;
        Competition = other.Competition;
        Year = other.Year;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
    }
}
