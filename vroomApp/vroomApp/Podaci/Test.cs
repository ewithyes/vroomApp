using SQLite;

namespace vroomApp.Podaci;

public class Test
{
    [PrimaryKey, AutoIncrement]
    public int TestId { get; set; }
    public string Name { get; set; } // Naziv testa
}
