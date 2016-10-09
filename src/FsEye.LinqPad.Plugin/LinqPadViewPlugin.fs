namespace Swensen.FsEye.Plugins

open System
open System.Windows.Forms
open Swensen.FsEye
open LINQPad

type LinqPadWatchViewer () =
    let panel = new Panel ()
    let webBrowser = new WebBrowser ()

    do
        webBrowser.Dock <- DockStyle.Fill
        webBrowser |> panel.Controls.Add 

    interface IWatchViewer with
        member __.Watch (_,value,_) =
            use writer = Util.CreateXhtmlWriter (enableExpansions=true)
            writer.Write(value)
            webBrowser.DocumentText <- writer.ToString ()
        member __.Control = 
            panel :> Control

type LinqPadPlugin() =
    interface IPlugin with
        member __.Name = 
            "LinqPad->Dump(...)"
        member __.CreateWatchViewer() = 
            () |> LinqPadWatchViewer :> IWatchViewer
        member this.IsWatchable(_,_) =
            true
