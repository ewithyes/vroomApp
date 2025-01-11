using vroomApp.Podaci;

namespace vroomApp;

public partial class LoginPage : ContentPage
{
    private readonly BazaService _bazaService = new BazaService();

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        var user = await _bazaService.LoginAsync(username, password);

        if (user != null)
        {
            await DisplayAlert("Success", "Login successful!", "OK");
            await Navigation.PushModalAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Error", "Invalid username or password.", "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegistrationPage());
    }
}
