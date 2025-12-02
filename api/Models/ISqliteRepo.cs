using System;

namespace api.Models;

public interface ISqliteRepo
{
    void AddFilm(Film film);
    Film? GetFilm(int id);
    void UpdateFilm(Film film);
    void DeleteFilm(int id);
    List<Film> GetAllFilms();
}