using GetGitHubRepoStartLocation.Logic;
using GetGitHubRepoStartLocation.Models;
using System.IO;

namespace GetGitHubRepoStartLocation.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(@"C:/GitHubReposList"))
                Directory.CreateDirectory(@"C:/GitHubReposList");

			string token = "";

            CompleteSearch search = new CompleteSearch("erinaldo", token);

            string fileCompleteName = "C:/GitHubReposList/CreatedFromLocalRepositoryFirst.txt";

            FileStream stream = File.Create(fileCompleteName);

            var resultList = search.WithStartLocally();

            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (RepositoryInfoDTO item in resultList)
                {
                    writer.WriteLine(item.full_name);
                }
            }

            fileCompleteName = "C:/GitHubReposList/CreatedRemoteRepositoryFirst.txt";

            stream = File.Create(fileCompleteName);

            resultList = search.WithStartRemotely();

            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (RepositoryInfoDTO item in resultList)
                {
                    writer.WriteLine(item.full_name);
                }
            }
        }
    }
}
