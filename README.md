# fable-jest

Fable bindings for Jest.

[![Build Status](https://travis-ci.org/jgrund/fable-jest.svg?branch=master)](https://travis-ci.org/jgrund/fable-jest)
[![codecov](https://codecov.io/gh/jgrund/fable-jest/branch/master/graph/badge.svg)](https://codecov.io/gh/jgrund/fable-jest)

## Setup

* Install / update template

  * `dotnet new -i Fable.Template.Jest`

* Create project

  * `dotnet new fable-jest -n my-test-app -lang F#`

* Run the tests
  * `dotnet fable npm-run test`
* Run the tests and output code coverage
  * `dotnet fable npm-run coverage`
* Run the tests in watch mode:

  * In one terminal
    * `dotnet fable start` In a second terminal
    * `npm run test-watch`
      * This will allow you to run all, or just a subset of tests, and will
        re-test the changed files on save.

## More Info

Refer to the
[template readme](https://github.com/jgrund/fable-template-jest/blob/master/Content/README.md)
for more info.
