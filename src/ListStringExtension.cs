using System.Collections.Generic;

namespace Soenneker.Extensions.List.String;

/// <summary>
/// A collection of helpful List{string} extension methods
/// </summary>
public static class ListStringExtension
{
    public static void Replace(this List<string> list, string oldValue, string newValue)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i].Replace(oldValue, newValue);
        }
    }
}