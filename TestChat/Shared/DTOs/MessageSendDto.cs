using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.DTOs
{
    public record MessageSendDto(int ToUserId, string Message);
}
