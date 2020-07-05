#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"

Push-Location

set-location $PSScriptRoot

. .\functions.ps1

$certpassword = ConvertTo-SecureString -String "test1234" -AsPlainText -Force

$cert = New-SelfSignedCertificate -DnsName sp.anysoft.dk -CertStoreLocation cert:\LocalMachine\My
$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath '..\certificates\selfsigned_ssl_sp_anysoft_dk.pfx' -Password $pwd

$cert = New-SelfSignedCertificate -DnsName sp.anysoft.dk -CertStoreLocation cert:\LocalMachine\My
$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath '..\certificates\selfsigned_signing_certificate_sp_anysoft_dk.pfx' -Password $pwd

write-host "Installing serviceprovider ssl certificate"
$serviceProviderSslcertificate = Import-PfxCertificate '..\certificates\selfsigned_ssl_sp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\My
$serviceProviderSslcertificate = Import-PfxCertificate '..\certificates\selfsigned_ssl_sp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\TrustedPeople
write-host "Installed serviceprovider ssl certificate $($sslcertificate.Thumbprint) in LocalMachine\My and LocalMachine\TrustedPeople. This ensures the certificate is trusted on your machine and browser"

write-host "Installing serviceprovider's signing certificate"
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_sp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\My
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_sp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\TrustedPeople
write-host "Installed serviceprovider's signing certificate $($serviceprovidercertificate.Thumbprint) in LocalMachine\My and LocalMachine\TrustedPeople. This ensures the certificate is trusted on your machine and browser"
write-host "This certificate is used by the demo website (service provider) as its signing certificate"

#add-HostEntry "127.0.0.1" "sp.anysoft.dk"

write-host "Setup completed!"
write-host "You should now open the solution in Visual Studio, build it and run it!"

Pop-Location

