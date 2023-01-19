using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Domain.IConnection;
using EmployeeCrud.Services.Iservices;
using EmployeeCrud.Services.Mapping;
using EmployeeCrud.Services.Services;
using EmployeeCrud.WebAPI.Connection;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeCrud.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());

            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddSingleton<IConnection, Connection.Connection>();
            builder.Services.AddDbContext<EmployeeDBContext>(opts =>
        opts.UseSqlServer("Server= DESKTOP-JQ923B7\\SQLEXPRESS; Database=EmployeeDB; Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True; Integrated Security=True;"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}