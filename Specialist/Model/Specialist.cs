using System;

namespace Specialist.Model
{
    public class Specialist
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime Birthday { get; set; }

        public string Education { get; set; }

        public string Position { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime DismissalDate { get; set; }

        public decimal WageRate { get; set; }

        public int? SubunitId { get; set; }

        public int? UnitId { get; set; }

        public int? ParlourId { get; set; }
    }
}
