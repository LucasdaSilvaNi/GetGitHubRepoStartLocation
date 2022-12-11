using System;

namespace GetGitHubRepoStartLocation.Models
{
    public class CommitsInfoDTO
    {
        public string sha { get; set; }

        public CommitInfoDTO commit { get; set; }

        public CommitAuthorGitHubInfoDTO author { get; set; }
    }

    public class CommitInfoDTO
    {
        public string message { get; set; }

        public CommitAuthorInfoDTO author { get; set; }
        public CommitAuthorInfoDTO committer { get; set; }
    }

    public class CommitAuthorInfoDTO
    {
        public string name { get; set; }

        public DateTime date { get; set; }
    }

    public class CommitAuthorGitHubInfoDTO
    {
        public string login { get; set; }
    }
}