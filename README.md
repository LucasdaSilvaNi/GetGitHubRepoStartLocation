# GetGitHubRepoStartLocation

This class library project search a GITHUB user's repositories list, available in GITHUB's oficial API, e filter them by how these repositories were possible started (if as a local or remote repository)*, based on their first commit.

*(In this project context: It's considering the repository started as local when possibly the first commit (excluding GITHUB's default commit "Initial Commit") were made before cloning the remote repository or added the URL manually in "git remote add" command. Other than that, it's considering the repository started as remote.)

The console project is for demonstration purpose.

It's was created for training the test driven development (TDD).

In case you want upgrade, warn something, or fix some unexpect behaviour of project, you can feel free to open a pull request or issue to this repository! ;-)

------------------------------

Esse projeto class library busca a lista de repositórios de um usuário do GITHUB, disponíveis na API do próprio GITHUB, e filtra conforme sua possível origem (se começou como repositório local, ou como repositório remoto)*, com base no primeiro commit.

*(Para contextualizar: O começo do repositório é considerado local quando possivelmente o primeiro commit (com exceção do commit padrão do GITHUB "Initial Commit") ocorreu antes de clonar o repositório remoto ou antes de adicionar a URL com comando "git remote add". Caso contrário, é considerado como início remoto).

O projeto Console serve para demonstração.

Foi criado com propósito para treinar o desenvolvimento de sistemas orientado a testes (test driven development, o TDD).

Caso deseje aprimorar, alertar sobre algo ou corrigir algum comportamento inesperado do projeto, pode ficar a vontade em abrir um pull request ou uma issue para esse respositório! ;-)
