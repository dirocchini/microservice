using System;

namespace Rocchini.Common.Commands.Interfaces
{
    public interface IAuthenticate : ICommand
    {
        Guid UserId { get; set; }
    }
}
