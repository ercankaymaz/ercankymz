using System;

namespace CSUtilities.Converters;

internal class DefaultEndianConverter : IEndianConverter
{
	public byte[] GetBytes(char value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(short value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(ushort value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(int value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(uint value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(long value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(ulong value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(double value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes(float value)
	{
		return BitConverter.GetBytes(value);
	}

	public byte[] GetBytes<T>(T value) where T : struct
	{
		if (!(value is byte b))
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
		return new byte[1] { b };
	}

	public char ToChar(byte[] arr)
	{
		return BitConverter.ToChar(arr, 0);
	}

	public short ToInt16(byte[] arr)
	{
		return BitConverter.ToInt16(arr, 0);
	}

	public ushort ToUInt16(byte[] arr)
	{
		return BitConverter.ToUInt16(arr, 0);
	}

	public int ToInt32(byte[] arr)
	{
		return BitConverter.ToInt32(arr, 0);
	}

	public uint ToUInt32(byte[] arr)
	{
		return BitConverter.ToUInt32(arr, 0);
	}

	public long ToInt64(byte[] arr)
	{
		return BitConverter.ToInt64(arr, 0);
	}

	public ulong ToUInt64(byte[] arr)
	{
		return BitConverter.ToUInt64(arr, 0);
	}

	public double ToDouble(byte[] arr)
	{
		return BitConverter.ToDouble(arr, 0);
	}

	public float ToSingle(byte[] arr)
	{
		return BitConverter.ToSingle(arr, 0);
	}

	public char ToChar(byte[] arr, int length)
	{
		return BitConverter.ToChar(arr, length);
	}

	public short ToInt16(byte[] arr, int length)
	{
		return BitConverter.ToInt16(arr, length);
	}

	public ushort ToUInt16(byte[] arr, int length)
	{
		return BitConverter.ToUInt16(arr, length);
	}

	public int ToInt32(byte[] arr, int length)
	{
		return BitConverter.ToInt32(arr, length);
	}

	public uint ToUInt32(byte[] arr, int length)
	{
		return BitConverter.ToUInt32(arr, length);
	}

	public long ToInt64(byte[] arr, int length)
	{
		return BitConverter.ToInt64(arr, length);
	}

	public ulong ToUInt64(byte[] arr, int length)
	{
		return BitConverter.ToUInt64(arr, length);
	}

	public double ToDouble(byte[] arr, int length)
	{
		return BitConverter.ToDouble(arr, length);
	}

	public float ToSingle(byte[] arr, int length)
	{
		return BitConverter.ToSingle(arr, length);
	}
}
