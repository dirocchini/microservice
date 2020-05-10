using System;

namespace Rocchini.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid UserId);
    }
}
