# piko-server-.NET

Application for creating surveys in the form of contests.

You can access it here http://31.129.106.57:3001/

Also You can see the client implementation here https://github.com/mnsavag/piko-client-react/

### Interacting with app (client)

#### Home Page

All polls are here. You can go through them by clicking the "start" button.

Or see the rating by clicking the "show result" button.

**Example**

![alt text](https://github.com/mnsavag/piko-server-.NET/blob/master/site-home-page.png?raw=true)

#### Create Championship Page

Here you can create your survey. Available image formats: png/jpg/jpeg.

At the moment the editor preview does not correspond to the real preview.
​
### Swagger API

#### /swagger/index.html

### Database view

![alt text](https://github.com/mnsavag/piko-server-.NET/blob/master/piko-db.png?raw=true)

### Installation

### Running the app

Set up the database in file **appsettings.json**

```bash
# set up database
$ dotnet ef database update
```
