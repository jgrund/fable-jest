module Fable.Import.Jest.Test.Util

open Fable.Import.Node
open Fable.Import.Jest
open Util
open Matchers
open Fable.PowerPack

let private from (x:string) = 
  Buffer.Buffer.from x

testAsync "streamToPromise" <| fun() ->
  promise {
    let s = Stream.PassThrough.Create<Buffer.Buffer>()

    s.write(from "foo")
      |> ignore

    s.``end``(from "bar")
      |> ignore

    let! xs = streamToPromise(s)

    xs == ([ "foo"; "bar" ] |> List.map from)
  }