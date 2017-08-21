module Fable.Import.Jest.Test.Main

open Fable.Core.JsInterop

// This is necessary to collect all test files
importAll "./Exports.test.fs"
importAll "./Matchers.test.fs"
importAll "./Bindings.test.fs"
