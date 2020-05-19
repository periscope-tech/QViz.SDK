#!/bin/sh
URL=https://maven.pkg.github.com/periscope-tech/QViz.SDK
REPO=periscope-tech
VERSION=$1

echo Building the QViz SDK Documentation Site
cd docs
rm -rf public
hugo
cd ..

echo Building the QViz.Java SDK Package
cd QViz.Java
mvn clean install -DskipTests
mvn javadoc:jar -DskipTests
mvn source:jar -DskipTests

echo Building the QViz.Java SDK Reference Documentation
mvn site -DskipTests

echo Deploying the QViz.Java SDK Package Version $VERSION to Maven Repository...
mvn deploy:deploy-file -Durl=$URL \
	-DrepositoryId=$REPO \
	-Dfile=target/QViz-$VERSION.jar \
	-DpomFile=pom.xml \
	-Dsources=target/QViz-$VERSION-sources.jar \
	-Djavadoc=target/QViz-$VERSION-javadoc.jar
cd ..

echo Building the QViz.NET SDK Package
cd QViz.NET/Periscope.QViz
dotnet pack --configuration Release

echo Building the QViz.NET SDK Reference Documentation
rm -rf Doxygen
doxygen Doxyfile

echo Deploying the QViz.NET SDK Package Version $VERSION to NuGet Repository...
dotnet nuget push "bin/Release/Periscope.QViz.$VERSION.nupkg" --source "periscope-tech"
cd ../..
