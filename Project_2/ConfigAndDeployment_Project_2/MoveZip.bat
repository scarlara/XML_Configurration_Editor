@echo off


rem Clean not used files


rem FOR /f "tokens=4 delims=(=" %%G IN ('%_ping_cmd% ^|find "loss"') DO echo Result is [%%G]
rem save current directory. (Project level)
set currDir=%CD%

cd ..
cd XML_Configuration_Editor
cd XML_Configuration_Editor

set projectDir=%CD%


robocopy "." "%currDir%\This Is My Application" *.* 

rem copy help
cd ..
cd Documentation
cd Help

robocopy . "%currDir%\This Is My Application" Documentation.chm

cd "%currDir%\This Is My Application"

exit 0
 



