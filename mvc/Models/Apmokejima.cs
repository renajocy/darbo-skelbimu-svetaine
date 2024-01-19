using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mvc.Models
{
    public partial class Apmokejima
    {
        public Apmokejima()
        {
            Skelbimas = new HashSet<Skelbima>();
        }


        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Tipas")]
        public string Name { get; set; }

        public virtual ICollection<Skelbima> Skelbimas { get; set; }
    }
}
