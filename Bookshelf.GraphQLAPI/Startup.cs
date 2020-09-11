using Bookshelf.Application;
using Bookshelf.Infrastructure;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookshelf.GraphQLAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment Environment;

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public Startup(IWebHostEnvironment env)
        {
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(MyLoggerFactory);
            services.AddApplication();

            services.AddScoped<Types.AuthorType>();
            services.AddScoped<Types.BookType>();
            services.AddScoped<Types.GenreType>();

            services.AddSingleton<Input.BookInputType>();

            services.AddScoped<Loaders.BookLoader>();

            services.AddScoped<GraphQLAPIQuery>();
            services.AddScoped<GraphQLAPIMutation>();
            services.AddScoped<ISchema, GraphQLAPISchema>();

            services
                .AddGraphQL(options =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    options.ExposeExceptions = Environment.IsDevelopment();
                })
                .AddSystemTextJson()
                .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<ISchema>("/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/",
            });
        }
    }
}
