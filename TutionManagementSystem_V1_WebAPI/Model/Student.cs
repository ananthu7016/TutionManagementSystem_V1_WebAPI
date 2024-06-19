using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TutionManagementSystem_V1_WebAPI.Model;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public bool? IsActive { get; set; }

    public int? ClassId { get; set; }

    public int? StatusId { get; set; }

    public int? UserId { get; set; }

    [JsonIgnore]
    public virtual Class? Class { get; set; }

    [JsonIgnore]
    public virtual EducationalStatus? Status { get; set; }

    [JsonIgnore]
    public virtual User? User { get; set; }
}
