using System.ComponentModel.DataAnnotations;

namespace KGD.Domain.Entity
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
