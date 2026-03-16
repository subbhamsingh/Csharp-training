using System;
using System.Collections.Generic;

namespace SqlMapping.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }  // added after scaffold from database approach
    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!; // navigation property demonstation and use 
}
