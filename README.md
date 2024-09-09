SUMÁRIO
INTRODUÇÃO PROJETO AEC TESTE
1.	Descrição
2.	Estrutura do Projeto
o	CursoAplication
o	AluraSearchDbContext
o	CursoItemMap
o	CursoModelDTO
o	CursoModel
o	ICursoRepository e CursoRepository
o	ICursoService e CursoService
3.	Configuração e Inicialização
o	appsettings.json
o	Program Class
4.	Diagrama
5.	Execução do Projeto
6.	Dependências
7.	Notas
Decisões Técnicas e Escolhas de Ferramentas



INTRODUÇÃO PROJETO AEC TESTE

O propósito principal deste projeto é facilitar a automação da coleta de dados de cursos e seu armazenamento em um banco de dados relacional, permitindo análises e consultas mais eficientes. A aplicação foi estruturada para garantir uma integração fluida entre a coleta de dados da web e o gerenciamento de dados, através de uma arquitetura modular que separa claramente as responsabilidades entre coleta de dados, lógica de negócios e acesso ao banco de dados
Trazendo consigo uma visão geral detalhada do projeto, incluindo a estrutura das classes, configuração e inicialização da aplicação, bem como as dependências e notas importantes para garantir a correta execução e manutenção do sistema.

1.	DESCRIÇÃO
Este projeto é uma aplicação ASP.NET Core que realiza a automação de busca e salvamento de informações sobre cursos usando Selenium WebDriver para interação com uma página da web. A aplicação utiliza Entity Framework Core para gerenciamento de dados e armazena informações em um banco de dados SQL Server.
2.	ESTRUTURA DO PROJETO
Classes e Funcionalidades
CursoAplication
•	Responsabilidade:
o	Realiza a automação de busca de cursos na web e salva as informações no banco de dados.
•	Métodos Principais:
o	BuscarCursos():
•	Navega até a página da web especificada, preenche o campo de pesquisa, realiza a busca, coleta informações sobre o curso e as salvas no banco de dados.
AluraSearchDbContext
•	Responsabilidade:
o	Contexto do banco de dados para a aplicação, gerenciando as operações de CRUD para a entidade CursoModel.
•	Propriedades:
•	Curso: DbSet para a entidade CursoModel.
•	Métodos Importantes:
•	OnModelCreating(ModelBuilder modelBuilder): Aplica a configuração do mapeamento da entidade.
CursoItemMap
•	Responsabilidade:
o	Configuração de mapeamento para a entidade CursoModel.
•	Configurações:
o	Define chaves primárias, propriedades obrigatórias e limitações de comprimento.
o	
CursoModelDTO
•	Responsabilidade:
o	Data Transfer Object (DTO) para representar os dados do curso na camada de serviço.
•	Propriedades:
o	Id, Titulo, Professor, CargaHoraria, Descricao.
CursoModel
•	Responsabilidade:
•	Entidade que representa um curso no banco de dados.
•	Propriedades:
•	Id, Titulo, Professor, CargaHoraria, Descricao.
ICursoRepository e CursoRepository
•	Responsabilidade:
o	Interface e implementação para operações de acesso ao banco de dados para a entidade CursoModel.


•	Métodos Principais:
•	SalvarCursos(CursoModel curso): Salva um curso no banco de dados e retorna a entidade salva.

ICursoService e CursoService
•	Responsabilidade:
•	Interface e implementação para a lógica de negócio relacionada a cursos.
•	Métodos Principais:
•	SalvarCursos(CursoModelDTO curso): Converte um DTO para CursoModel, salva no banco de dados e retorna a entidade salva.
3.	CONFIGURAÇÃO E INICIALIZAÇÃO
appsettings.json
•	Seções Importantes:
•	Logging: Configura os níveis de log para a aplicação.
•	ConnectionStrings: Contém a string de conexão para o banco de dados SQL Server.
•	AllowedHosts: Define quais hosts são permitidos para acessar a aplicação.

Program Class
•	Responsabilidade:
•	Configura e inicializa a aplicação ASP.NET Core.
•	Principais Tarefas:
•	Configuração de serviços e middleware.
•	Registro dos repositórios e serviços com injeção de dependências.
•	Configuração do Selenium WebDriver.
•	Execução da automação de busca de cursos antes de iniciar a aplicação.



