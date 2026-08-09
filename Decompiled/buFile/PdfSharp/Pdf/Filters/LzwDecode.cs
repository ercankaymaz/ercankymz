using System;
using System.IO;

namespace PdfSharp.Pdf.Filters;

public class LzwDecode : Filter
{
	private readonly int[] _andTable = new int[4] { 511, 1023, 2047, 4095 };

	private byte[][] _stringTable;

	private byte[] _data;

	private int _tableIndex;

	private int _bitsToGet = 9;

	private int _bytePointer;

	private int _nextData = 0;

	private int _nextBits = 0;

	private int NextCode
	{
		get
		{
			try
			{
				_nextData = (_nextData << 8) | (_data[_bytePointer++] & 0xFF);
				_nextBits += 8;
				if (_nextBits < _bitsToGet)
				{
					_nextData = (_nextData << 8) | (_data[_bytePointer++] & 0xFF);
					_nextBits += 8;
				}
				int result = (_nextData >> _nextBits - _bitsToGet) & _andTable[_bitsToGet - 9];
				_nextBits -= _bitsToGet;
				return result;
			}
			catch
			{
				return 257;
			}
		}
	}

	public override byte[] Encode(byte[] data)
	{
		throw new NotImplementedException("PDFsharp does not support LZW encoding.");
	}

	public override byte[] Decode(byte[] data, FilterParms parms)
	{
		if (data[0] == 0 && data[1] == 1)
		{
			throw new Exception("LZW flavour not supported.");
		}
		MemoryStream memoryStream = new MemoryStream();
		InitializeDictionary();
		_data = data;
		_bytePointer = 0;
		_nextData = 0;
		_nextBits = 0;
		int num = 0;
		int nextCode;
		while ((nextCode = NextCode) != 257)
		{
			if (nextCode == 256)
			{
				InitializeDictionary();
				nextCode = NextCode;
				if (nextCode == 257)
				{
					break;
				}
				memoryStream.Write(_stringTable[nextCode], 0, _stringTable[nextCode].Length);
				num = nextCode;
			}
			else if (nextCode < _tableIndex)
			{
				byte[] array = _stringTable[nextCode];
				memoryStream.Write(array, 0, array.Length);
				AddEntry(_stringTable[num], array[0]);
				num = nextCode;
			}
			else
			{
				byte[] array = _stringTable[num];
				memoryStream.Write(array, 0, array.Length);
				AddEntry(array, array[0]);
				num = nextCode;
			}
		}
		if (memoryStream.Length >= 0)
		{
			memoryStream.Capacity = (int)memoryStream.Length;
			return memoryStream.GetBuffer();
		}
		return null;
	}

	private void InitializeDictionary()
	{
		_stringTable = new byte[8192][];
		for (int i = 0; i < 256; i++)
		{
			_stringTable[i] = new byte[1];
			_stringTable[i][0] = (byte)i;
		}
		_tableIndex = 258;
		_bitsToGet = 9;
	}

	private void AddEntry(byte[] oldstring, byte newstring)
	{
		int num = oldstring.Length;
		byte[] array = new byte[num + 1];
		Array.Copy(oldstring, 0, array, 0, num);
		array[num] = newstring;
		_stringTable[_tableIndex++] = array;
		if (_tableIndex == 511)
		{
			_bitsToGet = 10;
		}
		else if (_tableIndex == 1023)
		{
			_bitsToGet = 11;
		}
		else if (_tableIndex == 2047)
		{
			_bitsToGet = 12;
		}
	}
}
