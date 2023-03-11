@ECHO OFF

taskkill /f /im SoTFEditor
xcopy /E /Y .\Update .
rd /s /q .\Update
del SoTFEditor.zip
del TempVersion.txt
start "" SoTFEditor.exe
move nul 2>&0