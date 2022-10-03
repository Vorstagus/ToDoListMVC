using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListMVC.Models
{


    [Table("Users")]
    public class  UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Required]
       
        public  int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        //email needs to be unique
        public  string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public  string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
        //  public virtual ICollection<UserModel> Users { get; set; }

      /*  [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }*/

    }
}
