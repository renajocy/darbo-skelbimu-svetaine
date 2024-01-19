using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mvc.Models
{
    public partial class Komentara
    {
        [DisplayName("Komentaras")]
        public string Komentaras { get; set; }
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Komentatorius")]
        public int FkVartotojasid { get; set; }
        [DisplayName("Skelbimas")]
        public int FkSkelbimasid { get; set; }

        public virtual Skelbima FkSkelbimas { get; set; }
        public virtual Vartotoja FkVartotojas { get; set; }
    }
}
