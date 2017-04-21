try {
    msbuild /t:clean /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # .NET Framework 3.5 Target

    msbuild /t:restore /p:TargetFramework=net35 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild /p:TargetFramework=net35 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # .NET Framework 4.5.1 Target

    msbuild /t:restore /p:TargetFramework=net451 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild /p:TargetFramework=net451 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # .NET Standard 1.4 Target

    msbuild .\TwilioWithThinq\TwilioWithThinQLCR.csproj /t:restore /p:TargetFramework=netstandard1.4 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild .\TwilioWithThinq\TwilioWithThinQLCR.csproj /p:TargetFramework=netstandard1.4 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # Create the NuGet Package

    msbuild .\TwilioWithThinq\TwilioWithThinQLCR.csproj /t:pack /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    Move-Item TwilioWithThinq\bin\Release\TwilioWithThinq.*.nupkg .\
    if ($lastExitCode -ne 0) { exit $lastExitCode }
} catch {
    write-host "Caught an exception:" -ForegroundColor Red
    write-host "Exception Type: $($_.Exception.GetType().FullName)" -ForegroundColor Red
    write-host "Exception Message: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}