namespace Swensen.FsEye.Forms

open Swensen.FsEye.WatchModel

[<RequireQualifiedAccess>]
module AppEvents =
    let private watchObjectSelected = new Event<ValueInfo> ()

    let onWatchObjectSelected = watchObjectSelected.Publish
    let triggerWatchObjectSelected = watchObjectSelected.Trigger