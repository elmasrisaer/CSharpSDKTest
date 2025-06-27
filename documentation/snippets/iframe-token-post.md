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

var response = await client.IFrame.TokenAsync();

Console.WriteLine(response);

```
