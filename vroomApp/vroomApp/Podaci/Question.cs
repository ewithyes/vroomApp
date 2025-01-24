using SQLite;

namespace vroomApp.Podaci;

using SQLite;

public class Question
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Text { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string CorrectAnswer { get; set; }
    public int TestId { get; set; } // Veza s testom
}
