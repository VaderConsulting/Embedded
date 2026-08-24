@echo off
rem * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
rem *                           Deployment cleanup                            *
rem * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
rem * Copyright 2012 Stefan Thoolen (http://netmftoolbox.codeplex.com/)       *
rem *                                                                         *
rem * Licensed under the Apache License, Version 2.0 (the "License");         *
rem * you may not use this file except in compliance with the License.        *
rem * You may obtain a copy of the License at                                 *
rem *                                                                         *
rem *     http://www.apache.org/licenses/LICENSE-2.0                          *
rem *                                                                         *
rem * Unless required by applicable law or agreed to in writing, software     *
rem * distributed under the License is distributed on an "AS IS" BASIS,       *
rem * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.*
rem * See the License for the specific language governing permissions and     *
rem * limitations under the License.                                          *
rem * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
rem * The purpose of this script is to clean up a lot of 'useless' files      *
rem * before committing to a repository.                                      *
rem * It removes all temporarily files and user preferences. Also, it removes *
rem * images used by the .NET Micro Framework Emulator and other files that   *
rem * should not be in the online repository.                                 *
rem * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

echo Are you sure you want to remove all unnecessary files?
echo Press ENTER to continue or Ctrl+C to stop
pause > nul

rem Visual Studio Solution User Options (Hidden files)
del /s /ah *.suo

rem Visual Studio Project User Options
del /s *.user

rem Emulator memory (are created when forgetting to select a target device and is crappy lost space)
del /s OnBoardFlash.dat

rem Binary folders (will be recreated after opening a project and removing them
rem saves bandwidth for downloaders)
for /f "delims=" %%a in ('dir /s /b /ad bin') do (
	echo Removing directory %%a ...
	rmdir /s /q "%%a"
)

rem Object folders (will be recreated after opening a project and removing them
rem saves bandwidth for downloaders)
for /f "delims=" %%a in ('dir /s /b /ad obj') do (
	echo Removing directory %%a ...
	rmdir /s /q "%%a"
)

rem Emulator folders (are created when forgetting to select a target device and is crappy lost space)
for /f "delims=" %%a in ('dir /s /b /ad DOTNETMF_FS_EMULATION') do (
	echo Removing directory %%a ...
	rmdir /s /q "%%a"
)

rem These files are created when building the framework but aren't required
rem and are property of Secret Labs LLC. They are created because they're a
rem result of using the AnalogInput and PWM classes. Both could become obsolete
rem in a final 4.2 build.
del Release\SecretLabs.NETMF.Hardware.dll
del Release\SecretLabs.NETMF.Hardware.pdb
del Release\be\SecretLabs.NETMF.Hardware.pdbx
del Release\be\SecretLabs.NETMF.Hardware.pe
del Release\le\SecretLabs.NETMF.Hardware.pdbx
del Release\le\SecretLabs.NETMF.Hardware.pe
del Release\SecretLabs.NETMF.Hardware.Netduino.dll
del Release\SecretLabs.NETMF.Hardware.Netduino.pdb
del Release\be\SecretLabs.NETMF.Hardware.Netduino.pdbx
del Release\be\SecretLabs.NETMF.Hardware.Netduino.pe
del Release\le\SecretLabs.NETMF.Hardware.Netduino.pdbx
del Release\le\SecretLabs.NETMF.Hardware.Netduino.pe

del "Release (4.2)\SecretLabs.NETMF.Hardware.dll"
del "Release (4.2)\SecretLabs.NETMF.Hardware.pdb"
del "Release (4.2)\be\SecretLabs.NETMF.Hardware.pdbx"
del "Release (4.2)\be\SecretLabs.NETMF.Hardware.pe"
del "Release (4.2)\le\SecretLabs.NETMF.Hardware.pdbx"
del "Release (4.2)\le\SecretLabs.NETMF.Hardware.pe"
del "Release (4.2)\SecretLabs.NETMF.Hardware.Netduino.dll"
del "Release (4.2)\SecretLabs.NETMF.Hardware.Netduino.pdb"
del "Release (4.2)\be\SecretLabs.NETMF.Hardware.Netduino.pdbx"
del "Release (4.2)\be\SecretLabs.NETMF.Hardware.Netduino.pe"
del "Release (4.2)\le\SecretLabs.NETMF.Hardware.Netduino.pdbx"
del "Release (4.2)\le\SecretLabs.NETMF.Hardware.Netduino.pe"

pause