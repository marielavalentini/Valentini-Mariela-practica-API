using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.RegularExpressions;

namespace WSAuto.Models
{
    [Table("Vehiculo")]

    public class Auto        
    {
        public int Id { get; set; }

        [Required]//campo obligatorio - DB: NOT NULL
        [Column(TypeName = "varchar(50)")]//tipo de datos de sql server
       

        public string Marca { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]

        public string Modelo { get; set; }

        [Column(TypeName = "varchar(50)")]
        
        public string Color { get; set; }

        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
    }
}
