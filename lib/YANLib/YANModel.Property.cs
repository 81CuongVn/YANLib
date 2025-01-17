﻿using static System.Activator;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{
    /// <summary>
    /// Checks whether all properties of the specified object have non-default values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if all properties of the specified object have non-default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties of the specified objects have non-default values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether all properties have non-default values.</returns>
    public static IEnumerable<bool> AllPropertiesNotDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesNotDefault();
        }
    }

    /// <summary>
    /// Checks whether all properties of the specified object have default values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if all properties of the specified object have default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in typeof(T).GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default(T)))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties of the specified objects have default values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether all properties have default values.</returns>
    public static IEnumerable<bool> AllPropertiesDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesDefault();
        }
    }

    /// <summary>
    /// Checks whether any property of the specified object has a value other than the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if any property of the specified object has a value other than the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether any property of the specified objects has a non-default value, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether any property has a non-default value.</returns>
    public static IEnumerable<bool> AnyPropertiesNotDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesNotDefault();
        }
    }

    /// <summary>
    /// Checks whether any property of the specified object has a value equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if any property of the specified object has a value equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether any property of the specified objects has a default value, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether any property has a default value.</returns>
    public static IEnumerable<bool> AnyPropertiesDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesDefault();
        }
    }

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have values that are not equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have values that are not equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties of the specified objects have non-default values, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether all properties, except for the specified names, have non-default values.</returns>
    public static IEnumerable<bool> AllPropertiesNotDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesNotDefault(names);
        }
    }

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have values that are equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have values that are equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties of the specified objects have default values, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether all properties, except for the specified names, have default values.</returns>
    public static IEnumerable<bool> AllPropertiesDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesDefault(names);
        }
    }

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have values that are not equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have values that are not equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether any property of the specified objects has a non-default value, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether any property, except for the specified names, has a non-default value.</returns>
    public static IEnumerable<bool> AnyPropertiesNotDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesNotDefault(names);
        }
    }

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have values that are equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have values that are equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether any property of the specified objects has a default value, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether any property, except for the specified names, has a default value.</returns>
    public static IEnumerable<bool> AnyPropertiesDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesDefault(names);
        }
    }

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have values that are not equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have values that are not equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties of the specified objects have non-default values, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether all properties, except for the specified names, have non-default values.</returns>
    public static IEnumerable<bool> AllPropertiesNotDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesNotDefault(names);
        }
    }

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have values that are equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have values that are equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties of the specified objects have default values, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether all properties, except for the specified names, have default values.</returns>
    public static IEnumerable<bool> AllPropertiesDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesDefault(names);
        }
    }

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have values that are not equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have values that are not equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether any property of the specified objects has a non-default value, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether any property, except for the specified names, has a non-default value.</returns>
    public static IEnumerable<bool> AnyPropertiesNotDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesNotDefault(names);
        }
    }

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have values that are equal to the default value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have values that are equal to the default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether any property of the specified objects has a default value, including all their nested properties and properties in lists, except for properties with the specified names.
    /// If any of the objects is <see langword="null"/>, returns <see langword="false"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to check.</typeparam>
    /// <param name="mdls">The objects to check.</param>
    /// <param name="names">The names of properties to exclude from the check.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing <see langword="true"/> or <see langword="false"/> for each object, indicating whether any property, except for the specified names, has a default value.</returns>
    public static IEnumerable<bool> AnyPropertiesDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesDefault(names);
        }
    }
}
