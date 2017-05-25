module rec Fable.Import.Jest.Matchers

open Fable.Import.Jest
open Fable.Import.Jest.Bindings

// let firstCall (x:Mock<'A>) =
  // Array.head x?mock?calls

let toEqual expected actual =
  expect.Invoke(expected).toEqual(actual)

let toBeCalledWith expected value =
  expect.Invoke(expected).toBeCalledWith value

let toBeCalledWith2 expected value1 value2 =
  expect.Invoke(expected).toBeCalledWith(value1, value2)