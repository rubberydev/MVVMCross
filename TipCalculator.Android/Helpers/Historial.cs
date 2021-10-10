using SQLite;

namespace TipCalculator.Android.Helpers
{
    public class Historial
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Register { get; set; }
    }
}