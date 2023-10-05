using SchoolTimeTable.Models;

namespace SchoolTimeTable.Data
{
    public class SchoolDeptModelView
    {
        public School School { get; set; }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }
    }
}