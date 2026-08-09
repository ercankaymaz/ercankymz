using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Diagnostics;

namespace System.Xml;

internal class BufferedWrite
{
	private byte[] buffer;

	private int offset;

	internal int Length => offset;

	internal BufferedWrite()
		: this(256)
	{
	}

	internal BufferedWrite(int initialSize)
	{
		buffer = new byte[initialSize];
	}

	private void EnsureBuffer(int count)
	{
		int num = buffer.Length;
		if (count <= num - offset)
		{
			return;
		}
		int num2 = num;
		do
		{
			if (num2 == int.MaxValue)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.WriteBufferOverflow));
			}
			num2 = ((num2 < 1073741823) ? (num2 * 2) : int.MaxValue);
		}
		while (count > num2 - offset);
		byte[] dst = new byte[num2];
		Buffer.BlockCopy(buffer, 0, dst, 0, offset);
		buffer = dst;
	}

	internal byte[] GetBuffer()
	{
		return buffer;
	}

	internal void Reset()
	{
		offset = 0;
	}

	internal void Write(byte[] value)
	{
		Write(value, 0, value.Length);
	}

	internal void Write(byte[] value, int index, int count)
	{
		EnsureBuffer(count);
		Buffer.BlockCopy(value, index, buffer, offset, count);
		offset += count;
	}

	internal void Write(string value)
	{
		Write(value, 0, value.Length);
	}

	internal void Write(string value, int index, int count)
	{
		EnsureBuffer(count);
		for (int i = 0; i < count; i++)
		{
			char c = value[index + i];
			if (c > 'ÿ')
			{
				ExceptionUtility exceptionUtility = DiagnosticUtility.ExceptionUtility;
				string mimeHeaderInvalidCharacter = System.SR.MimeHeaderInvalidCharacter;
				object p = c;
				int num = c;
				throw exceptionUtility.ThrowHelperError(new FormatException(System.SR.Format(mimeHeaderInvalidCharacter, p, num.ToString("X", CultureInfo.InvariantCulture))));
			}
			buffer[offset + i] = (byte)c;
		}
		offset += count;
	}
}
