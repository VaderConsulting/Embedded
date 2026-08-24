rem * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
rem *                  .NET Micro Framework version converter                 *
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
rem * The purpose of this script is to create copies of the project files for *
rem * different versions of the .NET Micro Framework.                         *
rem * The .NETMF doesn't have downwards compatibility on DLL files, so with   *
rem * this, it's possible to use the same source code for different versions. *
rem * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

rem Confirms if we want to overwrite the files
if MsgBox("Are you sure you want to overwrite the 4.2 project files?", vbYesNo, "Generate Beta Project") = vbNo then WScript.Quit(1)

rem Converts a project file from 4.1 to 4.2
Sub Convert(FromFile, ToFile)
	rem Generic File System Object
	Set FSO = CreateObject("Scripting.FileSystemObject")
	
	rem Reads the full file
	Set ReadFile = FSO.OpenTextFile(FromFile, 1)
	Source = ReadFile.ReadAll()
	
	rem Makes some small modifications
	Target = Replace(Source, "<TargetFrameworkVersion>v4.1", "<TargetFrameworkVersion>v4.2")
	Target = Replace(Target, "<OutputPath>..\Release\", "<OutputPath>..\Release (4.2)\")
	Target = Replace(Target, "<DocumentationFile>..\Release\", "<DocumentationFile>..\Release (4.2)\")
	Target = Replace(Target, "<OutputPath>..\..\Release\", "<OutputPath>..\..\Release (4.2)\")
	Target = Replace(Target, "<DocumentationFile>..\..\Release\", "<DocumentationFile>..\..\Release (4.2)\")
	Target = Replace(Target, "<ProjectReference Include=""..\Toolbox.NETMF.csproj"">", "<ProjectReference Include=""..\Toolbox.NETMF (4.2).csproj"">")
	
	rem Writes the new file
	set WriteFile = FSO.OpenTextFile(ToFile, 2, true)
	WriteFile.Write(Target)
End Sub 

rem Converts all related project files
Convert "Toolbox.NETMF.csproj", "Toolbox.NETMF (4.2).csproj"
Convert "Hardware\Toolbox.NETMF.Hardware.csproj", "Hardware\Toolbox.NETMF.Hardware (4.2).csproj"
Convert "NET\Toolbox.NETMF.NET.csproj", "NET\Toolbox.NETMF.NET (4.2).csproj"

msgbox("Completed")