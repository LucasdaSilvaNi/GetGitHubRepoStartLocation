using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GetGitHubRepoStartLocation.Data
{
    public class APIConnection
    {
        private HttpClient client;
        private string uri = "https://api.github.com/";
        private string apiHeaderVersion = "2022-11-28";

        public APIConnection(string bearer)
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri(uri);
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", apiHeaderVersion);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("LucasDaSilvaNi", "GetGitHubRepoStartLocation")); // set your own values here
        }

        public async Task<bool> checkConnection()
        {
            var response = await client.GetAsync("");
            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> GetUserDataResponse(string userName)
        {
            return await client.GetAsync($"/users/{userName}");
        }

        public async Task<HttpResponseMessage> GetUserRepositoriesDataResponse(string userName, int page = 1, int perpage = 30)
        {
            return await client.GetAsync($"/users/{userName}/repos?page={page}&per_page={perpage}&sort=updated");
        }

        public async Task<HttpResponseMessage> GetRepositoryDataResponse(string userName, string repositoryName)
        {
            return await client.GetAsync($"/repos/{userName}/{repositoryName}");
        }

        public async Task<HttpResponseMessage> GetRepositoryCommitsDataResponse(string userName, string repositoryName, int page = 1, int per_page = 100)
        {
            return await client.GetAsync($"/repos/{userName}/{repositoryName}/commits?page={page}&per_page={per_page}");
        }
    }
}
