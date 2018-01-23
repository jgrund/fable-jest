module Fable.Import.Jest.Test.Util

open Fable.Import.Node
open Fable.Import.Jest
open Util
open Matchers
open Fable.PowerPack

let private from (x:string) = 
  buffer.Buffer.from x

testAsync "streamToPromise" <| fun() ->
  promise {
    let s = stream.PassThrough.Create<Buffer.Buffer>()

    s.write(from "foo")
      |> ignore

    s.``end``(from "bar")
      |> ignore

    let! xs = streamToPromise(s)

    xs == ([ "foo"; "bar" ] |> List.map from)
  }