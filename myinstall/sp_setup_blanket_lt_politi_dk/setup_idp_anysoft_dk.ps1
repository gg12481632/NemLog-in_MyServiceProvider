#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"

Push-Location

set-location $PSScriptRoot

. .\functions.ps1

$certpassword = ConvertTo-SecureString -String "test1234" -AsPlainText -Force

#SSL certificate setup. Alternativ, benyt letsencrypt istedet for selfsigned ssl certificat eller et indkobt certifikat
#$cert = New-SelfSignedCertificate -DnsName idp.anysoft.dk -CertStoreLocation cert:\LocalMachine\My
#$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
#Export-PfxCertificate -Cert $cert -FilePath '..\certificates\selfsigned_ssl_idp_anysoft_dk.pfx' -Password $pwd

#Selfsigned signing certificate
#$cert = New-SelfSignedCertificate -DnsName idp.anysoft.dk -KeyFriendlyName IdpSigningCertificate  -CertStoreLocation cert:\LocalMachine\My
#$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
#Export-PfxCertificate -Cert $cert -FilePath '..\certificates\selfsigned_signing_certificate_idp_anysoft_dk.pfx' -Password $pwd
#write-host "Installed identintity provider signing certificate $($sslcertificate.Thumbprint) in LocalMachine\My and LocalMachine\TrustedPeople. This ensures the certificate is trusted on your machine and browser"

write-host "Installing identity provider signing certificate"
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_idp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\My
$serviceprovidercertificate = Import-PfxCertificate '..\certificates\selfsigned_signing_certificate_idp_anysoft_dk.pfx' -Password $certpassword -CertStoreLocation Cert:\LocalMachine\TrustedPeople

#kun hvis lokalt> add-HostEntry "127.0.0.1" "idp.anysoft.dk"

write-host "Setup completed!"

Pop-Location
