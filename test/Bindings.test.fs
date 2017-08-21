module Fable.Import.Jest.Test.Bindings

open Fable.Import.Jest.Exports
open Fable.PowerPack

type Foo = {foo:string; bar:string;}
type Bar = {bar:string;}

describe "expect" <| fun () ->
  test "should contain not" <| fun () ->
    expect.Invoke(3).not.toBe(4)

  test "should contain resolves" <| fun () ->
    expect.Invoke(Promise.lift 3).resolves.toBe(3)

  test "should contain rejects" <| fun () ->
    let p = Fable.Import.JS.Promise.reject("Boom")

    expect.Invoke(p).rejects.toBe("Boom")

  test "should contain toEqual" <| fun () ->
    expect.Invoke(3).toEqual(3)

  test "should contain toBe" <| fun () ->
    expect.Invoke(3).toBe(3)

  test "should contain toBeCloseTo" <| fun () ->
    expect.Invoke(5.0).toBeCloseTo 5.03 1

  test "should contain toBeFalsy" <| fun () ->
    expect.Invoke(false).toBeFalsy()

  test "should contain toBeGreaterThan" <| fun () ->
    expect.Invoke(3).toBeGreaterThan 2

  test "should contain toBeTruthy" <| fun () ->
    expect.Invoke(true).toBeTruthy()

  test "should contain toBeLessThan" <| fun () ->
    expect.Invoke(4).toBeLessThan 5

  test "should contain toBeGreaterThanOrEqual" <| fun () ->
    expect.Invoke(3).toBeGreaterThanOrEqual 3

  test "should contain toBeLessThanOrEqual" <| fun () ->
    expect.Invoke(3).toBeLessThanOrEqual 3

  test "should contain toBeNull" <| fun () ->
    expect.Invoke(null).toBeNull()

  test "should contain toContain" <| fun () ->
    expect.Invoke([| 1;2;3 |]).toContain(3)

  test "should contain toContainEqual" <| fun () ->
    expect.Invoke([| 1;1;1 |]).toContainEqual(1)

  test "should contain toHaveLength" <| fun () ->
    expect.Invoke([||]).toHaveLength 0

  test "should contain toMatch" <| fun () ->
    expect.Invoke("foo").toMatch("fo")

  test "should contain toMatchObject" <| fun () ->
    expect.Invoke({foo = "foo"; bar = "bar"}).toMatchObject({bar = "bar"})

  test "should contain toHaveProperty" <| fun () ->
    expect.Invoke({bar = "bard"}).toHaveProperty "bar" (Some "bard")

  test "should contain toMatchSnapshot" <| fun () ->
    expect.Invoke({foo = "foo"; bar = "bar"}).toMatchSnapshot()

  test "should contain toThrow" <| fun () ->
    expect.Invoke(fun () -> raise (System.Exception "blah")).toThrow()
