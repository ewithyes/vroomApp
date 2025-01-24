using System.Collections.ObjectModel;

namespace vroomApp;
using vroomApp.Podaci;
public class TeorijaPageViewModel
{
    public ObservableCollection<Test> Testovi { get; set; }
        public TeorijaPageViewModel(Kategorije odabranaKategorija)
        {
            Testovi = new ObservableCollection<Test>
            {
                new Test { Name = "TEST 1", TestId=1 },
                new Test { Name = "TEST 2", TestId=2 },
                new Test { Name = "TEST 3", TestId=3 },
                new Test { Name = "TEST 4", TestId=4 },
                new Test { Name = "TEST 5", TestId=5 }
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