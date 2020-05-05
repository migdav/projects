using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class KnygoesDouble
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KnygoesDouble()
        {
            this.UzsakymaiKnygos = new HashSet<UzsakymaiKnygo>();
        }

        [Required(ErrorMessage = "Privalomas laukas")]
        public string Vardas { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Pavarde { get; set; }
        public Nullable<int> AutoriusId { get; set; }

        [Required(ErrorMessage = "Privalomas laukas")]
        public string Pav1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Leidykla1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public int Metai1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> KalbaId1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> ZanrasId1 { get; set; }

        [Required(ErrorMessage = "Privalomas laukas")]
        public string Pav2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Leidykla2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public int Metai2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> KalbaId2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> ZanrasId2 { get; set; }

        public virtual Autoriai Autoriai { get; set; }
        public virtual Kalbo Kalbo { get; set; }
        public virtual Zanrai Zanrai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UzsakymaiKnygo> UzsakymaiKnygos { get; set; }
    }
}