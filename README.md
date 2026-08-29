[![](https://img.shields.io/nuget/v/soenneker.extensions.func.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.func/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.func/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.func/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.func.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.func/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.func/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.func/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Func
A collection of helpful Func extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.Func
```

## Quick start

```csharp
using Soenneker.Extensions.Func;

// Given an existing Func<TResult> named func:
var result = func.ToTask();
```

## Common operations

- `ToTask()` - Wraps the function in a new, unstarted `Task<TResult>`; call `Start()` yourself or use `RunAsync()` to schedule it immediately.
- `RunAsync()` - Equivalent to `Task.Run(func)`
