using System;
using System.Collections.Generic;
using MemoryPack.Tests.Models;

namespace MemoryPack.Tests;

public class UnmanagedPackAsManagedTest
{
    [Fact]
    public void TestUnmanagedPackAsManagedStruct()
    {
        var data = new UnmanagedPackAsManagedStruct { X = 1, Y = 2, Z = 3 };
        var bytes = MemoryPackSerializer.Serialize(data);

        var deserialized = MemoryPackSerializer.Deserialize<UnmanagedPackAsManagedStruct>(bytes);

        Assert.Equal(data.X, deserialized.X);
        Assert.Equal(data.Y, deserialized.Y);
        Assert.Equal(0, deserialized.Z);
    }

    [Fact]
    public void TestUnmanagedPackAsManagedArray()
    {
        var data = new UnmanagedPackAsManagedStruct[] { new() { X = 1, Y = 2, Z = 3 }, new() { X = 4, Y = 5, Z = 6} };
        var bytes = MemoryPackSerializer.Serialize(data);

        var deserialized = MemoryPackSerializer.Deserialize<UnmanagedPackAsManagedStruct[]>(bytes)!;

        Assert.Equal(data[0].X, deserialized[0].X);
        Assert.Equal(data[0].Y, deserialized[0].Y);
        Assert.Equal(0, deserialized[0].Z);
        Assert.Equal(data[1].X, deserialized[1].X);
        Assert.Equal(data[1].Y, deserialized[1].Y);
        Assert.Equal(0, deserialized[1].Z);
    }

    [Fact]
    public void TestUnmanagedPackAsManagedList()
    {
        var data = new List<UnmanagedPackAsManagedStruct>
        {
            new() { X = 1, Y = 2, Z = 3 },
            new() { X = 4, Y = 5, Z = 6 },
        };
        var bytes = MemoryPackSerializer.Serialize(data);

        var deserialized = MemoryPackSerializer.Deserialize<UnmanagedPackAsManagedStruct[]>(bytes)!;

        Assert.Equal(data[0].X, deserialized[0].X);
        Assert.Equal(data[0].Y, deserialized[0].Y);
        Assert.Equal(0, deserialized[0].Z);

        Assert.Equal(data[1].X, deserialized[1].X);
        Assert.Equal(data[1].Y, deserialized[1].Y);
        Assert.Equal(0, deserialized[1].Z);
    }

    [Fact]
    public void TestUnmanagedPackAsManagedDictionary()
    {
        var data = new Dictionary<int, UnmanagedPackAsManagedStruct>
        {
            [1] = new() { X = 1, Y = 2, Z = 3 },
            [2] = new() { X = 4, Y = 5, Z = 6 }
        };

        var bytes = MemoryPackSerializer.Serialize(data);

        var deserialized = MemoryPackSerializer.Deserialize<Dictionary<int, UnmanagedPackAsManagedStruct>>(bytes)!;

        Assert.Equal(data[1].X, deserialized[1].X);
        Assert.Equal(data[1].Y, deserialized[1].Y);
        Assert.Equal(0, deserialized[1].Z);
        Assert.Equal(data[2].X, deserialized[2].X);
        Assert.Equal(data[2].Y, deserialized[2].Y);
        Assert.Equal(0, deserialized[2].Z);
    }

    [Fact]
    public void TestUnmanagedPackAsManagedTuple()
    {
        var data = new ValueTuple<UnmanagedPackAsManagedStruct, UnmanagedPackAsManagedStruct>()
        {
            Item1 = { X = 1, Y = 2, Z = 3 },
            Item2 = { X = 4, Y = 5, Z = 6 }
        };

        var bytes = MemoryPackSerializer.Serialize(data);

        var deserialized = MemoryPackSerializer.Deserialize<ValueTuple<UnmanagedPackAsManagedStruct, UnmanagedPackAsManagedStruct>>(bytes)!;

        Assert.Equal(data.Item1.X, deserialized.Item1.X);
        Assert.Equal(data.Item1.Y, deserialized.Item1.Y);
        Assert.Equal(0, deserialized.Item1.Z);
        Assert.Equal(data.Item2.X, deserialized.Item2.X);
        Assert.Equal(data.Item2.Y, deserialized.Item2.Y);
        Assert.Equal(0, deserialized.Item2.Z);
    }
}
