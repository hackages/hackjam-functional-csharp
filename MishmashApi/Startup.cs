using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MishmashApi.Entities.Shop;
using MishmashApi.Implementations;
using Newtonsoft.Json;

namespace MishmashApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var list = new List<Product>();

            var perishable = GetMockData<Perishable>("Perishable.json");
            var shoes = GetMockData<Shoes>("Shoes.json");
            var clothes = GetMockData<Clothes>("Clothes.json");

            list.AddRange(perishable);
            list.AddRange(shoes);
            list.AddRange(clothes);

            //Mocks
            services.AddSingleton<IList<Product>>(list);

            //Dictionary Memoization
            services.AddScoped<Dictionary<long, long>>();
            
            //Fibonacci Implementations
            services.AddSingleton<Func<long, long>>(FibonacciImplementations.FibonacciWithoutMemoization);
            services.AddSingleton<Func<long, Dictionary<long,long>, long>>(FibonacciImplementations.FibonacciWithMemoization);
            
            //Function Implementations
            services.AddSingleton<FunctionImplementations>();

            //Inventory Implementations
            services.AddScoped<InventoryImplementations>();

            services
                .AddMvcCore()
                .AddCors()
                .AddJsonFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            app.UseMvcWithDefaultRoute();
        }

        private IList<T> GetMockData <T>(string filename)
        {
            var seed = File.ReadAllText("Assets/" + filename);
            return JsonConvert.DeserializeObject<List<T>>(seed);
        }

        
    }
}
