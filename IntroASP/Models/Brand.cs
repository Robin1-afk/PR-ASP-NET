using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Beers = new HashSet<Beer>();
        }
        [Key]  // Esto indica que BeerId es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Esto indica que se generará automáticamente
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
