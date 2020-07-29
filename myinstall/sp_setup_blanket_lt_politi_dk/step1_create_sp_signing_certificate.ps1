#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"

Push-Location

set-location $PSScriptRoot

. .\functions.ps1

$certpassword = ConvertTo-SecureString -String "test1234" -AsPlainText -Force

#Create a Selfsigned signing certificate for the IDP available at: sp.anysoft.dk
$cert = New-SelfSignedCertificate -DnsName blanket-lt.politi.dk -CertStoreLocation cert:\LocalMachine\My -KeySpec Signature
$pwd = ConvertTo-SecureString -String "test1234" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath '..\certificates\ssc_blanket_lt_politi_dkabcde.pfx' -Password $pwd

write-host "Setup completed!"

Pop-Location
