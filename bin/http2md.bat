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

curl %1 > %2.html


if exist %2.html (
GOTO Do3
) 

 ECHO File not found
GOTO End1


:Do3
ECHO Converting %2.html to %2.md 
pandoc %2.html -o %2.md  %RefLink%
GOTO End1

:No1
ECHO .
ECHO HTML to Markdown
ECHO -----------------
ECHO Must be HTML document
ECHO .
ECHO No param 1: Need HTML document filename or basename
ECHO .
ECHO Uses Pandoc
ECHO Raw option if there is a second parameter


GOTO End1


:End1
