using WebApi_Jayasri.Models;

namespace WebApi_Jayasri.Service
{
    public interface IStudentService
    {
        Task<List<Student>> Getstudents();
        Task<Student?> Getstudent(int id);
        
    }
}
