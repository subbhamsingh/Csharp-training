using FirstWebApi;


// create a web app
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// in memory product list
var products = new List<Product>();

//get all products
app.MapGet("/products", () => products);

//post a new product 
//app.MapPost("/products", (Product p) =>
//    {
//        products.Add(p);
//        return Results.Created($"/products/{p.Name}", p);
//    });


// request-response model
app.MapPost("/products", (CreateProductRequest request) =>
{
    var product = new Product
    {
        Id = products.Count + 1,
        Name = request.Name,
        Price = request.Price
    };

    products.Add(product);

    var response = new ProductResponse
    {
        Id = product.Id,
        Name = product.Name,
        Price = product.Price
    };

    return Results.Created($"/products/{product.Id}", response);
});


app.Run();


