module rec Fable.Import.Jest.Matchers

open Fable.Import.Jest
open Fable.Import.Jest.Bindings

// let firstCall (x:Mock<'A>) =
  // Array.head x?mock?calls

let toEqual expected actual =
  expect.Invoke(expected).toEqual(actual)

let toBe expected actual =
  expect.Invoke(expected).toBe(actual)

let toBeCalledWith mock value =
  expect.Invoke(mock).toBeCalledWith value

let toBeCalledWith2 mock value1 value2 =
  expect.Invoke(mock).toBeCalledWith(value1, value2)