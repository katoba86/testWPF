using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1.Entities;

using System.Collections.Generic;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Navigation Property: Ein Kunde hat mehrere Produkte
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
