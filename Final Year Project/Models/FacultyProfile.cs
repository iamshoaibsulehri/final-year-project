using System;
using System.Collections.Generic;

namespace FinalYearProject.Models
{
    public partial class FacultyProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string University { get; set; }
    }
}
