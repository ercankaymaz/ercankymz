using System;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegHuffmanEncodingTable
{
	private readonly int _codeCount;

	private readonly JpegHuffmanCanonicalCode[] _codes;

	private readonly byte[] _symbolMap;

	public ushort BytesRequired => (ushort)(16 + _codeCount);

	public JpegHuffmanEncodingTable(JpegHuffmanCanonicalCode[] codes)
	{
		_codes = codes ?? throw new ArgumentNullException("codes");
		int num = 0;
		_symbolMap = new byte[256];
		for (int i = 0; i < codes.Length; i++)
		{
			JpegHuffmanCanonicalCode jpegHuffmanCanonicalCode = codes[i];
			if (jpegHuffmanCanonicalCode.CodeLength != 0)
			{
				_symbolMap[jpegHuffmanCanonicalCode.Symbol] = (byte)i;
				num++;
			}
		}
		_codeCount = num;
	}

	public bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		bytesWritten = 0;
		if (buffer.Length < 16)
		{
			return false;
		}
		for (int i = 1; i <= 16; i++)
		{
			int num = 0;
			for (int j = _codes.Length - _codeCount; j < _codes.Length; j++)
			{
				if (_codes[j].CodeLength == i)
				{
					num++;
				}
			}
			buffer[i - 1] = (byte)num;
		}
		buffer = buffer.Slice(16);
		bytesWritten += 16;
		if (buffer.Length < _codeCount)
		{
			return false;
		}
		int num2 = 0;
		for (int k = _codes.Length - _codeCount; k < _codes.Length; k++)
		{
			buffer[num2++] = _codes[k].Symbol;
		}
		bytesWritten += num2;
		return true;
	}

	public void GetCode(int symbol, out ushort code, out int codeLength)
	{
		JpegHuffmanCanonicalCode jpegHuffmanCanonicalCode = _codes[_symbolMap[symbol]];
		code = jpegHuffmanCanonicalCode.Code;
		codeLength = jpegHuffmanCanonicalCode.CodeLength;
	}
}
