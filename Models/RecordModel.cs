using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListMVC.Models
{
    [Table("Records")]
    public class RecordModel 
    {
        [Key,Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
     
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
