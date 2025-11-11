using ApplicationAPI.Extensions;
using GraphQL;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages;
using GraphQL.Queries;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Repository;
using HotChocolate.Data;
using GraphQL.ProgrammingLanguages.Mutation;
using DataAnnotatedModelValidations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

//builder.Services.AddHttpClient();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Application.Presentation.AssemblyReference).Assembly);
builder.Services.AddSingleton<HttpClient>();



builder.Services.AddGraphQL();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProgrammingLanguageType>()
    .AddType<LectureType>()
    .AddMutationType<Mutation>()
    .AddType<ProgrammingLanguageMutation>()
    .AddType<LectureMutation>()
    .AddSubscriptionType<Subscription>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    .AddDataAnnotationsValidator();

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

app.UseWebSockets();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, 
"/graphql-voyager");

app.Run();
