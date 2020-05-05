using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class AutoriaiDouble
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AutoriaiDouble()
        {
            this.Knygos = new HashSet<Knygo>();
        }

        [Required(ErrorMessage = "Privalomas laukas")]
        [StringLength(50, ErrorMessage = "Vardas negali būti ilgesnis nei 50 simbolių")]
        public string Vardas1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        [StringLength(50, ErrorMessage = "Pavardė negali būti ilgesnė nei 50 simbolių")]
        public string Pavarde1 { get; set; }


        [Required(ErrorMessage = "Privalomas laukas")]
        [StringLength(50, ErrorMessage = "Vardas negali būti ilgesnis nei 50 simbolių")]
        public string Vardas2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        [StringLength(50, ErrorMessage = "Pavardė negali būti ilgesnė nei 50 simbolių")]
        public string Pavarde2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Knygo> Knygos { get; set; }
    }
}