REM @echo off
@echo on

IF %1.==. GOTO No1

@echo Going

if exist %1 (
GOTO Do1
) 

if exist %1.doc (
GOTO Do2
) 

if exist %1.docx (
GOTO Do3
) 

 ECHO File not found
GOTO End1

:Do1
ECHO Converting %1 to %1.md 
pandoc -s %1 --wrap=none --reference-links -t markdown -o %1.md
GOTO End1

:Do2
ECHO Converting %1.doc to %1.md 
pandoc -s %1.doc --wrap=none --reference-links -t markdown -o %1.md
GOTO End1

:Do3
ECHO Converting %1.docx to %1.md 
pandoc -s %1.docx --wrap=none --reference-links -t markdown -o %1.md
GOTO End1

:No1
  ECHO No param 1: Need Word document filename or basename. Can be doc or docx
GOTO End1


:End1
