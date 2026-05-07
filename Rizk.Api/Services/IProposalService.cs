using System.Threading.Tasks;
using Rizk.Api.Models;

namespace Rizk.Api.Services;

public interface IProposalService
{
    Task<bool> SubmitProposalAsync(Proposal proposal);
}
