using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vroomApp.Podaci
{
    public class BazaService
    {
        private readonly SQLiteAsyncConnection _database;

        public BazaService()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath);
        }

        public async Task InitializeAsync()
        {
            await InitializeDatabaseAsync();
        }

        // Inicijalizacija baze
        private async Task InitializeDatabaseAsync()
        {
            await _database.CreateTableAsync<User>();
            await _database.CreateTableAsync<Question>();
            await _database.CreateTableAsync<Test>();

            var tests = await GetTestsAsync();
            if (!tests.Any())
            {
                // Dodavanje testova ako ih nema
                var testovi = new List<Test>
                {
                    new Test { Name = "Test Kategorija A" },
                    new Test { Name = "Test Kategorija B" }
                };

                foreach (var test in testovi)
                {
                    await _database.InsertAsync(test);
                }

                // Dodavanje pitanja za testove
                var questions = new List<Question>
                {
                    new Question { Text = "Sta je auto", OptionA = "Auto", OptionB = "Biciklo", OptionC = "Crna magija", OptionD = "IDK", CorrectAnswer = "Auto", TestId = 1 },
                    new Question { Text = "Koje je drugo slovo abecede", OptionA = "A", OptionB = "B", OptionC = "C", OptionD = "D", CorrectAnswer = "B", TestId = 1 },
                    new Question { Text = "Pitanje 1 za Kategoriju B", OptionA = "A", OptionB = "B", OptionC = "C", OptionD = "D", CorrectAnswer = "C", TestId = 2 },
                    new Question { Text = "Pitanje 2 za Kategoriju B", OptionA = "A", OptionB = "B", OptionC = "C", OptionD = "D", CorrectAnswer = "D", TestId = 2 }
                };

                foreach (var question in questions)
                {
                    await _database.InsertAsync(question);
                }
            }
        }

        // Dodavanje korisnika
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

        // Dohvaćanje testova
        public Task<List<Test>> GetTestsAsync()
        {
            return _database.Table<Test>().ToListAsync();
        }

        public Task InsertTestAsync(Test test)
        {
            return _database.InsertAsync(test);
        }

        // Dohvaćanje pitanja
        public Task<List<Question>> GetQuestionsAsync()
        {
            return _database.Table<Question>().ToListAsync();
        }

        public Task<List<Question>> GetQuestionsByTestIdAsync(int testId)
        {
            return _database.Table<Question>()
                            .Where(q => q.TestId == testId)
                            .ToListAsync();
        }
    }
}
