using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Game
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public string GameName { get; set; } = null!;

    public DateTime? GameCreationDate { get; set; }

    public byte[]? GameLogo { get; set; }

    public int GamePrice { get; set; }

    public int? GameTags { get; set; }

    public int? GamePublisher { get; set; }

    public bool? GameReview { get; set; }

    public virtual Price GamePriceNavigation { get; set; } = null!;

    public virtual Publisher? GamePublisherNavigation { get; set; }

    public virtual Tag? GameTagsNavigation { get; set; }
}
