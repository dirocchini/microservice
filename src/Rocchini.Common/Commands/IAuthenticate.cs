using System;
using System.Collections.Generic;
using System.Text;

namespace Rocchini.Common.Commands
{
    public interface IAuthenticate : ICommand
    {
        Guid UserId { get; set; }
    }
}
