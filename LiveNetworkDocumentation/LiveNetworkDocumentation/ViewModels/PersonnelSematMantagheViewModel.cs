using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LiveNetworkDocumentation.Models;

namespace LiveNetworkDocumentation.ViewModels
{
    public class PersonnelSematMantagheViewModel
    {
        public byte Id { get; set; }

        [Display(Name = "نام مسئول خدمات ماشینی")]
        public string Name { get; set; }

        public Semat SematId { get; set; }

        [Display(Name = "سِمَت")]
        public IEnumerable<Semat> Semats { get; set; }

        [Display(Name = "تلفن داخلی")]
        public string TelDakheli { get; set; }

        [Display(Name = "تلفن مستقیم")]
        public string TelMostaghim { get; set; }

        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        public Manategh MantagheId { get; set; }

        [Display(Name = "منطقه")]
        public IEnumerable<Manategh> Manateghs { get; set; }

    }
}