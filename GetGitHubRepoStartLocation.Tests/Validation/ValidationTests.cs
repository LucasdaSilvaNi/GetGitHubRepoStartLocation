using GetGitHubRepoStartLocation.Logic;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GetGitHubRepoStartLocation.Tests.Validation
{
    public class ValidationTests : BaseTest
    {
        [Test]
        public void ValidUserName()
        {
            List<string> userNames = new List<string> { "Lucas-1995", "Lucas1995", "-Lucas", "1995-", "Lucas 1995", "Lucas--1995", "" };

            ValidGitHubUserName validName;

            foreach (var userName in userNames)
            {
                validName = new ValidGitHubUserName(userName);

                Assert.IsFalse(string.IsNullOrEmpty(userName) && validName.IsValid);
                Assert.IsFalse(string.IsNullOrWhiteSpace(userName) && validName.IsValid);
                Assert.IsFalse(userName.Length > 39 && validName.IsValid);
                Assert.IsFalse(userName.StartsWith("-") && validName.IsValid);
                Assert.IsFalse(userName.EndsWith("-") && validName.IsValid);
                Assert.IsFalse(userName.Contains("--") && validName.IsValid);
                Assert.IsFalse(userName.Contains(" ") && validName.IsValid);
                Assert.IsFalse(userName.Any(c => !char.IsLetterOrDigit(c) && c != '-') && validName.IsValid);
            }
        }

    }
}