4.	DIAGRAMA
---------------------
| Início              |
---------------------
          |
          v
---------------------
| Configuração do     |
| Ambiente            |
-----------------------
          |
          v
---------------------
| Configuração dos    |
| Serviços e DI       |
-----------------------
          |
          v
---------------------
| Inicialização do    |
| Selenium WebDriver  |
+---------------------+
          |
          v
---------------------
| Executar Automação  |
| (CursoAplication)   |
---------------------
          |
          v
-----------------------
| Navegar e Buscar    |
| Cursos              |
------------------------
          |
          v
-------------------------
| Coletar Dados e     |
| Salvar no Banco de  |
| Dados               |
---------------------------
          |
          v
------------------------
| Encerrar e Fechar   |
| WebDriver           |
-------------------------
          |
          v
------------------------
| Fim                 |
-------------------------




5.	EXECUÇÃO DO PROJETO
1.	Configuração do Banco de Dados:
•	Certifique-se de que a string de conexão no appsettings.json está correta e que o banco de dados está acessível.
2.	Execução:
•	Compile e execute o projeto. A aplicação inicializará e executará a automação de busca de cursos, salvando as informações coletadas no banco de dados.
6.	DEPENDÊNCIAS PRESENTES NO PROJETO
•	FluentAssertions (6.12.0)
•	Microsoft.AspNetCore.App
•	Microsoft.AspNetCore.Http.Abstractions (2.2.0)
•	Microsoft.EntityFrameworkCore (7.0.20)
•	Microsoft.EntityFrameworkCore.Relational (7.0.20)
•	Microsoft.EntityFrameworkCore.SqlServer (7.0.20)
•	Microsoft.EntityFrameworkCore.Tools (7.0.20)
•	Microsoft.Extensions.Hosting (8.0.0)
•	Microsoft.Graph (5.57.0)
•	MySqlConnector (2.3.7)
•	NUnit (3.13.3)
•	Selenium.Opera.WebDriver (2.30.0)
•	Selenium.Support (4.24.0)
•	Selenium.WebDriver (4.24.0)
•	Selenium.WebDriver.ChromeDriver (128.0.6613.11900)
•	SeleniumExtras.WaitHelpers (1.0.2)
•	System.Configuration.ConfigurationManager (8.0.0)
•	System.Data.SqlClient (4.8.6)


•	Selenium.WebDriver: Utilizado para a automação de navegação e coleta de dados na web.
•	EntityFrameworkCore: Para o mapeamento e gerenciamento de entidades no banco de dados.
•	FluentAssertions: Simplifica a escrita de asserts em testes, deixando o código mais legível.
•	NUnit: Framework para testes unitários e de integração.
•	System.Configuration.ConfigurationManager: Utilizado para carregar configurações da aplicação, como a string de conexão com o banco de dados.

7.	Notas
Segurança:
 As credenciais do banco de dados estão diretamente no arquivo de configuração.
Práticas de Automação
O método de automação é executado durante a inicialização da aplicação, e o WebDriver é corretamente encerrado, mesmo em caso de erro.

Decisões Técnicas e Escolhas de Ferramentas
ASP.NET Core: Escolhido pela sua robustez e flexibilidade para construir aplicações web e APIs. Oferece uma estrutura modular que facilita a configuração, escalabilidade e alta performance.
Entity Framework Core: Utilizado para gerenciar o acesso a dados com um ORM que simplifica operações CRUD e gestão das entidades. Suporta migrations para manter o esquema do banco de dados atualizado conforme o desenvolvimento.
Selenium WebDriver: Selecionado para automação da coleta de dados da web. Permite interação programática com páginas da web e extração de informações, oferecendo flexibilidade e suporte a múltiplos navegadores.
Dependências:
•	FluentAssertions: FluentAssertions proporciona uma sintaxe clara para asserts.
•	System.Configuration.ConfigurationManager: Gerencia configurações da aplicação, incluindo strings de conexão, permitindo fácil configuração para diferentes ambientes.


Estrutura do Projeto:
•	Separação de Responsabilidades: Arquitetura modular para separar a coleta de dados, lógica de negócios e acesso ao banco de dados, promovendo manutenção e escalabilidade do código.

