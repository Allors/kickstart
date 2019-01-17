@echo off
@echo =====
@echo Clean
@echo =====

rmdir /s /q .\Database\Domain\Generated >nul 2>&1
rmdir /s /q .\Database\Diagrams\Generated >nul 2>&1
rmdir /s /q .\Workspace\Typescript\Domain\src\allors\meta\generated >nul 2>&1
rmdir /s /q .\Workspace\Typescript\Domain\src\allors\domain\generated >nul 2>&1
rmdir /s /q .\Workspace\Typescript\Intranet\src\allors\meta\generated >nul 2>&1
rmdir /s /q .\Workspace\Typescript\Intranet\src\allors\domain\generated >nul 2>&1

@echo ==========
@echo Repository
@echo ==========

dotnet restore ..\allors\Platform\Repository\Repository.sln
dotnet msbuild ..\allors\Platform\Repository\Repository.sln

dotnet restore Repository.sln

cd repository/domain
dotnet ..\..\..\allors\Platform\Repository\Generate\bin\Debug\netcoreapp2.2\Generate.dll repository.csproj ../../../allors/Domains/Core/Repository/Templates/meta.cs.stg ../../database/meta/generated
cd ../../

@echo ====================
@echo Domain and Workspace
@echo ====================

dotnet restore Database.sln
dotnet msbuild Database.sln /target:Clean /verbosity:minimal
dotnet msbuild Database.sln /target:Database\Generate:Rebuild /p:Configuration="Debug" /verbosity:minimal

@echo Generating

dotnet Database\Generate\bin\Debug\netcoreapp2.2\Generate.dll

rem dotnet msbuild Database\Resources/Merge.proj /verbosity:minimal

pause

