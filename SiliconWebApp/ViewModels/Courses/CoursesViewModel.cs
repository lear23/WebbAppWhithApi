using System.ComponentModel.DataAnnotations.Schema;

namespace SiliconWebApp.ViewModels.Courses;

public class CoursesViewModel
{
    public IEnumerable<CourseModel> CourseModels { get; set; } = []; 
}
