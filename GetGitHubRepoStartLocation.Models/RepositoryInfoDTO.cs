namespace GetGitHubRepoStartLocation.Models
{
    public class RepositoryInfoDTO
    {
        public long id { get; set; }

        public bool fork { get; set; }

        public string name { get; set; }

        public string full_name { get; set; }

        public int size { get; set; }

        public UserInfoDTO owner { get; set; }
    }
}
