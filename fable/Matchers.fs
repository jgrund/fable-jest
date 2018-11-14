module Fable.Import.Jest.Matchers

open Fable.Core
open Fable.Import
open JsInterop
open Fable.Import.Jest
open Bindings

[<Emit("$0.mock")>]
let getMock (_:obj):Mock<'A> = jsNative

[<Emit("$0")>]
let noCurry (_:obj):obj = jsNative

type [<AllowNullLiteral>] Matcher<'A, 'B> (?impl:'A -> 'B) =
  let fn =
    match impl with
      | Some(x) -> jest.fn1 x
      | None -> jest.fn1()
  member __.Mock:'A -> 'B = fn
  member __.CalledWith (a:'A) =
    expect.Invoke(noCurry(fn)).toBeCalledWith(a)
  member __.LastCalledWith() =
    expect.Invoke(noCurry(fn)).lastCalledWith()
  member __.LastCalledWith (a:'A) =
    expect.Invoke(noCurry(fn)).lastCalledWith(a)
  member __.Calls:'A[][] = (getMock fn).calls
  member x.LastCall:'A = x.Calls |> Array.last |> Array.last

type [<AllowNullLiteral>] Matcher2<'A, 'B, 'C> (?impl:'A -> 'B -> 'C) =
  let fn =
    match impl with
      | Some(x) -> jest.fn2 x
      | None -> jest.fn2()
  member __.Mock(a:'A) (b:'B) = fn a b
  member __.CalledWith (a:'A) (b:'B):unit =
    expect.Invoke(noCurry(fn)).toBeCalledWith(a, b)
  member __.LastCalledWith (a:'A) (b:'B) =
    expect.Invoke(noCurry(fn)).lastCalledWith(a, b)
  member __.Calls:('A * 'B)[] = (getMock fn).calls
  member x.LastCall:('A * 'B) = x.Calls |> Array.last

type [<AllowNullLiteral>] Matcher3<'A, 'B, 'C, 'D> (?impl:'A -> 'B -> 'C -> 'D) =
  let fn =
    match impl with
      | Some(x) -> jest.fn3 x
      | None -> jest.fn3()
  member __.Mock(a:'A) (b:'B) (c:'C) = fn a b c
  member __.CalledWith (a:'A) (b:'B) (c:'C) =
    expect.Invoke(noCurry(fn)).toBeCalledWith(a, b, c)
  member __.LastCalledWith (a:'A) (b:'B) (c:'C) =
    expect.Invoke(noCurry(fn)).lastCalledWith(a, b, c)
  member __.Calls:('A * 'B * 'C)[] = (getMock fn).calls
  member x.LastCall:('A * 'B * 'C) = x.Calls |> Array.last

let toEqual (expected:'A) (actual:'A) =
  expect.Invoke(expected).toEqual(actual)

let toBe (expected:'A) (actual:'A) =
  expect.Invoke(expected).toBe(actual)

let toMatchSnapshot expected =
  expect.Invoke(expected).toMatchSnapshot()

expect.extend (createObj
    [
    "toEqualSome" ==> fun x y ->
      match x with
      | Some z ->
        let this:obj = jsThis

        let isEqual:bool = !!(this?equals(z, y))

        match isEqual with
          | true -> createObj ["message" ==> (sprintf "Expected %A not to equal %A" (this?utils?printExpected(x))  (this?utils?printReceived(y))); "pass" ==> true]
          | false -> createObj ["message" ==> (sprintf "Expected %A  to equal %A" (this?utils?printExpected(x)) (this?utils?printReceived(y))); "pass" ==> false]
      | None -> createObj ["message" ==> "Expected Some Got None"; "pass" ==> false];
    "toEqualNone" ==> fun x ->
      match x with
      | Some _ -> createObj ["message" ==> "Expected None Got some"; "pass" ==> false]
      | None -> createObj ["message" ==> "Expected not to get None"; "pass" ==> true]
    ]
  )
  |> ignore

let toEqualSome x y =
  expect.Invoke(x)?toEqualSome(y) |> ignore

let toEqualNone (x):unit =
  expect.Invoke(x)?toEqualNone() |> ignore

[<AutoOpen>]
module Assertions =
  /// Asserts the left side is equal to the right.
  let (==) e a = toEqual e a
  /// Asserts the left side is the same reference as the right.
  let (===) e a = toBe e a
  /// Assert matcher is lastCalled with arg
  let (<?>) (m:Matcher<_, _>) a = m.LastCalledWith a
  /// Assert matcher2 is lastCalled with args
  let (<??>) (m:Matcher2<_, _, _>) (a, b) = m.LastCalledWith a b
  /// Assert matcher3 is lastCalled with args

  let (<???>) (m:Matcher3<_, _, _, _>) (a, b, c) = m.LastCalledWith a b c

[<AutoOpen>]
module Jesto =
  type Test =
    | Test of string * (unit -> unit)
    | TestDone of string * (DoneStatic -> unit)
    | TestAsync of string * (unit -> JS.Promise<unit>)

  /// Takes a list of tests and runs them.
  let testList (name:string) (xs:seq<Test>) =
    describe name <| fun () ->
      xs
      |> Seq.iter (function
        | Test(s, fn) -> test s fn
        | TestDone(s, fn) -> testDone s fn
        | TestAsync(s, fn) -> testAsync s fn
      )

  /// Creates a fixture to pass into tests.
  let testFixture (fixture: 'a -> unit -> unit) xs =
    xs
      |> Seq.map (fun (name, fn) -> Test(name, fixture(fn)))

  /// Creates a done fixture to pass into tests.
  let testFixtureDone (fixture: 'a -> DoneStatic -> unit) xs =

    xs
      |> Seq.map (fun (name, fn) ->
        TestDone(name, fun x -> fixture fn x)
      )

  /// Creates an async fixture to pass into tests.
  let testFixtureAsync (fixture: 'a -> unit -> JS.Promise<unit>) xs =
    xs
      |> Seq.map (fun (name, fn) -> TestAsync(name, fixture(fn)))
