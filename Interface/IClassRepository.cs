using SchoolTimeTable.Data;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Interface
{
    public interface IClassRepository
    {
        Task<IEnumerable<StudentClass>> GetAllClasses();
        Task<StudentClass> GetClassById(string Id);
        Task<bool> Create(SChoolClassModelView modelView);
        Task<bool> Update(StudentClass studentClass);
        Task<bool> Delete(StudentClass studentClass);
        bool Save();
    }
}