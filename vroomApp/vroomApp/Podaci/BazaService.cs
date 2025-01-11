using SQLite;
using System.Threading.Tasks;

namespace vroomApp.Podaci;

public class BazaService
{
    private readonly SQLiteAsyncConnection _database;

    public BazaService()
    {
        _database = new SQLiteAsyncConnection(Constants.DatabasePath);
        _database.CreateTableAsync<User>().Wait();
    }

    public Task RegisterUserAsync(User user)
    {
        return _database.InsertAsync(user);
    }

    public Task<User> LoginAsync(string username, string password)
    {
        return _database.Table<User>()
                        .Where(u => u.Username == username && u.Password == password)
                        .FirstOrDefaultAsync();
    }
}

