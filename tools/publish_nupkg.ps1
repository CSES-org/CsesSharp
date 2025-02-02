param($is_release)

$ErrorActionPreference = "Stop"

if ($(Test-Path ./out) -eq $false) {
    mkdir out
} else {
    rm out/* -Recurse -Force
}
$tag = $(git describe --tags --abbrev=0)
$count = $(git rev-list --count HEAD)

if([System.Version]::TryParse($tag, [ref]$null)){
    $ver = [System.Version]$tag
} else {
    $ver = "0.0.0.0"
}

if ($is_release -eq "true") {
    $version = $ver
} else {
    $version = $($ver -as [string]) + "-dev" + $count
}
echo PackageVersion:$($version -as [string])
echo Version:$($ver -as [string])
#dotnet clean

dotnet build -c Release -p:Platform="Any CPU" -p:Version=$($ver -as [string]) -p:PackageVersion=$($version -as [string])
cp ./**/bin/Release/*.nupkg ./out

Get-ChildItem ./out