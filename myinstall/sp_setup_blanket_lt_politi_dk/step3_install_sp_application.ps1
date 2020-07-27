#Requires -RunAsAdministrator
$ErrorActionPreference = "Stop"
#Note replace IdpAnysoftDk with our folder name
# replace _idp_anysoft_dk.pfx with _blanket_lt_politi_dk.pfx


#PRECONDITION:
#The application must be installed at C:\inetpub\xxx port 443 and equipped with ssl certificate
# sl1bvaabweb01


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




