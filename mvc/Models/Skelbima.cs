using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mvc.Models
{
    public partial class Skelbima
    {
        public Skelbima()
        {
            Isiminta = new HashSet<Isimintum>();
            Komentaras = new HashSet<Komentara>();
        }

        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }
        [DisplayName("Aprašymas")]
        public string Aprasymas { get; set; }
        [DisplayName("Adresas")]
        public string Adresas { get; set; }
        [DisplayName("Užmokestis")]
        public decimal Uzmokestis { get; set; }
        [DisplayName("Sukūrimo data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayName("Apmokėjimas")]
        public int MokejimoBudas { get; set; }
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Sukūrė")]
        public int? FkVartotojasid { get; set; }
        [DisplayName("Kategorija")]
        public int FkKategorijaid { get; set; }

        [DisplayName("Kategorija")]
        public virtual Kategorija FkKategorija { get; set; }
        [DisplayName("Sukūrė")]
        public virtual Vartotoja FkVartotojas { get; set; }
        [DisplayName("Atsiskaitymo būdas")]
        public virtual Apmokejima MokejimoBudasNavigation { get; set; }
        public virtual ICollection<Isimintum> Isiminta { get; set; }
        public virtual ICollection<Komentara> Komentaras { get; set; }
    }
}
