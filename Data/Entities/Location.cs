using System;
using System.Collections.Generic;

namespace IdigitalCafe.Data.Entities;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationName { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedById { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int? UpdatedById { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public int? DeletedById { get; set; }

    public DateOnly? DeleteDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
