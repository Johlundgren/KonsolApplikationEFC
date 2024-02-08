using KonsolApplikationEFC;
using KonsolApplikationEFC.Contexts;
using KonsolApplikationEFC.Repositories;
using KonsolApplikationEFC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\KonsolApplikationEFC\KonsolApplikationEFC\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<RoleRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ProductService>();
    services.AddScoped<RoleService>();


    services.AddSingleton<ConsoleUI>();
}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();



consoleUI.ShowMainMenu();
//consoleUI.CreateProduct_UI();
//consoleUI.GetProducts_UI();
//consoleUI.UpdateProduct_UI();
//consoleUI.DeleteProduct_UI();

//consoleUI.CreateCustomer_UI();
//consoleUI.GetCustomers_UI();
//consoleUI.UpdateCustomer_UI();
//consoleUI.DeleteCustomer_UI();