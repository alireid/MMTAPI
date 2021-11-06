
# MMTAPI - WebAPI with .NET 5.0 - Alasdair Reid

- The API exposes customer data from the MMT supplied endpoint.
- The API communicates with a DB based on parameters user and customer ID.
- Tested using SwaggerUI as part of the WEBAPI testing tools in .NET CORE 5.0 using the following detail.



**Local IISExpress URL: https://localhost:44375/api/Order**

```
request data:
{
  "user": "cat.owner@mmtdigital.co.uk",
  "customerId": "C34454"
}
```


```
response data:
{
  "customer": {
    "firstName": "Charlie",
    "lastName": "Cat"
  },
  "order": {
    "orderNumber": 4,
    "orderDate": "2020-09-11T00:00:00",
    "deliveryAddress": "1a, Uppingham Gate, Uppingham, LE15 9NY",
    "orderItems": [
      {
        "product": "'I love my pet' t-shirt",
        "quantity": 1,
        "priceEach": 12.5
      },
      {
        "product": "'I love my pet' t-shirt",
        "quantity": 1,
        "priceEach": 15.99
      }
    ],
    "deliveryExpected": "2021-05-07T00:00:00"
  }
}
```


**Improvements:**
- Put the API keys in appsettings.json, surfaced via a configuration class into /Services/CustomerService.cs
- Lighter weight controller action
- Add implementations for full CRUD actions in the API

**Notes:**
- Supplied JSON example for response has two formatting errors, comma missing after OrderNumber and OrderItems array.


