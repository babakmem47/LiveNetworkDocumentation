//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveNetworkDocumentation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manategh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manategh()
        {
            this.KhadamatMashiniPersonnels = new HashSet<KhadamatMashiniPersonnel>();
            this.VoipLines = new HashSet<VoipLine>();
        }
    
        public byte Id { get; set; }
        public byte Shakhes { get; set; }
        public string Name { get; set; }
        public string CityCenter { get; set; }
        public string Address { get; set; }
        public string PreTelCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhadamatMashiniPersonnel> KhadamatMashiniPersonnels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VoipLine> VoipLines { get; set; }
    }
}
