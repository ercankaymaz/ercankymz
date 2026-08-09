using System;

namespace CSUtilities.Converters;

internal class InverseConverter : IEndianConverter
{
	public byte[] GetBytes(char value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(short value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(ushort value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(uint value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(long value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(ulong value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(double value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public byte[] GetBytes(float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		fullInverse(bytes);
		return bytes;
	}

	public char ToChar(byte[] arr)
	{
		return BitConverter.ToChar(fullInverse(arr), 0);
	}

	public short ToInt16(byte[] arr)
	{
		return BitConverter.ToInt16(fullInverse(arr), 0);
	}

	public ushort ToUInt16(byte[] arr)
	{
		return BitConverter.ToUInt16(fullInverse(arr), 0);
	}

	public int ToInt32(byte[] arr)
	{
		return BitConverter.ToInt32(fullInverse(arr), 0);
	}

	public uint ToUInt32(byte[] arr)
	{
		return BitConverter.ToUInt32(fullInverse(arr), 0);
	}

	public long ToInt64(byte[] arr)
	{
		return BitConverter.ToInt64(fullInverse(arr), 0);
	}

	public ulong ToUInt64(byte[] arr)
	{
		return BitConverter.ToUInt64(fullInverse(arr), 0);
	}

	public double ToDouble(byte[] arr)
	{
		return BitConverter.ToDouble(fullInverse(arr), 0);
	}

	public float ToSingle(byte[] arr)
	{
		return BitConverter.ToSingle(fullInverse(arr), 0);
	}

	public char ToChar(byte[] arr, int offset)
	{
		return BitConverter.ToChar(fullInverse(arr), offset);
	}

	public short ToInt16(byte[] arr, int offset)
	{
		return BitConverter.ToInt16(fullInverse(arr, offset), 0);
	}

	public ushort ToUInt16(byte[] arr, int offset)
	{
		return BitConverter.ToUInt16(fullInverse(arr, offset), 0);
	}

	public int ToInt32(byte[] arr, int offset)
	{
		return BitConverter.ToInt32(fullInverse(arr, offset), 0);
	}

	public uint ToUInt32(byte[] arr, int offset)
	{
		return BitConverter.ToUInt32(fullInverse(arr, offset), 0);
	}

	public long ToInt64(byte[] arr, int offset)
	{
		return BitConverter.ToInt64(fullInverse(arr, offset), 0);
	}

	public ulong ToUInt64(byte[] arr, int offset)
	{
		return BitConverter.ToUInt64(fullInverse(arr, offset), 0);
	}

	public double ToDouble(byte[] arr, int offset)
	{
		return BitConverter.ToDouble(fullInverse(arr, offset), 0);
	}

	public float ToSingle(byte[] arr, int offset)
	{
		return BitConverter.ToSingle(fullInverse(arr, offset), 0);
	}

	public byte[] GetBytes<T>(T value) where T : struct
	{
		if (!(value is char value2))
		{
			if (!(value is short value3))
			{
				if (!(value is ushort value4))
				{
					if (!(value is int value5))
					{
						if (!(value is uint value6))
						{
							if (!(value is long value7))
							{
								if (!(value is ulong value8))
								{
									if (!(value is double value9))
									{
										if (value is float value10)
										{
											return GetBytes(value10);
										}
										throw new NotSupportedException("type " + typeof(T).FullName + " not supported");
									}
									return GetBytes(value9);
								}
								return GetBytes(value8);
							}
							return GetBytes(value7);
						}
						return GetBytes(value6);
					}
					return GetBytes(value5);
				}
				return GetBytes(value4);
			}
			return GetBytes(value3);
		}
		return GetBytes(value2);
	}

	private static byte[] fullInverse(byte[] arr)
	{
		byte[] array = new byte[arr.Length];
		int num = arr.Length - 1;
		for (int i = 0; i < arr.Length; i++)
		{
			array[num] = arr[i];
			num--;
		}
		return array;
	}

	private static byte[] fullInverse(byte[] arr, int offset)
	{
		byte[] array = new byte[arr.Length];
		int num = arr.Length - 1;
		for (int i = 0; i < arr.Length; i++)
		{
			array[num] = arr[offset - i];
			num--;
		}
		return array;
	}
}
