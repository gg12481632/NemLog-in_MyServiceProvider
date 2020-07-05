param(
    [string] [parameter(Mandatory = $true)] $version, 
    [string] [parameter(Mandatory = $true)] $assemblyVersion, 
    [switch] $pushPackages)

$ErrorActionPreference = "Stop"

if($pushPackages.IsPresent)
{
    write-host "pushing package dk.nita.saml20" -ForegroundColor Yellow
    .\nuget.exe push $("dk.nita.saml20.$version.nupkg") -Source https://www.nuget.org/api/v2/package

    write-host "pushing package dk.nita.saml20.ext.audit.log4net" -ForegroundColor Yellow
    .\nuget.exe push $("dk.nita.saml20.ext.audit.log4net.$version.nupkg") -Source https://www.nuget.org/api/v2/package
    
    write-host "pushing package dk.nita.saml20.ext.sessionstore.sqlserver" -ForegroundColor Yellow
    .\nuget.exe push $("dk.nita.saml20.ext.sessionstore.sqlserver.$version.nupkg") -Source https://www.nuget.org/api/v2/package
}
else
{
    write-host "Generating assembly versioning" -ForegroundColor Yellow

    "using System.Reflection; 

    [assembly: AssemblyVersion(`"$assemblyversion`")]
    [assembly: AssemblyFileVersion(`"$assemblyversion`")]
    [assembly: AssemblyInformationalVersion(`"$assemblyversion`")]" | sc ..\src\dk.nita.saml20\CommonAssemblyInfo.cs

    write-host "Restoring nuget packages" -ForegroundColor Yellow
    .\nuget.exe restore ..\src\dk.nita.saml20

    write-host "Building nuget package dk.nita.saml20" -ForegroundColor Yellow
    .\nuget.exe pack ..\src\dk.nita.saml20\dk.nita.saml20\dk.nita.saml20.csproj -build -Version $version -Symbols -Properties Configuration=Release

    write-host "Building nuget package dk.nita.saml20.ext.audit.log4net" -ForegroundColor Yellow
    .\nuget.exe pack ..\src\dk.nita.saml20\dk.nita.saml20.ext.audit.log4net\dk.nita.saml20.ext.audit.log4net.csproj -build -Version $version -Symbols -Properties Configuration=Release

    write-host "Building nuget package dk.nita.saml20.ext.sessionstore.sqlserver" -ForegroundColor Yellow
    .\nuget.exe pack ..\src\dk.nita.saml20\dk.nita.saml20.ext.sessionstore.sqlserver\dk.nita.saml20.ext.sessionstore.sqlserver.csproj -build -Version $version -Symbols -Properties Configuration=Release
}