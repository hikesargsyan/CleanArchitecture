var builder = DistributedApplication.CreateBuilder(args);


var databaseName = "Database"; 

var postgres = builder
    .AddPostgres("Postgres")
    .WithEnvironment("POSTGRES_DB", databaseName);

var database = postgres.AddDatabase(databaseName);

builder.AddProject<Projects.API>("App")
    .WithReference(database) 
    .WaitFor(database);

builder.Build().Run();
