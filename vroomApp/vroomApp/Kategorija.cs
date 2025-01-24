using System.Windows.Input;
using vroomApp;

public class Kategorije
{
    public string Naziv { get; set; }
    public string Slika { get; set; }
    public string Opis { get; set; }

    public string TestInfo { get; set; }
}
public class KategorijeViewModel
{
    public List<Kategorije> Kategorije { get; set; }
    public KategorijeViewModel()
    {
        Kategorije = new List<Kategorije>
            {
                new Kategorije { Naziv = "A KATEGORIJA", Slika = "motor.png", Opis="Lekcije za spremanje ispita za kategorije A i A1, odnosno vožnju motocikla i mopeda.", TestInfo="Pitanja su podijeljena u 16 lekcija od po 20 pitanja." },
                new Kategorije { Naziv = "B KATEGORIJA", Slika = "auto.png", Opis="Lekcija za spremanje ispita za kazegorije B i B1, odnosno vožnju automobila i mopeda.", TestInfo="Pitanja su podijeljena u 19 lekcija od po 20 pitanja."},
                new Kategorije { Naziv = "C KATEGORIJA", Slika = "kamion.png", Opis="Lekcije za spremanje ispita za kategorije C i C1, odnosno vožnju kamiona i kamiona do 7.5t.", TestInfo="Pitanja su podijeljena u 20 lekcija od po 20 pitanja." },
                new Kategorije { Naziv = "D KATEGORIJA", Slika = "bus.png", Opis="Lekcije za spremanje ispita za kategoriju D, odnosno vožnju autobusa.", TestInfo="Pitanja su podijeljena u 18 lekcija od po 20 pitanja." },
                new Kategorije { Naziv = "T KATEGORIJA", Slika = "traktortom.png", Opis="Lekcije za spremanje ispita za kategoriju T, odnosno vožnju traktora i radnih strojeva.", TestInfo="Pitanja su podijeljena u 10 lekcija od po 10 pitanja." }
            };
    }
}

