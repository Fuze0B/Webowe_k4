using MySql.Data.MySqlClient;

namespace arkusz.Models
{
    public class CityRepo
    {
        private readonly string _connectionString;

        public CityRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("mysql")
                ?? throw new InvalidOperationException("Brak connection stringa 'mysql' w appsettings.json");
        }

        public List<Miasto> GetCitiesByPrefix(string prefix)
        {
            var miasta = new List<Miasto>();

            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT miasta.nazwa AS miasto, wojewodztwa.nazwa AS wojewodztwo
                FROM miasta
                JOIN wojewodztwa ON wojewodztwa.id = miasta.id_wojewodztwa
                WHERE miasta.nazwa LIKE @p
                ORDER BY miasta.nazwa;
            ";
            cmd.Parameters.AddWithValue("@p", prefix + "%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                miasta.Add(new Miasto
                {
                    Nazwa = reader.GetString("miasto"),
                    Wojewodztwo = reader.GetString("wojewodztwo")
                });
            }

            return miasta;
        }
    }
}
