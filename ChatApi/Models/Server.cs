using System;
using System.Collections.Generic;

namespace ChatApi.Models;

public partial class Server
{
    public int IdServer { get; set; }

    public string Name { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
