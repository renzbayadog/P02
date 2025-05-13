using System;
using System.Collections.Generic;

namespace IdigitalCafe.Data.Entities;

public partial class Forecast
{
    public int ForecastId { get; set; }

    public string ForecastName { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedById { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int? UpdatedById { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public int? DeletedById { get; set; }

    public DateOnly? DeleteDate { get; set; }

    public int SalesId { get; set; }

    public virtual ICollection<GradeLevel> GradeLevels { get; set; } = new List<GradeLevel>();

    public virtual Sale Sales { get; set; }
}
