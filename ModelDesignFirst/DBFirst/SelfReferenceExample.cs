//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelDesignFirst.DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class SelfReferenceExample
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SelfReferenceExample()
        {
            this.SelfReference1 = new HashSet<SelfReferenceExample>();
        }
    
        public int SelfReferenceId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentSelfReferenceId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SelfReferenceExample> SelfReference1 { get; set; }
        public virtual SelfReferenceExample SelfReference2 { get; set; }
    }
}