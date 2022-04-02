# UNA Project

Create migrations:
```powershell
dotnet ef migrations add InitialModel --context appdbcontext -p ../UNAProject.Infrastructure/UNAProject.Infrastructure.csproj -s UNAProject.Web.csproj -o Data/Migrations
dotnet ef migrations add InitialIdentityModel --context appidentitydbcontext -p ../UNAProject.Infrastructure/UNAProject.Infrastructure.csproj -s UNAProject.Web.csproj -o Identity/Migrations
```

Apply migrations:

```powershell
dotnet ef database update -c appdbcontext -p ../UNAProject.Infrastructure/UNAProject.Infrastructure.csproj -s UNAProject.Web.csproj
dotnet ef database update -c appidentitydbcontext -p ../UNAProject.Infrastructure/UNAProject.Infrastructure.csproj -s UNAProject.Web.csproj
```

Generate script:

```powershell
dotnet ef migrations script --context appidentitydbcontext -p ../UNAProject.Infrastructure/UNAProject.Infrastructure.csproj -s UNAProject.Web.csproj | out-file ./script.sql
```
