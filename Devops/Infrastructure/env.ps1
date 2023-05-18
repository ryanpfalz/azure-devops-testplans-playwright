param(
    [Parameter()]
    [String]$rgName,
    [String]$location,
    [String]$appServicePlan,
    [String]$appServiceName
)

az group create --name $rgName --location $location

# linux
az appservice plan create --resource-group $rgName --name $appServicePlan --sku "B1" --location $location --is-linux

az webapp create --resource-group $rgName --plan $appServicePlan --name $appServiceName --runtime "DOTNETCORE:6.0"

# windows
# az appservice plan create --resource-group $rgName --name $appServicePlan --sku "F1" --location $location # --is-linux

# az webapp create --resource-group $rgName --plan $appServicePlan --name $appServiceName --runtime "dotnet:6"

# to run: .\Devops\Infrastructure\env.ps1 'azdo-rg' 'centralus' 'azdodemoasp' 'azdodemowebappqa'