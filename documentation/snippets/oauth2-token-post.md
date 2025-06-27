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

var input = new GetAccessTokenRequest();

var response = await client.OAuth.GetAccessTokenAsync(input);

Console.WriteLine(response);

```
