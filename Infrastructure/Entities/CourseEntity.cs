

namespace Infrastructure.Entities;

public class CourseEntity
{

    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? Discount { get; set; }
    public string? Hours { get; set; }
    public bool? IsBestSeller { get; set; }
    public string? LikesNumbers { get; set; }
    public string? LikesProcent { get; set; }
    public string? Author { get; set; }

}
