﻿using MemoryPack.Internal;
using System.Runtime.CompilerServices;

namespace MemoryPack.Formatters;

[Preserve]
public sealed class NullableFormatter<T> : MemoryPackFormatter<T?>
    where T : struct
{
    // Nullable<T> is sometimes serialized on UnmanagedFormatter.
    // to keep same result, check if type is unmanaged.

    [Preserve]
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref T? value)
    {
        if (Helpers.IsUnmanagedPackable<T?>())
        {
            writer.DangerousWriteUnmanaged(value);
            return;
        }

        if (!value.HasValue)
        {
            writer.WriteNullObjectHeader();
            return;
        }
        else
        {
            writer.WriteObjectHeader(1);
        }

        writer.WriteValue(value.Value);
    }

    [Preserve]
    public override void Deserialize(ref MemoryPackReader reader, scoped ref T? value)
    {
        if (Helpers.IsUnmanagedPackable<T?>())
        {
            reader.DangerousReadUnmanaged(out value);
            return;
        }

        if (!reader.TryReadObjectHeader(out var count))
        {
            value = null;
            return;
        }

        if (count != 1) MemoryPackSerializationException.ThrowInvalidPropertyCount(1, count);

        value = reader.ReadValue<T>();
    }
}
