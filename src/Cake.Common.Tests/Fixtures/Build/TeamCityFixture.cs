using Cake.Common.Build.TeamCity;
using Cake.Core;
using NSubstitute;

namespace Cake.Common.Tests.Fixtures.Build
{
    internal sealed class TeamCityFixture
    {
        public ICakeEnvironment Environment { get; set; }

        public TeamCityFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            Environment.WorkingDirectory.Returns("C:\\build\\CAKE-CAKE-JOB1");
            Environment.GetEnvironmentVariable("TEAMCITY_VERSION").Returns((string)null);
        }

        public void IsRunningOnTeamCity()
        {
            Environment.GetEnvironmentVariable("TEAMCITY_VERSION").Returns("9.1.6");
        }

        public TeamCityProvider CreateTeamCityService()
        {
            return new TeamCityProvider(Environment);
        }
    }
}