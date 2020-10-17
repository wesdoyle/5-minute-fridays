using System;
using Example.Tests.SystemUnderTest;
using FluentAssertions;
using Moq;
using Xunit;

namespace Example.Tests {
    public class TestTimeDependency {
        
        /// <summary>
        /// This test is non-deterministic!
        /// Due to tight coupling of the class under test to factors
        /// outside of our direct control (the system clock), this test
        /// will pass or fail depending on the day of week the test is run.
        /// </summary>
        [Fact]
        public void TryBuildWeeklyEmail_Given_TodayIsDayOfWeek_Returns_WeeklyEmail() {
            // Arrange
            var sut = new NonDeterministicEmailer();
            
            // Act
            var result = sut.TryBuildEmail(DayOfWeek.Thursday);
            
            // Assert
            result.Should().Be("Weekly Recap");
        }
        
        /// <summary>
        /// We _can_ unit test the deterministic class by inverting control
        /// from the system under test to the outer scope that encloses it!
        /// Note that we don't need to use a heavyweight mocking framework,
        /// as is done here - we could also write any implementation of an
        /// IDateTimeProvider we like and control the output of IsTodayDayOfWeek
        /// to emulate the specific cases of otherwise non-deterministic
        /// behavior to suit our specific use cases under test.
        /// However, Moq makes this type of setup very easy.
        /// </summary>
        [Fact]
        public void TryBuildWeeklyEmail_Given_IsTodayDayOfWeek_Returns_WeeklyEmail() {
            // Arrange
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            
            dateTimeProvider
                .Setup(provider 
                    => provider.IsTodayDayOfWeek(It.IsAny<DayOfWeek>()))
                .Returns(true);
            
            // IoC via Constructor Injection
            var sut = new DeterministicEmailer(dateTimeProvider.Object);
            
            // Act
            var result = sut.TryBuildEmail(DayOfWeek.Thursday);
            
            // Assert
            result.Should().Be("Weekly Recap");
        }
        
        [Fact]
        public void TryBuildWeeklyEmail_Given_Not_IsTodayDayOfWeek_Returns_NormalEmail() {
            // Arrange
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            
            dateTimeProvider
                .Setup(provider 
                    => provider.IsTodayDayOfWeek(It.IsAny<DayOfWeek>()))
                .Returns(false);
            
            // IoC via Constructor Injection
            var sut = new DeterministicEmailer(dateTimeProvider.Object);
            
            // Act
            var result = sut.TryBuildEmail(DayOfWeek.Thursday);
            
            // Assert 
            result.Should().Be("Normal Email");
        }
    }
}
