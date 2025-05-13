using System;
using System.Collections.Generic;

namespace IdigitalCafe.Data.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int? GradeLevelId { get; set; }

    public int? LocationId { get; set; }

    public string ProductName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual GradeLevel GradeLevel { get; set; }

    public virtual Location Location { get; set; }
}
