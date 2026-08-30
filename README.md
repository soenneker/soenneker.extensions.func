[![](https://img.shields.io/nuget/v/soenneker.extensions.func.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.func/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.func/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.func/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.func.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.func/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.func/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.func/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Func

Wraps synchronous `Func<TResult>` delegates in either an unstarted `Task<TResult>` or an immediately scheduled task.

## Installation

```bash
dotnet add package Soenneker.Extensions.Func
```

## Create an unstarted task

```csharp
using Soenneker.Extensions.Func;

Func<int> calculate = () => 42;
Task<int> task = calculate.ToTask();

// task.Status == TaskStatus.Created
task.Start();
int result = await task;
```

`ToTask()` uses the `Task<TResult>` constructor. The delegate does not run until the task is explicitly started. Do not await the returned task without starting it; an unstarted task does not schedule itself. `Start(TaskScheduler)` can be used when a particular scheduler is required.

Delegate exceptions are stored on the task and rethrown when it is awaited.

## Schedule immediately

```csharp
int result = await calculate.RunAsync(cancellationToken);
```

`RunAsync()` delegates to `Task.Run(func, cancellationToken)`, normally scheduling the synchronous delegate on the thread pool. A token canceled before scheduling produces a canceled task. Because the delegate itself receives no token, cancellation cannot interrupt it after execution has started; use a token-aware delegate for cooperative cancellation.

These helpers are intended for synchronous work. Do not use them to wrap a `Func<Task<T>>`, which would introduce nested-task or unnecessary scheduling concerns.
