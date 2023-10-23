//using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PuginInterfaces;
using IMS.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace IMS.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMudServices();
            var conntectionstring = builder.Configuration.GetConnectionString("Server");
            var serverVersion = new MySqlServerVersion(new Version(10, 5, 21));

            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddDbContext<InventoryContext>(options => 
                options.UseMySql(conntectionstring,serverVersion)
            );

			builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
			builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
			builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
			builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
			builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}