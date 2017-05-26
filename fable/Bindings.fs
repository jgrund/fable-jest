module rec Fable.Import.Jest.Bindings

open Fable.Core
open Fable.Core.JsInterop

type [<AllowNullLiteral>] Expect =
  abstract toEqual: 'a -> unit
  abstract toBe: 'a -> unit
  abstract toBeCalledWith:('a) -> unit
  abstract toBeCalledWith:'a * 'b -> unit

type [<AllowNullLiteral>] ExpectStatic =
  [<Emit("$0($1)")>] abstract Invoke: 'a -> Expect
  abstract assertions: int -> unit
  abstract any: 'a -> 'a

type [<AllowNullLiteral>] DoneStatic =
  [<Emit("$0()")>] abstract ``done``: 'a -> unit
  abstract fail: 'a -> 'b

type [<AllowNullLiteral>] JestStatic =
  abstract fn: unit -> ('A -> 'B)
  abstract fn: (unit -> 'B) -> ('A -> 'B)
  abstract mock:string -> unit
  abstract mock:string * (unit -> 'A) -> unit
  abstract enableAutomock: unit -> unit
  abstract disableAutomock: unit -> unit
  abstract isMockFunction: ('A -> 'B) -> bool
  abstract genMockFromModule: string -> 'A
  abstract spyOn: 'A -> string -> Mock<_>

type [<AllowNullLiteral>] Mock<'A> =
  abstract calls: List<'A>

type IExports =
  abstract Expect: ExpectStatic with get, set
  abstract Jest: JestStatic with get, set
