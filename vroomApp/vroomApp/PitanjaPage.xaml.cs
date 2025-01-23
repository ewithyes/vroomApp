using System.Collections.ObjectModel;
using System.ComponentModel;

namespace vroomApp;

public class PitanjaPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private readonly List<Pitanja> _pitanja;
    private int _trenutnoPitanjeIndex;
    private int _brojTacnihOdgovora;

    public ObservableCollection<string> OdabraniOdgovori { get; } = new ObservableCollection<string>();
    public Pitanja trenuntnoPitanje => _pitanja[_trenutnoPitanjeIndex];
    public string FeedbackText { get; private set; }
    public bool PrikaziFeedback { get; private set; }
    public Command SljedecePitanjeCommand { get; }
    private bool feedback { get; }

    public PitanjaPageViewModel(Test odabraniTest, bool feedback)
    {
        feedback = feedback;
        _pitanja = LoadPitanja(odabraniTest);
        _trenutnoPitanjeIndex = 0;
        _brojTacnihOdgovora = 0;

        SljedecePitanjeCommand = new Command(SljedecePitanje);
    }

    private List<Pitanja> LoadPitanja(Test test)
    {
           return new List<Pitanja>
        {
            new Pitanja
            {
                Pitanje = "Koje je glavno pravilo za vožnju u naselju?",
                Odgovori = new List<string> { "Vozi brzo", "Vozi polako", "Vozi pažljivo" },
                TacanOdgovor = "Vozi pažljivo"
            },
            new Pitanja
            {
                Pitanje = "Koje je glavno pravilo za vožnju u naselju?",
                Odgovori = new List<string> { "Vozi brzo", "Vozi polako", "Vozi pažljivo" },
                TacanOdgovor = "Vozi pažljivo"
            },
            new Pitanja
            {
                Pitanje = "Koje je glavno pravilo za vožnju u naselju?",
                Odgovori = new List<string> { "Vozi brzo", "Vozi polako", "Vozi pažljivo" },
                TacanOdgovor = "Vozi pažljivo"
            },
            new Pitanja
            {
                Pitanje = "Koje je glavno pravilo za vožnju u naselju?",
                Odgovori = new List<string> { "Vozi brzo", "Vozi polako", "Vozi pažljivo" },
                TacanOdgovor = "Vozi pažljivo"
            },
            new Pitanja
            {
                Pitanje = "Koje je glavno pravilo za vožnju u naselju?",
                Odgovori = new List<string> { "Vozi brzo", "Vozi polako", "Vozi pažljivo" },
                TacanOdgovor = "Vozi pažljivo"
            }
        };

}

private void SljedecePitanje()
    {
        if (feedback)
        {
            ProvjeriOdgovor();
        }
        OdabraniOdgovori.Clear();
        _trenutnoPitanjeIndex++;
        if (_trenutnoPitanjeIndex >= _pitanja.Count)
        {
            ZavrsiTest();
        } else
        {
            OnPropertyChanged(nameof(trenuntnoPitanje));
            PrikaziFeedback = false;
            OnPropertyChanged(nameof(PrikaziFeedback));
        }
    }

    private void ProvjeriOdgovor()
    {
        var tacanOdgovor = _pitanja[_trenutnoPitanjeIndex].TacanOdgovor;
        var odabraniOdgovori = OdabraniOdgovori.ToList();
        if (odabraniOdgovori.Count == 1 && odabraniOdgovori[0] == tacanOdgovor)
        {
            _brojTacnihOdgovora++;
            FeedbackText = "Tačno!";
        } else
        {
            FeedbackText = "Netačno!";
        }
        PrikaziFeedback = true;
        OnPropertyChanged(nameof(FeedbackText));
        OnPropertyChanged(nameof(PrikaziFeedback));
    }

    private void ZavrsiTest()
    {
        string rezultatPoruka = $"Imate {_brojTacnihOdgovora} tačnih odgovora.";
        Application.Current.MainPage.DisplayAlert("Rezultat", rezultatPoruka, "OK");
        Application.Current.MainPage.Navigation.PopToRootAsync();
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class Pitanja
    {
        public string Pitanje{ get; set; }
        public List<string> Odgovori { get; set; }
        public string TacanOdgovor { get; set; }
    }
        
 }
public partial class PitanjaPage : ContentPage
{
	public PitanjaPage(Test odabraniTest, bool feedback)
	{
		InitializeComponent();
        BindingContext = new PitanjaPageViewModel(odabraniTest, feedback);
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