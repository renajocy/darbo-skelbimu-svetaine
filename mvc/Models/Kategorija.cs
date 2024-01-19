using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mvc.Models
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Skelbimas = new HashSet<Skelbima>();
        }

        [DisplayName("Kategorijos pavadinimas")]
        public string Pavadinimas { get; set; }
        [DisplayName("Id")]
        public int Id { get; set; }

        public virtual ICollection<Skelbima> Skelbimas { get; set; }
    }
}
