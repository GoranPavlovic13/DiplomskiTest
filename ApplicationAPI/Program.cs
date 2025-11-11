using ApplicationAPI.Extensions;
using GraphQL;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages;
<<<<<<< HEAD
using GraphQL.Queries;
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Repository;
<<<<<<< HEAD
using HotChocolate.Data;
using GraphQL.ProgrammingLanguages.Mutation;
using DataAnnotatedModelValidations;
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
<<<<<<< HEAD
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

//builder.Services.AddHttpClient();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Application.Presentation.AssemblyReference).Assembly);
builder.Services.AddSingleton<HttpClient>();


=======

//builder.Services.AddHttpClient();
builder.Services.AddSingleton<HttpClient>();

builder.Services.AddDbContextFactory<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

builder.Services.AddGraphQL();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
<<<<<<< HEAD
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
=======
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<ProgrammingLanguageType>()
    //.AddType<LectureType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting().
    AddInMemorySubscriptions();

builder.Services.AddControllers();
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

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
