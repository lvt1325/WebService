param($installPath, $toolsPath, $package, $project)
 
. (Join-Path $toolsPath "CommonPropertyValues.ps1");
. (Join-Path $toolsPath "ImportMSBuild.ps1");

# Find and remove the property group
$allMatchingProperties = $msbuild.Xml.Properties | Where-Object { $_.Name -eq $inProjectFileUniquePackageRelativeUtilityAssembliesFolderPropertyName };
$firstMatchingProperty = $allMatchingProperties | Select-Object -First 1;

$msbuild.Xml.RemoveChild($firstMatchingProperty.Parent) | Out-Null;

# Find and remove the target
$allMatchingTargets = $msbuild.Xml.Targets | Where-Object { $_.Name -eq $inProjectFileUniqueCopyUtilityAssembliesTargetName };
$firstMatchingTarget = $allMatchingTargets | Select-Object -First 1;

$msbuild.Xml.RemoveChild($firstMatchingTarget) | Out-Null;

# Save the project
$project.Save();
