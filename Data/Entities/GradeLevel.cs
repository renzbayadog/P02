using System;
using System.Collections.Generic;

namespace IdigitalCafe.Data.Entities;

public partial class GradeLevel
{
    public int GradeLevelId { get; set; }

    public string GradeLevelName { get; set; }

    public int? Sequence { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedById { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int? UpdatedById { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public int? DeletedById { get; set; }

    public DateOnly? DeleteDate { get; set; }

    public int? ForecastId { get; set; }

    public virtual Forecast Forecast { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
