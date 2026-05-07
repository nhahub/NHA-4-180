using System.Threading.Tasks;

namespace Rizk.Api.Services;

public interface IAdminService
{
    Task<bool> VerifyProviderAsync(int providerId);
}
