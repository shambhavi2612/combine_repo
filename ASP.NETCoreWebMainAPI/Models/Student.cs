using System;
using System.Collections.Generic;

namespace ASP.NETCoreWebMainAPI.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? StudentGender { get; set; }
        public int? Age { get; set; }
        public int? Standards { get; set; }
        public string? FatherName { get; set; }
    }
}
