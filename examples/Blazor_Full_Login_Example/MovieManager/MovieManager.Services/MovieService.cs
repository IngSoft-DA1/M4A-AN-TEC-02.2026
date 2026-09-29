using MovieManager.DataAccess;
using MovieManager.Domain;
using MovieManager.Services.Interfaces;
using MovieManager.Services.Models;

namespace MovieManager.Services;

public class MovieService : IMovieService
{
    private readonly InMemoryMovieRepository _movieRepository;

    public MovieService(InMemoryMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void AddMovie(MovieDTO movie)
    {
        ValidateUniqueTitle(movie.Title);
        _movieRepository.AddMovie(ToEntity(movie));
    }

    public void DeleteMovie(string title)
    {
        Movie? movieToDelete = _movieRepository.GetMovie(title);
        _movieRepository.DeleteMovie(movieToDelete);
    }

    public List<MovieDTO> GetMovies()
    {
        List<MovieDTO> moviesDTO = new List<MovieDTO>();
        foreach (Movie movie in _movieRepository.GetMovies())
        {
            moviesDTO.Add(FromEntity(movie));
        }

        return moviesDTO;
    }

    public void UpdateMovie(MovieDTO movieToUpdate)
    {
        Movie? movie = _movieRepository.GetMovie(movieToUpdate.Title);
        if (movie == null)
        {
            throw new ArgumentException("Cannot find the specified movie");
        }

        movie.Title = movieToUpdate.Title;
        movie.Director = movieToUpdate.Director;
        movie.ReleaseDate = movieToUpdate.ReleaseDate;

        movieToUpdate.Budget = movie.Budget;
        _movieRepository.UpdateMovie(movie);
    }

    public MovieDTO GetMovie(string title)
    {
        Movie? movie = _movieRepository.GetMovie(title);
        if (movie == null)
        {
            throw new ArgumentException("Cannot find movie with this title");
        }

        return FromEntity(movie);
    }

    private void ValidateUniqueTitle(string title)
    {
        string inputTitle = title.Trim().ToLowerInvariant();
        foreach (var movie in _movieRepository.GetMovies())
        {
            string retrievedTitle = movie.Title.Trim().ToLowerInvariant();
            if (retrievedTitle.Equals(inputTitle))
            {
                throw new ArgumentException("There`s a movie already defined with that title");
            }
        }
    }

    private static Movie ToEntity(MovieDTO movieDTO)
    {
        return new Movie(movieDTO.Title, movieDTO.Director, movieDTO.ReleaseDate, movieDTO.Budget);
    }

    private static MovieDTO FromEntity(Movie movie)
    {
        return new MovieDTO()
        {
            Title = movie.Title,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
        };
    }
}