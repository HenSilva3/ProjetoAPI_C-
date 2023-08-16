<h1 align="center"> Access control API </h1>

<p align="center">
  <img src="http://img.shields.io/static/v1?label=Version&message=1&color=red&style=for-the-badge&logo=ruby"/>
  <img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

> Status do Projeto: :heavy_check_mark: :warning: Concluido

### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Funcionalidades](#funcionalidades)

:small_blue_diamond: [Layout da Aplicação](#layout-da-aplicação-dash)

:small_blue_diamond: [Pré-requisitos](#pré-requisitos)

:small_blue_diamond: [Como rodar a aplicação](#como-rodar-a-aplicação-arrow_forward)

## Descrição do projeto 

<p align="justify">
  O projeto Desenvolvido é uma API para facilitar a inserção e visualização de registros no banco de dados, com objetivo em controle de acesso de um prédio comercial, baseada em ASP.Net.  
</p>

## Funcionalidades

:heavy_check_mark: Registro de pessoas e acesso 

:heavy_check_mark: Visualização de registros  

:heavy_check_mark: Atualização de registros  

:heavy_check_mark: Exclusão de registros

## Layout da Aplicação :dash:

> ![API](https://github.com/HenSilva3/ProjetoAPI_C-/assets/139809573/51dd7f6c-a3fb-4991-92ea-4d380decdf2f)


## Pré-requisitos

:warning: [.Net6]([https://nodejs.org/en/download/](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0))

:warning: [Mysql Workbench 8.0 CE]([[https://nodejs.org/en/download/](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)](https://www.mysql.com/products/workbench/))

:warning: [MicrosoftentityFrameworkCore] (Gerenciador de pacote NuGet)

:warning: [MicrosoftentityFrameworkCoreTools] (Gerenciador de pacote NuGet)

:warning: [PomeloEntityFrameworkCoreMySql] (Gerenciador de pacote NuGet)

:warning: [AutoMapper] (Gerenciador de pacote NuGet)

:warning: [AutoMapperExtensionsMicrosoftDependencyInjection] (Gerenciador de pacote NuGet)

## Como rodar a aplicação :arrow_forward:

No terminal, clone o projeto: 

```
git clone https://github.com/HenSilva3/ProjetoAPI_C-.git
```

Após clone do Projeto:

- Abrir o projeto com o Visual Studio realizar as instalações dos pacotes necessários.
- Conferir as Migrations na pasta "Migrations" se estão de acordo com as classes na pasta "Models".

Caso queira gerar novas migrations:
- Basta abrir o console do gerenciador de pacotes Nuget e digitar o comando:

```
Add-Migrations "Criando a Migration"
```

Com o termino da geração Migration:
- Abrir o arquivo "appsettings.json" e alterar as configurações de usuário para conexão com o banco

Configurações realizadas, rodar o comando no console do gerenciador de pacotes Nuget:

```
Update-Database
```

Após isso pode rodar a aplicação em:
- Iniciar Sem Depurar.
- url da aplicação localizada no arquivo "launchSettings.json" linha 17.




