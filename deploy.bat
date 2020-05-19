@ECHO OFF
SET URL=https://maven.pkg.github.com/periscope-tech/QViz.SDK
SET REPO=periscope-tech
SET VERSION=%1

@ECHO Building the QViz SDK Documentation Site
CALL cd docs
CALL del /s /q /f public
CALL hugo
CALL cd ..

@ECHO Building the QViz.Java SDK Package
CALL cd QViz.Java
CALL mvn clean install -DskipTests
CALL mvn javadoc:jar -DskipTests
CALL mvn source:jar -DskipTests

@ECHO Building the QViz.Java SDK Reference Documentation
CALL mvn site -DskipTests

@ECHO Deploying the QViz.Java SDK Package Version %VERSION% to Maven Repository...
CALL mvn deploy:deploy-file -Durl=%URL% ^
	-DrepositoryId=%REPO% ^
	-Dfile=target\QViz-%VERSION%.jar ^
	-DpomFile=pom.xml ^
	-Dsources=target\QViz-%VERSION%-sources.jar ^
	-Djavadoc=target\QViz-%VERSION%-javadoc.jar
CALL cd ..

@ECHO Building the QViz.NET SDK Package
CALL cd QViz.NET\Periscope.QViz
CALL dotnet pack --configuration Release

@ECHO Building the QViz.NET SDK Reference Documentation
CALL del /s /q /f Doxygen
CALL doxygen Doxyfile

@ECHO Deploying the QViz.NET SDK Package Version %VERSION% to NuGet Repository...
CALL dotnet nuget push "bin/Release/Periscope.QViz.%VERSION%.nupkg" --source "periscope-tech"
CALL cd ..\..
