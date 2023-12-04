using System.Threading.Tasks;
using System;

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
}