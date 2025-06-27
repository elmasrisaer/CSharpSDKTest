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

var input = new CreatePurchaseV2Request("FRA", 1, 1);

var response = await client.Purchases.CreatePurchaseV2Async(input);

Console.WriteLine(response);

```
