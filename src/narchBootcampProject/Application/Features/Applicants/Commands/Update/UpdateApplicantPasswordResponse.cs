using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Applicants.Commands.Update;

public class UpdateApplicantPasswordResponse : IResponse
{
    public Guid Id { get; set; }
    public AccessToken AccessToken { get; set; }

    public UpdateApplicantPasswordResponse() { }

    public UpdateApplicantPasswordResponse(Guid id, AccessToken accessToken)
    {
        Id = id;
        AccessToken = accessToken;
    }
}
