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
    /// Executes the to task operation.
    /// </summary>
    /// <typeparam name="TResult">The TResult type.</typeparam>
    /// <param name="func">The func.</param>
    /// <returns>A task containing the result of the operation.</returns>
    public static Task<TResult> ToTask<TResult>(this Func<TResult> func)
    {
        return new Task<TResult>(func);
    }

    /// <summary>
    /// Equivalent to <code>Task.Run(func)</code>
    /// </summary>
    public static Task<TResult> RunAsync<TResult>(this Func<TResult> func, CancellationToken cancellationToken = default)
    {
        return Task.Run(func, cancellationToken);
    }
}