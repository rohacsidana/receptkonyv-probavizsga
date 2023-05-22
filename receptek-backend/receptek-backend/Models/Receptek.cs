
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace receptek_backend.Models;

public partial class Receptek
{
    public int? Id { get; set; }

    public string Nev { get; set; } = null!;

    public int KatId { get; set; }

    public string KepEleresiUt { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    
    public virtual Kategoriak? Kat { get; set; } = null!;
}
