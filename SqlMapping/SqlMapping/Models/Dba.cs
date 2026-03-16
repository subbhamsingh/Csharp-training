using System;
using System.Collections.Generic;

namespace SqlMapping.Models;

public partial class Dba
{
    public int DbaId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
