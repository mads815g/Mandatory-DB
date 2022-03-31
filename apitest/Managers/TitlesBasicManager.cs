using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using apitest.Models;
using Microsoft.Data.SqlClient;

namespace apitest.Managers
{
    public class TitlesBasicManager
    {
        private readonly IMDBContext _context = new IMDBContext();

        public List<MovieView> GetAllMovieData()
        {
            _context.connection = "server = localhost; database = IMDB; user id = reader123; password = 123";
            return _context.MovieView.Take(2).OrderBy(a => a.PrimaryTitle).ToList();
        }
        public List<ActorView> GetAllActorData()
        {
            _context.connection = "server = localhost; database = IMDB; user id = reader123; password = 123";
            return _context.ActorView.Take(10).OrderBy(a => a.PrimaryName).ToList();
        }

        public ActorView GetActorData(string name)
        {
            _context.connection = "server = localhost; database = IMDB; user id = reader123; password = 123";
            return _context.ActorView.FirstOrDefault(a => a.PrimaryName.Contains(name));
        }

        public MovieView GetMovieData(string name)
        {
            _context.connection = "server = localhost; database = IMDB; user id = reader123; password = 123";
            return _context.MovieView.FirstOrDefault(a => a.PrimaryTitle.Contains(name));
        }

        public NameBasics AddActor(NameBasics newActor)
        {
            _context.connection = "server = localhost; database = IMDB; user id = writer123; password = 123";
            _context.NameBasics.Add(newActor);
            _context.SaveChanges();
            return newActor;
        }

        public TitlesBasic AddMovie(TitlesBasic newMovie)
        {
            _context.connection = "server = localhost; database = IMDB; user id = writer123; password = 123";
            _context.TitlesBasic.Add(newMovie);
            _context.SaveChanges();
            return newMovie;
        }

        public NameBasics UpdateActor(string name, NameBasics value)
        {
            _context.connection = "server = localhost; database = IMDB; user id = writer123; password = 123";
            NameBasics actor = _context.NameBasics.FirstOrDefault(a => a.PrimaryName == name);
            if (actor == null) return null;
            actor.BirthYear = value.BirthYear;
            actor.DeathYear = value.DeathYear;
            _context.SaveChanges();
            return actor;
        }

        public TitlesBasic UpdateMovie(string name, TitlesBasic value)
        {
            _context.connection = "server = localhost; database = IMDB; user id = writer123; password = 123";
            TitlesBasic movie = _context.TitlesBasic.FirstOrDefault(a => a.PrimaryTitle == name);
            if (movie == null) return null;
            movie.OriginalTitle = value.OriginalTitle;
            movie.EndYear = value.EndYear;
            movie.StartYear = value.StartYear;
            movie.IsAdult = value.IsAdult;
            movie.RunTimeMinutes = value.RunTimeMinutes;
            movie.TitleType = value.TitleType;
            _context.SaveChanges();
            return movie;
        }

        public void DeleteActor(string name)
        {
            _context.connection = "server = localhost; database = IMDB; user id = writer123; password = 123";
            NameBasics ActorToDelete = _context.NameBasics.FirstOrDefault(a => a.PrimaryName == name);
            _context.NameBasics.Remove(ActorToDelete);
            _context.SaveChanges();
        }

        public void DeleteMovie(string name)
        {
            _context.connection = "server = localhost; database = IMDB; user id = writer123; password = 123";
            TitlesBasic MovieToDelete = _context.TitlesBasic.FirstOrDefault(a => a.PrimaryTitle == name);
            _context.TitlesBasic.Remove(MovieToDelete);
            _context.SaveChanges();
        }
    }
}
