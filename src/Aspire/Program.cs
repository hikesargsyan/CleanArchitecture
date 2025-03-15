var builder = DistributedApplication.CreateBuilder(args);


var databaseName = "AppDatabase";

var postgres = builder
    .AddPostgres("Postgres")
    .WithEnvironment("POSTGRES_DB", databaseName);

var database = postgres.AddDatabase(databaseName);

builder.AddProject<Projects.API>("API")
    .WithReference(database)
    .WaitFor(database);

builder.Build().Run();
