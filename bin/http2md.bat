@echo on

GOTO SkipRaw

if %3.==. GOTO NoRaw
GOTO Raw

:Raw
set "RefLink=--parse-raw"

:NoRaw
set RefLink=

:SkipRaw

IF %1.==. GOTO No1
IF %2.==. GOTO No1

@echo Going

GOTO SkipCurl

curl %1 > temp.html


if exist temp.html (
GOTO Do3
) 

 ECHO File not found
GOTO End1

:SkipCurl

:Do3
ECHO Converting %1 to %2.md 
rem pandoc temp.html -o temp.md  %RefLink%
pandoc -f html -t markdown %1 > temp1.md
findstr /V ::: temp1.md >temp.md
echo --- > %2.md
echo layout: default >> %2.md
echo title: "%2" >> %2.md
echo --- >> %2.md
echo.  >> %2.md
type temp.md >> %2.md
del /q temp.md
rem del /q temp.html
GOTO End1

:No1
ECHO.
ECHO HTTP to Markdown
ECHO -----------------
ECHO.
ECHO No param 1 and or 2: Need Url and Title
ECHO.
ECHO Uses Pandoc



GOTO End1


:End1
