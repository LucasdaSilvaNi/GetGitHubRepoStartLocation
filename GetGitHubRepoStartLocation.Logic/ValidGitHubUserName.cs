namespace GetGitHubRepoStartLocation.Logic
{
    public class ValidGitHubUserName
    {
        string userName { get; set; }

        public bool IsValid { get; set; }

        public ValidGitHubUserName(string _userName)
        {
            userName = _userName;
            IsValid = ValidUserName();
        }

        private bool ValidUserName()
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
                return false;

            if (userName.Length > 39)
                return false;

            if (userName.StartsWith("-") || userName.EndsWith("-") || userName.Contains("--"))
                return false;

            for (int i = 0; i < userName.Length; i++)
            {
                if (!char.IsLetterOrDigit(userName[i]) && userName[i] != '-')
                    return false;
            }

            return true;
        }
    }
}
