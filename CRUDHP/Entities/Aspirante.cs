using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDHP.Entities
{
        [Table("aspirante")]
    public class Aspirante
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Identification { get; set; }
        public int Age { get; set; }
        public string House { get; set; }
    }
}
