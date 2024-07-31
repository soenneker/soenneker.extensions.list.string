using System;
using System.Collections.Generic;

namespace Soenneker.Extensions.List.String;

/// <summary>
/// A collection of helpful List{string} extension methods
/// </summary>
public static class ListStringExtension
{
    /// <summary>
    /// Replaces all occurrences of a specified string in each element of the list with another specified string.
    /// </summary>
    /// <param name="list">The list of strings in which to replace substrings.</param>
    /// <param name="oldValue">The string to be replaced.</param>
    /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="list"/>, <paramref name="oldValue"/>, or <paramref name="newValue"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method iterates through each element in the <paramref name="list"/> and replaces all occurrences of <paramref name="oldValue"/> with <paramref name="newValue"/>.
    /// </remarks>
    public static void Replace(this IList<string> list, string oldValue, string newValue)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i].Replace(oldValue, newValue);
        }
    }
}