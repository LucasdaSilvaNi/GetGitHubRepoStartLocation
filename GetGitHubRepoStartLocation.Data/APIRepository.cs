using GetGitHubRepoStartLocation.Models;
using System.Collections.Generic;

namespace GetGitHubRepoStartLocation.Data
{
    public class APIRepository
    {
        APIConnection connection { get; set; }

        ResponseContentParser parser { get; set; }
        
        public APIRepository(APIConnection _connection)
        {
            connection = _connection;
            parser = new ResponseContentParser();
        }

        public UserInfoDTO GetUser(string userName)
        {
            var result = connection.GetUserDataResponse(userName).Result;

            if (!result.IsSuccessStatusCode)
                return null;

            return parser.ParseUserInfo(result.Content).Result;
        }

        public IList<RepositoryInfoDTO> GetUserRepositories(string userName, int page = 1, int perpage = 30)
        {
            var result = connection.GetUserRepositoriesDataResponse(userName, page, perpage).Result;

            if (!result.IsSuccessStatusCode)
                return null;

            return parser.ParseRepositoryInfoList(result.Content).Result;
        }

        public RepositoryInfoDTO GetRepository(string userName, string repositoryName)
        {
            var result = connection.GetRepositoryDataResponse(userName, repositoryName).Result;

            if (!result.IsSuccessStatusCode)
                return null;

            return parser.ParseRepositoryInfo(result.Content).Result;
        }

        public IList<CommitsInfoDTO> GetRepositoryCommits(string userName, string repositoryName, int page = 1, int per_page = 100)
        {
            var result = connection.GetRepositoryCommitsDataResponse(userName, repositoryName, page, per_page).Result;

            if (!result.IsSuccessStatusCode)
                return null;

            return parser.ParseCommitsInfoList(result.Content).Result;
        }

    }
}
