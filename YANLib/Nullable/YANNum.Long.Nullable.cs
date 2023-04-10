﻿namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a long integer.
    /// Returns the converted <see cref="long"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="long"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static long? ToLong<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToInt64(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Parses the string representation of a long using the default format.
    /// Returns the parsed <see cref="long"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="long"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static long? ToLong<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToLong(dfltVal.Value) : default;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long? GenRandomLong<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomLong(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long? GenRandomLong<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomLong(min, max.Value) : default;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long? GenRandomLong<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomLong(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <see cref="long.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="long"/> value between <see cref="long.MinValue"/> and <paramref name="max"/>.</returns>
    public static long? GenRandomLong<T>(T? max) where T : struct => max.HasValue ? GenRandomLong(long.MinValue, max.Value) : default;
}
