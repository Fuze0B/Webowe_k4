using System.ComponentModel;

namespace arkusz.Models
{
    public class Miasto
    {
        public int Id { get; set; }

        [DisplayName("Miasto")]
        public string ?Nazwa { get; set; }

        public int Id_Wojewodztwa { get; set; }

        [DisplayName("Województwo")]
        public string ?Wojewodztwo { get; set; }
    }
}
