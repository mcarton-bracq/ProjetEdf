//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace edfWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class controleur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public controleur()
        {
            this.client = new HashSet<client>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string login { get; set; }
        public string mdp { get; set; }
        public string statut { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> client { get; set; }
    }
}
