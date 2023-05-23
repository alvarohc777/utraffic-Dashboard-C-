@RD /S /Q -r Migrations
DEL Solicitudes.db
dotnet ef migrations add Initial --context ClienteContext 
dotnet ef database update --context ClienteContext