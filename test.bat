dotnet test /p:AltCover=true /p:AltCoverCobertura="AltCover.Cobertura.xml" /p:AltCoverAssemblyExcludeFilter="(FSharp.Core||FSharp.Compiler.Service||FSharp.DependencyManager.Nuget||NUnit||.Test||AltCover.Monitor)" -l:trx;LogFileName=TestRunner.TrxResults.xml

"C:\Program Files (x86)\GnuWin32\bin\sed" -i "s/C:\\%NODE_NAME%\\workspace\\%JOB_NAME%\\//g" PipesAsClassesBug.Test\AltCover.Cobertura.xml