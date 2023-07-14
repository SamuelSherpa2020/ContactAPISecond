using ContactAPI.Data;
using ContactAPI.Models;
using ContactAPI.Repository.Implementation;
using ContactAPI.Repository.Interfaces;
using ContactAPI.Services.Implementation;
using ContactAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI
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

            //builder.Services.AddDbContext<ContactApiDbContext>(options => options.UseInMemoryDatabase("ContactsDB"));
            builder.Services.AddDbContext<ContactApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));
            builder.Services.AddTransient(typeof(IContactRepo<>),typeof(ContactRepo<>));
            builder.Services.AddTransient(typeof(IContactService<>),typeof(ContactService<>));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
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