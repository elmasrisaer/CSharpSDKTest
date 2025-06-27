# ESimService

A list of all methods in the `ESimService` service. Click on the method name to view detailed information about that method.

| Methods                                     | Description      |
| :------------------------------------------ | :--------------- |
| [GetEsimAsync](#getesimasync)               | Get eSIM Status  |
| [GetEsimDeviceAsync](#getesimdeviceasync)   | Get eSIM Device  |
| [GetEsimHistoryAsync](#getesimhistoryasync) | Get eSIM History |
| [GetEsimMacAsync](#getesimmacasync)         | Get eSIM MAC     |

## GetEsimAsync

Get eSIM Status

- HTTP Method: `GET`
- Endpoint: `/esim`

**Parameters**

| Name  | Type   | Required | Description    |
| :---- | :----- | :------- | :------------- |
| iccid | string | ✅       | ID of the eSIM |

**Return Type**

`GetEsimOkResponse`

**Example Usage Code Snippet**

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

var response = await client.ESim.GetEsimAsync("1111222233334444555000");

Console.WriteLine(response);
```

## GetEsimDeviceAsync

Get eSIM Device

- HTTP Method: `GET`
- Endpoint: `/esim/{iccid}/device`

**Parameters**

| Name  | Type   | Required | Description    |
| :---- | :----- | :------- | :------------- |
| iccid | string | ✅       | ID of the eSIM |

**Return Type**

`GetEsimDeviceOkResponse`

**Example Usage Code Snippet**

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

var response = await client.ESim.GetEsimDeviceAsync("1111222233334444555000");

Console.WriteLine(response);
```

## GetEsimHistoryAsync

Get eSIM History

- HTTP Method: `GET`
- Endpoint: `/esim/{iccid}/history`

**Parameters**

| Name  | Type   | Required | Description    |
| :---- | :----- | :------- | :------------- |
| iccid | string | ✅       | ID of the eSIM |

**Return Type**

`GetEsimHistoryOkResponse`

**Example Usage Code Snippet**

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

var response = await client.ESim.GetEsimHistoryAsync("1111222233334444555000");

Console.WriteLine(response);
```

## GetEsimMacAsync

Get eSIM MAC

- HTTP Method: `GET`
- Endpoint: `/esim/{iccid}/mac`

**Parameters**

| Name  | Type   | Required | Description    |
| :---- | :----- | :------- | :------------- |
| iccid | string | ✅       | ID of the eSIM |

**Return Type**

`GetEsimMacOkResponse`

**Example Usage Code Snippet**

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

var response = await client.ESim.GetEsimMacAsync("1111222233334444555000");

Console.WriteLine(response);
```
