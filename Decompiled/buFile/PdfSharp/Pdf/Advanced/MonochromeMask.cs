namespace PdfSharp.Pdf.Advanced;

internal class MonochromeMask
{
	private readonly byte[] _maskData;

	private readonly int _sizeX;

	private readonly int _sizeY;

	private int _writeOffset;

	private int _byteBuffer;

	private int _bitsWritten;

	public byte[] MaskData => _maskData;

	public MonochromeMask(int sizeX, int sizeY)
	{
		_sizeX = sizeX;
		_sizeY = sizeY;
		int num = (sizeX + 7) / 8 * sizeY;
		_maskData = new byte[num];
		StartLine(0);
	}

	public void StartLine(int newCurrentLine)
	{
		_bitsWritten = 0;
		_byteBuffer = 0;
		_writeOffset = (_sizeX + 7) / 8 * (_sizeY - 1 - newCurrentLine);
	}

	public void AddPel(bool isTransparent)
	{
		if (_bitsWritten < _sizeX)
		{
			if (isTransparent)
			{
				_byteBuffer = (_byteBuffer << 1) + 1;
			}
			else
			{
				_byteBuffer <<= 1;
			}
			_bitsWritten++;
			if ((_bitsWritten & 7) == 0)
			{
				_maskData[_writeOffset] = (byte)_byteBuffer;
				_writeOffset++;
				_byteBuffer = 0;
			}
			else if (_bitsWritten == _sizeX)
			{
				int num = 8 - (_bitsWritten & 7);
				_byteBuffer <<= num;
				_maskData[_writeOffset] = (byte)_byteBuffer;
			}
		}
	}

	public void AddPel(int shade)
	{
		AddPel(shade < 128);
	}
}
