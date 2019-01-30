using Cassandra;
using Cassandra.Mapping;
using CQRSDataStorage.DependenciesCore.Registries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace CQRSDataStorage.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            PopulateServicesMapping(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void PopulateServicesMapping(IServiceCollection services)
        {
            var contactPoints = Configuration.GetSection("CassandraClusterContactPoints");

            var container = new Container(x =>
            {
                x.For<ISession>()
                    .Use(y => Cluster.Builder()
                        .AddContactPoints(contactPoints.Value)
                        .Build()
                        .Connect())
                    .Singleton();

                x.For<IMapper>()
                    .Use(y => new Mapper(y.GetInstance<ISession>()))
                    .ContainerScoped();
            });

            container.Configure(config =>
            {
                config.AddRegistry<DataAccessLayerRegistry>();
                config.Populate(services);
            });
        }
    }
}
