﻿namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a short using the default format.
    /// Returns the parsed <see cref="short"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="short"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static short? ParseShort(this string str, short? dfltVal) => short.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random nullable <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static short? RandomNumberShort(short? min, short max) => min.HasValue ? YANLib.YANNum.GenRandomShort(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random nullable <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static short? RandomNumberShort(short min, short? max) => max.HasValue ? YANLib.YANNum.GenRandomShort(min, max.Value) : null;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and 1 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and 1.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static short? RandomNumberShort(short? min, short? max) => min.HasValue ? YANLib.YANNum.GenRandomShort(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <see cref="short.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see cref="short.MaxValue"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A nullable <see cref="short"/> value representing a random number between <see cref="short.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static short? RandomNumberShort(short? max) => max.HasValue ? YANLib.YANNum.GenRandomShort(short.MinValue, max.Value) : null;
}
