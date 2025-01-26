using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vroomApp.Podaci;

public class UserSessionService
{
    // Privatna statička instanca za singleton
    private static UserSessionService _instance;

    // Svojstvo za pristup instanci
    public static UserSessionService Instance => _instance ??= new UserSessionService();

    // ID trenutno prijavljenog korisnika
    public int CurrentUserId { get; set; }
    public static User CurrentUser { get; internal set; }

    // Privatni konstruktor za sprječavanje vanjskog instanciranja
    private UserSessionService()
    {
        // Po želji inicijaliziraj default ID (npr. za gosta)
        CurrentUserId = 0;
    }
}
