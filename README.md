
# Login CRUD

Es un login que cuando se registra y despues uno ingresa sesion apaprece un cierto menu donde se puede hacer un CRUD de peliculas, es usando EF en .Net8.




## Run

To run this project run

```bash
  dotnet run
```


## Installation

Correr LoginCRUD con dotnet

```bash
  cd LoginCRUD
  dotnet build
  dotnet tool install --global dotnet-ef
  export PATH="$PATH:/Users/'your user folder'/.dotnet/tools"
  dotnet restore
  dotnet ef migrations add initial
  dotnet ef database update
  dotnet run

```

## Crear CRUD

Se corren los siguientes comandos

```bash
 dotnet tool install -g dotnet-aspnet-codegenerator
 export PATH=$HOME/.dotnet/tools:$PATH 
 dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc LoginCRUD.Identity.Data.LoginDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
```

    
## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://katherineoelsner.com/)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/)
[![twitter](https://img.shields.io/badge/twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/)


## Roadmap

- .Net8

- Librerias -v8

## Despliegue

[![pagina1](https://img.shields.io/badge/Azure-Web-blue)](https://logincrud.azurewebsites.net/Identity/Account/Login?ReturnUrl=%2F)

[![pagina2](https://img.shields.io/badge/Somee-Web-blue)](http://logincrud.somee.com/Identity/Account/Login?ReturnUrl=%2F)



