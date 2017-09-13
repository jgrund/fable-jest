module Fable.Import.Jest.Test.Matchers

open Fable.Import
open Fable.Import.Jest
open Fable.Import.Jest.Matchers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Node
open Fable.PowerPack

test "it should have a toEqual function" <| fun () ->
  toEqual 1 1

test "it should have toEqual sugar" <| fun () ->
  1 == 1

test "it should have toBe sugar" <| fun () ->
  1 === 1

test "it should have a toBe function" <| fun () ->
  toBe 1 1

test "it should have matcher sugar" <| fun () ->
  let m = Matcher()

  m.Mock "1"

  m <?> "1"

test "it should have a matcher" <| fun () ->
  let m = Matcher()

  m.Mock (fun () -> ())

  m.CalledWith (expect.any Fable.Import.JS.Function)

test "it should have a matcher2" <| fun () ->
  let m = Matcher2()

  m.Mock "1" "2"

  m.CalledWith "1" "2"

test "it should have matcher2 sugar" <| fun () ->
  let m = Matcher2()

  m.Mock "1" "2"

  m <??> ("1", "2")

test "it should have a matcher3" <| fun () ->
  let m = Matcher3()

  m.Mock "1" "2" "3"

  m.CalledWith "1" "2" "3"

test "it should track calls for matcher2" <| fun () ->
  expect.assertions 3

  let m = Matcher2()

  m.Mock "0" "1"
  m.Mock "3" "4"

  toEqual m.Calls [|("0", "1"); ("3", "4")|]
  toEqual m.LastCall ("3", "4")
  m.LastCalledWith "3" "4"

test "it should track calls for matcher3" <| fun () ->
  expect.assertions 3

  let m = Matcher3()

  m.Mock "0" "1" "2"
  m.Mock "3" "4" "5"

  toEqual m.Calls [|("0", "1", "2"); ("3", "4", "5")|]
  toEqual m.LastCall ("3", "4", "5")
  m.LastCalledWith "3" "4" "5"

test "it should have matcher3 sugar" <| fun () ->
  let m = Matcher3()

  m.Mock "1" "2" "3"

  m <???> ("1", "2", "3")

test "should work with matching options" <| fun () ->
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

testList "Testing the testList" [
  Test("adding", fun () -> 1 === 1);
  TestDone("waiting", fun (x) ->
    1 === 1

    x.``done``()
  );
  TestAsync("promises", fun () ->
    promise {
      1 === 1
    }
  )
]

testList "testFixtures" [
  let fixture fn () =
    fn(+)

  yield! testFixture fixture [
    "add some stuff", fun (op) -> op 1 2 === 3
  ]

  let doneFixture fn (x:Bindings.DoneStatic) =
    fn(-)

    x.``done``()

  yield! testFixtureDone doneFixture [
    "subtract some stuff", fun (op) -> op 2 1 === 1
  ]

  let asyncFixture fn () =
    promise {
      let! op = Promise.lift(*)

      fn(op)
    }

  yield! testFixtureAsync asyncFixture [
    "multiply some stuff", fun (op) -> op 3 2 === 6
  ]
]
