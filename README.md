<h1>Cadastro de Clientes TGS</h1> 


### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Solicitação do Cliente](#solicitação-do-cliente)

:small_blue_diamond: [Funcionalidades](#funcionalidades)

:small_blue_diamond: [Pré-requisitos](#pré-requisitos)

:small_blue_diamond: [Tecnologias implementadas](#tecnologias-implementadas)

:small_blue_diamond: [Bibliotecas](#bibliotecas)

:small_blue_diamond: [Segurança](#segurança)


## Descrição do projeto 

<p align="justify">
  Projeto de API para controle de Clientes com interface para uso e autenticação. 
</p>

## Solicitação do Cliente

<ul>
  <li>Deve ser possível criar, atualizar, visualizar e remover Cliente.</span></li>
  <ul>
    <li><span>O cadastro dos clientes deve conter apenas os seguintes campos:</span></li>
    <li><span>Nome</span></li>
    <li><span>e-mail</span></li>
    <li><span>Logotipo;</span></li>
    <li><span>Logradouro, Um cliente pode conter vários logradouros</span></li>
    <li><span>Um cliente não pode se registrar duas vezes com o mesmo endereço de e-mail</span></li>
    <li><span>Deve ser possível criar, atualizar, visualizar e remover os logradouros</span></li>
	<li><span>O acesso à API deve ser aberto ao mundo, porém deve possuir autenticação e autorização</span></li>
	<li><span>A API terá um grande volume de requisições então tenha em mente que a preocupação com performance é algo que temos constantemente preocupação</span></li>
  </ul>
</ul>

## Funcionalidades

:heavy_check_mark: Cadastro de Clientes: É possível realizar cadastros de clientes, para cada cliente cadastrado ira gerar um usuário para manutenção dos dados.

:heavy_check_mark: Cadastro de Logradouros: É possível realizar cadastros de logradouros para um determinado cliente.

:heavy_check_mark: Autenticação: É possível se autenticar na API e alterar senha depois de autenticado.

## Pré-requisitos

Caso for rodar o projeto localmente
<ul>
  <li>:warning: .NET Core SDK 8.0</li>
  <li>:warning: SQL SERVER</li>
  <li>:warning: Visual Studio 2022 ou VS Code</li>
   <li>:warning: Azure Data Studio</li>
  </ul>

## Como rodar a aplicação :arrow_forward:

Abra um terminal e clone o projeto: 

git clone https://github.com/artpinho/desafiothomasgreg.git


<b>Configurar o banco de dados</b>
<ul>
    <li>Abra o Azure Data Studio.</li>
    <li>No painel lateral esquerdo, clique em "Extensions" (Extensões).</li>
    <li>Pesquise por "SQL Server" na barra de pesquisa.</li>
    <li>Encontre a extensão "SQL Server (mssql)" e clique em "Install" (Instalar).</li>
    <li>Conecte-se ao seu servidor SQL Server, se ainda não estiver conectado.</li>
    <li>No painel de navegação à esquerda, clique com o botão direito no banco de dados de destino.</li>
    <li>Escolha a opção para importar um banco de dados</li>
    <li>Especifique o arquivo DB_SistemaClientes.bacpac dentro da pasta do projeto.</li>
    <li>Configure as opções de importação, como o nome do banco de dados de destino.</li>
</ul>
<b>Configurar a conexão com o banco</b>
<ul>
  <li>Dentro do diretório do projeto vá até a pasta ..\Cadastro\abra o arquivo appsettings.json</li>
  <li>Configure a connectionString na sua IDE</li>
  <li>Certifique-se de que a DefaultConnection está configurada. Ex: "Server=10.0.0.1,5555;Database=DB_Database;User ID=Usuario;Password=Senha;TrustServerCertificate=True"</li>
</ul>

<b>Rodar o projeto</b>
<ul>
  <li>Abra um terminal e navegue até a pasta ..\Cadastro\</li>
  <li>Fazer restore do nugget executando o comando dotnet restore</li>
  <li>Fazer a execução do projeto com o comando dotnet run</li>
  <li>Será feito a compilação da API, no final será exibido à URL para abrir a API</li>
  <li>No navegador acesse http://localhost:5067</li>
  <li>Realize o login com os dados de acesso admin@desafio.com *Admin123*</li>
  <li>Para acesso ao Swagger utilize http://localhost:5067/swagger/index.html ou https://localhost:7117/swagger/index.html</li>
</ul>

## Resumo
<ul>
<li>O usuário pode realizar o login através de email e senha para acesso ao cadastro de clientes.</li>
<li>É necessário estar autenticado com usuário do sistema para acesso as páginas de cadastro de clientes e endereços</li>
<li>Na página Clientes é possível visualizar os clientes cadastrados com informações como nome, Email, se possui logotipo e botões de ação rápido para adicionar, ver detalhes, alterar ou apagar cadastro.</li>
<li>Na página de Endereços é possível visualizar a lista de endereços cadastrados com a informação de quem o endereço está associado. Ao adicionar um novo endereço é necessário informar qual cliente estará recebendo a informação, desta forma um cliente poderá ter vários endereços.</li>
<li>Na página de gerenciamento da conta é possível alterar o e-mail e senha, adicionar um telefone, baixar suas informações pessoais, apagar a conta e habilitar autenticação em 2 fatores.</li>
</ul>

## Tecnologias implementadas
<ul>
<li>ASP.NET Core 8.0</li>
<li>ASP.NET WebApi Core</li>
<li>Entity Framework</li>
<li>Identity</li>
<li>SQL Server</li>
<li>Swagger UI</li>
<li>JWT Token</li>
</ul>

## Segurança
<ul>
  <li>Tokens de autorização com JWT Bearer</li>
</ul>

## Bibliotecas

<li>ASP.NET Core: Framework web usado para construir o backend da aplicação.</li>
<li>Entity Framework Core: ORM (Object-Relational Mapper) usado para mapear objetos de domínio para o banco de dados.</li>
<li>Microsoft.EntityFrameworkCore.SqlServer: Provedor de banco de dados SQL Server para o Entity Framework Core.</li>
<li>Microsoft.EntityFrameworkCore.Design: Ferramentas para design e migração de banco de dados com Entity Framework Core.</li>
<li>Microsoft.EntityFrameworkCore.Tools: Conjunto de ferramentas para desenvolvimento e migração de banco de dados com Entity Framework Core.</li>
<li>Microsoft.VisualStudio.Web.CodeGeneration.Design: Biblioteca de geração de código para ASP.NET Core.</li>
<li>Swashbuckle.AspNetCore (Swagger): Biblioteca para documentação e teste de APIs usando o Swagger.</li>
<li>System.IdentityModel.Tokens.Jwt: Biblioteca para geração e validação de tokens JWT (JSON Web Tokens) no ASP.NET Core.</li>
<li>Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore: Biblioteca para diagnósticos e manuseio de erros com Entity Framework Core no ASP.NET Core.</li>
<li>Microsoft.AspNetCore.Identity.UI: Interface de usuário e funcionalidades para ASP.NET Core Identity.</li>

## Licença 

Copyright :copyright: 2024 - Cadastro de Clientes TGS - Artenir Pinho
