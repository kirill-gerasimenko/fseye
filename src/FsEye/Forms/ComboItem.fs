namespace Swensen.FsEye.Forms
open System.Windows.Forms
open System.Reflection
open Swensen.FsEye

type ComboItem =
    | Plugin of ManagedPlugin
    | Empty 
    with
        override this.ToString () =
            match this with
            | Plugin p -> p.Plugin.Name
            | Empty -> ""
