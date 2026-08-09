using System.Runtime;
using System.Text;

namespace System.ServiceModel.Channels;

internal abstract class EncodedFramingRecord
{
	public byte[] EncodedBytes { get; private set; }

	protected EncodedFramingRecord(byte[] encodedBytes)
	{
		EncodedBytes = encodedBytes;
	}

	internal EncodedFramingRecord(FramingRecordType recordType, string value)
	{
		int byteCount = Encoding.UTF8.GetByteCount(value);
		int encodedSize = IntEncoder.GetEncodedSize(byteCount);
		EncodedBytes = Fx.AllocateByteArray(checked(1 + encodedSize + byteCount));
		EncodedBytes[0] = (byte)recordType;
		int num = 1;
		num += IntEncoder.Encode(byteCount, EncodedBytes, num);
		Encoding.UTF8.GetBytes(value, 0, value.Length, EncodedBytes, num);
		SetEncodedBytes(EncodedBytes);
	}

	protected void SetEncodedBytes(byte[] encodedBytes)
	{
		EncodedBytes = encodedBytes;
	}

	public override int GetHashCode()
	{
		return (EncodedBytes[0] << 16) | (EncodedBytes[EncodedBytes.Length / 2] << 8) | EncodedBytes[EncodedBytes.Length - 1];
	}

	public override bool Equals(object o)
	{
		if (o is EncodedFramingRecord)
		{
			return Equals((EncodedFramingRecord)o);
		}
		return false;
	}

	public bool Equals(EncodedFramingRecord other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		byte[] encodedBytes = other.EncodedBytes;
		if (EncodedBytes.Length != encodedBytes.Length)
		{
			return false;
		}
		for (int i = 0; i < EncodedBytes.Length; i++)
		{
			if (EncodedBytes[i] != encodedBytes[i])
			{
				return false;
			}
		}
		return true;
	}
}
