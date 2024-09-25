using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [ApiController]
    [Route("[controller]")]
    public class Program : ControllerBase // Inherit from ControllerBase to use convenience methods
    {
        public static List<Product> products = new List<Product>();

        [HttpPost("/create-req")]
        public IActionResult CreateRequest([FromBody] Product product)
        {
            // Check if product is null
            if (product == null)
            {
                // Return HTTP 400 Bad Request with a message
                return BadRequest("Product cannot be null.");
            }

            // Validate product fields (e.g., if Name is null or empty)
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest("Product Name cannot be empty.");
            }
            if (product.Name.Contains("null"))
            {
                return BadRequest("Product Name cannot be empty.");
            }
            products.Add(product);

            // Return 201 Created with a success message
            return Ok(product);
        }

      

        [HttpGet("/get-products/{id}")]
        
        public IActionResult GetProductById(int id)
        {
            Product pr = null;
            products.ForEach(product =>
            {
                if(product.Id==id)
                {
                    pr = product;
                }

            });
            if(pr!=null)
            {
                return new StatusCodeResult(200);
            }
            return BadRequest("Product Name cannot be empty.");



        }

       

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add Swagger services for API documentation.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public void SetValues(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
