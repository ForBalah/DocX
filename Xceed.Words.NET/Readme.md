## Publish new version to RelatedFeed:

Update version in the .nuspec file

**In the solution folder:**

1. nuget pack Xceed.Words.NET.csproj
2. nuget push DocX.1.4.0-dev003.nupkg -ApiKey VSTS -source RelatedFeed