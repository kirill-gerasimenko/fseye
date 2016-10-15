[<AutoOpen>]
module Option
    let apply fOpt xOpt = 
        match fOpt,xOpt with
        | Some f, Some x -> Some (f x)
        | _ -> None

    let (.<!>) o f = Option.map f o
    let (.>>=) o f = Option.bind f o

    type OptionBuilder () =
        member this.Bind (m, f) = Option.bind f m
        member this.Return v = Some v
        member this.ReturnFrom v = v
        member this.Zero() = None

    let opt = OptionBuilder ()