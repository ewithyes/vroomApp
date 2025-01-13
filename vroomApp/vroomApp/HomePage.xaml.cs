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
    }
    private async void OnKategorijaTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new KategorijaPage());
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