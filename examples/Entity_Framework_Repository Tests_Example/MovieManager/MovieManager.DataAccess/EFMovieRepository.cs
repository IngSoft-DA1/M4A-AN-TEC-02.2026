using Microsoft.EntityFrameworkCore;
using MovieManager.Domain;

namespace MovieManager.DataAccess;

public class EFMovieRepository
{
    private readonly AppDbContext _appDbContext;

    public EFMovieRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Movie> GetMovies()
    {
        return _appDbContext.Set<Movie>().AsQueryable<Movie>().ToList();
    }

    public Movie? GetMovie(Func<Movie, bool> filter)
    {
        return _appDbContext.Set<Movie>().FirstOrDefault(filter);
    }

    public void AddMovie(Movie movie)
    {
        try
        {
            _appDbContext.Set<Movie>().Add(movie);
            _appDbContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new Exception("Cannot add the movie to database", e);
        }
    }

    public void DeleteMovie(Movie movie)
    {
        try
        {
            _appDbContext.Set<Movie>().Remove(movie);
            _appDbContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new Exception("Cannot delete the movie", e);
        }
    }

    public void UpdateMovie(Movie movie)
    {
        try
        {
            _appDbContext.Update(movie);
            _appDbContext.Entry<Movie>(movie).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new Exception("Cannot update the movie", e);
        }
    }
}