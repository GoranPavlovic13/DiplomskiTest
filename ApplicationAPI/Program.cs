using ApplicationAPI.Extensions;
using GraphQL;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddDbContextFactory<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<ProgrammingLanguageType>()
    //.AddType<LectureType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy ");

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, 
"/graphql-voyager");

app.Run();
