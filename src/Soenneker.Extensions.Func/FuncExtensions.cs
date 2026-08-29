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
    /// Invokes a synchronous function immediately and exposes its result as a completed task.
    /// </summary>
    /// <typeparam name="TResult">The function result type.</typeparam>
    /// <param name="func">The synchronous function to invoke.</param>
    /// <returns>A completed task containing the function result.</returns>
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