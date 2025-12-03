using WebApi_Jayasri.Interfaces;

namespace WebApi_Jayasri.Services
{
    public class SingletonGuidService : ISingletonGuidService
    {
        private readonly string _guid;

        public SingletonGuidService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string GetGuid() => _guid;
    }
}
