using System.Text.Json.Serialization;
using System;


namespace receptek_backend.Models;

public partial class Kategoriak
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Receptek>? Recepteks { get; set; } = new List<Receptek>();
}
