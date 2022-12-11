using GetGitHubRepoStartLocation.Logic;
using GetGitHubRepoStartLocation.Models;
using NUnit.Framework;
using System.Linq;

namespace GetGitHubRepoStartLocation.Tests
{
    public class LogicTests : BaseTest
    {
        [Test]
        public void ReturnAllUserRepositories()
        {
            var user = repository.GetUser(validUserName);

            var repositories = returnAllUsersRepo.searchByName(validUserName);

            var listDistinctId = repositories.Select(r => r.id).Distinct().ToList();

            var anyFromOtherUser = repositories.Where(r => r.owner.login != validUserName).Any();

            Assert.IsTrue(user.public_repos == repositories.Count);
            Assert.IsTrue(listDistinctId.Count == repositories.Count);
            Assert.IsFalse(anyFromOtherUser);

        }

        [Test]
        public void ReturnNoUserRepositories()
        {
            var repositories = returnAllUsersRepo.searchByName(validUserNameWithoutRepository);

            Assert.IsTrue(repositories.Count == 0);
        }

        [Test]
        public void ReturnAllRepositoriesCommit()
        {
            var commits = returnAllRepoCommits.searchByName(validUserName, validRepositoryName);

            var distinctShas = commits.Select(c => c.sha).Distinct().ToList();

            var anyWithouCommitObject = commits.Where(c => c.commit == null).Any();

            Assert.IsTrue(commits != null);
            Assert.IsTrue(commits.Count > 0);
            Assert.IsTrue(commits.Count == distinctShas.Count);
            Assert.IsFalse(anyWithouCommitObject);

        }

        [Test]
        public void ReturnNoRepositoriesCommit()
        {
            var commits = returnAllRepoCommits.searchByName(validUserName, validRepositoryNameWithoutCommits);

            Assert.IsTrue(commits != null);
            Assert.IsFalse(commits.Count > 0);
        }

        [Test]
        public void ReturnRepositoryLocallyStarted()
        {
            CompleteSearch searcher = new CompleteSearch(validUserName, bearerToken);

            var repositories = searcher.WithStartLocally();

            Assert.IsFalse(repositories == null);
            Assert.IsFalse(repositories.Count == 0);
            Assert.IsTrue(repositories.Where(r => r.name.ToLower() == validRepositoryNameLocallyStarted.ToLower()).Any());
            Assert.IsFalse(repositories.Where(r => r.name.ToLower() == validRepositoryNameRemotelyStarted.ToLower()).Any());
        }

        [Test]
        public void ReturnRepositoryRemotelyStarted()
        {
            CompleteSearch searcher = new CompleteSearch(validUserName, bearerToken);

            var repositories = searcher.WithStartRemotely();

            Assert.IsFalse(repositories == null);
            Assert.IsFalse(repositories.Count == 0);
            Assert.IsFalse(repositories.Where(r => r.name.ToLower() == validRepositoryNameLocallyStarted.ToLower()).Any());
            Assert.IsTrue(repositories.Where(r => r.name.ToLower() == validRepositoryNameRemotelyStarted.ToLower()).Any());
        }

        [Test]
        public void ReturnRepositoryLocallyStartedEvenWithInitialCommit()
        {
            CompleteSearch searcher = new CompleteSearch(validUserName, bearerToken);

            var repositoriesLocaly = searcher.WithStartLocally();

            Assert.IsFalse(repositoriesLocaly == null);
            Assert.IsFalse(repositoriesLocaly.Count == 0);
            Assert.IsTrue(repositoriesLocaly.Where(r => r.name.ToLower() == validRepositoryNameLocallyStartedWithInitialCommit.ToLower()).Any());
        }

        [Test]
        public void ReturnRepositoryLocallyStartedWithAddFilesViaUploadCommit()
        {
            CompleteSearch searcher = new CompleteSearch(validUserName, bearerToken);

            var repositories = searcher.WithStartLocally();

            Assert.IsFalse(repositories == null);
            Assert.IsFalse(repositories.Count == 0);
            Assert.IsTrue(repositories.Where(r => r.name.ToLower() == validRepositoryNameLocallyStartedWithAddFilesViaUploadCommit.ToLower()).Any());
        }
    }
}
