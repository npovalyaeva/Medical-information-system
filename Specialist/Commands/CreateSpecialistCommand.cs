using System;

namespace Specialist.Commands
{
    public class CreateSpecialistCommand : CreateSpecialistNameCommand
    {
        public bool IsDoctor { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Birthday { get; set; }

        public string Education { get; set; }

        public string Position { get; set; }

        public string AdmissionDate { get; set; }

        //public DateTime DismissalDate { get; set; }

        public decimal WageRate { get; set; }

        public string Subunit { get; set; }

        public string Unit { get; set; }

        public int Parlour { get; set; }

        public string DiplomaSpeciality { get; set; }

        public int Qualification { get; set; }

        public int PostNumber { get; set; }
    }
}
