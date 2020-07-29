#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"
#Note replace idp.anysoft.dk with our domain name

Push-Location

set-location $PSScriptRoot

. .\functions.ps1

$certpassword = ConvertTo-SecureString -String "test1234" -AsPlainText -Force

#Create a Selfsigned signing certificate for the IDP available at: idp.asnysoft.dk
$cert = New-SelfSignedCertificate -DnsName idp.anysoft.dk -KeyFriendlyName IdpSigningCertificate  -CertStoreLocation cert:\LocalMachine\My -KeySpec Signature
# KeySpec Signature means oldstyle private key
$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath '..\certificates\ssc_idp_anysoft_dk.pfx' -Password $pwd

#write-host "Installed identintity provider signing certificate $($sslcertificate.Thumbprint) in LocalMachine\My and LocalMachine\TrustedPeople. This ensures the certificate is trusted on your machine and browser"
#write-host "Installing identity provider signing certificate"
#$serviceprovidercertificate = Import-PfxCertificate '..\certificates\ssc_idp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\My
#$serviceprovidercertificate = Import-PfxCertificate '..\certificates\ssc_idp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\TrustedPeople

#write-host "Setup completed!"

Pop-Location
