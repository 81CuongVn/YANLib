﻿using static System.Math;
using static System.Nullable;

namespace YANLib.Collection;

public static partial class YANEnumerable
{
    /// <summary>
    /// Splits a given <see cref="List{T}"/> into smaller chunks of a specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="srcs">The source list to be chunked.</param>
    /// <param name="chunkSize">The maximum number of elements in each chunk.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="List{T}"/>s, where each inner list has a maximum size of <paramref name="chunkSize"/>.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this List<T> srcs, int chunkSize)
    {
        if (srcs?.Count > 0 && chunkSize > 0)
        {
            var cnt = srcs.Count;
            for (var i = 0; i < cnt; i += chunkSize)
            {
                yield return srcs.GetRange(i, Min(chunkSize, cnt - i));
            }
        }
        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Cleans a given <see cref="IEnumerable{T}"/> by removing null or whitespace elements depending on the type of T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="srcs">The source enumerable to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains only non-null or non-whitespace elements.</returns>
    public static IEnumerable<T>? Clean<T>(this IEnumerable<T> srcs)
    {
        if (srcs?.Any() == true)
        {
            var t = typeof(T);
            if (t.IsClass || GetUnderlyingType(t) != null)
            {
                foreach (var item in srcs)
                {
                    if (item != null)
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                foreach (var item in srcs)
                {
                    yield return item;
                }
            }
        }
        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Cleans a given <see cref="IList{T}"/> by removing null or whitespace elements depending on the type of T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="srcs">The source list to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains only non-null or non-whitespace elements.</returns>
    public static IEnumerable<T>? Clean<T>(this IList<T> srcs)
    {
        if (srcs?.Count > 0)
        {
            var t = typeof(T);
            var cnt = srcs.Count;
            if (t.IsClass || GetUnderlyingType(t) != null)
            {
                for (var i = 0; i < cnt; i++)
                {
                    T item = srcs[i];
                    if (item != null)
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                for (var i = 0; i < cnt; i++)
                {
                    yield return srcs[i];
                }
            }
        }
        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Cleans a given enumerable of strings by removing null or whitespace elements, returning a new enumerable that contains only non-null and non-whitespace elements.
    /// </summary>
    /// <param name="srcs">The source enumerable of strings to be cleaned.</param>
    /// <returns>An enumerable of strings that contains only non-null or non-whitespace elements, or null if the input enumerable is null.</returns>
    public static IEnumerable<string>? Clean(this IEnumerable<string> srcs)
    {
        if (srcs?.Any() == true)
        {
            foreach (var item in srcs)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Cleans a given list of strings by removing null or whitespace elements, returning a new enumerable that contains only non-null and non-whitespace elements.
    /// </summary>
    /// <param name="srcs">The source list of strings to be cleaned.</param>
    /// <returns>An enumerable of strings that contains only non-null or non-whitespace elements, or null if the input list is null.</returns>
    public static IEnumerable<string>? Clean(this IList<string> srcs)
    {
        if (srcs?.Count > 0)
        {
            foreach (var item in srcs)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            yield break;
        }
    }
}
