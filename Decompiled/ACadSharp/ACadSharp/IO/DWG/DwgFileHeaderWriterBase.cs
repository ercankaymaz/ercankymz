using System;
using System.IO;
using System.Text;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal abstract class DwgFileHeaderWriterBase : IDwgFileHeaderWriter
{
	protected ACadVersion _version;

	protected Encoding _encoding;

	protected Stream _stream;

	protected CadDocument _document;

	public abstract int HandleSectionOffset { get; }

	protected abstract int _fileHeaderSize { get; }

	protected DwgFileHeader _fileHeader { get; }

	public DwgFileHeaderWriterBase(Stream stream, Encoding encoding, CadDocument model)
	{
		if (!stream.CanSeek || !stream.CanWrite)
		{
			throw new ArgumentException();
		}
		_document = model;
		_stream = stream;
		_version = model.Header.Version;
		_encoding = encoding;
	}

	public abstract void AddSection(string name, MemoryStream stream, bool isCompressed, int decompsize = 29696);

	public abstract void WriteFile();

	protected ushort getFileCodePage()
	{
		ushort num = (ushort)CadUtils.GetCodeIndex(CadUtils.GetCodePage(_document.Header.CodePage));
		if (num < 1)
		{
			return 30;
		}
		return num;
	}

	protected void applyMask(byte[] buffer, int offset, int length)
	{
		byte[] bytes = LittleEndianConverter.Instance.GetBytes(0x4164536B ^ (int)_stream.Position);
		int num = offset + length;
		while (offset < num)
		{
			for (int i = 0; i < 4; i++)
			{
				buffer[offset + i] ^= bytes[i];
			}
			offset += 4;
		}
	}

	protected bool checkEmptyBytes(byte[] buffer, ulong offset, ulong spearBytes)
	{
		bool result = true;
		ulong num = offset + spearBytes;
		for (ulong num2 = offset; num2 < num; num2++)
		{
			if (buffer[num2] != 0)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	protected void writeMagicNumber()
	{
		for (int i = 0; i < (int)(_stream.Position % 32); i++)
		{
			_stream.WriteByte(DwgCheckSumCalculator.MagicSequence[i]);
		}
	}

	protected void applyMagicSequence(MemoryStream stream)
	{
		byte[] buffer = stream.GetBuffer();
		for (int i = 0; i < (int)stream.Length; i++)
		{
			buffer[i] ^= DwgCheckSumCalculator.MagicSequence[i];
		}
	}
}
