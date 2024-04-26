using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestChat.Server.Data.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime SentOn { get; set; }

        [ForeignKey(nameof(Message.FromId))]
        public virtual User FromUser { get; set; }

        [ForeignKey(nameof(Message.ToId))]
        public virtual User ToUser { get; set; }
    }
}
