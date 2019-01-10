param (
    [string]$resourceGroup,
    [string]$location = 'westeurope',
    [string]$storageName,
    [string]$functionName
)

# Creates a Resource group to hold our application
az group create -l $location -n $resourceGroup

# Storage account where Azure Functions will keep its data and logs
az storage account create --sku Standard_LRS --location $location --kind Storage -g $resourceGroup -n $storageName.ToLower() --https-only $true

# Creates our Function Application
az functionapp create -n $functionName -g $resourceGroup -s $storageName.ToLower() -c $location --os-type Windows --runtime dotnet
