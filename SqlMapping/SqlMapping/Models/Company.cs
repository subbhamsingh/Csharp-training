using System;
using System.Collections.Generic;

namespace SqlMapping.Models;

public partial class Company
{
    public int CompId { get; set; }

    public string CompName { get; set; } = null!;

    public string RegisterNo { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int DbaId { get; set; }

    public virtual Dba Dba { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
