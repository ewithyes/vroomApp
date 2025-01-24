namespace vroomApp;

public partial class PrvaPomocPage : ContentPage
{
	public PrvaPomocPage()
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