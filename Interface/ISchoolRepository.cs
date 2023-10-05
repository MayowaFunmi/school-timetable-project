using SchoolTimeTable.Models;

namespace SchoolTimeTable.Interface
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetAllSchools();
        Task<School> GetSchoolById(string Id);
        Task<bool> Create(School school, string userId);
        Task<bool> Update(School school);
        Task<bool> Delete(School school);
        bool Save();
    }
}