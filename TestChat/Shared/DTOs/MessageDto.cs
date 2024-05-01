using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.DTOs
{
    public record MessageDto(int ToUserId, int FromUserId, string Message, DateTime SentOn);
}
