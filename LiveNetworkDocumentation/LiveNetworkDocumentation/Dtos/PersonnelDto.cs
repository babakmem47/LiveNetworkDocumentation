using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LiveNetworkDocumentation.Models;

namespace LiveNetworkDocumentation.Dtos
{
    public class PersonnelDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Semat Semat { get; set; }

        public byte? SematId { get; set; }

        public string TelDakheli { get; set; }

        public string TelMostaghim { get; set; }

        public string Mobile { get; set; }

        public Manategh Manategh { get; set; }

        public byte? ManateghId { get; set; }
    }
}