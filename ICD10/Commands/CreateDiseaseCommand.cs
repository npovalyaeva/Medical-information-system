using System;
using System.Collections.Generic;
using System.Text;

namespace Disease.Commands
{
    public class CreateDiseaseCommand
    {
        public string Id { get; set; }

        public string Subcategory { get; set; }

        public string Category { get; set; }

        public string Block { get; set; }

        public string Chapter { get; set; }
    }
}
