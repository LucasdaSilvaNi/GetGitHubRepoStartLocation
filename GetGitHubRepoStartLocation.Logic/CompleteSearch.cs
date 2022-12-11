using GetGitHubRepoStartLocation.Data;
using GetGitHubRepoStartLocation.Models;
using System.Collections.Generic;
using System.Linq;

namespace GetGitHubRepoStartLocation.Logic
{
    public class CompleteSearch
    {
        string userName { get; set; }
        APIRepository apiRepository { get; set; }
        ReturnAllUserRepositories returnAllUserRepositories { get; set; }
        ReturnAllRepositoryCommits returnAllRepositoryCommits { get; set; }

        public CompleteSearch(string _userName, string bearerToken)
        {
            apiRepository = new APIRepository(new APIConnection(bearerToken));
            returnAllUserRepositories = new ReturnAllUserRepositories(apiRepository);
            returnAllRepositoryCommits = new ReturnAllRepositoryCommits(apiRepository);
            userName = _userName;
        }

        public List<RepositoryInfoDTO> WithStartLocally()
        {
            return GetResultList(GetAllUserRepositories(), false);
        }

        public List<RepositoryInfoDTO> WithStartRemotely()
        {
            return GetResultList(GetAllUserRepositories(), true);
        }

        private List<RepositoryInfoDTO> GetAllUserRepositories()
        {
            return returnAllUserRepositories.searchByName(userName).ToList();
        }

        private List<RepositoryInfoDTO> GetResultList(List<RepositoryInfoDTO> repositories, bool withAuthor)
        {
            List<RepositoryInfoDTO> result = new List<RepositoryInfoDTO>();

            if (repositories.Count == 0)
                return result;

            CommitsInfoDTO firstCommit;
            bool commitUploadedViaGithubApp = false;

            foreach (RepositoryInfoDTO githubRepository in repositories)
            {                
                firstCommit = ReturnRepositoryFirstCommitExceptDefaultInitialCommit(userName, githubRepository);

                if (firstCommit != null)
                {
                    commitUploadedViaGithubApp = (firstCommit.commit.committer.name == "GitHub" && firstCommit.commit.message == "Add files via upload");
                
                    if (((firstCommit.author == null || commitUploadedViaGithubApp) && !withAuthor) || (firstCommit.author != null && withAuthor))
                        result.Add(githubRepository);
                }

            }

            return result;
        }

        private CommitsInfoDTO ReturnRepositoryFirstCommitExceptDefaultInitialCommit(string userName, RepositoryInfoDTO githubRepository)
        {
            List<CommitsInfoDTO> commits = returnAllRepositoryCommits.searchByName(userName, githubRepository.name).ToList();

            if (commits.Count == 0)
                return null;

            commits = commits.OrderBy(c => c.commit.author.date).ToList();

            if (commits[0].commit.committer.name == "GitHub" && commits[0].commit.message == "Initial commit")
                commits.RemoveAt(0);

            if (commits.Count == 0)
                return null;

            return commits.First();
        }

    }
}
