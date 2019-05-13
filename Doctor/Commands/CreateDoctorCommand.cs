using Specialist.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Commands
{
    public class CreateDoctorCommand : CreateSpecialistCommand
    {
        public string DiplomaSpeciality { get; set; }

        public int Qualification { get; set; }
    }
}
