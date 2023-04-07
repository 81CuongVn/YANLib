﻿using static System.Nullable;

namespace YANLib.Collection;

public static partial class YANList
{
    /// <summary>
    /// Cleans a given <see cref="IEnumerable{T}"/> by removing null or whitespace elements depending on the type of T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="srcs">The source list to be cleaned.</param>
    /// <returns>A new <see cref="List{T}"/> that contains only non-null or non-whitespace elements.</returns>
    public static List<T>? Clean<T>(this IEnumerable<T> srcs)
    {
        if (srcs?.Count() > 0)
        {
            var t = typeof(T);
            if (t.IsClass || GetUnderlyingType(t) != null)
            {
                return srcs.ClnPrcYld().ToList();
            }
        }
        return srcs?.ToList();
    }

    /// <summary>
    /// Cleans a given <see cref="IList{T}"/> by removing null or whitespace elements depending on the type of T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="srcs">The source list to be cleaned.</param>
    /// <returns>A new <see cref="List{T}"/> that contains only non-null or non-whitespace elements.</returns>
    public static List<T>? Clean<T>(this IList<T> srcs)
    {
        if (srcs?.Count > 0)
        {
            var t = typeof(T);
            if (t.IsClass || GetUnderlyingType(t) != null)
            {
                return srcs.ClnPrcYld().ToList();
            }
        }
        return srcs?.ToList();
    }

    /// <summary>
    /// Cleans a given list string by removing null or whitespace elements, returning a new list that contains only non-null and non-whitespace elements.
    /// </summary>
    /// <param name="srcs">The source list to be cleaned.</param>
    /// <returns>A new list string that contains only non-null or non-whitespace elements, or null if the input list is null.</returns>
    public static List<string>? Clean(this IEnumerable<string> srcs) => srcs?.Count() > 0 ? srcs.ClnPrcYld().ToList() : srcs?.ToList();

    public static List<string>? Clean(this IList<string> srcs) => srcs?.Count > 0 ? srcs.ClnPrcYld().ToList() : srcs?.ToList();
}
