using GetGitHubRepoStartLocation.Data;
using GetGitHubRepoStartLocation.Models;
using System.Collections.Generic;

namespace GetGitHubRepoStartLocation.Logic
{
    public class ReturnAllUserRepositories
    {

        APIRepository repository { get; set; }

        public ReturnAllUserRepositories(APIRepository _repository)
        {
            repository = _repository;
        }

        public IList<RepositoryInfoDTO> searchByName(string userName)
        {
            var user = repository.GetUser(userName);

            if (user.public_repos == 0)
                return new List<RepositoryInfoDTO>();

            int quantityLoop = user.public_repos / 100;

            if (user.public_repos % 100 > 0)
                quantityLoop += 1;

            List <RepositoryInfoDTO> result = new List<RepositoryInfoDTO>();

            for (int i = 1; i <= quantityLoop; i++)
            {
                result.AddRange(repository.GetUserRepositories(userName, i, 100));
            }

            return result;
        }
    }
}
