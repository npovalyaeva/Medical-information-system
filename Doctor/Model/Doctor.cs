using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Model
{
    public class Doctor : Specialist.Model.Specialist
    {
        public string DiplomaSpeciality { get; set; }

        public int Qualification { get; set; }
    }
}
