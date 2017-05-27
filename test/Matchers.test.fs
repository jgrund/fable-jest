module Fable.Import.Jest.Test.Matchers

open Fable.Import.Jest
open Fable.Core
open Fable.Core.JsInterop

jest.mock("net", fun () -> 
  createObj ["isIP" ==> jest.fn()]
)

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

test "it should have a toBeCalledWith3 function" <| fun () ->
  let mock = jest.fn()

  mock "1" "2" "3"

  toBeCalledWith3 mock "1" "2" "3"

test "should work with mocking external deps" <| fun () ->   
  Net.isIP("foo")
    |> ignore

  Net?isIP
  |> getMock
  |> fun x -> x.calls
  |> List.last
  |> List.last
  |> toBe "foo"

test "should work with matching some" <| fun () ->
  expect.assertions 2
  toEqualSome "3" (Some 3)
  toEqualNone None