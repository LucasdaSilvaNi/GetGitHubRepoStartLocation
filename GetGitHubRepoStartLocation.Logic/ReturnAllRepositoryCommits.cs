using GetGitHubRepoStartLocation.Data;
using GetGitHubRepoStartLocation.Models;
using System.Collections.Generic;
using System.Linq;

namespace GetGitHubRepoStartLocation.Logic
{
    public class ReturnAllRepositoryCommits
    {
        APIRepository repository { get; set; }

        public ReturnAllRepositoryCommits(APIRepository _repository)
        {
            repository = _repository;
        }

        public IList<CommitsInfoDTO> searchByName(string userName, string repositoryName)
        {
            bool complete = false;
            int page = 1;

            List<CommitsInfoDTO> result = new List<CommitsInfoDTO>();
            IList<CommitsInfoDTO> reponse = null;

            do
            {
                reponse = repository.GetRepositoryCommits(userName, repositoryName, page, 100);

                if (reponse == null)
                {
                    complete = true;
                    continue;
                }

                result.AddRange(reponse.ToList());

                if (result.Count != (page * 100))
                    complete = true;
                else
                    page++;

            } while (!complete);

            return result;
        }
    }
}
