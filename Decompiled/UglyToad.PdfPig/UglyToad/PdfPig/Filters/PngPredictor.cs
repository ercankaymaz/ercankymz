using System;
using System.IO;

namespace UglyToad.PdfPig.Filters;

internal static class PngPredictor
{
	private sealed class PredictorOutputStream : Stream
	{
		private readonly Stream _baseStream;

		private int _predictor;

		private readonly int _colors;

		private readonly int _bitsPerComponent;

		private readonly int _columns;

		private readonly int _rowLength;

		private readonly bool _predictorPerRow;

		private byte[] _currentRow;

		private byte[] _lastRow;

		private int _currentRowData;

		private bool _predictorRead;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => true;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public PredictorOutputStream(Stream baseStream, int predictor, int colors, int bitsPerComponent, int columns)
		{
			_baseStream = baseStream;
			_predictor = predictor;
			_colors = colors;
			_bitsPerComponent = bitsPerComponent;
			_columns = columns;
			_rowLength = CalculateRowLength(colors, bitsPerComponent, columns);
			_predictorPerRow = predictor >= 10;
			_currentRow = new byte[_rowLength];
			_lastRow = new byte[_rowLength];
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num = offset;
			int num2 = num + count;
			while (num < num2)
			{
				if (_predictorPerRow && _currentRowData == 0 && !_predictorRead)
				{
					_predictor = buffer[num] + 10;
					num++;
					_predictorRead = true;
					continue;
				}
				int num3 = Math.Min(_rowLength - _currentRowData, num2 - num);
				Array.Copy(buffer, num, _currentRow, _currentRowData, num3);
				_currentRowData += num3;
				num += num3;
				if (_currentRowData == _currentRow.Length)
				{
					DecodeAndWriteRow();
				}
			}
		}

		private void DecodeAndWriteRow()
		{
			DecodePredictorRow(_predictor, _colors, _bitsPerComponent, _columns, _currentRow, _lastRow);
			_baseStream.Write(_currentRow, 0, _currentRow.Length);
			FlipRows();
		}

		private void FlipRows()
		{
			byte[] currentRow = _currentRow;
			byte[] lastRow = _lastRow;
			_lastRow = currentRow;
			_currentRow = lastRow;
			_currentRowData = 0;
			_predictorRead = false;
		}

		public override void Flush()
		{
			if (_currentRowData > 0)
			{
				_currentRow.AsSpan(_currentRowData, _rowLength - _currentRowData).Fill(0);
				DecodeAndWriteRow();
			}
			_baseStream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("Read not supported");
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("Not supported");
		}
	}

