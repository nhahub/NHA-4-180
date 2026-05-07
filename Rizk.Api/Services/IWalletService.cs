using System.Threading.Tasks;

namespace Rizk.Api.Services;

public interface IWalletService
{
    Task<bool> ChargeWalletAsync(int userId, decimal amount);
}
