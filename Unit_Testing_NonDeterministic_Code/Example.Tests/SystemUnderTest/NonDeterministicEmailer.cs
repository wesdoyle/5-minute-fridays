using System;

namespace Example.Tests.SystemUnderTest {
    /// <summary>
    /// Cannot easily deterministically unit test, as we depend on
    /// a state of the world we don't easily control - in this case,
    /// the system clock.
    /// </summary>
    public class NonDeterministicEmailer {
        public string TryBuildEmail(DayOfWeek startDay) {
            return DateTime.Now.DayOfWeek == startDay 
                ? "Weekly Recap" 
                : "Normal Email";
        }
    }
}