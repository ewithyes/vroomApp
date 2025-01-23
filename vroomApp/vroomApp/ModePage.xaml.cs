namespace vroomApp;
public class ModePageViewModel
{
    private Test OdabraniTest { get; }
    public Command RezultatiOdmahCommand { get; }
    public Command RezultatiNakonTestaCommand { get; }

    public ModePageViewModel(Test odabraniTest)
    {
        OdabraniTest = odabraniTest;
        RezultatiOdmahCommand = new Command(async () =>
        {
        await Application.Current.MainPage.Navigation.PushModalAsync(new PitanjaPage(OdabraniTest, true));
        });
        RezultatiNakonTestaCommand = new Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new PitanjaPage(OdabraniTest, false));
        });
    }
}
public partial class ModePage : ContentPage
{
	public ModePage(Test odabraniTest)
    {
        InitializeComponent();
        BindingContext = new ModePageViewModel(odabraniTest);
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