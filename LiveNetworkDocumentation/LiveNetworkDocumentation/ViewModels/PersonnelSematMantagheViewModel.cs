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
        public PersonnelSematMantagheViewModel()
        {
            Id = 0;
        }

        public PersonnelSematMantagheViewModel(KhadamatMashiniPersonnel personnel)
        {
            Id = personnel.Id;
            SematId = personnel.SematId;
            ManateghId = personnel.ManateghId;
            Name = personnel.Name;
            TelDakheli = personnel.TelDakheli;
            TelMostaghim = personnel.TelMostaghim;
            Mobile = personnel.Mobile;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [Display(Name = "نام مسئول خدمات ماشینی")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "انتخاب سِمَت اجباری است")]
        [Display(Name = "سِمَت")]
        public byte? SematId { get; set; }

        public IEnumerable<Semat> Semats { get; set; }

        [Display(Name = "تلفن داخلی")]
        [StringLength(19, ErrorMessage = "حداکثر طول مجاز 30 کاراکتر است")]
        public string TelDakheli { get; set; }

        [Display(Name = "تلفن مستقیم")]
        [StringLength(30)]
        public string TelMostaghim { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = " فقط ورود ارقام مجاز می باشد")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل باید یازده رقم باشد")]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        //[Required(ErrorMessage = "انتخاب منطقه اجباری است")]
        [Display(Name = "منطقه")]
        public byte? ManateghId { get; set; }

        public IEnumerable<Manategh> Manateghs { get; set; }

        public string Title
        {
            get
            {
                if (Id == 0)                               
                {
                    return "ایجاد پرسنل جدید";          //    return Id == 0 ? "ایجاد پرسنل جدید" : "ویرایش پرسنل ";
                }

                return "ویرایش پرسنل ";
            }
        }

    }
}