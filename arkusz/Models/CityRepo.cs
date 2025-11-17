using MySql.Data.MySqlClient;

namespace arkusz.Models
{
    public class CityRepo
    {
        private readonly string? _connectionString;

        public CityRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("mysql");
        }

        public List<Miasto> GetCitiesByPrefix(string prefix)
        {
            List<Miasto> miasta = new();

            using var conn = new MySqlConnection(_connectionString);
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT miasta.id,
                       miasta.nazwa AS miasto,
                       miasta.id_wojewodztwa,
                       wojewodztwa.nazwa AS wojewodztwo
                FROM miasta
                JOIN wojewodztwa ON miasta.id_wojewodztwa = wojewodztwa.id
                WHERE miasta.nazwa LIKE @p
                ORDER BY miasta.nazwa;
            ";

            cmd.Parameters.AddWithValue("@p", prefix + "%");

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                miasta.Add(new Miasto
                {
                    Id = reader.GetInt32("id"),
                    Nazwa = reader.GetString("miasto"),
                    Id_Wojewodztwa = reader.GetInt32("id_wojewodztwa"),
                    Wojewodztwo = reader.GetString("wojewodztwo")
                });
            }

            return miasta;
        }
    }
}
