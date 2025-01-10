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
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        try
        {
            var user = new User { Username = username, Password = password };
            await _bazaService.RegisterUserAsync(user);
            await DisplayAlert("Success", "Registration successful!", "OK");
            await Navigation.PopModalAsync(); // Dismiss the modal and return to MainPage
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "User already exists.", "OK");
        }
    }
}