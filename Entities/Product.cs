using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Fremdschlüssel zum Kunden
    public int ClientId { get; set; }
    public Client? Client { get; set; }
}