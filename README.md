# piko-server-.NET

Application for creating surveys in the form of contests.

You can access it here http://31.129.106.57:3001/

Also You can see the client implementation here https://github.com/mnsavag/piko-client-react/

## Main stack

- C#
- ASP.NET Core
- PostgreSQL
- Entity Framework
​
## Swagger API

### URL Address

```bash
/swagger/index.html
```

### Preview

![alt text](https://github.com/mnsavag/piko-server-.NET/blob/master/api-preview.png?raw=true)

## Database view

![alt text](https://github.com/mnsavag/piko-server-.NET/blob/master/piko-db.png?raw=true)

## Installation

### Set environment variables

Set up the database in file **appsettings.json** by "DefaultConnection" value. Feel free to change it according to your own configuration.

### Set up database

Use PostgreSQL

```bash
dotnet ef database update
```
