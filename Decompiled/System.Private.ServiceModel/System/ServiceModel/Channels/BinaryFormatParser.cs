using System.Xml;

namespace System.ServiceModel.Channels;

internal static class BinaryFormatParser
{
	public static bool IsSessionKey(int value)
	{
		return (value & 1) != 0;
	}

	public static int GetSessionKey(int value)
	{
		return value / 2;
	}

	public static int GetStaticKey(int value)
	{
		return value / 2;
	}

	public static int ParseInt32(byte[] buffer, int offset, int size)
	{
		return size switch
		{
			1 => buffer[offset], 
			2 => (buffer[offset] & 0x7F) + (buffer[offset + 1] << 7), 
			3 => (buffer[offset] & 0x7F) + ((buffer[offset + 1] & 0x7F) << 7) + (buffer[offset + 2] << 14), 
			4 => (buffer[offset] & 0x7F) + ((buffer[offset + 1] & 0x7F) << 7) + ((buffer[offset + 2] & 0x7F) << 14) + (buffer[offset + 3] << 21), 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("size", size, System.SR.Format(System.SR.ValueMustBeInRange, 1, 4))), 
		};
	}

	public static int ParseKey(byte[] buffer, int offset, int size)
	{
		return ParseInt32(buffer, offset, size);
	}

	public static UniqueId ParseUniqueID(byte[] buffer, int offset, int size)
	{
		return new UniqueId(buffer, offset);
	}

	public static int MatchBytes(byte[] buffer, int offset, int size, byte[] buffer2)
	{
		if (size < buffer2.Length)
		{
			return 0;
		}
		int num = offset;
		int num2 = 0;
		while (num2 < buffer2.Length)
		{
			if (buffer2[num2] != buffer[num])
			{
				return 0;
			}
			num2++;
			num++;
		}
		return buffer2.Length;
	}

	public static bool MatchAttributeNode(byte[] buffer, int offset, int size)
	{
		if (size < 1)
		{
			return false;
		}
		System.Xml.XmlBinaryNodeType xmlBinaryNodeType = (System.Xml.XmlBinaryNodeType)buffer[offset];
		if (xmlBinaryNodeType >= System.Xml.XmlBinaryNodeType.MinAttribute)
		{
			return xmlBinaryNodeType <= System.Xml.XmlBinaryNodeType.DictionaryAttribute;
		}
		return false;
	}

	public static int MatchKey(byte[] buffer, int offset, int size)
	{
		return MatchInt32(buffer, offset, size);
	}

	public static int MatchInt32(byte[] buffer, int offset, int size)
	{
		if (size > 0 && (buffer[offset] & 0x80) == 0)
		{
			return 1;
		}
		if (size > 1 && (buffer[offset + 1] & 0x80) == 0)
		{
			return 2;
		}
		if (size > 2 && (buffer[offset + 2] & 0x80) == 0)
		{
			return 3;
		}
		if (size > 3 && (buffer[offset + 3] & 0x80) == 0)
		{
			return 4;
		}
		return 0;
	}

	public static int MatchUniqueID(byte[] buffer, int offset, int size)
	{
		if (size < 16)
		{
			return 0;
		}
		return 16;
	}
}
