using System.Reflection;
using System.Runtime.CompilerServices;

namespace MemoryPack;

public static class Helpers
{
    static readonly MethodInfo isReferenceOrContainsReferences =
        typeof(RuntimeHelpers).GetMethod("IsReferenceOrContainsReferences")!;

    public static bool IsUnmanagedPackable(Type type)
    {
        return !(bool)isReferenceOrContainsReferences.MakeGenericMethod(type).Invoke(null, null)!
               && !typeof(IAsManagedPackable).IsAssignableFrom(type);
    }

    public static bool IsUnmanagedPackable<T>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<T>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T));
    }

    public static bool IsUnmanagedPackable<TKey, TValue>(Tag<KeyValuePair<TKey, TValue>> tag = default)
    {
        return IsUnmanagedPackable<TKey>() && IsUnmanagedPackable<TValue>();
    }

    public static bool IsUnmanagedPackableTuple<T1>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2, T3>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?, T3?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T3));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2, T3, T4>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?, T3?, T4?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T3)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T4));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2, T3, T4, T5>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?, T3?, T4?, T5?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T3)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T4)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T5));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2, T3, T4, T5, T6>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T3)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T4)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T5)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T6));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2, T3, T4, T5, T6, T7>()
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T3)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T4)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T5)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T6)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T7));
    }

    public static bool IsUnmanagedPackableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>() where TRest: struct
    {
        return !RuntimeHelpers.IsReferenceOrContainsReferences<ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest>>() &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T1)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T2)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T3)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T4)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T5)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T6)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(T7)) &&
               !typeof(IAsManagedPackable).IsAssignableFrom(typeof(TRest));
    }

    public struct Tag<T>
    {
    }
}
