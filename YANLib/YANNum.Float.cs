﻿namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a single-precision floating-point number.
    /// Returns the converted <see cref="float"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="float"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static float ToFloat<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToSingle(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Parses the string representation of a <see cref="float"/> using the default format.
    /// Returns the parsed <see cref="float"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static float ToFloat(this string str) => float.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Parses the string representation of a float using the default format.
    /// Returns the parsed <see cref="float"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="float"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static float ToFloat<T>(this string str, T dfltVal) where T : struct => float.TryParse(str, out var num) ? num : dfltVal.ToFloat();

    /// <summary>
    /// Generates a random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static float GenRandomFloat<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToFloat();
        var maxValue = max.ToFloat();
        return minValue > maxValue ? default : new Random().NextSingle(minValue, maxValue);
    }

    /// <summary>
    /// Generates a random <see cref="float"/> value between <see cref="float.MinValue"/> and <see cref="float.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="float"/> value between <see cref="float.MinValue"/> and <see cref="float.MaxValue"/>.</returns>
    public static float GenRandomFloat() => GenRandomFloat(float.MinValue, float.MaxValue);

    /// <summary>
    /// Generates a random <see cref="float"/> value between <see cref="float.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="float"/> value between <see cref="float.MinValue"/> and <paramref name="max"/>.</returns>
    public static float GenRandomFloat<T>(T max) where T : struct => GenRandomFloat(float.MinValue, max);
}
