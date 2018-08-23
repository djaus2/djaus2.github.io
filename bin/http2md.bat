@echo on

if %3.==. GOTO NoRaw
GOTO Raw

:Raw
set "RefLink=--parse-raw"

:NoRaw
set RefLink=

IF %1.==. GOTO No1
IF %2.==. GOTO No1

@echo Going

curl %1 > temp.html


if exist temp.html (
GOTO Do3
) 

 ECHO File not found
GOTO End1


:Do3
ECHO Converting temp.html to %2.md 
pandoc temp.html -o temp.md  %RefLink%
echo --- > %2.md
echo layout: default >> %2.md
echo title: "%2" >> %2.md
echo --- >> %2.md
echo.  >> %2.md
type temp.md >> %2.md
del /q temp.md
del /q temp.html
GOTO End1

:No1
ECHO.
ECHO HTML to Markdown
ECHO -----------------
ECHO Must be HTML document
ECHO.
ECHO No param 1: Need HTML document filename or basename
ECHO.
ECHO Uses Pandoc
ECHO Raw option if there is a second parameter


GOTO End1


:End1
