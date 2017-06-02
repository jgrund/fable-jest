module rec Fable.Import.Jest.Bindings

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.JS


type [<AllowNullLiteral>] Expect =
  abstract not: Expect with get, set
  abstract resolves: Expect with get, set
  abstract rejects: Expect with get, set
  abstract toEqual: 'a -> unit
  abstract toBe: 'a -> unit
  abstract toHaveBeenCalled: unit -> unit
  abstract toHaveBeenCalledTimes: int -> unit
  abstract toBeCalledWith:('a) -> unit
  abstract toBeCalledWith:'a * 'b -> unit
  abstract lastCalledWith:('a) -> unit
  abstract lastCalledWith:'a * 'b -> unit
  abstract toBeDefined: unit -> unit
  abstract toBeFalsy: unit -> unit
  abstract toBeTruthy: unit -> unit
  abstract toHaveProperty: string -> 'a -> unit

type [<AllowNullLiteral>] ExpectStatic =
  [<Emit("$0($1)")>] abstract Invoke: 'a -> Expect
  abstract assertions: int -> unit
  abstract extend: obj -> unit
  abstract any: 'a -> 'a
  abstract anything: unit -> unit
  abstract arrayContaining: 'a list -> unit
  abstract hasAssertions: unit -> unit
  abstract objectContaining: obj -> unit
  abstract stringContaining: string -> unit

type [<AllowNullLiteral>] DoneStatic =
  [<Emit("$0()")>] abstract ``done``: 'a -> unit
  abstract fail: 'a -> 'b

type [<AllowNullLiteral>] Virtual =
  abstract ``virtual``: bool with get, set

type [<AllowNullLiteral>] JestStatic =
  abstract fn: unit -> ('A -> 'B)
  abstract fn: (unit -> 'B) -> ('A -> 'B)
  abstract mock:string -> unit
  abstract mock:string * (unit -> 'A) -> unit
  abstract mock:string * (unit -> 'A) * Virtual -> unit
  abstract unmock:string -> unit
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
