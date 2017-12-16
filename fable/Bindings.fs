module Fable.Import.Jest.Bindings

open System.Text.RegularExpressions
open Fable.Core

type [<AllowNullLiteral>] Expect =
  /// If you know how to test something, ```.not``` lets you test its opposite.
  abstract not: Expect with get, set
  /// Use resolves to unwrap the value of a fulfilled promise so any other matcher can be chained. If the promise is rejected the assertion fails.
  abstract resolves: Expect with get, set
  /// Use ```.rejects``` to unwrap the reason of a rejected promise so any other matcher can be chained. If the promise is fulfilled the assertion fails.
  abstract rejects: Expect with get, set
  /// Use ```.toEqual``` when you want to check that two objects have the same value. This matcher recursively checks the equality of all fields, rather than checking for object identity—this is also known as "deep equal".
  abstract toEqual: 'a -> unit
  /// toBe just checks that a value is what you expect. It uses === to check strict equality.
  abstract toBe: 'a -> unit
  /// Use ```.toBeCalled``` to ensure that a mock function got called.
  abstract toBeCalled: unit -> unit
  /// Use ```.toHaveBeenCalled``` to ensure that a mock function got called.
  abstract toHaveBeenCalled: unit -> unit
  /// Use ```.toHaveBeenCalledTimes``` to ensure that a mock function got called exact number of times.
  abstract toHaveBeenCalledTimes: int -> unit
  ///  Use ```.toBeCalledWith``` to ensure that a mock function was called with specific arguments.
  abstract toBeCalledWith:'a -> unit
  abstract toBeCalledWith:'a * 'b -> unit
  abstract toBeCalledWith:'a * 'b * 'c -> unit
  abstract toBeCalledWith:'a * 'b * 'c * 'd -> unit
  abstract toBeCalledWith:'a * 'b * 'c * 'd * 'e -> unit
  /// If you have a mock function, you can use ```.lastCalledWith``` to test what arguments it was last called with
  abstract lastCalledWith:'a -> unit
  abstract lastCalledWith:'a * 'b -> unit
  abstract lastCalledWith:'a * 'b * 'c -> unit
  abstract lastCalledWith:'a * 'b * 'c * 'd -> unit
  abstract lastCalledWith:'a * 'b * 'c * 'd * 'e -> unit
  abstract toBeCloseTo: float -> int -> unit
  /// Use .toBeDefined to check that a variable is not undefined
  abstract toBeDefined: unit -> unit
  /// Use ```.toBeFalsy``` when you don't care what a value is, you just want to ensure a value is false in a boolean context
  abstract toBeFalsy: unit -> unit
  /// To compare floating point numbers, you can use toBeGreaterThan.
  abstract toBeGreaterThan: int -> unit
  abstract toBeGreaterThan: float -> unit
  /// To compare floating point numbers, you can use toBeGreaterThanOrEqual.
  abstract toBeGreaterThanOrEqual: int -> unit
  abstract toBeGreaterThanOrEqual: float -> unit
  /// To compare floating point numbers, you can use toBeLessThan.
  abstract toBeLessThan: int -> unit
  abstract toBeLessThan: float -> unit
  /// To compare floating point numbers, you can use toBeLessThanOrEqual.
  abstract toBeLessThanOrEqual: int -> unit
  abstract toBeLessThanOrEqual: float -> unit
  /// ```.toBeNull()``` is the same as ```.toBe(null)``` but the error messages are a bit nicer.
  abstract toBeNull: unit -> unit
  /// Use ```.toBeTruthy``` when you don't care what a value is, you just want to ensure a value is true in a boolean context.
  abstract toBeTruthy: unit -> unit
  /// Use ```.toBeUndefined``` to check that a variable is undefined
  abstract toBeUndefined: unit -> unit
  /// Use ```.toContain``` when you want to check that an item is in an array.
  abstract toContain: 'a -> unit
  /// Use ```.toContainEqual``` when you want to check that an item is in a list. For testing the items in the list, this matcher recursively checks the equality of all fields, rather than checking for object identity.
  abstract toContainEqual: 'a -> unit
  /// Use ```.toHaveLength``` to check that an object has a ```.length``` property and it is set to a certain numeric value.
  /// This is especially useful for checking arrays or strings size.
  abstract toHaveLength: int -> unit
  /// Use ```.toMatch``` to check that a string matches a regular expression.
  abstract toMatch: Regex -> unit
  abstract toMatch: string -> unit
  /// Use ```.toMatchObject``` to check that a JavaScript object matches a subset of the properties of an object. It will match received objects with properties that are not in the expected object.
  /// You can also pass an array of objects, in which case the method will return true only if each object in the received array matches (in the toMatchObject sense described above) the corresponding object in the expected array. This is useful if you want to check that two arrays match in their number of elements, as opposed to arrayContaining, which allows for extra elements in the received array.
  abstract toMatchObject: obj -> unit
  /// Use ```.toHaveProperty``` to check if property at provided reference keyPath exists for an object. For checking deeply nested properties in an object use dot notation for deep references.
  /// Optionally, you can provide a value to check if it's equal to the value present at keyPath on the target object. This matcher uses 'deep equality' (like toEqual()) and recursively checks the equality of all fields.
  abstract toHaveProperty: string -> 'a option -> unit
  /// This ensures that a value matches the most recent snapshot. Check out the Snapshot Testing guide for more information.
  /// You can also specify an optional snapshot name. Otherwise, the name is inferred from the test.
  abstract toMatchSnapshot: unit -> unit
  abstract toMatchSnapshot: string -> unit
  /// Use ```.toThrow``` to test that a function throws when it is called.
  /// If you want to test that a specific error gets thrown, you can provide an argument to toThrow. The argument can be a string for the error message, a class for the error, or a regex that should match the error.
  abstract toThrow: unit -> unit
  abstract toThrow: System.Exception -> unit
  abstract toThrow: string -> unit
  abstract toThrow: Regex -> unit
  /// Use ```.toThrowErrorMatchingSnapshot``` to test that a function throws an error matching the most recent snapshot when it is called.
  abstract toThrowErrorMatchingSnapshot: unit -> unit



