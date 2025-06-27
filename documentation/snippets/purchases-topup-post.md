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

var input = new TopUpEsimRequest("1111222233334444555000", 1);

var response = await client.Purchases.TopUpEsimAsync(input);

Console.WriteLine(response);

```
