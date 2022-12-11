using System;

namespace GetGitHubRepoStartLocation.Models
{
    public class UserInfoDTO
    {
        public string login { get; set; }

        public int public_repos { get; set; }

        public DateTime created_at { get; set; }
    }
}