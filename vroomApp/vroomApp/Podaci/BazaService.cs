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
                    new Question { Text = "Vozač je:", OptionA = "svako lice koje se u saobraćaju na putu nalazi u vozilu", OptionB = "lice koje na putu upravlja vozilom", OptionC = "sve navedeno", OptionD="ništa od navedenog", CorrectAnswer = "lice koje na putu upravlja vozilom", TestId = 1 },
                    new Question { Text = "Šta je zaustavljanje vozila?", OptionA = "Svaki prekid kretanja vozila na putu u trajanju do 15 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", OptionB = "Svaki prekid kretanja vozila na putu u trajanju do 5 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", OptionC = "Svaki prekid kretanja vozila na putu u trajanju do 10 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", OptionD = "Svaki prekid kretanja vozila na putu bez obzira na trajanje", CorrectAnswer = "Svaki prekid kretanja vozila na putu u trajanju do 15 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", TestId = 1 },
                    new Question { Text = "Koje vozilo se ne smije vući pomoću užeta?", OptionA = "Motorno vozilo na kojem su neispravni uređaji za osvjetljenje", OptionB = "Motorno vozilo na kojem su neispravni uređaji za davanje znakova", OptionC = "Motorno vozilo na kojem su neispravni uređaji za zaustavljanje", OptionD = "Motorno vozilo na kojem su neispravni uređaji za upravljanje", CorrectAnswer = "Motorno vozilo na kojem su neispravni uređaji za upravljanje", TestId = 1 },
                    new Question { Text = "Koliko važi ljekarsko uvjerenje o zdravstvenoj sposobnosti za upravljanje motornim vozilom?", OptionA = "12 mjeseci od dana izdavanja", OptionB = "6 mjeseci od dana izdavanja", OptionC = "24 mjeseca od dana izdavanja", OptionD = "36 mjeseci od dana izdavanja", CorrectAnswer = "12 mjeseci od dana izdavanja", TestId = 1 },
                    new Question { Text = "Šta podrazumijeva pojam 'pješak'?", OptionA = "Lice koje učestvuje u saobraćaju, a ne upravlja vozilom, niti se prevozi u vozilu ili na vozilu", OptionB = "Lice koje upravlja vozilom, ili se prevozi u vozilu ili na vozilu", OptionC = "Lice koje se prevozi u vozilu ili na vozilu", OptionD = "Lice koje upravlja vozilom", CorrectAnswer = "Lice koje učestvuje u saobraćaju, a ne upravlja vozilom, niti se prevozi u vozilu ili na vozilu", TestId = 1 },
                    new Question { Text = "Šta je stiker-naljepnica?", OptionA = "Dokaz o izvršenom tehničkom pregledu", OptionB = "Dokaz o plaćenoj putarini", OptionC = "Dokaz o registrovanju vozila", OptionD = "Dokaz o osiguranju vozila", CorrectAnswer = "Dokaz o registrovanju vozila", TestId = 1 },
                    new Question { Text = "Koliko važi registracija mopeda?", OptionA = "Nije vremenski ograničena", OptionB = "Jednu godinu", OptionC = "Dvije godine", OptionD = "Tri godine", CorrectAnswer = "Nije vremenski ograničena", TestId = 1 },
                    new Question { Text = "Koje je osnovno pravilo imobilizacije?", OptionA = "Da se imobiliziraju dva susjedna zgloba", OptionB = "Da se imobilizira jedan povrijeđen zglob", OptionC = "Da se imobiliziraju svi zglobovi", OptionD = "Da se imobilizira samo povrijeđeni dio", CorrectAnswer = "Da se imobiliziraju dva susjedna zgloba", TestId = 1 },
                    new Question { Text = "Koliko dugo se vrši oživljavanje (kardiopulmonalna reanimacija - KPR)?", OptionA = "20 minuta", OptionB = "40 minuta", OptionC = "Do dolaska stručne pomoći", OptionD = "Dok se povrijeđeni ne oporavi", CorrectAnswer = "Do dolaska stručne pomoći", TestId = 1 },
                    new Question { Text = "Kada ne treba započeti oživljavanje (KPR)?", OptionA = "Ako je sigurno prošlo više od 10 minuta od zastoja srca", OptionB = "Ako postoji otvorena rana na grudnom košu", OptionC = "Ako je opečena površina tijela veća od 60%", OptionD = "Ako je povrijeđeni bez svijesti", CorrectAnswer = "Ako je sigurno prošlo više od 10 minuta od zastoja srca", TestId =1 },
                    new Question { Text = "Koji je odnos disanja i vanjske masaže srca kod oživljavanja (KPR)?", OptionA = "5 upuhivanja i 5 masaža srca, tj. odnos 1:1", OptionB = "2 upuhivanja i 15 masaža srca, tj. odnos 2:15", OptionC = "30 masaža srca i 2 upuhivanja, tj. odnos 30:2", OptionD = "15 masaža srca i 2 upuhivanja, tj. odnos 15:2", CorrectAnswer = "30 masaža srca i 2 upuhivanja, tj. odnos 30:2", TestId = 2 },
                    new Question { Text = "Šta označava plava boja svjetlosnog signala na vozilu?", OptionA = "Prevoz materijala opasnih po okolinu", OptionB = "Posebne namjene u hitnim slučajevima", OptionC = "Obilježavanje vozila koje prati teret", OptionD = "Obilježavanje sporih vozila", CorrectAnswer = "Posebne namjene u hitnim slučajevima", TestId =2 },
                    new Question { Text = "Šta je cilj vožnje u skladu sa saobraćajnim pravilima?", OptionA = "Brže stići do odredišta", OptionB = "Izbjegavanje kazni", OptionC = "Povećanje sigurnosti svih učesnika u saobraćaju", OptionD = "Štednja goriva", CorrectAnswer = "Povećanje sigurnosti svih učesnika u saobraćaju", TestId = 2 },
                    new Question { Text = "Kada je dozvoljeno koristiti sirenu?", OptionA = "U svakoj situaciji", OptionB = "Samo kada je potrebno izbjeći saobraćajnu nezgodu", OptionC = "Tokom preticanja vozila", OptionD = "Prilikom parkiranja vozila", CorrectAnswer = "Samo kada je potrebno izbjeći saobraćajnu nezgodu", TestId = 2 },
                    new Question { Text = "Koliko je minimalna dubina šare na pneumaticima za ljetni period?", OptionA = "1,6 mm", OptionB = "3 mm", OptionC = "4 mm", OptionD = "2 mm", CorrectAnswer = "1,6 mm", TestId = 2 },
                    new Question { Text = "Koji je maksimalni dozvoljeni nivo alkohola u krvi za profesionalne vozače?", OptionA = "0,5 g/kg", OptionB = "0,2 g/kg", OptionC = "0,0 g/kg", OptionD = "0,3 g/kg", CorrectAnswer = "0,0 g/kg", TestId = 2 },
                    new Question { Text = "Koji uređaj je obavezan u vozilu u zimskom periodu?", OptionA = "Lanac za snijeg", OptionB = "Komplet za prvu pomoć", OptionC = "Reflektujući prsluk", OptionD = "Rezervni točak", CorrectAnswer = "Lanac za snijeg", TestId = 2 },
                    new Question { Text = "Koji je cilj obavezne vozačke obuke?", OptionA = "Dobijanje vozačke dozvole", OptionB = "Savladavanje saobraćajnih pravila i sigurnog upravljanja vozilom", OptionC = "Poznavanje tehničkih karakteristika vozila", OptionD = "Smanjenje saobraćajnih kazni", CorrectAnswer = "Savladavanje saobraćajnih pravila i sigurnog upravljanja vozilom", TestId = 2 },
                    new Question { Text = "Koliko iznosi dozvoljena brzina u naseljenim mjestima, osim ako nije drugačije označeno?", OptionA = "40 km/h", OptionB = "50 km/h", OptionC = "60 km/h", OptionD = "70 km/h", CorrectAnswer = "50 km/h", TestId = 2 },
                    new Question { Text = "Kada vozač mora koristiti sigurnosni pojas?", OptionA = "Samo na autoputu", OptionB = "Samo u urbanim područjima", OptionC = "Uvijek kada je vozilo u pokretu", OptionD = "Kada je brzina veća od 40 km/h", CorrectAnswer = "Uvijek kada je vozilo u pokretu", TestId = 2 },
                    new Question { Text = "Ko ima prednost na raskrsnici sa kružnim tokom saobraćaja?", OptionA = "Vozila koja ulaze u kružni tok", OptionB = "Vozila koja izlaze iz kružnog toka", OptionC = "Vozila koja se kreću unutar kružnog toka", OptionD = "Pješaci na obližnjem prelazu", CorrectAnswer = "Vozila koja se kreću unutar kružnog toka", TestId = 2 },
                    new Question { Text = "Šta je obavezno provjeriti prije polaska na duže putovanje?", OptionA = "Stanje ulja, rashladne tečnosti, i pritisak u gumama", OptionB = "Čistoću prozora", OptionC = "Ispravnost klima uređaja", OptionD = "Broj putnika", CorrectAnswer = "Stanje ulja, rashladne tečnosti, i pritisak u gumama", TestId = 3 },
                    new Question { Text = "Vozač je:", OptionA = "svako lice koje se u saobraćaju na putu nalazi u vozilu", OptionB = "lice koje na putu upravlja vozilom", OptionC = "sve navedeno", OptionD="ništa od navedenog", CorrectAnswer = "lice koje na putu upravlja vozilom", TestId = 3 },
                    new Question { Text = "Šta je zaustavljanje vozila?", OptionA = "Svaki prekid kretanja vozila na putu u trajanju do 15 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", OptionB = "Svaki prekid kretanja vozila na putu u trajanju do 5 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", OptionC = "Svaki prekid kretanja vozila na putu u trajanju do 10 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", OptionD = "Svaki prekid kretanja vozila na putu bez obzira na trajanje", CorrectAnswer = "Svaki prekid kretanja vozila na putu u trajanju do 15 minuta, osim prekida koji se pravi da bi se postupilo po znaku ili pravilu kojim se reguliše saobraćaj", TestId = 3 },
                    new Question { Text = "Koje vozilo se ne smije vući pomoću užeta?", OptionA = "Motorno vozilo na kojem su neispravni uređaji za osvjetljenje", OptionB = "Motorno vozilo na kojem su neispravni uređaji za davanje znakova", OptionC = "Motorno vozilo na kojem su neispravni uređaji za zaustavljanje", OptionD = "Motorno vozilo na kojem su neispravni uređaji za upravljanje", CorrectAnswer = "Motorno vozilo na kojem su neispravni uređaji za upravljanje", TestId = 3 },
                    new Question { Text = "Koliko važi ljekarsko uvjerenje o zdravstvenoj sposobnosti za upravljanje motornim vozilom?", OptionA = "12 mjeseci od dana izdavanja", OptionB = "6 mjeseci od dana izdavanja", OptionC = "24 mjeseca od dana izdavanja", OptionD = "36 mjeseci od dana izdavanja", CorrectAnswer = "12 mjeseci od dana izdavanja", TestId = 3 },
                    new Question { Text = "Šta podrazumijeva pojam 'pješak'?", OptionA = "Lice koje učestvuje u saobraćaju, a ne upravlja vozilom, niti se prevozi u vozilu ili na vozilu", OptionB = "Lice koje upravlja vozilom, ili se prevozi u vozilu ili na vozilu", OptionC = "Lice koje se prevozi u vozilu ili na vozilu", OptionD = "Lice koje upravlja vozilom", CorrectAnswer = "Lice koje učestvuje u saobraćaju, a ne upravlja vozilom, niti se prevozi u vozilu ili na vozilu", TestId = 3 },
                    new Question { Text = "Šta je stiker-naljepnica?", OptionA = "Dokaz o izvršenom tehničkom pregledu", OptionB = "Dokaz o plaćenoj putarini", OptionC = "Dokaz o registrovanju vozila", OptionD = "Dokaz o osiguranju vozila", CorrectAnswer = "Dokaz o registrovanju vozila", TestId = 3 },
                    new Question { Text = "Koliko važi registracija mopeda?", OptionA = "Nije vremenski ograničena", OptionB = "Jednu godinu", OptionC = "Dvije godine", OptionD = "Tri godine", CorrectAnswer = "Nije vremenski ograničena", TestId = 3 },
                    new Question { Text = "Koje je osnovno pravilo imobilizacije?", OptionA = "Da se imobiliziraju dva susjedna zgloba", OptionB = "Da se imobilizira jedan povrijeđen zglob", OptionC = "Da se imobiliziraju svi zglobovi", OptionD = "Da se imobilizira samo povrijeđeni dio", CorrectAnswer = "Da se imobiliziraju dva susjedna zgloba", TestId = 3 },
                    new Question { Text = "Koliko dugo se vrši oživljavanje (kardiopulmonalna reanimacija - KPR)?", OptionA = "20 minuta", OptionB = "40 minuta", OptionC = "Do dolaska stručne pomoći", OptionD = "Dok se povrijeđeni ne oporavi", CorrectAnswer = "Do dolaska stručne pomoći", TestId = 3 },
                    new Question { Text = "Kada ne treba započeti oživljavanje (KPR)?", OptionA = "Ako je sigurno prošlo više od 10 minuta od zastoja srca", OptionB = "Ako postoji otvorena rana na grudnom košu", OptionC = "Ako je opečena površina tijela veća od 60%", OptionD = "Ako je povrijeđeni bez svijesti", CorrectAnswer = "Ako je sigurno prošlo više od 10 minuta od zastoja srca", TestId =4 },
                    new Question { Text = "Koji je odnos disanja i vanjske masaže srca kod oživljavanja (KPR)?", OptionA = "5 upuhivanja i 5 masaža srca, tj. odnos 1:1", OptionB = "2 upuhivanja i 15 masaža srca, tj. odnos 2:15", OptionC = "30 masaža srca i 2 upuhivanja, tj. odnos 30:2", OptionD = "15 masaža srca i 2 upuhivanja, tj. odnos 15:2", CorrectAnswer = "30 masaža srca i 2 upuhivanja, tj. odnos 30:2", TestId = 4 },
                    new Question { Text = "Šta označava plava boja svjetlosnog signala na vozilu?", OptionA = "Prevoz materijala opasnih po okolinu", OptionB = "Posebne namjene u hitnim slučajevima", OptionC = "Obilježavanje vozila koje prati teret", OptionD = "Obilježavanje sporih vozila", CorrectAnswer = "Posebne namjene u hitnim slučajevima", TestId =4 },
                    new Question { Text = "Šta je cilj vožnje u skladu sa saobraćajnim pravilima?", OptionA = "Brže stići do odredišta", OptionB = "Izbjegavanje kazni", OptionC = "Povećanje sigurnosti svih učesnika u saobraćaju", OptionD = "Štednja goriva", CorrectAnswer = "Povećanje sigurnosti svih učesnika u saobraćaju", TestId = 4 },
                    new Question { Text = "Kada je dozvoljeno koristiti sirenu?", OptionA = "U svakoj situaciji", OptionB = "Samo kada je potrebno izbjeći saobraćajnu nezgodu", OptionC = "Tokom preticanja vozila", OptionD = "Prilikom parkiranja vozila", CorrectAnswer = "Samo kada je potrebno izbjeći saobraćajnu nezgodu", TestId = 4 },
                    new Question { Text = "Koliko je minimalna dubina šare na pneumaticima za ljetni period?", OptionA = "1,6 mm", OptionB = "3 mm", OptionC = "4 mm", OptionD = "2 mm", CorrectAnswer = "1,6 mm", TestId = 4 },
                    new Question { Text = "Koji je maksimalni dozvoljeni nivo alkohola u krvi za profesionalne vozače?", OptionA = "0,5 g/kg", OptionB = "0,2 g/kg", OptionC = "0,0 g/kg", OptionD = "0,3 g/kg", CorrectAnswer = "0,0 g/kg", TestId = 5 },
                    new Question { Text = "Koji uređaj je obavezan u vozilu u zimskom periodu?", OptionA = "Lanac za snijeg", OptionB = "Komplet za prvu pomoć", OptionC = "Reflektujući prsluk", OptionD = "Rezervni točak", CorrectAnswer = "Lanac za snijeg", TestId = 5 },
                    new Question { Text = "Koji je cilj obavezne vozačke obuke?", OptionA = "Dobijanje vozačke dozvole", OptionB = "Savladavanje saobraćajnih pravila i sigurnog upravljanja vozilom", OptionC = "Poznavanje tehničkih karakteristika vozila", OptionD = "Smanjenje saobraćajnih kazni", CorrectAnswer = "Savladavanje saobraćajnih pravila i sigurnog upravljanja vozilom", TestId = 5 },
                    new Question { Text = "Koliko iznosi dozvoljena brzina u naseljenim mjestima, osim ako nije drugačije označeno?", OptionA = "40 km/h", OptionB = "50 km/h", OptionC = "60 km/h", OptionD = "70 km/h", CorrectAnswer = "50 km/h", TestId = 5 },
                    new Question { Text = "Kada vozač mora koristiti sigurnosni pojas?", OptionA = "Samo na autoputu", OptionB = "Samo u urbanim područjima", OptionC = "Uvijek kada je vozilo u pokretu", OptionD = "Kada je brzina veća od 40 km/h", CorrectAnswer = "Uvijek kada je vozilo u pokretu", TestId = 5 },
                    new Question { Text = "Ko ima prednost na raskrsnici sa kružnim tokom saobraćaja?", OptionA = "Vozila koja ulaze u kružni tok", OptionB = "Vozila koja izlaze iz kružnog toka", OptionC = "Vozila koja se kreću unutar kružnog toka", OptionD = "Pješaci na obližnjem prelazu", CorrectAnswer = "Vozila koja se kreću unutar kružnog toka", TestId = 5 },
                };

                foreach (var question in questions)
                {
                    await _database.InsertAsync(question);
                }
            }
        }
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set => _currentUser = value;
        }

        // Dodavanje korisnika
        public Task RegisterUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _database.Table<User>()
                            .Where(u => u.Username == username && u.Password == password)
                            .FirstOrDefaultAsync();
            if (user != null)
            {
                UserSessionService.CurrentUser = user;
                    }
            return user;
        }
        public Task<User> GetUserByIdAsync(int userId)
        {
            return _database.Table<User>()
                            .Where(u => u.ID == userId)
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
