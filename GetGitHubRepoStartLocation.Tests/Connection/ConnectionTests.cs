using NUnit.Framework;

namespace GetGitHubRepoStartLocation.Tests.Connection
{
    public class ConnectionTests : BaseTest
    {

        [Test]
        public void CheckIfGitHubAPIISAvailable()
        {
            Assert.IsTrue(connection.checkConnection().Result);
        }

        [Test]
        public void CheckIfGitHubUserAPIISAvailable()
        {
            var response = connection.GetUserDataResponse(validUserName).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public void CheckIfGitHubRepositoryAPIISAvailable()
        {
            var response = connection.GetRepositoryDataResponse(validUserName, validRepositoryName).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public void CheckIfGitCommitsAPIISAvailable()
        {
            var response = connection.GetRepositoryCommitsDataResponse(validUserName, validRepositoryName).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
