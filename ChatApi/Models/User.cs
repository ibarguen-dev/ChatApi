using System;
using System.Collections.Generic;

namespace ChatApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Password { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
