namespace vroomApp;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using vroomApp.Podaci;

public partial class ProfilPage : ContentPage
{
	public ProfilPage()
	{
		InitializeComponent();
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