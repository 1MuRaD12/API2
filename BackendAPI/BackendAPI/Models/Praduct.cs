using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class Praduct
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
    }
}
