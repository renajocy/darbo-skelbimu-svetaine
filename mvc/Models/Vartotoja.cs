using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mvc.Models
{
    public partial class Vartotoja
    {
        public Vartotoja()
        {
            Isiminta = new HashSet<Isimintum>();
            Komentaras = new HashSet<Komentara>();
        }

        [DisplayName("Vardas")]
        public string Vardas { get; set; }
        [DisplayName("Slaptažodis")]
        [Required(ErrorMessage = "Turite įvesti slaptažodį!")]
        [StringLength(50, ErrorMessage = "Turi būti mažiausiai 5 simboliai!", MinimumLength = 5)]
        public string Slaptazodis { get; set; }

        [Required(ErrorMessage = "Patvirtinkite įvestą slaptažodį!")]
        [DisplayName("Patvirtinti slaptažodį")]
        [Compare("Slaptazodis", ErrorMessage = "Slaptažodis turi sutapti!")]
        [NotMapped]
        public string PatvirtintiSlaptazodi { get; set; }
        [DisplayName("Tel. Nr.")]
        public string Telefonas { get; set; }
        [DisplayName("El. Paštas")]
        public string EPastas { get; set; }
        [DisplayName("Miestas")]
        public string Miestas { get; set; }
        [DisplayName("Vartotojo identifikacinis numeris")]
        public int Id { get; set; }

        public virtual Skelbima Skelbima { get; set; }
        public virtual ICollection<Isimintum> Isiminta { get; set; }
        public virtual ICollection<Komentara> Komentaras { get; set; }
    }
}
