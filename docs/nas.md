# Steps to host ASP.NET Core in Docker on a Synology NAS

This guide assumes that Docker is already installed on the NAS named `nas1`, and that there is a shared folder prepared called `docker`.

The instructions here a for a Windows machine.

---

## 1. Initial set-up (once per NAS)

### Folder structure

Create the following folders in the `docker` shared folder

- `configs`
- `https`
- `keys`

When set up the folder structure will look something like the following.

```folders
docker
├───configs
│   └───  project1.syno.json
│
├───https
│   └───  aspnetapp.pfx
│
├───keys
│   └───  key-xx...xx.xml
│
├───project1
│   ├───  Dockerfile
│   ├───configs
│   │   ├───  appsettings.json
│   │   └───  appsettings.Production.json
│   ├───data
│   └───publish
│       └───...
│
└───project2
    ├───  Dockerfile
    ├───configs
    ├───data
    └───publish
        └───...
```

#### Folder structure explanation

| Folder | Description | Example |
| :---   | :---        | :---    |
| docker/configs | Folder to store the exported container settings | _projectname.syno.json_ |
| https | Folder to store the pfx file created by the `dotnet dev-certs` command | _aspnetapp.pfx_ |
| keys | Folder to store the keys created whilst running ASP.NET Core apps | _key-xx...xx.xml_ |
| _project1_ | An ASP.NET Core project to be hosted | _project1_ |
| _project1_/configs | Configuration files stored outside of the container so they persist | _appsettings.json_ |
| _project1_/data | Data that needs to persist outside of the container | _appIdentity.db_ |
| _project1_/publish | Output from the `dotnet publish` command or publishing from Visual Studio. These files end up in the image and aren't accessed again | |

### Create a certificate

Create a certificate and store it in the https folder. The password used here will be configured when setting up the docker project container.

```windows
dotnet dev-certs https -ep \\nas1\docker\https\aspnetapp.pfx -p { password }
```

---

## 2. Repeated for each solution to host

In this case the solution is called `project1`.

### Publish a project to the NAS

- Create a Publish profile
- Publish to `\\nas1\docker\project1\publish\`

### Set up the Docker image

Create a `Dockerfile` in your project folder that looks something like the following:

```Dockerfile
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
COPY publish /app
WORKDIR /app
EXPOSE 443

ENTRYPOINT ["dotnet", "Web.Server.dll"]
```

Adjust the `ENTRYPOINT` to match your app.

Note that as this app will only be using `https`, port 80 is not exposed.

### Connect to NAS and build the Docker image

```bash
ssh user@nas1 -p portno

sudo -i

# Optionally get the latest version of the base runtime image
docker pull mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim

cd /volume1/docker/project1
docker build -t project1 .
```

### Configuration files

### Configure external logins

#### Microsoft personal account

- Documentation at <https://docs.microsoft.com/en-gb/azure/app-service/configure-authentication-provider-microsoft>

- <https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade>

#### Twitter

- Documentation at <https://docs.microsoft.com/en-gb/azure/app-service/configure-authentication-provider-twitter>  
- <https://developer.twitter.com/en/apps>

### Launch and Configure the image

### Set up reverse proxy

1. Use a subdomain on the DDNS name.
1. Use Control Panel / Application Portal / Reverse Proxy