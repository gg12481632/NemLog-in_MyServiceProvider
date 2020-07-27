#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"

Push-Location

set-location $PSScriptRoot

. .\functions.ps1

$certpassword = ConvertTo-SecureString -String "test1234" -AsPlainText -Force

#Create a Selfsigned signing certificate for the IDP available at: sp.anysoft.dk
$cert = New-SelfSignedCertificate -DnsName sp.anysoft.dk -KeyFriendlyName IdpSigningCertificate  -CertStoreLocation cert:\LocalMachine\My
$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath '..\certificates\selfsigned_signing_certificate_sp_anysoft.dk' -Password $pwd
write-host "Installed identintity provider signing certificate $($sslcertificate.Thumbprint) in LocalMachine\My and LocalMachine\TrustedPeople. This ensures the certificate is trusted on your machine and browser"

write-host "Installing identity provider signing certificate"
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_sp_anysoft.dk' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\My
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_sp_anysoft.dk' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\TrustedPeople

write-host "Setup completed!"

Pop-Location
