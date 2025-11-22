using WebApi_Jayasri.Models;
using WebApi_Jayasri.Repositories;

namespace WebApi_Jayasri.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Student>> Getstudents() => _repo.GetAllAsync();

        public Task<Student?> Getstudent(int id) => _repo.GetByIdAsync(id);
    }
}

