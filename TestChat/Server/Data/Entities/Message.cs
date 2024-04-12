using System.ComponentModel.DataAnnotations;

namespace TestChat.Server.Data.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime AddedOn { get; set; }


        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
    }
}
