param($installPath, $toolsPath, $package, $project)

. (Join-Path $toolsPath "CommonPropertyValues.ps1");
. (Join-Path $toolsPath "ImportMSBuild.ps1");

# Make the path to the targets file relative.
$projectUri = new-object Uri('file://' + $project.FullName);

# Get current project TargetFramework
$targetFrameworkVersion = $msbuild.Properties | Where-Object { $_.Name -eq "TargetFrameworkVersion" } | Select-Object -First 1;
if($targetFrameworkVersion.EvaluatedValue -eq "v3.5") { $targetFrameworkDir = "net35" };
if($targetFrameworkVersion.EvaluatedValue -eq "v4.0") { $targetFrameworkDir = "net40" };
if($targetFrameworkVersion.EvaluatedValue -ge "v4.5") { $targetFrameworkDir = "net45" };

# Prepare the "TelerikWebUI assemblies" path value:
$UtilityAssembliesDir = [System.IO.Path]::Combine($toolsPath, $inPackageUtilityAssembliesFolderName, $targetFrameworkDir);
$UtilityAssembliesDirTargetUri = new-object Uri('file://' + $UtilityAssembliesDir);
$UtilityAssembliesDirRelativePath = $projectUri.MakeRelativeUri($UtilityAssembliesDirTargetUri).ToString().Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar);

# Declare the properties and add them
$utilityAssembliesRelatedPropertyContainer = $msbuild.Xml.CreatePropertyGroupElement();
$msCSharpTargetsImport = $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith("Microsoft.CSharp.targets") };
$msbuild.Xml.InsertAfterChild($utilityAssembliesRelatedPropertyContainer, $msCSharpTargetsImport);
$utilityAssembliesSourcePathProperty = $utilityAssembliesRelatedPropertyContainer.AddProperty($inProjectFileUniquePackageRelativeUtilityAssembliesFolderPropertyName, $UtilityAssembliesDirRelativePath);
$utilityAssembliesBuildDependsOnProperty = $utilityAssembliesRelatedPropertyContainer.AddProperty("BuildDependsOn", "`$(BuildDependsOn);" + $inProjectFileUniqueCopyUtilityAssembliesTargetName);

# Declare the target and add it:
$copyUtilityAssembliesTarget = $msbuild.Xml.AddTarget($inProjectFileUniqueCopyUtilityAssembliesTargetName);
$utilityAssembliesSourceDirFullPathPropGroup = $copyUtilityAssembliesTarget.AddPropertyGroup();
$inProjectFileUniquePackageRelativeUtilityAssembliesFolderFullPathPropertyName = $inProjectFileUniquePackageRelativeUtilityAssembliesFolderPropertyName + "FullPath";
$inProjectFileUniquePackageRelativeUtilityAssembliesFolderFullPathPropertyValue = "`$([System.IO.Path]::GetFullPath('`$(" + $inProjectFileUniquePackageRelativeUtilityAssembliesFolderPropertyName + ")'))";
$utilityAssembliesSourceDirFullPathPropGroup.AddProperty($inProjectFileUniquePackageRelativeUtilityAssembliesFolderFullPathPropertyName, $inProjectFileUniquePackageRelativeUtilityAssembliesFolderFullPathPropertyValue);
$utilityAssemblyFilesItemGroup = $copyUtilityAssembliesTarget.AddItemGroup();
$utilityAssemblyFilesItemGroupIncludeDeclaration = "`$(" + $inProjectFileUniquePackageRelativeUtilityAssembliesFolderFullPathPropertyName + ")\" + $inPackageUtilityAssemblyName;
$utilityAssemblyFilesItemGroup.AddItem($inProjectFileUniqueUtilityAssembliesItemGroupName, $utilityAssemblyFilesItemGroupIncludeDeclaration);
$copyUtilityAssembliesTask = $copyUtilityAssembliesTarget.AddTask("Copy");
$utilityAssemblyFilesItemGroupUsage = "@(" + $inProjectFileUniqueUtilityAssembliesItemGroupName + ")";
$copyUtilityAssembliesTask.SetParameter("SourceFiles", $utilityAssemblyFilesItemGroupUsage);
$copyUtilityAssembliesTask.SetParameter("DestinationFolder", "`$(TargetDir)");
$copyUtilityAssembliesTask.SetParameter("SkipUnchangedFiles", "true");

# Save the project
$project.Save();
