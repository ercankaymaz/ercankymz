namespace devDept.Serialization;

internal class ProtoBitmapSurrogate
{
	public byte[] Data;

	public ProtoBitmapSurrogate(byte[] data)
	{
		Data = data;
	}

	public static implicit operator ProtoBitmap(ProtoBitmapSurrogate surrogate)
	{
		if (surrogate == null || surrogate.Data == null)
		{
			return null;
		}
		return new ProtoBitmap(surrogate.Data);
	}

	public static implicit operator ProtoBitmapSurrogate(ProtoBitmap source)
	{
		if (source == null)
		{
			return null;
		}
		return new ProtoBitmapSurrogate(source.Data);
	}
}
