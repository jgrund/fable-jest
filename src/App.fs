module Jest
open Fable.Core
open Fable.Core.JsInterop

module expect_types =
  type Expect =
    abstract toEqual: 'a -> unit
    abstract toBe: 'a -> unit
    abstract toBeCalledWith: 'a -> unit

  and ExpectStatic =
    [<Emit("$0($1...)")>] abstract Invoke: 'a -> Expect
    abstract assertions: int -> unit

  and Globals =
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
let itAsync(msg: string) (f: unit -> Fable.Import.JS.Promise<'T>) = jsNative

let toEqual expected actual =
  expect.Invoke(expected).toEqual(actual)

let toBeCalledWith expected value =
  expect.Invoke(expected).toBeCalledWith(value)
