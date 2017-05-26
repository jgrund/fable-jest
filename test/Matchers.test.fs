module Fable.Import.Jest.Test.Matchers

open Fable.Import.Jest
open Fable.Core

// Track: https://github.com/fable-compiler/Fable/issues/965
// jest.enableAutomock()
// jest.mock "net"
// jest.disableAutomock()

open Fable.Import.Jest.Matchers
open Fable.Import.Node

test "it should have a toEqual function" <| fun () -> 
  toEqual 1 1

test "it should have a toBe function" <| fun () ->
  toBe 1 1

test "it should have a toBeCalledWith function" <| fun () ->
  let mock = jest.fn()

  mock("1")

  toBeCalledWith mock "1"

test "it should have a toBeCalledWith2 function" <| fun () ->
  let mock = jest.fn()

  mock "1" "2"

  toBeCalledWith2 mock "1" "2"

// Track https://github.com/fable-compiler/Fable/issues/965
// test "should work with mocking external deps" <| fun () -> 
//   Net.isIP("foo")

//   (Net :?> obj)?isIP
//   |> getMock 
//   |> fun x -> x.calls
//   |> List.head
//   |> toBe "food"