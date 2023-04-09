﻿namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static decimal ToDecimal(this string str) => decimal.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static decimal ToDecimal<T>(this string str, T dfltVal) where T : struct => decimal.TryParse(str, out var num) ? num : dfltVal.ToDecimal();

    /// <summary>
    /// Converts the specified value to a decimal.
    /// Returns the converted <see cref="decimal"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="decimal"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static decimal ToDecimal<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal GenRandomDecimal<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDecimal();
        var maxValue = max.ToDecimal();
        return minValue > maxValue ? default : new Random().NextDecimal(minValue, maxValue);
    }

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.</returns>
    public static decimal GenRandomDecimal() => GenRandomDecimal(decimal.MinValue, decimal.MaxValue);

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.</returns>
    public static decimal GenRandomDecimal<T>(T max) where T : struct => GenRandomDecimal(decimal.MinValue, max);
}
