using WebApi_Jayasri.Models;

namespace WebApi_Jayasri.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
    }
}
