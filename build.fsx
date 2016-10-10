// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake

// Directories
let deployDir           = "./deploy/"
let buildDir            = "./build/"
let pluginsBuildDir     = buildDir </> "plugins"
let pluginsDeployDir    = deployDir </> "plugins"
let pluginsProjects     = ["./src/FsEye.LinqPad.Plugin/FsEye.LinqPad.Plugin.fsproj"]

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir;deployDir]
)

Target "Build" <| fun _ ->
    MSBuildRelease buildDir "Build" ["./src/FsEye/FsEye.fsproj"] |> Log "AppBuild-Output: "
    MSBuildRelease pluginsBuildDir "Build" pluginsProjects |> Log "AppBuild-Output: "

Target "CopyArtefacts" <| fun _ ->
    Copy deployDir ([ "FsEye.dll"; "FSharp.Core.dll"; "Utils.dll" ] |> Seq.map ((</>) buildDir))
    Copy pluginsDeployDir ([ "FsEye.LinqPad.Plugin.dll"; "LINQPad.exe" ] |> Seq.map ((</>) pluginsBuildDir))

// Build order
"Clean"
  ==> "Build"
  ==> "CopyArtefacts"

// start build
RunTargetOrDefault "CopyArtefacts"
