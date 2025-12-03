using WebApi_Jayasri.Interfaces;

namespace WebApi_Jayasri.Services
{
    public class ScopedGuidService: IScopedGuidService
    {
        private readonly string _guid;

        public ScopedGuidService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string GetGuid() => _guid;
    }
}

