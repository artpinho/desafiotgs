<h1>Cadastro de Clientes TGS</h1> 

> Status do Projeto: :heavy_check_mark:

### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Solicitação do Cliente](#solicitação-do-cliente)

:small_blue_diamond: [Funcionalidades](#funcionalidades)

:small_blue_diamond: [Pré-requisitos](#pré-requisitos)

:small_blue_diamond: [Tecnologias implementadas](#tecnologias-implementadas)


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

:heavy_check_mark: Cadastro de Clientes: É possível realizar cadastros de clientes, para cada cliente cadastrado ira gerar um usuario para manutenção dos dados

:heavy_check_mark: Cadastro de Logradouros: É possível realizar cadastros de logradouros para um determinado cliente

:heavy_check_mark: Autenticação: É possível se autenticar na API e alterar senha depois de autenticado

## Pré-requisitos

Caso for rodar o projeto localmente
<ul>
  <li>:warning: .NET Core SDK 8.0</li>
  <li>:warning: SQL SERVER</li>
  <li>:warning: Visual Studio 2022 ou VS Code</li>
  </ul>

## Como rodar a aplicação :arrow_forward:

Abra um terminal e clone o projeto: 

```
git clone https://github.com/artpinho/desafiothomasgreg.git
```

<b>Rodar projeto localmente</b>
<ul>
  <li>Vá até a pasta src\Clients\Presentantion\WebAPI abra o arquivo appsettings.json e altere os dados da string da conexão DefaultConnection com os dados de acesso ao SQL</li>
  <li>Abra um terminal e navegue até a pasta src\Clients\Presentantion\WebAPI</li>
  <li>Fazer restore do nuget executando o comando dotnet restore</li>
  <li>Fazer a execucao do projeto com o comando dotnet run</li>
  <li>Será feito a compilação da API, no final será exibido à URL para abrir a API, acesse a url em um browser passando no final da urm o link /swagger/index.html</li>
</ul>
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
<ul>
  <li>Configure a connectionString na sua IDE</li>
  <li>Abra o arquivo appsettings.json e certifique-se de que a DefaultConnection está configurada. Ex: "Server=10.0.0.1,5555;Database=DB_Database;User ID=Usuario;Password=Senha;TrustServerCertificate=True"</li>
  <li>Abra o terminal e vá até a raiz do projeto.</li>
  <li>Execute dotnet run</li>
  <li>No navegador acesse http://localhost:5067</li>
  <li>Realize o login com os dados de acesso admin@desafio.com *Admin123*</li>
</ul>


## Resumo
<ul>
<li>O usuário pode realizar o login através de email e senha para acesso ao cadastro de clientes.</li>
<li>É necessário estar autenticado com usuário do sistema para acesso as páginas de cadastro de clientes e endereços</li>
<li>Na página Clientes é possível visualizar os clientes cadastrados com informações como nome, Email, se possui logotipo e botões de ação rápido para adicionar, ver detalhes, alterar ou apagar cadastro.</li>
<li>Na página de Endereços é possível visualizar a lista de endereços cadastrados com a informação de quem o endereço está associado. Ao adicionar um novo endereço é necessário informar qual cliente estará recebendo a informação, desta forma um cliente poderá ter vários endereços.</li>
</ul>

## Tecnologias implementadas
<ul>
<li>ASP.NET Core 8.0</li>
<li>ASP.NET WebApi Core</li>
<li>Entity Framework</li>
<li>Identity</li>
<li>SQL Server</li>
<li>Swagger UI</li>
<li>Migrations</li>
</ul>

## Licença 

Copyright :copyright: 2024 - Cadastro de Clientes TGS - Artenir Pinho
