```csharp
using Celitech;
using Celitech.Config;
using Celitech.Models;
using Environment = Celitech.Http.Environment;

var config = new CelitechConfig{
    Environment = Environment.Default,
	ClientId = "CLIENTID",
	ClientSecret = "CLIENTSECRET"
};

var client = new CelitechClient(config);

var input = new CreatePurchaseRequest("FRA", 1, "2023-11-01", "2023-11-20");

var response = await client.Purchases.CreatePurchaseAsync(input);

Console.WriteLine(response);

```
