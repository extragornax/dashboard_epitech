using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dashboard_api.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;

namespace dashboard_api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            Console.WriteLine("kappa");
            var dbClient = new MongoClient("mongodb://root:example@localhost:27017");
            // dbClient.user
            var database = dbClient.GetDatabase("foo");
            // database.
            var collection = database.GetCollection<BsonDocument>("bar");
            var document = new BsonDocument { { "name", "MongoDB" }, { "type", "Database" }, { "count", 1 }, {
                    "info",
                    new BsonDocument { { "x", 203 }, { "y", 102 }
                    }
                    }
            };
            collection.InsertOne(document);

            // services.Add<UserContext>(opt => opt.);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
