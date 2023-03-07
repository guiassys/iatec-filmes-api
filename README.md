# iatec-filmes-api
Simples API .Net C# que permite manter filmes desenvolvido durante o curso IATEC Academy 2023




Pre requisitos:
1. Instalar .NET V6
2. Instalar Docker

Passos para rodar o projeto:
1. Configure o banco de dados, navegue até o diretório Docker e digite o comando: docker-compose -f docker-compose-bd.yml up.
2. Execute as migrations do projeto: dotnet ef database update
3. Subir a API,  no diretório raiz do projeto digite os comandos: 
   3.1 dotnet build;
   3.2 dotnet run;
4. Para ter acesso a documentação Swagger acesse -> https://localhost:7106/swagger/index.html
