using System;
using Microsoft.Data.Sqlite;

namespace api.Models;

public class SqliteRepo : ISqliteRepo
{
    private readonly string? _connectionString;
    public SqliteRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    public void AddFilm(Film film)
    {
         using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO movies (title, director, year) "
        + "VALUES (@title, @director, @year);";
        cmd.Parameters.AddWithValue("@title", film.Title);
        cmd.Parameters.AddWithValue("@director", film.Director);
        cmd.Parameters.AddWithValue("@year", film.Year);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void DeleteFilm(int id)
    {
         using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM movies WHERE id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public List<Film> GetAllFilms()
    {
        using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT id, title, director, year FROM movies";
        conn.Open();
        using SqliteDataReader reader = cmd.ExecuteReader();
        List<Film> films = new List<Film>();
        while (reader.Read()){
            Film film = new Film();
            film.Id = reader.GetInt32(0);
            film.Title = reader.GetString(1);
            film.Director = reader.GetString(2);
            film.Year = reader.GetInt32(3);
            films.Add(film);
        }
        return films;
    }

    public Film? GetFilm(int id)
    {
         using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT id, title, director, year FROM movies WHERE id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        conn.Open();
        using SqliteDataReader reader = cmd.ExecuteReader();
        if (!reader.HasRows)
        {
            return null;
        }
        reader.Read();
        Film film = new Film();
        film.Id = reader.GetInt32(0);
        film.Title = reader.GetString(1);
        film.Director = reader.GetString(2);
        film.Year = reader.GetInt32(3);
        return film;
    }

    public void UpdateFilm(Film film)
    {
        using SqliteConnection conn = new SqliteConnection(_connectionString);
        using SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE movies SET title = @title, director = @director, "
                        + "year = @year WHERE id = @id;";
        cmd.Parameters.AddWithValue("@title", film.Title);
        cmd.Parameters.AddWithValue("@director", film.Director);
        cmd.Parameters.AddWithValue("@year", film.Year);
        cmd.Parameters.AddWithValue("@id", film.Id);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}