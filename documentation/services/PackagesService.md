# PackagesService

A list of all methods in the `PackagesService` service. Click on the method name to view detailed information about that method.

| Methods                                 | Description   |
| :-------------------------------------- | :------------ |
| [ListPackagesAsync](#listpackagesasync) | List Packages |

## ListPackagesAsync

List Packages

- HTTP Method: `GET`
- Endpoint: `/packages`

**Parameters**

| Name             | Type   | Required | Description                                                                                                                                                                                                         |
| :--------------- | :----- | :------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| destination      | string | ❌       | ISO representation of the package's destination.                                                                                                                                                                    |
| startDate        | string | ❌       | Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.                                                                      |
| endDate          | string | ❌       | End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.                                                                                                    |
| dataLimitInGb    | double | ❌       | Size of the package in GB. For **limited packages**, the available options are: **0.5, 1, 2, 3, 5, 8, 20GB**. For **unlimited packages** (available to Region-3), please use **-1** as an identifier.               |
| includeUnlimited | bool   | ❌       | A boolean flag to include the **unlimited packages** in the response. The flag is false by default.                                                                                                                 |
| afterCursor      | string | ❌       | To get the next batch of results, use this parameter. It tells the API where to start fetching data after the last item you received. It helps you avoid repeats and efficiently browse through large sets of data. |
| limit            | double | ❌       | Maximum number of packages to be returned in the response. The value must be greater than 0 and less than or equal to 160. If not provided, the default value is 20                                                 |
| startTime        | long   | ❌       | Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months                                                              |
| endTime          | long   | ❌       | Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time                                                                                                   |
| duration         | double | ❌       | Duration in seconds for the package's validity. If this parameter is present, it will override the startTime and endTime parameters. The maximum duration for a package's validity period is 90 days                |

**Return Type**

`ListPackagesOkResponse`

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

var response = await client.Packages.ListPackagesAsync();

Console.WriteLine(response);
```
