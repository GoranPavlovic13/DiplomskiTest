using ApplicationAPI.Extensions;

using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.HttpOverrides;

using DataAnnotatedModelValidations;
using GraphQL;
using GraphQL.ProgrammingLanguages;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages.Mutation;
using AutoMapper;
using GraphQL.Authentication;
using NLog;
using GraphQL.DataLoaders;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile("nlog.config");

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddAuthentication();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddHttpClient();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Application.Presentation.AssemblyReference).Assembly);
builder.Services.AddSingleton<HttpClient>();


builder.Services.AddGraphQL();

builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddType<ProgrammingLanguageType>()
    //.AddType<LectureType>()
    .AddMutationType<Mutation>()
    .AddType<ProgrammingLanguageMutation>()
    .AddType<LectureMutation>()
    .AddType<AuthenticationMutation>()
    .AddSubscriptionType<Subscription>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    .AddDataAnnotationsValidator()
    .AddDataLoader<LecturesByLanguageIdDataLoader>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, 
"/graphql-voyager");

app.Run();
