using SchoolTimeTable.Data;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartmentById(string Id);
        Task<bool> Create(SchoolDeptModelView departmentView);
        Task<bool> Update(Department department);
        Task<bool> Delete(Department department);
        bool Save();
    }
}