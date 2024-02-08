using KonsolApplikationEFC.Services;

namespace KonsolApplikationEFC;

internal class ConsoleUI
{

    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleUI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }


    //PRODUCTS UI
    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("***** Create Product *****");

        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.Write("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Category: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created.");
            Console.ReadKey();
        }
    }
    public void GetProducts_UI()
    {
        Console.Clear();

        var products = _productService.GetAllProducts();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }
        Console.ReadKey();
    }
    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id: ");

        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine();

            Console.Write("New Product Title: ");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");

        }
        else
        {
            Console.WriteLine("No product found.");
        }

        Console.ReadKey();
    }
    public void DeleteProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id: ");

        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("Product was deleted.");
        }
        else
        {
            Console.WriteLine("No product found.");
        }

        Console.ReadKey();
    }

    //CUSTOMER UI

    public void CreateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("***** Create Customer *****");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Street Name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Role Name: ");
        var roleName = Console.ReadLine()!;



        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was created.");
            Console.ReadKey();
        }

    }
    public void GetCustomers_UI()
    {
        Console.Clear();

        var customers = _customerService.GetAllCustomers();

        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
        }
        Console.ReadKey();
    }
    public void UpdateCustomer_UI()
    {
        Console.Clear();
        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        if (customer != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{customer.FirstName} {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
            Console.WriteLine();

            Console.Write("New Last Name: ");
            customer.LastName = Console.ReadLine()!;

            var newCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine();
            Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} ({newCustomer.Role.RoleName})");
            Console.WriteLine($"{newCustomer.Address.StreetName}, {newCustomer.Address.PostalCode}, {newCustomer.Address.City}");
            Console.WriteLine();

        }
        else
        {
            Console.WriteLine("No customer found.");
        }

        Console.ReadKey();
    }

    public void DeleteCustomer_UI()
    {
        Console.Clear();
        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        if (customer != null)
        {
            _customerService.DeleteCustomer(customer.Id);
            Console.WriteLine("Customer was deleted.");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }

        Console.ReadKey();
    }



    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine($"{"1.",-4} Product Menu");
            Console.WriteLine($"{"2.",-4} Customer Menu");
            Console.WriteLine();
            Console.WriteLine($"{"0.",-4} Exit Application");
            Console.WriteLine();
            Console.Write("Enter your Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ProductMenu();
                    break;

                case "2":
                    CustomerMenu();
                    break;

                case "0":
                    ShowExitApplicationOption();
                    break;

                default:
                    Console.WriteLine("\nInvalid Option, press any key to try again.");
                    break;

            }
            Console.ReadKey();
        }
    }

    public void ProductMenu()
    {
        Console.Clear();
        Console.WriteLine($"{"1.",-4} Add A New Product");
        Console.WriteLine($"{"2.",-4} View All Products");
        Console.WriteLine($"{"3.",-4} Update Product");
        Console.WriteLine($"{"4.",-4} Delete a Product by ID");
        Console.WriteLine($"{"5.",-4} Go back to main Menu");
        Console.WriteLine();
        Console.Write("Enter your Option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                CreateCustomer_UI();
                break;

            case "2":
                GetCustomers_UI();
                break;

            case "3":
                UpdateCustomer_UI();
                break;

            case "4":
                DeleteCustomer_UI();
                break;

            case "5":
                ShowMainMenu();
                break;

            default:
                Console.WriteLine("\nInvalid Option, press any key to try again.");
                break;
        }
    }

    public void CustomerMenu()
    {
        Console.Clear();
        Console.WriteLine($"{"1.",-4} Add A New Customer");
        Console.WriteLine($"{"2.",-4} View All Customers");
        Console.WriteLine($"{"3.",-4} Update Customer");
        Console.WriteLine($"{"4.",-4} Delete a Customer by Email");
        Console.WriteLine($"{"5.",-4} Go back to main Menu");
        Console.WriteLine();
        Console.Write("Enter your Option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                CreateCustomer_UI();
                break;

            case "2":
                GetCustomers_UI();
                break;

            case "3":
                UpdateCustomer_UI();
                break;

            case "4":
                DeleteCustomer_UI();
                break;

            case "5":
                ShowMainMenu();
                break;

            default:
                Console.WriteLine("\nInvalid Option, press any key to try again.");
                break;
        }
    }


    public static void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to EXIT this application? (y/n): ");
        var option = Console.ReadLine();

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(0);
        }
    }


    public static void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"##### {title} #####");
        Console.WriteLine();
    }
}
   

