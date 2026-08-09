using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text.Json.Serialization.Metadata;

internal readonly struct PropertyRef(ulong key, JsonPropertyInfo info, byte[] utf8PropertyName) : IEquatable<PropertyRef>
{
	private const int PropertyNameKeyLength = 7;

	public readonly ulong Key = key;

	public readonly JsonPropertyInfo Info = info;

	public readonly byte[] Utf8PropertyName = utf8PropertyName;

	public bool Equals(PropertyRef other)
	{
		return Equals(other.Utf8PropertyName, other.Key);
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyRef other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Key.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(ReadOnlySpan<byte> propertyName, ulong key)
	{
		if (key == Key)
		{
			if (propertyName.Length > 7)
			{
				return propertyName.SequenceEqual(Utf8PropertyName);
			}
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong GetKey(ReadOnlySpan<byte> name)
	{
		ref byte reference = ref MemoryMarshal.GetReference(name);
		int length = name.Length;
		ulong num = (ulong)(byte)length << 56;
		switch (length)
		{
		case 2:
			num |= Unsafe.ReadUnaligned<ushort>(ref reference);
			break;
		case 3:
			num |= Unsafe.ReadUnaligned<ushort>(ref reference);
			goto case 1;
		case 4:
			num |= Unsafe.ReadUnaligned<uint>(ref reference);
			break;
		case 5:
			num |= Unsafe.ReadUnaligned<uint>(ref reference);
			goto case 1;
		case 6:
			num |= Unsafe.ReadUnaligned<uint>(ref reference) | ((ulong)Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref reference, 4)) << 32);
			break;
		case 7:
			num |= Unsafe.ReadUnaligned<uint>(ref reference) | ((ulong)Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref reference, 4)) << 32);
			goto case 1;
		default:
			num |= Unsafe.ReadUnaligned<ulong>(ref reference) & 0xFFFFFFFFFFFFFFL;
			break;
		case 1:
		{
			int num2 = length - 1;
			num |= (ulong)Unsafe.Add(ref reference, num2) << num2 * 8;
			break;
		}
		case 0:
			break;
		}
		return num;
	}
}
