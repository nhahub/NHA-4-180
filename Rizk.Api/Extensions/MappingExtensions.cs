using Rizk.Api.Models;
using Rizk.Api.ViewModels;

namespace Rizk.Api.Extensions;

public static class MappingExtensions
{
    public static UserViewModel ToViewModel(this User user)
    {
        if (user == null) return null!;

        return new UserViewModel
        {
            Id = user.ID,
            FullName = user.FullName,
            Phone = user.Phone,
            Role = user.Role
        };
    }

    public static ProviderProfileViewModel ToViewModel(this ProviderProfile profile)
    {
        if (profile == null) return null!;

        return new ProviderProfileViewModel
        {
            Id = profile.ID,
            FullName = profile.User?.FullName ?? string.Empty,
            CategoryName = profile.Category?.Name ?? string.Empty,
            IsVerified = profile.IsVerified,
            YearsOfExperience = profile.YearsOfExperience
        };
    }

    public static ServiceRequestViewModel ToViewModel(this ServiceRequest request)
    {
        if (request == null) return null!;

        return new ServiceRequestViewModel
        {
            Id = request.ID,
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            CategoryName = request.Category?.Name ?? string.Empty,
            CustomerName = request.Customer?.FullName ?? string.Empty
        };
    }

    public static ProposalViewModel ToViewModel(this Proposal proposal)
    {
        if (proposal == null) return null!;

        return new ProposalViewModel
        {
            Id = proposal.ID,
            VisitFee = proposal.VisitFee,
            Status = proposal.Status,
            ProviderName = proposal.Provider?.FullName ?? string.Empty
        };
    }
}
