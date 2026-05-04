using System;
using System.Collections.Generic;

public static class CollectionUtils
{
    public static List<T> Distinct<T>(List<T> source)
    {
        var result = new List<T>();
        var seen = new HashSet<T>();

        foreach (var item in source)
        {
            if (seen.Add(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public static Dictionary<TKey, List<TValue>> GroupBy<TValue, TKey>(
        List<TValue> source,
        Func<TValue, TKey> keySelector) where TKey : notnull
    {
        var groups = new Dictionary<TKey, List<TValue>>();

        foreach (var item in source)
        {
            TKey key = keySelector(item);
            if (!groups.ContainsKey(key))
            {
                groups[key] = new List<TValue>();
            }
            groups[key].Add(item);
        }
        return groups;
    }

    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
        Dictionary<TKey, TValue> first,
        Dictionary<TKey, TValue> second,
        Func<TValue, TValue, TValue> conflictResolver) where TKey : notnull
    {
        var result = new Dictionary<TKey, TValue>(first);

        foreach (var kvp in second)
        {
            if (result.TryGetValue(kvp.Key, out TValue? existingValue))
            {
                result[kvp.Key] = conflictResolver(existingValue, kvp.Value);
            }
            else
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }
        return result;
    }

    public static T MaxBy<T, TKey>(List<T> source, Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        if (source == null || source.Count == 0)
            throw new InvalidOperationException("Sequence contains no elements.");

        T maxItem = source[0];
        TKey maxValue = selector(maxItem);

        for (int i = 1; i < source.Count; i++)
        {
            TKey currentValue = selector(source[i]);
            if (currentValue.CompareTo(maxValue) > 0)
            {
                maxValue = currentValue;
                maxItem = source[i];
            }
        }
        return maxItem;
    }
}
