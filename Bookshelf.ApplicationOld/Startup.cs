using Bookshelf.ApplicationOld.Common;
using Bookshelf.ApplicationOld.GraphQL.Loaders;
using Bookshelf.ApplicationOld.GraphQL.Scalars;
using Bookshelf.ApplicationOld.GraphQL.Types;
using Bookshelf.Infrastructure;
using HotChocolate;
using HotChocolate.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookshelf.ApplicationOld
{
    public class Startup
    {
        private readonly IWebHostEnvironment Environment;

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public Startup(IWebHostEnvironment env)
        {
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(MyLoggerFactory);
            services.AddMediatR(typeof(Startup));

            services.AddSingleton<ISBNValidator>();

            services.AddDataLoader<BookRatingsLoader>();

            services.AddGraphQL(serviceProvider =>
            {
                return SchemaBuilder.New()
                    .AddServices(serviceProvider)
                    .AddQueryType<QueryType>()
                    .AddMutationType<MutationType>()
                    .AddType<AuthorType>()
                    .AddType<BookType>()
                    .AddType<GenreType>()
                    .AddType<ReviewType>()
                    .BindClrType<string, ISBNType>()
                    .Create();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL();
            app.UsePlayground();
        }
    }
}
