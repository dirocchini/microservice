using Rocchini.Common.Events.Interfaces;

namespace Rocchini.Common.Events
{
    public class UserAuthenticated : IEvent
    {
        public string  Email { get; }

        protected UserAuthenticated()
        {

        }
        
        public UserAuthenticated(string email)
        {
            Email = email;
        }
    }
}
