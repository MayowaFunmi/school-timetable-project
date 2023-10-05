namespace SchoolTimeTable.Interface
{
    public interface IClassArmRepository
    {
        Task<bool> Create();
        bool Save();
    }
}