	public static void DecodePredictorRow(int predictor, int colors, int bitsPerComponent, int columns, byte[] actline, byte[] lastline)
	{
		if (predictor == 1)
		{
			return;
		}
		int num = (colors * bitsPerComponent + 7) / 8;
		int num2 = actline.Length;
		switch (predictor)
		{
		case 2:
		{
			switch (bitsPerComponent)
			{
			case 8:
			{
				for (int l = num; l < num2; l++)
				{
					int num17 = actline[l] & 0xFF;
					int num18 = actline[l - num] & 0xFF;
					actline[l] = (byte)(num17 + num18);
				}
				return;
			}
			case 16:
			{
				for (int k = num; k < num2 - 1; k += 2)
				{
					int num14 = ((actline[k] & 0xFF) << 8) + (actline[k + 1] & 0xFF);
					int num15 = ((actline[k - num] & 0xFF) << 8) + (actline[k - num + 1] & 0xFF);
					int num16 = num14 + num15;
					actline[k] = (byte)((num16 >> 8) & 0xFF);
					actline[k + 1] = (byte)(num16 & 0xFF);
				}
				return;
			}
			case 1:
			{
				if (colors != 1)
				{
					break;
				}
				for (int j = 0; j < num2; j++)
				{
					for (int num11 = 7; num11 >= 0; num11--)
					{
						int num12 = (actline[j] >> num11) & 1;
						if (j != 0 || num11 != 7)
						{
							int num13 = ((num11 != 7) ? ((actline[j] >> num11 + 1) & 1) : (actline[j - 1] & 1));
							if (((num12 + num13) & 1) == 0)
							{
								actline[j] &= (byte)(~(1 << num11));
							}
							else
							{
								actline[j] |= (byte)(1 << num11);
							}
						}
					}
				}
				return;
			}
			}
			int num19 = columns * colors;
			for (int m = colors; m < num19; m++)
			{
				int num20 = m * bitsPerComponent / 8;
				int startBit = 8 - m * bitsPerComponent % 8 - bitsPerComponent;
				int num21 = (m - colors) * bitsPerComponent / 8;
				int startBit2 = 8 - (m - colors) * bitsPerComponent % 8 - bitsPerComponent;
				int bitSeq = GetBitSeq(actline[num20], startBit, bitsPerComponent);
				int bitSeq2 = GetBitSeq(actline[num21], startBit2, bitsPerComponent);
				actline[num20] = (byte)CalcSetBitSeq(actline[num20], startBit, bitsPerComponent, bitSeq + bitSeq2);
			}
			break;
		}
		case 11:
		{
			for (int num25 = num; num25 < num2; num25++)
			{
				int num26 = actline[num25];
				int num27 = actline[num25 - num];
				actline[num25] = (byte)(num26 + num27);
			}
			break;
		}
		case 12:
		{
			for (int num28 = 0; num28 < num2; num28++)
			{
				int num29 = actline[num28] & 0xFF;
				int num30 = lastline[num28] & 0xFF;
				actline[num28] = (byte)((num29 + num30) & 0xFF);
			}
			break;
		}
		case 13:
		{
			for (int n = 0; n < num2; n++)
			{
				int num22 = actline[n] & 0xFF;
				int num23 = ((n - num >= 0) ? (actline[n - num] & 0xFF) : 0);
				int num24 = lastline[n] & 0xFF;
				actline[n] = (byte)((num22 + (num23 + num24) / 2) & 0xFF);
			}
			break;
		}
		case 14:
		{
			for (int i = 0; i < num2; i++)
			{
				int num3 = actline[i] & 0xFF;
				int num4 = ((i - num >= 0) ? (actline[i - num] & 0xFF) : 0);
				int num5 = lastline[i] & 0xFF;
				int num6 = ((i - num >= 0) ? (lastline[i - num] & 0xFF) : 0);
				int num7 = num4 + num5 - num6;
				int num8 = Math.Abs(num7 - num4);
				int num9 = Math.Abs(num7 - num5);
				int num10 = Math.Abs(num7 - num6);
				if (num8 <= num9 && num8 <= num10)
				{
					actline[i] = (byte)((num3 + num4) & 0xFF);
				}
				else if (num9 <= num10)
				{
					actline[i] = (byte)((num3 + num5) & 0xFF);
				}
				else
				{
					actline[i] = (byte)((num3 + num6) & 0xFF);
				}
			}
			break;
		}
		}
	}

	public static int CalculateRowLength(int colors, int bitsPerComponent, int columns)
	{
		int num = colors * bitsPerComponent;
		return (columns * num + 7) / 8;
	}

	private static int GetBitSeq(int by, int startBit, int bitSize)
	{
		int num = (1 << bitSize) - 1;
		return (by >> startBit) & num;
	}

	private static int CalcSetBitSeq(int by, int startBit, int bitSize, int val)
	{
		int num = (1 << bitSize) - 1;
		int num2 = val & num;
		num = ~(num << startBit);
		return (by & num) | (num2 << startBit);
	}

	public static Stream WrapPredictor(Stream outStream, int predictor, int colors, int bitsPerComponent, int columns)
	{
		if (predictor > 1)
		{
			return new PredictorOutputStream(outStream, predictor, colors, bitsPerComponent, columns);
		}
		return outStream;
	}
}
