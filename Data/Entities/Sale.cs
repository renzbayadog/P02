using System;
using System.Collections.Generic;

namespace IdigitalCafe.Data.Entities;

public partial class Sale
{
    public int SalesId { get; set; }

    public string SalesName { get; set; }

    public int CategoryId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedById { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int? UpdatedById { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public int? DeletedById { get; set; }

    public DateOnly? DeleteDate { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();

    public virtual ICollection<Pullout> Pullouts { get; set; } = new List<Pullout>();
}
