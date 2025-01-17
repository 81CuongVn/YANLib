﻿namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a double.
    /// Returns the converted <see cref="double"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="double"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static double? ToDouble<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToDouble(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{double}"/> containing the double representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{double}"/> containing the double representations of the objects.</returns>
    public static IEnumerable<double?> ToDouble<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDouble();
        }
    }

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static double? ToDouble(this string str) => double.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{double}"/> containing the double representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{double}"/> containing the double representations of the strings.</returns>
    public static IEnumerable<double?> ToDouble(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDouble();
        }
    }

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="double"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static double? ToDouble<T>(this string str, T dfltVal) where T : struct => double.TryParse(str, out var num) ? num : dfltVal.ToDouble();

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{double}"/> containing the double representations of the strings, using a default value for conversion failures.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for conversion failures.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to use for conversion failures.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{double}"/> containing the double representations of the strings.</returns>
    public static IEnumerable<double?> ToDouble<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDouble(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double? GenerateRandomDouble<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDouble();
        var maxValue = max.ToDouble();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().NextDouble(minValue.Value, maxValue.Value) : default;
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="double"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to generate.</param>
    /// <returns>An <see cref="IEnumerable{double}"/> containing the random double values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<double?> GenerateRandomDoubles<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value between <see cref="double.MinValue"/> and <see cref="double.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="double"/> value between <see cref="double.MinValue"/> and <see cref="double.MaxValue"/>.</returns>
    public static double? GenerateRandomDouble() => GenerateRandomDouble(double.MinValue, double.MaxValue);

    /// <summary>
    /// Generates a random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.</returns>
    public static double? GenerateRandomDouble<T>(T max) where T : struct => GenerateRandomDouble(double.MinValue, max);
}
