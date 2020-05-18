# QIF SDK using .NET
Software Development Kit (SDK) for Quality Insights Framework (QIF) Product by **Periscope Technologies, Inc.** written in .NET Standard to support both .NET Core and .NET Framework projects.

## Requirements
The following are the required software to run the .NET Core Tests:

* Any Operating System that supports [.NET Core version 3](https://dotnet.microsoft.com/download/dotnet-core/3.0) or later

## Running Locally
The following are the steps for installing and running the QIF .NET SDK in your local system:

1. Make sure you have the **.NET Core version 3** or later installed in the Local system.
2. Clone this Repository in any User accessible location: `git clone <repository-url>`
3. Switch to the Repository location: `cd <repository-folder-name>\QIF.NET`
4. Install the NuGet packages and build the Project: `dotnet build QIF.NET.sln`
5. Run the Unit Tests: `dotnet test QIF.NET.sln`

## Deploying the NuGet Package
The following are the steps for deploying the QIF .NET SDK Package in the NuGet Repository:

1. Download [NuGet Command-Line Tool](https://www.nuget.org/downloads) and install it in your local system.
2. Setup the [Azure Artifacts Credential Provider](https://github.com/microsoft/artifacts-credprovider#azure-artifacts-credential-provider) following the instructions provided in the link.
3. Switch to the Repository location: `cd <repository-folder-name>\QIF.NET`
4. Add the Periscope-Tech feed: `nuget sources Add -Name "periscope-tech" -Source "https://pkgs.dev.azure.com/periscope-tech/_packaging/periscope-tech/nuget/v3/index.json"`
5. Update the Version information (Periscope-Tech feed is immutable and will not accept an existing version being deployed again) in [Periscope.QIF.csproj](Periscope.QIF.csproj) file in the following sections:
    1. `<PropertyGroup><Version>`
    2. `<PropertyGroup><PackageVersion>`
    3. `<PropertyGroup><ReleaseVersion>`
    4. `<PropertyGroup><AssemblyVersion>`
    5. `<PropertyGroup><FileVersion>`
6. Build the Release version of QIF .NET SDK: `dotnet build QIF.NET.sln -c Release`
7. Deploy the Package to the NuGet Repository: `nuget push -Source "periscope-tech" -ApiKey AzureDevOps bin/Release/Periscope.QIF.<version>.nupkg`

## Generating the Doxygen Documentation
The following are the steps for generating the [Doxygen](http://www.doxygen.org/index.html) documentation site for QIF .NET SDK:

1. Download [Doxygen](http://www.doxygen.nl/download.html) for your OS and install as per instructions in the link.
2. Switch to the Repository location: `cd <repository-folder-name>\QIF.NET`
3. Make sure to update Version, Paths and other settings as per your local system correctly in the [Doxyfile](Doxyfile) file.
4. Generate the Documentation site: `doxygen Doxyfile`
5. Now you can browse the [Doxygen\html\index.html](Doxygen/html/index.html) file in any Browser.

## Information

### Contact
Srinivasan Annamalai ([srinivasan.annamalai@periscope-tech.com](mailto:srinivasan.annamalai@periscope-tech.com))

### Copyright
Copyright © 2018-2020, **Periscope Technologies, Inc.** All Rights Reserved.
