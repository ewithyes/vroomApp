namespace vroomApp;
using vroomApp.Podaci;
using SQLite;



public partial class Profil : ContentPage
{
    public Profil(string username)
    {
        InitializeComponent();

        // Fetch user details from SQLite
        using (var db = new SQLiteConnection(App.DatabasePath))
        {
            var user = db.Table<User>().FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                NameLabel.Text = user.Name;
                SurnameLabel.Text = user.Surname;
                EmailLabel.Text = user.Email;
                GenderLabel.Text = user.Gender;
                UsernameLabel.Text = user.Username;
            }
        }
    }
}
