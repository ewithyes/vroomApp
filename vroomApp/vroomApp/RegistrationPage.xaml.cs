using vroomApp.Podaci;

namespace vroomApp;

public partial class RegistrationPage : ContentPage
{
    private readonly BazaService _bazaService = new BazaService();

    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        var user = new User { Username = username, Password = password };

        try
        {
            await _bazaService.RegisterUserAsync(user);
            await DisplayAlert("Success", "Registration successful!", "OK");
            await Navigation.PopModalAsync(); // Return to LoginPage
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "User already exists.", "OK");
        }
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}
