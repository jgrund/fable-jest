module rec Fable.Import.Jest.Matchers.Test

open Fable.Import.Jest
open Fable.Import.Jest.Matchers

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