module Fable.Import.Jest.Util

open Fable.Import.Node
open Fable.PowerPack
let streamToPromise<'a, 'b when 'a :> Stream.Writable<'b>> (x:'a) =
    Promise.create(fun res rej -> 
        let mutable b: 'b list = []

        x.on("data", fun (x:'b) ->
            b <- b @ [x]
        ) 
            |> ignore

        x.once("error", rej)
            |> ignore

        x.once("end", fun () -> res b) 
            |> ignore
    )