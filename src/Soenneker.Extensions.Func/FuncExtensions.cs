using System.Threading.Tasks;
using System;
using System.Threading;

namespace Soenneker.Extensions.Func;

/// <summary>
/// A collection of helpful Func extension methods
/// </summary>
public static class FuncExtensions
{
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