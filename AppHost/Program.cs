using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("Pethouse");

builder.AddProject<Projects.PethouseAPI>("pethouseApi")
    .WithEndpoint("http", endpoint => endpoint.IsProxied = false)
    .WithEndpoint("https", endpoint => endpoint.IsProxied = false) // Disabling reverse proxy so we don't get CORS errors in Scalar
    .WithReference(db)
    .WaitFor(db);


builder.Build().Run();