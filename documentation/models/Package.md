# Package

**Properties**

| Name             | Type   | Required | Description                                                                                                                                                                 |
| :--------------- | :----- | :------- | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Id               | string | ❌       | ID of the package                                                                                                                                                           |
| DataLimitInBytes | double | ❌       | Size of the package in bytes. For **limited packages**, this field will return the data limit in bytes. For **unlimited packages**, it will return **-1** as an identifier. |
| Destination      | string | ❌       | ISO representation of the package's destination.                                                                                                                            |
| DestinationName  | string | ❌       | Name of the package's destination                                                                                                                                           |
| PriceInCents     | double | ❌       | Price of the package in cents                                                                                                                                               |
