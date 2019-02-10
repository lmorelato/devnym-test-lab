using System;

namespace NyTO.Library.Code
{
    /// <summary>
    /// In this approach I created an interface to provide the current DateTime object. It would be
    /// acceptable under the scenario when we can change the legacy class. Otherwise, we can use some
    /// pattern to encapsulate the current context to provide a fake DateTime object (this case won't
    /// be detailed in this example e.g. https://github.com/tonerdo/pose).
    /// </summary>
    public class LegacyClass
    {
        private readonly IAppDateTime _appDateTime;

        public LegacyClass(IAppDateTime appDateTime)
        {
            _appDateTime = appDateTime;
        }

        /// <summary>
        /// Simple method to simulate a legacy method
        /// </summary>
        public void CheckDate()
        {
            // lets make sure we have the current time
            var now = _appDateTime?.GetDateTime() ?? DateTime.Now;

            if (now.DayOfWeek == DayOfWeek.Saturday)
                throw new Exception("Saturday!");

        }
    }
}
