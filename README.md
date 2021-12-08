# Underground Connection App

#### An App for connecting artists with other artists

#### By Gabe Ayala, Sisi Vieira, Marni Sucher and Mary Marks

## Technologies Used

- .NET Core 5.0.1
- ASP.NET Core MVC
- ASP.NET Core Razor Pages
- C#
- Entity Framework Core
- GitHub
- HTML
- MySQL
- MySQL Workbench
- VS Code
- Underground Connection API

## Description

This is an app built in C#/.Net. It allows users log in a nd out, make a profile, edit their profile, and view other artists. 

## Setup/Installation Requirements

##### Software Requirements

1. Internet browser
2. A code editor such as VSCode to view and edit the code
3. .NET or follow along with the Installing .NET instructions to install .NET

##### Open Locally

- Click on the link to the API repository: [https://github.com/Gabeaya/Underground_ConnectionApi.Solution]()
- Follow the directions in the README to open the API on your local server
- Click on the link to the client repository [https://github.com/Gabeaya/UndergroundConnectionClient.Solution]
- Click on the green "Code" button and copy the repository URL
- Open your terminal and use the command `git clone https://github.com/Gabeaya/UndergroundConnectionClient.Solution` into the directory you would like to clone the repository
- Open in text editor to view code and make changes

##### Installing .NET

In order to run the application, please install .NET for your computer to recognize the `dotnet` command.

1. Download [.NET Core SDK (Software Development Kit)](https://dotnet.microsoft.com/download/dotnet). Clicking this link will prompt a file download for your particular OS from Microsoft.
2. Open the file. Follow the installation steps.
3. Confirm the installation is successful by opening your terminal and running the command `dotnet --version`. The response should be something similar to this:`5.0.100`. This means it was successfully installed.

##### Installing MySQL

MySQL is a type of database software used to create, edit, query, and manage SQL data.

- For Mac Users please [Click Here](https://dev.mysql.com/downloads/file/?id=484914) to download MySQL Installer
- For Windows Users please [Click Here](https://dev.mysql.com/downloads/file/?id=484919)

- Verify MySQL installation by opening the terminal and entering the command `mysql -uroot -p[THEPASSWORDYOUSELECTED]`
- If you gain access you will see see the MYSQL command line!

##### Installing MySQL Workbench

- Please [Click Here](https://dev.mysql.com/downloads/workbench/) to install the correct version for your machine
- Open MySQL Workbench and select `Local instance 3306 server`. You will need to enter the password you selected

##### Compiling

- Navigate to the UnderGroundConnectionsClient folder in the command line
- Use the command `dotnet build` to compile

##### Installing Packages

- Navigate to the UndergroundConnectionClient folder in the command line
- Use the command `dotnet restore`

<details>

  <summary>Expand for Database Installation Essentials!</summary>

### Database Connection

Create a connection string to connect the database to the web application

1. Create a file in the root directory called `appsettings.json`
2. Add the code below:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```

- Update all the information above in the square brackets. Change the server, port, and uid if necessary.

</details>

##### View In Browser
To run the API locally:
1. In your terminal navigate to the UndergroundConnectionsClient folder
2. run dotnet run
To view the documentation while the API is running locally open your browser to `http://localhost:5004`

## Known Bugs

* None

## License

MIT

## Contact Information

* Gabe Ayala <gabeayala100@gmail.com>
* Sisi Vieira <cicy886@gmail.com>
* Marni Sucher <suchermarni@gmail.com>
* Mary Marks <maryleemarks@gmail.com>