/// When you're writing tests, you often need to check that values meet certain conditions.
/// expect gives you access to a number of "matchers" that let you validate different things.
type [<AllowNullLiteral>] ExpectStatic =
  [<Emit("$0($1)")>] abstract Invoke: 'a -> Expect
  /// You can use expect.extend to add your own matchers to Jest.
  abstract extend: obj -> unit
  /// ```expect.anything()``` matches anything but null or undefined.
  /// You can use it inside toEqual or toBeCalledWith instead of a literal value.
  /// For example, if you want to check that a mock function is called with a non-null argument:
  abstract anything: unit -> 'a
  /// ```expect.any``` constructor matches anything that was created with the given constructor.
  /// You can use it inside toEqual or toBeCalledWith instead of a literal value.
  abstract any: 'a -> 'b
  /// ```expect.arrayContaining array``` matches a received array
  /// which contains all of the elements in the expected array.
  /// That is, the expected array is a subset of the received array.
  /// Therefore, it matches a received array which contains elements that are not in the expected array.
  /// You can use it instead of a literal value:
  ///   - in toEqual or toBeCalledWith
  ///   - to match a property in objectContaining or toMatchObject
  abstract arrayContaining: 'a [] -> unit
  /// ```expect.assertions int``` verifies that a certain number of assertions are called during a test. This is often useful when testing asynchronous code, in order to make sure that assertions in a callback actually got called.
  abstract assertions: int -> unit
  /// ```expect.hasAssertions()``` verifies that at least one assertion is called during a test. This is often useful when testing asynchronous code, in order to make sure that assertions in a callback actually got called.
  abstract hasAssertions: unit -> unit
  /// ```expect.objectContaining object``` matches any received object that recursively matches the expected properties. That is, the expected object is a subset of the received object. Therefore, it matches a received object which contains properties that are not in the expected object.
  /// Instead of literal property values in the expected object, you can use matchers, expect.anything(), and so on.
  abstract objectContaining: obj -> unit
  /// ```expect.stringContaining string``` matches any received string that contains the exact expected string.
  abstract stringContaining: string -> unit
  /// ```expect.stringMatching regexp``` matches any received string that matches the expected regexp.
  /// You can use it instead of a literal value:
  ///   - in toEqual or toBeCalledWith
  ///   - to match an element in arrayContaining
  ///   - to match a property in objectContaining or toMatchObject
  abstract stringMatching: Regex -> unit
  /// You can call ```expect.addSnapshotSerializer``` to add a module that formats application-specific data structures.
  /// For an individual test file, an added module precedes any modules from snapshotSerializers configuration, which precede the default snapshot serializers for built-in JavaScript types and for React elements. The last module added is the first module tested.
  abstract addSnapshotSerializer: obj -> unit

type [<AllowNullLiteral>] DoneStatic =
  [<Emit("$0()")>] abstract ``done``: 'a -> unit
  abstract fail: 'a -> 'b

type [<AllowNullLiteral>] Virtual =
  abstract ``virtual``: bool with get, set

type [<AllowNullLiteral>] Mock<'A> =
  abstract calls: 'A []

type [<AllowNullLiteral>] JestStatic =
  [<Emit("$0.fn()")>] abstract fn1: unit -> ('a -> 'b)
  [<Emit("$0.fn($1)")>] abstract fn1: ('a -> 'b) -> ('a -> 'b)
  [<Emit("$0.fn()")>] abstract fn2: unit -> ('a -> 'b -> 'c)
  [<Emit("$0.fn($1)")>] abstract fn2: ('a -> 'b -> 'c) -> ('a -> 'b -> 'c)
  [<Emit("$0.fn($1)")>] abstract fn3: ('a -> 'b -> 'c -> 'd) -> ('a -> 'b -> 'c -> 'd)
  [<Emit("$0.fn()")>] abstract fn3: unit -> ('a -> 'b -> 'c -> 'd)
  abstract mock:string -> unit
  abstract mock:string * (unit -> 'A) -> unit
  abstract mock:string * (unit -> 'A) * Virtual -> unit
  abstract unmock:string -> unit
  abstract enableAutomock: unit -> unit
  abstract disableAutomock: unit -> unit
  abstract isMockFunction: ('A -> 'B) -> bool
  abstract genMockFromModule: string -> 'A
  abstract spyOn: 'A -> string -> Mock<_>
  abstract setTimeout: int -> unit

type IExports =
  abstract Expect: ExpectStatic with get, set
  abstract Jest: JestStatic with get, set
