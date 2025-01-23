using System.Collections.ObjectModel;

namespace vroomApp;
public class Test {
    public string Naziv { get; set; }
}
public class TeorijaPageViewModel
{
    public ObservableCollection<Test> Testovi { get; set; }
        public TeorijaPageViewModel(Kategorije odabranaKategorija)
        {
            Testovi = new ObservableCollection<Test>
            {
                new Test { Naziv = "TEST 1" },
                new Test { Naziv = "TEST 2" },
                new Test { Naziv = "TEST 3" },
                new Test { Naziv = "TEST 4" },
                new Test { Naziv = "TEST 5" }
            };
        }
}
   
    public partial class TeorijaPage : ContentPage
{
    public TeorijaPage(Kategorije odabranaKategorija)
    {
        InitializeComponent();
        BindingContext = new TeorijaPageViewModel(odabranaKategorija);
    }
    private async void OnTestTapped(object sender, EventArgs e)
    {
        var tappedElement = (Microsoft.Maui.Controls.VisualElement)sender;
        var odabraniTest = tappedElement.BindingContext as Test;
        if (odabraniTest != null)
        {
            await Navigation.PushModalAsync(new ModePage(odabraniTest));
        }
    }
	private async void OnVroomTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new HomePage());
    }
	private async void OnProfilTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
}