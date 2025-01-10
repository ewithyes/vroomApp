using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace vroomApp.Podaci
{
    public class BazaService
    {
        private readonly SQLiteAsyncConnection _database;
        public BazaService() 
        {
            _database = new SQLiteAsyncConnection(BazaConstants.DatabasePath);
            _database.CreateTableAsync<User>().Wait();
        }
        public Task<int> RegisterUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }
        public Task<User> LoginAsync(string username, string password)
        {
            return _database.Table<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }
    }
}
