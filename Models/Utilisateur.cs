using System;
using System.Collections.Generic;

namespace ApplicationGestionFonciers.API.Models;

public partial class Utilisateur
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string Email { get; set; }

    public string Tel { get; set; }

    public string Adresse { get; set; }

    public string Account { get; set; }

    public string Password { get; set; }
}
