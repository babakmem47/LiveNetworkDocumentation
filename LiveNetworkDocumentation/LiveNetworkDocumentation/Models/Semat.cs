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
    
    public partial class Semat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semat()
        {
            this.KhadamatMashiniPersonnels = new HashSet<KhadamatMashiniPersonnel>();
        }
    
        public byte Id { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhadamatMashiniPersonnel> KhadamatMashiniPersonnels { get; set; }
    }
}