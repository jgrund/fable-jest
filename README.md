# fable-jest

Fable bindings for Jest. 

[![Build Status](https://travis-ci.org/jgrund/fable-jest.svg?branch=master)](https://travis-ci.org/jgrund/fable-jest)
[![codecov](https://codecov.io/gh/jgrund/fable-jest/branch/master/graph/badge.svg)](https://codecov.io/gh/jgrund/fable-jest)

## Setup

At a minimum, you will need a .babelrc file, jest.config.js, and some package.json entries:

`.babelrc`
```
{
  "presets": [
    [
      "env",
      {
        "targets": {
          "node": "current"
        }
      }
    ]
  ]
}
```

`jest.config.js`
```
module.exports = {
  testEnvironment: 'node',
  moduleFileExtensions: ['js', 'fs', 'fsx'],
  transform: {
    '^.+\\.(fs|fsx)$': 'jest-fable-preprocessor',
    '^.+\\.js$': 'babel-jest'
  },
  testMatch: ['**/**/*.(test.fs|test.fsx)'],
  coveragePathIgnorePatterns: ['packages/*']
};
```
`package.json`
```
  "scripts": {
    "prejest": "sendProjFile",
    "jest": "jest --coverage",
    "test": "dotnet fable npm-run jest",
    "cover": "yarn test -- --coverage"
  },
  "fable": {
    "projLocation": "./Base.fsproj"
  },
  "devDependencies": {
    "jest": "20.0.4",
    "jest-fable-preprocessor": "1.2.4"
  }
```

[jest-fable-preprocessor](https://github.com/jgrund/jest-fable-preprocessor) Will read your project. With this, we can get code coverage and jest file watching.