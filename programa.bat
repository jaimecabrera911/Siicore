::Crear la solución de Visual Studio; al ejecutar el siguiente comando, _dotnet _tomará como nombre de la solución, el nombre de la carpeta contenedora.
CALL dotnet new sln
CALL dotnet new globaljson --sdk-version 3.1

::Crear los proyectos de biblioteca
::Para la Lógica de Negocio (Business Layer o AppCore Layer)
CALL dotnet new classlib -o src\Siicore.Core -f "netcoreapp3.1"
CALL dotnet sln add src\Siicore.Core\Siicore.Core.csproj

::Para acceso a datos Infrastructure
CALL dotnet new classlib -o src\Siicore.Infrastructure -f "netcoreapp3.1"
CALL dotnet sln add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj

::Crear un proyecto web MVC con autenticación individual.
CALL dotnet new mvc -o src\Siicore.Web -f "netcoreapp3.1" --auth Individual --razor-runtime-compilation
CALL dotnet sln add src\Siicore.Web\Siicore.Web.csproj

::Establecer la referencia para el proyecto Siicore.Infrastructure.
CALL dotnet add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj reference src\Siicore.Core\Siicore.Core.csproj

::Establecer las referencias para el proyecto Siicore.Web
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj reference src\Siicore.Core\Siicore.Core.csproj
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj reference src\Siicore.Infrastructure\Siicore.Infrastructure.csproj

::MySqlData.EntityFrameworkCore
CALL dotnet add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj package Microsoft.AspNetCore.Identity --version 2.2.0
CALL dotnet add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 3.1.10
CALL dotnet add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Tools --version 3.1.10
CALL dotnet add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Design --version 3.1.10
CALL dotnet add src\Siicore.Infrastructure\Siicore.Infrastructure.csproj package MySql.Data.EntityFrameworkCore

::Microsoft.EntityFrameworkCore
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.AspNetCore.Identity.UI --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.EntityFrameworkCore --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.EntityFrameworkCore.Tools --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package Microsoft.EntityFrameworkCore.Design --version 3.1.10
CALL dotnet add src\Siicore.Web\Siicore.Web.csproj package MySql.Data.EntityFrameworkCore

::DATA FIRST
CALL dotnet add src\Siicore.Core\Siicore.Core.csproj package MySql.Data.EntityFrameworkCore
CALL dotnet add src\Siicore.Core\Siicore.Core.csproj package Microsoft.EntityFrameworkCore.Design --version 3.1.10
CALL cd .\src\Siicore.Infrastructure
CALL pause
CALL dotnet ef dbcontext scaffold "database=base_siicore;server=localhost;port=3306;user id=root;password=root" MySql.Data.EntityFrameworkCore -o ../Siicore.Core/Domain -c SiicoreDbContext --context-dir ../Siicore.Infrastructure/Data --context-namespace Siicore.Infrastructure.Data  -s ../Siicore.Web/Siicore.Web.csproj -v

pause