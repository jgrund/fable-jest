module Jest
open Fable.Core
open Fable.Core.JsInterop

module jest_types =
  type IExpectation =
    abstract toBeCalledWith: 'A -> unit

  type IGlobals =
    abstract fn: unit -> ('A -> 'B)
  
[<Global>]
let jest:jest_types.IGlobals = jsNative

[<Global>]
let expect expected: jest_types.IExpectation = jsNative

[<Global>]
let beforeEach f:unit -> unit = jsNative

[<Global("it")>]
let it(msg: string) (f: unit -> unit) = jsNative

[<Global("it")>]
let itAsync(msg: string) (f: unit -> Fable.Import.JS.Promise<'T>) = jsNative

[<Emit("expect($0).toEqual($1)")>]
let equals expected actual = jsNative

[<Global>]
let describe(msg: string) (f: unit -> unit) = jsNative