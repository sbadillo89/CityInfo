using System;
using System.Collections.Generic;

namespace CityInfo.Models;

public partial class History
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Info { get; set; }

    public DateTime? CreateDate { get; set; }
}
