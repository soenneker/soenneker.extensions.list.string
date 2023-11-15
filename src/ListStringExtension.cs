using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Soenneker.Extensions.List.String;

/// <summary>
/// A collection of helpful List{string} extension methods
/// </summary>
public static class ListStringExtension
{
    public static void Replace(this IList<string> list, string oldValue, string newValue)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i].Replace(oldValue, newValue);
        }
    }
}