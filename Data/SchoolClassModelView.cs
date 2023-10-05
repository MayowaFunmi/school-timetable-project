using SchoolTimeTable.Models;

namespace SchoolTimeTable.Data
{
    public class SChoolClassModelView
    {
        public School School { get; set; }
        public StudentClass StudentClass { get; set; }
        public List<StudentClass> StudentClasses { get; set; }
        public List<ClassArm> ClassArms { get; set; }
    }
}