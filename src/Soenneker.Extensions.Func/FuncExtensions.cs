using System.Threading.Tasks;
using System;
using System.Threading;

namespace Soenneker.Extensions.Func;

/// <summary>
/// A collection of helpful Func extension methods
/// </summary>
public static class FuncExtensions
{
    /// <summary>
    /// Wraps a synchronous function in a task that has not been scheduled or started.
    /// </summary>
    /// <typeparam name="TResult">The function result type.</typeparam>
    /// <param name="func">The synchronous function to invoke.</param>
    /// <returns>A task in the <see cref="TaskStatus.Created"/> state. The caller must start it before awaiting completion.</returns>
    public static Task<TResult> ToTask<TResult>(this Func<TResult> func)
    {
        return new Task<TResult>(func);
    }

    /// <summary>
    /// Equivalent to <code>Task.Run(func)</code>
    /// </summary>
    /// <returns>A task equivalent to <code>Task.Run(func)</code>.</returns>
    public static Task<TResult> RunAsync<TResult>(this Func<TResult> func, CancellationToken cancellationToken = default)
    {
        return Task.Run(func, cancellationToken);
    }
}
