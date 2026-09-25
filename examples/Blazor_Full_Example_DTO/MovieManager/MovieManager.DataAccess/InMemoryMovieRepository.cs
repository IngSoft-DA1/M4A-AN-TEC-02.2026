using MovieManager.Domain;

namespace MovieManager.DataAccess;

public class InMemoryMovieRepository
{
    private List<Movie> Movies { get; }

    public InMemoryMovieRepository()
    {
        Movies = new List<Movie>();
        LoadDefaultMovies();
    }

    public List<Movie> GetMovies()
    {
        return Movies;
    }

    public Movie? GetMovie(string title)
    {
        Movie? movie = Movies.FirstOrDefault(movie => movie.Title == title);
        return movie;
    }

    public void AddMovie(Movie movie)
    {
        Movies.Add(movie);
    }

    public void DeleteMovie(Movie movie)
    {
        Movies.Remove(movie);
    }

    public void UpdateMovie(Movie movieToUpdate)
    {
        Movie? movie = Movies.Find(m => m.Title == movieToUpdate.Title);
        var movieToUpdateIndex = Movies.IndexOf(movie);
        Movies[movieToUpdateIndex] = movieToUpdate;
    }

    private void LoadDefaultMovies()
    {
        Movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22), 200000));
    }
}