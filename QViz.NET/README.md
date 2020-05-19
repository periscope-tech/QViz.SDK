# QViz SDK for .NET
**S**oftware **D**evelopment **K**it (**SDK**) for **Q**uality **Vi**suali**z**ations (**QViz**) Product by **Periscope Technologies, Inc.** written in .NET Standard to support both .NET Core and .NET Framework projects.

## Requirements
The following are the required software to build QViz.NET SDK and run NUnit Tests:

* Any Operating System that supports [.NET Core version 3](https://dotnet.microsoft.com/download/dotnet-core/3.0) or later

## Running Locally
The following are the steps for installing and running the QViz.NET SDK in your local system:

1. Make sure you have the **.NET Core version 3** or later installed in the Local system.
2. Clone this Repository in any User accessible location: `git clone <repository-url>`
3. Switch to the Repository location: `cd <repository-folder-name>\QViz.NET`
4. Install the NuGet packages and build the Project: `dotnet build QViz.NET.sln`
5. Run the Unit Tests: `dotnet test QViz.NET.sln`

## Deploying the NuGet Package
The following are the steps for deploying the QViz.NET SDK Package in the NuGet Repository:

1. Get your Personal Access Token from GitHub following [this Guide](https://help.github.com/en/github/authenticating-to-github/creating-a-personal-access-token-for-the-command-line).
2. Download [NuGet Command-Line Tool](https://www.nuget.org/downloads) and install it in your local system.
3. Execute the following command to add the `periscope-tech` NuGet repository to your sources (replace `YOUR-USERNAME` and `YOUR-TOKEN` with your GitHub User Name and Personal Access Token):
```
nuget source add -Name periscope-tech -Source https://nuget.pkg.github.com/periscope-tech/index.json -Username YOUR-USERNAME -Password YOUR-TOKEN
```
4. Switch to the Repository location: `cd <repository-folder-name>\QViz.NET`
5. Update the Version information (`periscope-tech` NuGet Repository is immutable and will not accept an existing version being deployed again) in [Periscope.QViz\Periscope.QViz.csproj](Periscope.QViz/Periscope.QViz.csproj) file in the following sections:
    1. `<PropertyGroup><Version>`
    2. `<PropertyGroup><PackageVersion>`
    4. `<PropertyGroup><AssemblyVersion>`
    5. `<PropertyGroup><FileVersion>`
6. Build and Deploy the Package to the NuGet Repository using the following commands (replace `VERSION` with the actual version number as updated):
```
dotnet build QViz.NET.sln --configuration Release

dotnet nuget push "Periscope.QViz/bin/Release/Periscope.QViz.VERSION.nupkg" --source "periscope-tech"
```

## Generating the Doxygen Documentation
The following are the steps for generating the [Doxygen](http://www.doxygen.org/index.html) documentation site for QViz.NET SDK:

1. Download [Doxygen](http://www.doxygen.nl/download.html) for your OS and install as per instructions in the link.
2. Switch to the Project location: `cd <repository-folder-name>\QViz.NET\Periscope.QViz`
3. Make sure to update Version, Paths and other settings as per your local system correctly in the [Doxyfile](Periscope.QViz/Doxyfile) file.
4. Generate the Documentation site: `doxygen Doxyfile`
5. Now you can browse the [Periscope.QViz\Doxygen\html\index.html](Periscope.QViz/Doxygen/html/index.html) file in any Browser.

## Information

### Technical Architect
Srinivasan Annamalai ([srinivasan.annamalai@qviz.io](mailto:srinivasan.annamalai@qviz.io))

### Technical Support
QViz Support <[support@qviz.io](mailto:support@qviz.io)>

### Copyright
Copyright © 2018-2020, **Periscope Technologies, Inc.** All Rights Reserved.
