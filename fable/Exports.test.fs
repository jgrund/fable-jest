module rec Fable.Import.Jest.Exports.Test

open Fable.Import.Jest

describe "test suite" <| fun () ->
  it "should add numbers" <| fun () ->
    expect.Invoke(3).toEqual(3)

  it "should test identity" <| fun () ->
    expect.Invoke(1).toBe(1)

  test "should work with assertions" <| fun () ->
    expect.assertions(2)

    expect.Invoke("foo").toBe("foo")
    expect.Invoke("bar").toBe("bar")


  describe "mocking" <| fun () ->
    let mutable mock = id
    
    beforeEach <| fun () ->
      mock <- jest.fn()

    it "should assert calls" <| fun () ->
      mock("foo") |> ignore
      expect.Invoke(mock).toBeCalledWith("foo")

