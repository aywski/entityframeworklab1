using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Price
{
    public int Id { get; set; }

    public int PriceId { get; set; }

    public decimal? PriceInUah { get; set; }

    public decimal? PriceInUsd { get; set; }

    public decimal? PriceInEur { get; set; }

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
