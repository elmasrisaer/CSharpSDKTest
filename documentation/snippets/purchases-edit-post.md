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

var input = new EditPurchaseRequest("ae471106-c8b4-42cf-b83a-b061291f2922", "2023-11-01", "2023-11-20");

var response = await client.Purchases.EditPurchaseAsync(input);

Console.WriteLine(response);

```
