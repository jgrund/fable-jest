module rec Jest
open Fable.Core
open Fable.Core.JsInterop

module expect_types =
  type Expect =
    abstract toEqual: 'a -> unit
    abstract toBe: 'a -> unit
    abstract toBeCalledWith: 'a -> unit

  type DoneStatic =
    [<Emit("$0()")>] abstract ``done``: 'a -> unit
    abstract fail: 'a -> 'b

  type ExpectStatic =
    [<Emit("$0($1...)")>] abstract Invoke: 'a -> Expect
    abstract assertions: int -> unit

  type Globals =
    abstract Expect: ExpectStatic with get, set

[<Global>]
let expect: expect_types.ExpectStatic = jsNative

module jest_types =
  type JestStatic =
    abstract fn: unit -> ('A -> 'B)

  and Globals =
    abstract Jest: JestStatic with get, set

[<Global>]
let jest:jest_types.JestStatic = jsNative

[<Global>]
let describe(msg: string) (f: unit -> unit) = jsNative

[<Global>]
let beforeEach f:unit -> unit = jsNative

[<Global("it")>]
let it(msg: string) (f: unit -> unit) = jsNative

[<Global("it")>]
let itDone(msg:string) (f: expect_types.DoneStatic -> unit) = jsNative

[<Global("it")>]
let itAsync(msg: string) (f: unit -> Fable.Import.JS.Promise<'T>) = jsNative

[<Global("test")>]
let test(msg: string) (f: unit -> unit) = jsNative

[<Global("test")>]
let testDone(msg:string) (f: expect_types.DoneStatic -> unit) = jsNative

[<Global("test")>]
let testAsync(msg: string) (f: unit -> Fable.Import.JS.Promise<'T>) = jsNative

let toEqual expected actual =
  expect.Invoke(expected).toEqual(actual)

let toBeCalledWith expected value =
  expect.Invoke(expected).toBeCalledWith(value)
