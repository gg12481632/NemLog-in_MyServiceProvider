#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"


Push-Location

set-location $PSScriptRoot

. .\functions.ps1

$certpassword = ConvertTo-SecureString -String "test1234" -AsPlainText -Force

write-host "Installing identity provider signing certificate"
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_sp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\My
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_sp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\TrustedPeople

$Principal = "IIS_IUSRS"
Set-CertificatePermission $serviceprovidercertificate.Thumbprint $Principal


write-host "Setup completed!"

Pop-Location
