using WebApi_Jayasri.Interfaces;

namespace WebApi_Jayasri.Services
{
    public class TransientGuidService: ITransientGuidService
    {
        private readonly string _guid;

        public TransientGuidService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string GetGuid() => _guid;
    }
}
