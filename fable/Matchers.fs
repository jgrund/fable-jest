module rec Fable.Import.Jest.Matchers

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Jest
open Fable.Import.Jest.Bindings

let toEqual expected actual =
  expect.Invoke(expected).toEqual(actual)

let toBe expected actual =
  expect.Invoke(expected).toBe(actual)

[<Emit("expect($0).toBeCalledWith($1)")>]
let toBeCalledWith mock (value):unit = jsNative

[<Emit("expect($0).toBeCalledWith($1, $2)")>]
let toBeCalledWith2 mock value1 (value2):unit = jsNative

[<Emit("expect($0).toBeCalledWith($1, $2, $3)")>]
let toBeCalledWith3 mock value1 value2 (value3):unit = jsNative

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