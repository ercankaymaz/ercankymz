namespace devDept.Serialization;

internal class ProtoImageSurrogate
{
	public byte[] Data;

	public ProtoImageSurrogate(byte[] data)
	{
		Data = data;
	}

	public static implicit operator ProtoImage(ProtoImageSurrogate surrogate)
	{
		if (surrogate == null || surrogate.Data == null)
		{
			return null;
		}
		return new ProtoImage(surrogate.Data);
	}

	public static implicit operator ProtoImageSurrogate(ProtoImage source)
	{
		if (source == null)
		{
			return null;
		}
		return new ProtoImageSurrogate(source.Data);
	}
}
