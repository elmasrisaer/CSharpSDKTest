# Packages

**Properties**

| Name             | Type   | Required | Description                                                                                                                                                                 |
| :--------------- | :----- | :------- | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Id               | string | ❌       | ID of the package                                                                                                                                                           |
| Destination      | string | ❌       | ISO representation of the package's destination.                                                                                                                            |
| DataLimitInBytes | double | ❌       | Size of the package in bytes. For **limited packages**, this field will return the data limit in bytes. For **unlimited packages**, it will return **-1** as an identifier. |
| MinDays          | double | ❌       | Min number of days for the package                                                                                                                                          |
| MaxDays          | double | ❌       | Max number of days for the package                                                                                                                                          |
| PriceInCents     | double | ❌       | Price of the package in cents                                                                                                                                               |
