#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"
#Note replace idp.anysoft.dk with our domain name


#PRECONDITION:
#The application must be installed at C:\inetpub\IdentityProviderDemo port 2001 and equipped with ssl certificate



# ACTION: Do execute

$Right="ReadAndExecute"
$Principal = "IIS_IUSRS"
$StartingDir = "C:\inetpub\IdpAnysoftDk"

foreach ($file in $(Get-ChildItem $StartingDir -recurse)) {
	$rule=new-object `
    System.Security.AccessControl.FileSystemAccessRule($Principal,$Right,"Allow")
    
    $acl=Get-Acl $file.FullName

    Write-Output $file.FullName

    $acl.SetAccessRule($rule)

    Set-Acl $File.Fullname $acl
}


Set-CertificatePermission $demoidpcertificate.Thumbprint $Principal



