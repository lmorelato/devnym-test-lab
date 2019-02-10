using System;

namespace NyTO.Library.Code
{
    // Interface
    public interface IAppDateTime
    {
        DateTime GetDateTime();
    }

    // Implementation
    public class AppDateTime : IAppDateTime
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
