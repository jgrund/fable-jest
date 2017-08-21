module Fable.Import.Jest.Test.Exports

open Fable.Import.Jest
open Fable.PowerPack

describe "test suite" <| fun () ->
  it "should add numbers" <| fun () ->
    expect.Invoke(3).toEqual(3)

  it "should test identity" <| fun () ->
    expect.Invoke(1).toBe(1)

  test "should work with assertions" <| fun () ->
    expect.assertions(2)

    expect.Invoke("foo").toBe("foo")
    expect.Invoke("bar").toBe("bar")

  testAsync "should work with promises" <| fun () ->
    promise {
      expect.Invoke(1).toBe(1)
    }

  describe "mocking" <| fun () ->
    let mutable mock = id

    beforeEach <| fun () ->
      mock <- jest.fn None

    it "should assert calls" <| fun () ->
      mock("foo") |> ignore
      expect.Invoke(mock).toBeCalledWith("foo")
