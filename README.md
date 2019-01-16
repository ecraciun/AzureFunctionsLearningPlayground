# Azure Functions Learning Playground

[![Build status](https://emilcraciun.visualstudio.com/FunctionsPlayground/_apis/build/status/FunctionsPlayground-CI)](https://emilcraciun.visualstudio.com/FunctionsPlayground/_build/latest?definitionId=4)

I just want to take a look into what Azure Functions can do an refresh my hands-on experience :)


## Running the solution

### Prerequisites

1. [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) (or if want you can try out [Visual Studio 2019 Preview](https://visualstudio.microsoft.com/vs/preview/))
	1. Make sure you have the **Azure Development** workload installed
    2. And also the **.NET Core cross-platform development** workload
2. [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1)
3. An Azure Subscription ([Get a free Azure Trial Subscription](https://azure.microsoft.com/en-us/offers/ms-azr-0044p/))

### Locally

Open the solution in Visual Studio. Add a new file to the **FunctionsPlayground** project and name it **local.settings.json**.
Paste in this sample content, and adjust it accordingly for your preferences and environment:

```json
{
  "IsEncrypted": false,
  "Values": {
	"AzureWebJobsDashboard": "UseDevelopmentStorage=true",
	"AzureWebJobsStorage": "UseDevelopmentStorage=true",
	"WEBSITE_CONTENTAZUREFILECONNECTIONSTRING": "UseDevelopmentStorage=true",    
	"FUNCTIONS_EXTENSION_VERSION": "~2",
	"WEBSITE_NODE_DEFAULT_VERSION": "8.11.1",
	"FUNCTIONS_WORKER_RUNTIME": "dotnet",
	"AzureWebJobsSecretStorageType": "files" // temporary fix required for Azure Storage Emulator 5.8.0.0 and Azure Functions latest SDK.
  },
  "ConnectionStrings": {}
}
```

Hit F5 or Ctrl+F5 and have fun!

### Quick deploy to Azure

[![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)


## Resources

- [Azure Functions overview](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview)
- [Azure Durable Functions overview](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview)