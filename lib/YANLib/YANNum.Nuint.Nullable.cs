﻿namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a <see cref="nuint"/> (an unsigned integer type representing a pointer or a handle).
    /// Returns the converted <see cref="nuint"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="nuint"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static nuint ToNuint<T>(this T? num) where T : struct
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(num));
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Parses the string representation of a <see cref="nuint"/> using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nuint ToNuint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNuint(dfltVal.Value) : default;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint GenerateRandomNuint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNuint(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint GenerateRandomNuint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomNuint(min, max.Value) : default;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint GenerateRandomNuint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNuint(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nuint GenerateRandomNuint<T>(T? max) where T : struct => max.HasValue ? GenerateRandomNuint(nuint.MinValue, max.Value) : default;
}