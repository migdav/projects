using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class SkaitytojaiDouble
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkaitytojaiDouble()
        {
            this.Uzsakymais = new HashSet<Uzsakymai>();
        }

        [Required(ErrorMessage = "Privalomas laukas")]
        public int kodas1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Vardas1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Pavarde1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Gimimo_metai1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        [DisplayFormat(DataFormatString = "{0:D9}")]
        public int TelefonoNr1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Email1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> TipasId1 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> BibliotekaId1 { get; set; }

        [Required(ErrorMessage = "Privalomas laukas")]
        public int kodas2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Vardas2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Pavarde2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime Gimimo_metai2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public int TelefonoNr2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public string Email2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> TipasId2 { get; set; }
        [Required(ErrorMessage = "Privalomas laukas")]
        public Nullable<int> BibliotekaId2 { get; set; }

        public virtual Biblioteko Biblioteko { get; set; }
        public virtual Tipai Tipai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uzsakymai> Uzsakymais { get; set; }
    }
}