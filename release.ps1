# .NET api path src\mega.Api\mega.Api.csproj
# react app path src\mega.ClientApp\package.json

# Configuration
$Configuration = "Release"
$OutputPath = "publish"
$ApiProjectPath = "src\mega.Api\mega.Api.csproj"
$ReactAppPath = "src\mega.ClientApp\"

# Clean previous builds
Write-Host "Cleaning previous builds..." -ForegroundColor Yellow
if (Test-Path $OutputPath) {
    Remove-Item -Path $OutputPath -Recurse -Force
}

# Build and publish .NET API
Write-Host "Building and publishing .NET API..." -ForegroundColor Yellow
dotnet publish $ApiProjectPath -c $Configuration -o $OutputPath

# Build React app
Write-Host "Building React app..." -ForegroundColor Yellow
# pnpm install
pnpm --prefix $ReactAppPath run build

# Verify the build
if (Test-Path "$OutputPath\wwwroot") {
    Write-Host "Release completed successfully!" -ForegroundColor Green
    Write-Host "Output location: $((Get-Item $OutputPath).FullName)" -ForegroundColor Green
} else {
    Write-Host "Release failed! Please check the build logs." -ForegroundColor Red
    exit 1
}

