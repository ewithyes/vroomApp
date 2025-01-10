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
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

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
            await Navigation.PopModalAsync(); // Dismiss the modal and return to MainPage
        }
        else
        {
            await DisplayAlert("Error", "Invalid username or password.", "OK");
        }
    }
}