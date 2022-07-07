# DEPENDENCIES do Projeto
- dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0-preview.5.22302.2
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.0-preview.5
- dotnet tool install --global dotnet-ef
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0-preview.5.22302.2
- dotnet add package Microsoft.EntityFrameworkCore.Relational --version 7.0.0-preview.5.22302.2
- dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 7.0.0-preview.5.22303.8

## Gerando Context

Acesse o projeto e execute o comando abaixo para gerar as tabelas

```bash
dotnet ef dbcontext scaffold "Host=localhost;Database=jaspion_db;Username=postgres;Password=test" Npgsql.EntityFrameworkCore.PostgreSQL -f -o ./Models
```