using System.Threading.Tasks;
using Rizk.Api.Data;
using Rizk.Api.Models;

namespace Rizk.Api.Services;

public class ProposalService : IProposalService
{
    private readonly ApplicationDbContext _context;

    public ProposalService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SubmitProposalAsync(Proposal proposal)
    {
        if (proposal == null)
            return false;

        _context.Proposals.Add(proposal);

        return await _context.SaveChangesAsync() > 0;
    }
}
