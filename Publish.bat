@echo off

cls

set /p platform=What would you like the publishing platform to be? (Use Microsoft RID System) 

dotnet publish -r %platform% -c Release --no-self-contained