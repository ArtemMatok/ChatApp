using System.ComponentModel.DataAnnotations;

namespace TestChat.Server.Data.Entities
{
    
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }


}
