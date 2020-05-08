using Rocchini.Common.Commands.Interfaces;

namespace Rocchini.Common.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string  Email { get; set; }
        public string Password { get; set; }
    }
}
