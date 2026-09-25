namespace MovieManager.Domain;

public class Movie
{
    private string _title;
    private string _director;
    private DateTime _releaseDate;
    private int _budget;

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public string Director
    {
        get => _director;
        set => _director = value;
    }

    public DateTime ReleaseDate
    {
        get => _releaseDate;
        set => _releaseDate = value;
    }

    public int Budget
    {
        get => _budget;
        set => _budget = value;
    }

    public Movie(string title, string director, DateTime releaseYear, int budget)
    {
        Title = title;
        Director = director;
        ReleaseDate = releaseYear;
        Budget = budget;
    }
}