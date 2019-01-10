param (
    [string]$resourceGroup,
    [string]$location = 'westeurope',
    [string]$storageName,
    [string]$functionAppName,
    [string]$applicationInsightsName
)

# Creates a Resource group to hold our application
az group create -l $location -n $resourceGroup

# Storage account where Azure Functions will keep its data and logs
az storage account create --sku Standard_LRS --location $location --kind Storage -g $resourceGroup -n $storageName.ToLower() --https-only $true

# Creates our Function Application
az functionapp create -n $functionAppName -g $resourceGroup -s $storageName.ToLower() -c $location --os-type Windows --runtime dotnet

# Create a new Application Insights resource
az resource create --resource-group $resourceGroup --resource-type "Microsoft.Insights/components" --name $applicationInsightsName --location $location --properties '{\"Application_Type\":\"web\"}' 

# Get instrumentation key
$instrumentationKey = az resource show -g $resourceGroup -n $applicationInsightsName --resource-type "Microsoft.Insights/components" --query properties.InstrumentationKey

# Update Function App settings
az functionapp config appsettings set --name $functionAppName --resource-group $resourceGroup --settings "APPINSIGHTS_INSTRUMENTATIONKEY = $instrumentationKey"
