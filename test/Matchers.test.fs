module Fable.Import.Jest.Test.Matchers

open Fable.Import
open Fable.Import.Jest
open Fable.Import.Jest.Matchers
open Fable.Core
open Fable.Core.JsInterop

test "it should have a toEqual function" <| fun () ->
  toEqual 1 1

test "it should have a toBe function" <| fun () ->
  toBe 1 1

test "it should have a matcher" <| fun () ->
  let m = Matcher()

  m.Mock "1"

  m.CalledWith "1"

test "it should have a matcher2" <| fun () ->
  let m = Matcher2()

  m.Mock "1" "2"

  m.CalledWith "1" "2"

test "it should have a matcher3" <| fun () ->
  let m = Matcher3()

  m.Mock "1" "2" "3"

  m.CalledWith "1" "2" "3"

test "should work with matching some" <| fun () ->
  expect.assertions 2
  toEqualSome "3" (Some "3")
  toEqualNone None

describe "mocking external" <| fun () ->
  let mutable Net: obj = null
  let mutable mockMatcher: Matcher<string, float> = null

  beforeEach <| fun () ->
    mockMatcher <- Matcher<string, float>()

    jest.mock("net", fun () ->
      createObj ["isIP" ==> mockMatcher.Mock]
    )

    Net <- Fable.Import.Node.Globals.require.Invoke "net"

  test "should work with mocking external deps" <| fun () ->
    (Net :?> Node.Net.IExports).isIP("foo")
      |> ignore

    toBe "foo" mockMatcher.LastCall
