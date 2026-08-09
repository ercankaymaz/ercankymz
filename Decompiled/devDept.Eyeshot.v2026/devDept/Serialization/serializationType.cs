namespace devDept.Serialization;

public enum serializationType : byte
{
	Uncompressed,
	Compressed,
	WithLengthPrefix
}
