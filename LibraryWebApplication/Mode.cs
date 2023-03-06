using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Mode
{
    public int Id { get; set; }

    public int ModeId { get; set; }

    public bool? ModeSingleplayer { get; set; }

    public bool? ModeMultiplayer { get; set; }

    public virtual ICollection<Tag> Tags { get; } = new List<Tag>();
}
