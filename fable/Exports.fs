[<AutoOpen>]
module rec Fable.Import.Jest.Exports

open Fable.Core
open Fable.Import.Jest.Bindings

[<Global>]
let expect:ExpectStatic = jsNative

[<Global>]
let jest:JestStatic = jsNative

[<Global>]
let describe(msg: string) (f: unit -> unit):unit = jsNative

[<Global>]
let beforeEach (f:unit -> unit):unit = jsNative

[<Global("it")>]
let it(msg: string) (f: unit -> unit):unit = jsNative

[<Global("it")>]
let itDone(msg:string) (f: DoneStatic -> unit):unit = jsNative

[<Global("it")>]
let itAsync(msg: string) (f: unit -> Fable.Import.JS.Promise<'T>):unit = jsNative

[<Global("test")>]
let test(msg: string) (f: unit -> unit):unit = jsNative

[<Global("test")>]
let testDone(msg:string) (f: DoneStatic -> unit):unit = jsNative

[<Global("test")>]
let testAsync(msg: string) (f: unit -> Fable.Import.JS.Promise<'T>):unit = jsNative

[<Emit("$0.mock")>]
let getMock x:Mock<'A> = jsNative