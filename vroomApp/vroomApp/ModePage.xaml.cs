namespace vroomApp;

using System.ComponentModel.DataAnnotations.Schema;
using vroomApp.Podaci;
public partial class ModePage : ContentPage
{
    private Test selectedTest;
    private BazaService database;

    private List<Question> questions;
    public ModePage(Test test)
    {
        InitializeComponent();
        selectedTest = test;
        database = new BazaService();
        InitializeDatabaseAsync();
    }

    private async void InitializeDatabaseAsync()
    {
        await database.InitializeAsync();
    }

    private async void OnVroomTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new HomePage());
    }
    private async void OnProfilTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
    private async void OnUcenjeClicked(object sender, EventArgs e)
    {
        var questions = await database.GetQuestionsByTestIdAsync(selectedTest.TestId);
        await Navigation.PushModalAsync(new PitanjaPageOdgovoriOdmah(questions));
    }
    private async void OnProvjeraClicked(object sender, EventArgs e)
    {
        var questions = await database.GetQuestionsByTestIdAsync(selectedTest.TestId);
        await Navigation.PushModalAsync(new PitanjaPageOdgovoriNaKraju(questions));
    }

}