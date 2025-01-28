# ConsultaPersistenciaDadosDengue-ASP.NETCoreMVC

Visão Geral
O projeto ConsultaPersistenciaDadosDengue é uma aplicação ASP.NET MVC que permite consultar e persistir dados relacionados aos casos de dengue. A aplicação fornece uma interface web para visualizar e atualizar esses dados, oferecendo uma visão geral dos casos registrados nos últimos meses.

Estrutura do Projeto
A estrutura do projeto é organizada da seguinte maneira:

Controllers: Contém os controladores da aplicação, responsáveis por lidar com as requisições HTTP e retornar as respostas apropriadas.

Data: Inclui o contexto do Entity Framework Core, que gerencia as interações com o banco de dados.

Models: Contém os modelos de dados que representam a estrutura dos dados no banco.

Services: Inclui as interfaces e implementações dos serviços que contêm a lógica de negócios da aplicação.

Views: Contém as views (páginas) da aplicação, que são renderizadas para o usuário final.

Configuração
Pré-requisitos
Para rodar este projeto, você precisará ter instalado o .NET SDK (versão 8.0 ou superior), MySQL Server e uma IDE, como Visual Studio ou Visual Studio Code, que é opcional, mas recomendada para desenvolvimento.

Configuração do Banco de Dados
Criar o Banco de Dados: Crie um banco de dados MySQL com o nome DadosDengueDB.

Configurar a Conexão: Configure a cadeia de conexão no arquivo appsettings.jsoncom as credenciais do seu banco de dados MySQL.

Como Rodar o Projeto
Clonar o Repositório: Clone o repositório do projeto para a sua máquina local.

Navegar até o Diretório do Projeto: Navegue até o diretório do projeto onde os arquivos estão localizados.

Restaurar Dependências: Restaure as dependências do projeto utilizando o comando dotnet restore.

Atualizar o Banco de Dados: Atualize o banco de dados para a última versão do esquema utilizando o comando dotnet ef database update.

Executar o Projeto: Execute o projeto utilizando o comando dotnet run.

Testes
Executar Testes Unitários
Para executar os testes unitários, utilize o comando apropriado na raiz do diretório do projeto. Primeiro, execute os testes utilizando o comando dotnet test.
