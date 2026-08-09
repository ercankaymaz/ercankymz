using System.IO;

namespace System.ServiceModel.Channels;

internal struct IntDecoder
{
	private int _value;

	private short _index;

	private const int LastIndex = 4;

	public int Value
	{
		get
		{
			if (!IsValueDecoded)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
			}
			return _value;
		}
	}

	public bool IsValueDecoded { get; private set; }

	public void Reset()
	{
		_index = 0;
		_value = 0;
		IsValueDecoded = false;
	}

	public int Decode(byte[] buffer, int offset, int size)
	{
		DecoderHelper.ValidateSize(size);
		if (IsValueDecoded)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
		}
		int num = 0;
		while (num < size)
		{
			int num2 = buffer[offset];
			_value |= (num2 & 0x7F) << _index * 7;
			num++;
			if (_index == 4 && (num2 & 0xF8) != 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.FramingSizeTooLarge));
			}
			_index++;
			if ((num2 & 0x80) == 0)
			{
				IsValueDecoded = true;
				break;
			}
			offset++;
		}
		return num;
	}
}
