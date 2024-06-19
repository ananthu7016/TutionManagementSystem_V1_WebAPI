using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TutionManagementSystem_V1_WebAPI.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    [JsonIgnore]
    public virtual Role? Role { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [JsonIgnore]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
