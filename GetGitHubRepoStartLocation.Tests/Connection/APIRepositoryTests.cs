using GetGitHubRepoStartLocation.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GetGitHubRepoStartLocation.Tests.Connection
{
    public class APIRepositoryTests : BaseTest
    {
        [Test]
        public void ReturnValidUsers()
        {
            UserInfoDTO user = repository.GetUser(validUserName);

            Assert.IsTrue(user != null);
            Assert.IsTrue(user.login == validUserName);
        }

        [Test]
        public void ReturnInvalidUsers()
        {
            UserInfoDTO user = repository.GetUser("Lucas da Silva");

            Assert.IsFalse(user != null);
        }

        [Test]
        public void ReturnValidRepository()
        {
            RepositoryInfoDTO repo = repository.GetRepository(validUserName, validRepositoryName);

            Assert.IsTrue(repo != null);
            Assert.IsTrue(repo.id >= 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(repo.full_name));
            Assert.IsTrue(repo.owner.login == validUserName);
        }

        [Test]
        public void ReturnInvalidRepository()
        {
            RepositoryInfoDTO repo = repository.GetRepository(validUserName, "--Teste");

            Assert.IsFalse(repo != null);

            repo = repository.GetRepository("Lucas da Silva", validRepositoryName);

            Assert.IsFalse(repo != null);
        }

        [Test]
        public void ReturnRepositoryCommits()
        {
            List<CommitsInfoDTO> commits = repository.GetRepositoryCommits(validUserName, validRepositoryName).ToList();

            Assert.IsTrue(commits != null);
            Assert.IsTrue(commits.Count > 0);

            List<CommitsInfoDTO> commitsWithoutSha = commits.Where(c => string.IsNullOrEmpty(c.sha)).ToList();

            Assert.IsFalse(commitsWithoutSha.Count > 0);

            List<string> listDistinctShas = commits.Select(c => c.sha).Distinct().ToList();

            Assert.IsTrue(listDistinctShas.Count == commits.Count);
        }

        [Test]
        public void ReturnNoCommits()
        {
            IList<CommitsInfoDTO> commits = repository.GetRepositoryCommits(validUserName, validRepositoryNameWithoutCommits);

            Assert.IsFalse(commits != null);
        }
    }
}
