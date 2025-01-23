using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace vroomApp;

public class KategorijaPageViewModel
{
    public Kategorije odabranaKategorija { get; set; }

    public KategorijaPageViewModel(Kategorije odabranaKategorija)
    {
        odabranaKategorija = odabranaKategorija;
    }
}
public partial class KategorijaPage : ContentPage
{
    public KategorijaPage(Kategorije odabranaKategorija)
    {
        InitializeComponent();
        BindingContext = odabranaKategorija;
    }
    private async void OnVroomTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new HomePage());
    }
    private async void OnProfilTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
    private async void OnTeorijaTapped(object sender, EventArgs e)
    {
        var tappedElement = (Microsoft.Maui.Controls.VisualElement)sender;
        var odabranaKategorija = tappedElement.BindingContext as Kategorije;
        if (odabranaKategorija != null)
        {
            await Navigation.PushModalAsync(new TeorijaPage(odabranaKategorija));
        }
    }
    private async void OnIspitTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
    private async void OnZnakoviTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
    private async void OnRaskrsniceTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
}