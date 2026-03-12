using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Replace(this List<string> list, string oldValue, string newValue)
    {
        if (list is null)
            throw new ArgumentNullException(nameof(list));

        if (oldValue is null)
            throw new ArgumentNullException(nameof(oldValue));

        if (newValue is null)
            throw new ArgumentNullException(nameof(newValue));

        if (list.Count == 0)
            return;

        // string.Replace throws if oldValue is empty
        if (oldValue.Length == 0)
            return;

        // If they're the same value, no-op.
        // (ReferenceEquals catches the common case where caller passes same instance.)
        if (ReferenceEquals(oldValue, newValue) || string.Equals(oldValue, newValue, StringComparison.Ordinal))
            return;

        Span<string> span = CollectionsMarshal.AsSpan(list);

        for (int i = 0; i < span.Length; i++)
        {
            string? current = span[i];
            if (current is null)
                continue;

            // Replace returns the original instance if oldValue isn't found (no allocation).
            string replaced = current.Replace(oldValue, newValue, StringComparison.Ordinal);

            // Only write back when it actually changed.
            if (!ReferenceEquals(replaced, current))
                span[i] = replaced;
        }
    }
}