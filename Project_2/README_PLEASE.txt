Project dependencies: 
Inside "ConfigAndDeployment_Project_2\XML_Configuration_Editor\Documentation"
there is a shfbproj (sandbox) its references to "XML_Configuration_Editor.csproj" and "XML_Configuration_Editor.XML" might need to be updated.

To start/run automation, from VS2010 command prompt:

msbuild ConfigAndDeployment_Project_2.csproj

Under "ConfigAndDeployment_Project_2" folder
Project 1 is located: "XML_Configuration_Editor"

msbuild tasks will run as follows. 
1.- compile project 1
2.- run NUnit tests
3.- generate documentation
4.- copy files to "This Is My Application" folder under project "ConfigAndDeployment_Project_2" (current folder)
5.- create zip file
6.- move zip file under Project 1 folder "XML_Configuration_Editor" at project level (csproj)

Thanks and regards, 
Oscar. 