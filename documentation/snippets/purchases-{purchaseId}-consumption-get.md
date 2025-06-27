```csharp
using Celitech;
using Celitech.Config;
using Environment = Celitech.Http.Environment;

var config = new CelitechConfig{
    Environment = Environment.Default,
	ClientId = "CLIENTID",
	ClientSecret = "CLIENTSECRET"
};

var client = new CelitechClient(config);

var response = await client.Purchases.GetPurchaseConsumptionAsync("4973fa15-6979-4daa-9cf3-672620df819c");

Console.WriteLine(response);

```
