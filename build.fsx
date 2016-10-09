// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake

// Directories
let buildDir  = "./build/"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "Build" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
    |> Log "AppBuild-Output: "
)

// Build order
"Clean"
  ==> "Build"

// start build
RunTargetOrDefault "Build"
