using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TutionManagementSystem_V1_WebAPI.Model;

public partial class EducationalStatus
{
    public int StatusId { get; set; }

    public string? Status { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
