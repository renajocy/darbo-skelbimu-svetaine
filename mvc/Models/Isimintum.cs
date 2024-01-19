using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mvc.Models
{
    public partial class Isimintum
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Skelbimas")]
        public int FkSkelbimasid { get; set; }
        [DisplayName("Vartotojas")]
        public int FkVartotojasid { get; set; }

        public virtual Skelbima FkSkelbimas { get; set; }
        public virtual Vartotoja FkVartotojas { get; set; }
    }
}
