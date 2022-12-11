using GetGitHubRepoStartLocation.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetGitHubRepoStartLocation.Data
{
    public class ResponseContentParser
    {
        public async Task<UserInfoDTO> ParseUserInfo(HttpContent content)
        {
            if (content == null)
                return null;

            return JsonSerializer.Deserialize<UserInfoDTO>(await content.ReadAsStringAsync());
        }

        public async Task<RepositoryInfoDTO> ParseRepositoryInfo(HttpContent content)
        {
            if (content == null)
                return null;

            return JsonSerializer.Deserialize<RepositoryInfoDTO>(await content.ReadAsStringAsync());
        }

        public async Task<IList<RepositoryInfoDTO>> ParseRepositoryInfoList(HttpContent content)
        {
            if (content == null)
                return null;

            return JsonSerializer.Deserialize<List<RepositoryInfoDTO>>(await content.ReadAsStringAsync());
        }

        public async Task<IList<CommitsInfoDTO>> ParseCommitsInfoList(HttpContent content)
        {
            if (content == null)
                return null;

            return JsonSerializer.Deserialize<List<CommitsInfoDTO>>(await content.ReadAsStringAsync());
        }

    }
}
