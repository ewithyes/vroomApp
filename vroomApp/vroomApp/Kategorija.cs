using System.Windows.Input;
using vroomApp;

public class Kategorije
{
    public string Naziv { get; set; }
    public string Slika { get; set; }
}
public class KategorijeViewModel
{
    public List<Kategorije> Kategorije { get; set; }
    public KategorijeViewModel()
    {
        Kategorije = new List<Kategorije>
            {
                new Kategorije { Naziv = "A KATEGORIJA", Slika = "motor.png" },
                new Kategorije { Naziv = "B KATEGORIJA", Slika = "auto.png" },
                new Kategorije { Naziv = "C KATEGORIJA", Slika = "kamion.png" },
                new Kategorije { Naziv = "D KATEGORIJA", Slika = "bus.png" },
                new Kategorije { Naziv = "T KATEGORIJA", Slika = "traktortom.png" }
            };
    }
}

