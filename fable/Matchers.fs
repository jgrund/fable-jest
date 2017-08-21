module rec Fable.Import.Jest.Matchers

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Jest
open Fable.Import.Jest.Bindings

[<Emit("$0.mock")>]
let getMock (x:obj):Mock<'A> = jsNative

[<Emit("$0")>]
let noCurry (x:obj):obj = jsNative

type [<AllowNullLiteral>] Matcher<'A, 'B> (?impl:'A -> 'B) =
  let fn = jest.fn impl
  member x.Mock:'A -> 'B = fn
  member x.CalledWith (a:'A) =
    expect.Invoke(noCurry(fn)).toBeCalledWith(a)
  member x.LastCalledWith (a:'A) =
    expect.Invoke(noCurry(fn)).lastCalledWith(a)
  member x.Calls:'A[][] = (getMock fn).calls
  member x.LastCall:'A = x.Calls |> Array.last |> Array.last

type [<AllowNullLiteral>] Matcher2<'A, 'B, 'C> (?impl:'A -> 'B -> 'C) =
  let fn = jest.fn impl
  member x.Mock:'A -> 'B -> 'C = fn
  member x.CalledWith (a:'A) (b:'B) =
    expect.Invoke(noCurry(x.Mock)).toBeCalledWith(a, b)
  member x.LastCalledWith (a:'A) (b:'B) =
    expect.Invoke(noCurry(fn)).lastCalledWith(a, b)
  member x.Calls:('A * 'B)[] = (getMock fn).calls
  member x.LastCall:('A * 'B) = x.Calls |> Array.last

type [<AllowNullLiteral>] Matcher3<'A, 'B, 'C, 'D> (?impl:'A -> 'B -> 'C -> 'D) =
  let fn = jest.fn impl
  member x.Mock:'A -> 'B -> 'C -> 'D = fn
  member x.CalledWith (a:'A) (b:'B) (c:'C) =
    expect.Invoke(noCurry(x.Mock)).toBeCalledWith(a, b, c)
  member x.LastCalledWith (a:'A) (b:'B) (c:'C) =
    expect.Invoke(noCurry(fn)).lastCalledWith(a, b, c)
  member x.Calls:('A * 'B * 'C)[] = (getMock fn).calls
  member x.LastCall:('A * 'B * 'C) = x.Calls |> Array.last

let toEqual expected actual =
  expect.Invoke(expected).toEqual(actual)

let toBe expected actual =
  expect.Invoke(expected).toBe(actual)

expect.extend (createObj
    [
    "toEqualSome" ==> fun x y ->
      match x with
      | Some z ->
        let this:obj = Fable.Core.JsInterop.jsThis

        let isEqual:bool = !!(this?equals(z, y))

        match isEqual with
          | true -> createObj ["message" ==> (sprintf "Expected " + (this?utils?printExpected(x) :?> string) + " not to equal " +  (this?utils?printReceived(y) :?> string)); "pass" ==> true]
          | false -> createObj ["message" ==> (sprintf "Expected " + (this?utils?printExpected(x) :?> string) + " to equal " + (this?utils?printReceived(y) :?> string)); "pass" ==> false]
      | None -> createObj ["message" ==> "Expected Some Got None"; "pass" ==> false];
    "toEqualNone" ==> fun x ->
      match x with
      | Some _ -> createObj ["message" ==> "Expected None Got some"; "pass" ==> false]
      | None -> createObj ["message" ==> "Expected not to get None"; "pass" ==> true]
    ]
  )
  |> ignore

let toEqualSome x y =
  expect.Invoke(x)?toEqualSome(y) :?> unit

let toEqualNone (x):unit =
  expect.Invoke(x)?toEqualNone() :?> unit

[<AutoOpen>]
module Assertions =
  /// Asserts the left side is equal to the right.
  let (==) e a = toEqual e a
  /// Asserts the left side is the same reference as the right.
  let (===) e a = toBe e a
