@echo off
if EXIST src\bin\Debug\TerrariaServer.exe start src\bin\Debug\TerrariaServer.exe && exit
compile && cp Localisation src\bin\Debug\Localisation && run