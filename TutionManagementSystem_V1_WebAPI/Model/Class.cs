using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TutionManagementSystem_V1_WebAPI.Model;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [JsonIgnore]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
