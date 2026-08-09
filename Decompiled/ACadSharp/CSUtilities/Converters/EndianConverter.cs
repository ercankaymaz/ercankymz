namespace CSUtilities.Converters;

internal abstract class EndianConverter : IEndianConverter
{
	protected readonly IEndianConverter _converter;

	public EndianConverter()
	{
	}

	protected EndianConverter(IEndianConverter converter)
	{
		_converter = converter;
	}

	public byte[] GetBytes(char value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(short value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(ushort value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(int value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(uint value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(long value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(ulong value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(double value)
	{
		return _converter.GetBytes(value);
	}

	public byte[] GetBytes(float value)
	{
		return _converter.GetBytes(value);
	}

	public char ToChar(byte[] bytes)
	{
		return _converter.ToChar(bytes);
	}

	public short ToInt16(byte[] bytes)
	{
		return _converter.ToInt16(bytes);
	}

	public ushort ToUInt16(byte[] bytes)
	{
		return _converter.ToUInt16(bytes);
	}

	public int ToInt32(byte[] bytes)
	{
		return _converter.ToInt32(bytes);
	}

	public uint ToUInt32(byte[] bytes)
	{
		return _converter.ToUInt32(bytes);
	}

	public long ToInt64(byte[] bytes)
	{
		return _converter.ToInt64(bytes);
	}

	public ulong ToUInt64(byte[] bytes)
	{
		return _converter.ToUInt64(bytes);
	}

	public double ToDouble(byte[] bytes)
	{
		return _converter.ToDouble(bytes);
	}

	public float ToSingle(byte[] bytes)
	{
		return _converter.ToSingle(bytes);
	}

	public char ToChar(byte[] bytes, int offset)
	{
		return _converter.ToChar(bytes, offset);
	}

	public short ToInt16(byte[] bytes, int offset)
	{
		return _converter.ToInt16(bytes, offset);
	}

	public ushort ToUInt16(byte[] bytes, int offset)
	{
		return _converter.ToUInt16(bytes, offset);
	}

	public int ToInt32(byte[] bytes, int offset)
	{
		return _converter.ToInt32(bytes, offset);
	}

	public uint ToUInt32(byte[] bytes, int offset)
	{
		return _converter.ToUInt32(bytes, offset);
	}

	public long ToInt64(byte[] bytes, int offset)
	{
		return _converter.ToInt64(bytes, offset);
	}

	public ulong ToUInt64(byte[] bytes, int offset)
	{
		return _converter.ToUInt64(bytes, offset);
	}

	public double ToDouble(byte[] bytes, int offset)
	{
		return _converter.ToDouble(bytes, offset);
	}

	public float ToSingle(byte[] bytes, int offset)
	{
		return _converter.ToSingle(bytes, offset);
	}

	public byte[] GetBytes<T>(T value) where T : struct
	{
		return _converter.GetBytes(value);
	}
}
