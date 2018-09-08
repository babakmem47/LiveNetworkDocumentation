using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LiveNetworkDocumentation.Models
{

    public class ManateghMetadata
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "مقدار دهی فیلد شاخص الزامی است")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "مقدار فقط باید عددی باشد")]
        [Range(1, 60, ErrorMessage = "شاخص باید مابین اعداد 1 تا 60 باشد")]
        [Display(Name = "شاخص")]
        public byte Shakhes { get; set; }

        [Required(ErrorMessage = "مقدار دهی فیلد نام منطقه الزامی است")]
        [Display(Name = "نام منطقه")]
        [MaxLength(50, ErrorMessage = "نام حداکثر 50 کاراکتر می باشد")]
        public string Name { get; set; }

        [Display(Name = "مرکز")]
        [MaxLength(50, ErrorMessage = "نام حداکثر 50 کاراکتر می باشد")]
        public string CityCenter { get; set; }

        [Display(Name = "آدرس منطقه")]
        public string Address { get; set; }

        [Display(Name = "پیش شماره تلفن")]
        [MaxLength(4, ErrorMessage = "حداکثر چهار رقم")]
        public string PreTelCode { get; set; }


        [Required]
        public virtual ICollection<VoipLine> VoipLines { get; set; }
    }

    public class VoipLineMetadata
    {
        [Display(Name = "ردیف")]
        public byte Id { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = " فقط ورود ارقام مجاز می باشد")]
        [MaxLength(10, ErrorMessage = "حداکثر طول مجاز برای شماره پرونده ده رقم می باشد")]
        [Display(Name = "شماره پرونده خط")]
        public string FileNumber { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = " فقط ورود ارقام مجاز می باشد")]
        [MaxLength(4, ErrorMessage = "حداکثر چهار رقمی")]
        public int? Vlan { get; set; }

        public bool HaveVlan { get; set; }

        [Required(ErrorMessage = "وارد نمودن آی پی الزامی است")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "فرمت آی پی صحیح نمی باشد")]
        [Display(Name = "آی پی Wan سمت منطقه")]
        public string IpWanMantagheSide { get; set; }

        [Display(Name = "آیا ping داریم؟")]
        public bool IsPinged { get; set; }

        [DataType(DataType.Date, ErrorMessage = "فرمت تاریخ صحیح نمی باشد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاریخ تحویل خط در سایت ")]
        public DateTime? DateRecievedOnFiberInSite { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        [Display(Name = "تاریخ راه اندازی خط ")]
        public DateTime? DateCompletelyOperated { get; set; }

        [MaxLength(13, ErrorMessage = "حداکثر 13 رقمی")]
        [Display(Name = "شماره نامه")]
        public string LetterNumber { get; set; }

        [StringLength(7, MinimumLength = 7, ErrorMessage = "شماره شناسه باید هفت رقمی باشد")]
        [Display(Name = "شناسه نامه")]
        public string LetterId { get; set; }

        public Manategh Manategh { get; set; }

        [Required(ErrorMessage = "انتخاب منطقه الزامی است")]
        [Display(Name = "منطقه")]
        public byte ManateghId { get; set; }


    }

    public class KhadamatMashiniPersonnelMetadata
    {

        //[Required]
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

    public class SematMetadata
    {

        //[Required]      // comment it because of an error in API create and update : "Required property 'Id' not found in JSON Path......"
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

}