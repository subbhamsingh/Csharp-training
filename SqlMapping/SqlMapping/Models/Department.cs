using System;
using System.Collections.Generic;

namespace SqlMapping.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CompId { get; set; }

    public virtual Company Comp { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
