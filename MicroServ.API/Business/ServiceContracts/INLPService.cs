using System.Threading.Tasks;

namespace MicroServ.API.Business.ServiceContracts
{
    public interface INLPService
    {
         Task<string> GetDepartment(string input);
    }
}