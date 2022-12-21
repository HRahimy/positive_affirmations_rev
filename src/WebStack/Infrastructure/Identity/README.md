# Infrastructure Layer

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on.
These classes should be based on interfaces defined within the application layer.

## CLI commands cheat sheet

- Add a new migration

  `dotnet ef migrations add <Migration name> --project Infrastructure --startup-project WebUI --context ApplicationDbContext --namespace Identity.Migrations`
  > Replace `<Migration name>` with desired name

- Remove migrations
  
  `dotnet ef migrations remove --project Infrastructure --startup-project WebUI --context ApplicationDbContext`

- Apply migrations to database

  `dotnet ef database update --project Infrastructure --startup-project WebUI --context ApplicationDbContext`