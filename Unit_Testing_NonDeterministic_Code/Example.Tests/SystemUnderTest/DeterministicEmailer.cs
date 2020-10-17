using System;

namespace Example.Tests.SystemUnderTest {
    public interface IDateTimeProvider {
        public Boolean IsTodayDayOfWeek(DayOfWeek today);
    }
    
    public class DateTimeProvider : IDateTimeProvider {
        public Boolean IsTodayDayOfWeek(DayOfWeek today) 
            => DateTime.Now.DayOfWeek == today;
    }

    /// <summary>
    /// We can easily unit test the methods in this class
    /// that depend on the otherwise non-deterministic system clock
    /// because we invert control of the provider of this behavior
    /// to an outer scope - where this class is instantiated.
    /// </summary>
    public class DeterministicEmailer {
        private readonly IDateTimeProvider _dateTimeProvider;

        public DeterministicEmailer(IDateTimeProvider dateTimeProvider) {
            _dateTimeProvider = dateTimeProvider;
        }
        
        public string TryBuildEmail(DayOfWeek startDay) {
            return _dateTimeProvider.IsTodayDayOfWeek(startDay)
                ? "Weekly Recap" 
                : "Normal Email";
        }
    }
}