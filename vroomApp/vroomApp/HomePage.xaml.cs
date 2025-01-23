using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Controls;
using vroomApp.Podaci;
using System.Formats.Asn1;

namespace vroomApp;

public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();
        KategorijeViewModel kategorijeViewModel = new KategorijeViewModel();
        BindingContext = kategorijeViewModel;
    }
    private async void OnKategorijaTapped(object sender, EventArgs e)
    {
        var tappedElement = (Microsoft.Maui.Controls.VisualElement)sender;
        var odabranaKategorija = tappedElement.BindingContext as Kategorije;
        if (odabranaKategorija != null)
        {
            await Navigation.PushModalAsync(new KategorijaPage(odabranaKategorija));
        }
    }
    private async void OnProfilTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
    private async void OnVroomTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new HomePage());
    }
}