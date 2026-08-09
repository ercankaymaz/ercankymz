using System.Globalization;
using System.Text;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001;

internal sealed class SoapHexBinary
{
	private StringBuilder _sb = new StringBuilder(100);

	public byte[] Value { get; set; }

	public SoapHexBinary()
	{
	}

	public SoapHexBinary(byte[] value)
	{
		Value = value;
	}

	public override string ToString()
	{
		_sb.Length = 0;
		for (int i = 0; i < Value.Length; i++)
		{
			string text = Value[i].ToString("X", CultureInfo.InvariantCulture);
			if (text.Length == 1)
			{
				_sb.Append('0');
			}
			_sb.Append(text);
		}
		return _sb.ToString();
	}

	public static SoapHexBinary Parse(string value)
	{
		return new SoapHexBinary(ToByteArray(FilterBin64(value)));
	}

	private static byte[] ToByteArray(string value)
	{
		char[] array = value.ToCharArray();
		if (array.Length % 2 != 0)
		{
			throw new FormatException(System.SR.Format(System.SR.Remoting_SOAPInteropxsdInvalid, "xsd:hexBinary", value));
		}
		byte[] array2 = new byte[array.Length / 2];
		for (int i = 0; i < array.Length / 2; i++)
		{
			array2[i] = (byte)(ToByte(array[i * 2], value) * 16 + ToByte(array[i * 2 + 1], value));
		}
		return array2;
	}

	private static byte ToByte(char c, string value)
	{
		byte b = 0;
		string text = c.ToString();
		try
		{
			text = c.ToString();
			return byte.Parse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}
		catch (Exception)
		{
			throw new FormatException(System.SR.Format(System.SR.Remoting_SOAPInteropxsdInvalid, "xsd:hexBinary", value));
		}
	}

	internal static string FilterBin64(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] != ' ' && value[i] != '\n' && value[i] != '\r')
			{
				stringBuilder.Append(value[i]);
			}
		}
		return stringBuilder.ToString();
	}
}
