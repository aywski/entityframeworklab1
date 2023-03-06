using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Publisher
{
    public int Id { get; set; }

    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public string? PublisherReview { get; set; }

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
