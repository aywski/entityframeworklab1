using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Tag
{
    public int Id { get; set; }

    public int TagId { get; set; }

    public int TagMode { get; set; }

    public bool TagHorror { get; set; }

    public bool TagRpg { get; set; }

    public bool TagPvP { get; set; }

    public bool TagSurvival { get; set; }

    public bool TagOpenWorld { get; set; }

    public bool TagStrategy { get; set; }

    public bool TagIndie { get; set; }

    public bool TagRoguelike { get; set; }

    public bool TagSoulslike { get; set; }

    public virtual ICollection<Game> Games { get; } = new List<Game>();

    public virtual Mode TagModeNavigation { get; set; } = null!;
}
