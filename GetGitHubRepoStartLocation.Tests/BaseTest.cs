using GetGitHubRepoStartLocation.Data;
using GetGitHubRepoStartLocation.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetGitHubRepoStartLocation.Tests
{
    public abstract class BaseTest
    {
        protected const string bearerToken = "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";

        protected const string validUserName = "erinaldo";
        protected const string validUserNameWithoutRepository = "softver";
        protected const string validRepositoryName = "ProjetoLoja";
        protected const string validRepositoryNameWithoutCommits = "Xprodutos";
        protected const string validRepositoryNameLocallyStarted = "PEDIDOS_NFE";
        protected const string validRepositoryNameRemotelyStarted = "EasyGestSC";
        protected const string validRepositoryNameLocallyStartedWithInitialCommit = "DisoftBHF_CompraFacil";
        protected const string validRepositoryNameLocallyStartedWithAddFilesViaUploadCommit = "proyecto_taller2_meza_navarro";

        protected APIConnection connection { get; set; }
        protected APIRepository repository { get; set; }
        protected ReturnAllUserRepositories returnAllUsersRepo { get; set; }
        protected ReturnAllRepositoryCommits returnAllRepoCommits { get; set; }

        [SetUp]
        public void Init()
        {
            connection = new APIConnection(bearerToken);
            repository = new APIRepository(connection);
            returnAllUsersRepo = new ReturnAllUserRepositories(repository);
            returnAllRepoCommits = new ReturnAllRepositoryCommits(repository);
        }
    }
}
