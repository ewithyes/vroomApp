namespace vroomApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());
        }

    }

}
