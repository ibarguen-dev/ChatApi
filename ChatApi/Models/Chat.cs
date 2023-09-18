using System;
using System.Collections.Generic;

namespace ChatApi.Models;

public partial class Chat
{
    public int IdChat { get; set; }

    public string Chat1 { get; set; } = null!;

    public int? IdUser { get; set; }

    public int? IdServer { get; set; }

    public virtual Server? IdServerNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
