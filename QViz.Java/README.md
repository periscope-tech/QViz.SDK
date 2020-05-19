# QViz SDK for Java
**S**oftware **D**evelopment **K**it (**SDK**) for **Q**uality **Vi**suali**z**ations (**QViz**) Product by **Periscope Technologies, Inc.** written in Java 8 to support any JVM based projects.

## Requirements
The following are the required software to build QViz.Java SDK and run JUnit Tests:

* Any Operating System that supports [Java version 8](https://www.oracle.com/technetwork/java/javase/downloads/index.html) or later
* Any Operating System that supports [Maven version 3](https://maven.apache.org/download.cgi) or later

## Running Locally
The following are the steps for installing and running the QViz.Java SDK in your local system:

1. Make sure you have the **Java version 8** or later and **Maven version 3** or later installed in the Local system.
2. Clone this Repository in any User accessible location: `git clone <repository-url>`
3. Switch to the Repository location: `cd <repository-folder-name>\QViz.Java`
4. Install the required Maven packages: `mvn install`
5. Run the Tests: `mvn test`

## Deploying the Maven Package
The following are the steps for deploying the QViz.Java SDK Package in the Maven Repository:

1. Get your Personal Access Token from GitHub following [this Guide](https://help.github.com/en/github/authenticating-to-github/creating-a-personal-access-token-for-the-command-line).
2. Go to your local Maven Repository folder as per your Operating System:
    1. On Windows, it's usually at: `C:\Users\<your-name>\.m2`
    2. On MacOS, it's usually at: `/Users/<your-name>/.m2`
    3. On Linux, it's usually at: `/home/<your-name>/.m2`
3. Create a new `settings.xml` file (or update if one already exists) in that folder with the following contents (replace the `YOUR-USERNAME` and `YOUR-TOKEN` with your GitHub User Name and Personal Access Token):
```
<settings xmlns="http://maven.apache.org/SETTINGS/1.0.0"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xsi:schemaLocation="http://maven.apache.org/SETTINGS/1.0.0
                      https://maven.apache.org/xsd/settings-1.0.0.xsd">
	<servers>
		<server>
			<id>periscope-tech</id>
			<username>YOUR-USERNAME</username>
			<password>YOUR-TOKEN</password>
		</server>
	</servers>
</settings>
```
4. Switch to the Repository location: `cd <repository-folder-name>\QViz.Java`
5. Update the Version information (`periscope-tech` Maven Repository is immutable and will not accept an existing version being deployed again) in [pom.xml](pom.xml) file in the `<version>` block.
6. Build and Deploy the Package to the Maven Repository using the following commands (replace `VERSION` with actual version number as updated):
```
mvn clean install -DskipTests

mvn javadoc:jar -DskipTests

mvn source:jar -DskipTests

mvn deploy:deploy-file -Durl=https://maven.pkg.github.com/periscope-tech/QViz.SDK \
	-DrepositoryId=periscope-tech \
	-Dfile=target/QViz-VERSION.jar \
	-DpomFile=pom.xml \
	-Dsources=target/QViz-VERSION-sources.jar \
	-Djavadoc=target/QViz-VERSION-javadoc.jar
```

## Generating the JavaDoc Documentation
The following are the steps for generating the [JavaDoc](https://docs.oracle.com/javase/9/javadoc/javadoc.htm) documentation site for QViz.Java SDK:

1. Switch to the Repository location: `cd <repository-folder-name>\QViz.Java`
2. Generate the Documentation site: `mvn site`
3. Now you can browse the [target\site\apidocs\index.html](target/site/apidocs/index.html) file in any Browser for JavaDoc API Reference.
4. If you want the full Site, you can browse the [target\site\index.html](target/site/index.html) file in any Browser.

## Information

### Technical Architect
Srinivasan Annamalai ([srinivasan.annamalai@qviz.io](mailto:srinivasan.annamalai@qviz.io))

### Technical Support
QViz Support <[support@qviz.io](mailto:support@qviz.io)>

### Copyright
Copyright © 2018-2020, **Periscope Technologies, Inc.** All Rights Reserved.
