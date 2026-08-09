using System;

namespace PdfSharp.Drawing.BarCodes;

internal class DataMatrixImage
{
	private struct Ecc200Block(int h, int w, int ch, int cw, int bytes, int dataBlock, int rsBlock)
	{
		public readonly int Height = h;

		public readonly int Width = w;

		public readonly int CellHeight = ch;

		public readonly int CellWidth = cw;

		public readonly int Bytes = bytes;

		public readonly int DataBlock = dataBlock;

		public readonly int RSBlock = rsBlock;
	}

	private string _encoding;

	private readonly string _text;

	private readonly int _rows;

	private readonly int _columns;

	private static Ecc200Block[] ecc200Sizes = new Ecc200Block[31]
	{
		new Ecc200Block(10, 10, 10, 10, 3, 3, 5),
		new Ecc200Block(12, 12, 12, 12, 5, 5, 7),
		new Ecc200Block(8, 18, 8, 18, 5, 5, 7),
		new Ecc200Block(14, 14, 14, 14, 8, 8, 10),
		new Ecc200Block(8, 32, 8, 16, 10, 10, 11),
		new Ecc200Block(16, 16, 16, 16, 12, 12, 12),
		new Ecc200Block(12, 26, 12, 26, 16, 16, 14),
		new Ecc200Block(18, 18, 18, 18, 18, 18, 14),
		new Ecc200Block(20, 20, 20, 20, 22, 22, 18),
		new Ecc200Block(12, 36, 12, 18, 22, 22, 18),
		new Ecc200Block(22, 22, 22, 22, 30, 30, 20),
		new Ecc200Block(16, 36, 16, 18, 32, 32, 24),
		new Ecc200Block(24, 24, 24, 24, 36, 36, 24),
		new Ecc200Block(26, 26, 26, 26, 44, 44, 28),
		new Ecc200Block(16, 48, 16, 24, 49, 49, 28),
		new Ecc200Block(32, 32, 16, 16, 62, 62, 36),
		new Ecc200Block(36, 36, 18, 18, 86, 86, 42),
		new Ecc200Block(40, 40, 20, 20, 114, 114, 48),
		new Ecc200Block(44, 44, 22, 22, 144, 144, 56),
		new Ecc200Block(48, 48, 24, 24, 174, 174, 68),
		new Ecc200Block(52, 52, 26, 26, 204, 102, 42),
		new Ecc200Block(64, 64, 16, 16, 280, 140, 56),
		new Ecc200Block(72, 72, 18, 18, 368, 92, 36),
		new Ecc200Block(80, 80, 20, 20, 456, 114, 48),
		new Ecc200Block(88, 88, 22, 22, 576, 144, 56),
		new Ecc200Block(96, 96, 24, 24, 696, 174, 68),
		new Ecc200Block(104, 104, 26, 26, 816, 136, 56),
		new Ecc200Block(120, 120, 20, 20, 1050, 175, 68),
		new Ecc200Block(132, 132, 22, 22, 1304, 163, 62),
		new Ecc200Block(144, 144, 24, 24, 1558, 156, 62),
		new Ecc200Block(0, 0, 0, 0, 0, 0, 0)
	};

	private static int gfpoly;

	private static int symsize;

	private static int logmod;

	private static int rlen;

	private static int[] log = null;

	private static int[] alog = null;

	private static int[] rspoly = null;

	public static XImage GenerateMatrixImage(string text, string encoding, int rows, int columns)
	{
		DataMatrixImage dataMatrixImage = new DataMatrixImage(text, encoding, rows, columns);
		return dataMatrixImage.DrawMatrix();
	}

	public DataMatrixImage(string text, string encoding, int rows, int columns)
	{
		_text = text;
		_encoding = encoding;
		_rows = rows;
		_columns = columns;
	}

	public XImage DrawMatrix()
	{
		return CreateImage(DataMatrix(), _rows, _columns);
	}

	internal char[] DataMatrix()
	{
		int columns = _columns;
		int rows = _rows;
		int num = 200;
		if (string.IsNullOrEmpty(_encoding))
		{
			_encoding = new string('a', _text.Length);
		}
		int len = 0;
		int max = 0;
		int ecc = 0;
		char[] array = null;
		if (columns != 0 && rows != 0 && (columns & 1) != 0 && (rows & 1) != 0 && num == 200)
		{
			throw new ArgumentException(BcgSR.DataMatrixNotSupported);
		}
		array = Iec16022Ecc200(columns, rows, _encoding, _text.Length, _text, len, max, ecc);
		if (array == null || columns == 0)
		{
			throw new ArgumentException(BcgSR.DataMatrixNull);
		}
		return array;
	}

	internal char[] Iec16022Ecc200(int columns, int rows, string encoding, int barcodeLength, string barcode, int len, int max, int ecc)
	{
		char[] t = new char[3000];
		Ecc200Block ecc200Block = new Ecc200Block(0, 0, 0, 0, 0, 0, 0);
		for (int i = 0; i < 3000; i++)
		{
			t[i] = '\0';
		}
		Ecc200Block[] array = ecc200Sizes;
		foreach (Ecc200Block ecc200Block2 in array)
		{
			ecc200Block = ecc200Block2;
			if (ecc200Block.Width == columns && ecc200Block.Height == rows)
			{
				break;
			}
		}
		if (ecc200Block.Width == 0)
		{
			throw new ArgumentException(BcgSR.DataMatrixInvalid(columns, rows));
		}
		if (!Ecc200Encode(ref t, ecc200Block.Bytes, barcode, barcodeLength, encoding, ref len))
		{
			throw new ArgumentException(BcgSR.DataMatrixTooBig);
		}
		Ecc200(t, ecc200Block.Bytes, ecc200Block.DataBlock, ecc200Block.RSBlock);
		int num = columns - 2 * (columns / ecc200Block.CellWidth);
		int num2 = rows - 2 * (rows / ecc200Block.CellHeight);
		int[] array2 = new int[num * num2];
		Ecc200Placement(ref array2, num2, num);
		char[] array3 = new char[columns * rows];
		for (int k = 0; k < rows; k += ecc200Block.CellHeight)
		{
			for (int l = 0; l < columns; l++)
			{
				array3[k * columns + l] = '\u0001';
			}
			for (int l = 0; l < columns; l += 2)
			{
				array3[(k + ecc200Block.CellHeight - 1) * columns + l] = '\u0001';
			}
		}
		for (int l = 0; l < columns; l += ecc200Block.CellWidth)
		{
			for (int k = 0; k < rows; k++)
			{
				array3[k * columns + l] = '\u0001';
			}
			for (int k = 0; k < rows; k += 2)
			{
				array3[k * columns + l + ecc200Block.CellWidth - 1] = '\u0001';
			}
		}
		for (int k = 0; k < num2; k++)
		{
			for (int l = 0; l < num; l++)
			{
				int num3 = array2[(num2 - k - 1) * num + l];
				if (num3 == 1 || (num3 > 7 && (t[(num3 >> 3) - 1] & (1 << (num3 & 7))) != 0))
				{
					array3[(1 + k + 2 * (k / (ecc200Block.CellHeight - 2))) * columns + 1 + l + 2 * (l / (ecc200Block.CellWidth - 2))] = '\u0001';
				}
			}
		}
		return array3;
	}

	internal bool Ecc200Encode(ref char[] t, int targetLength, string s, int sourceLength, string encoding, ref int len)
	{
		char c = 'a';
		int num = 0;
		int num2 = 0;
		if (encoding.Length < sourceLength)
		{
			return false;
		}
		while (num2 < sourceLength && num < targetLength)
		{
			char c2 = c;
			if ((targetLength - num <= 1 && (c == 'c' || c == 't')) || (targetLength - num <= 2 && c == 'x'))
			{
				c = 'a';
			}
			c2 = char.ToLower(encoding[num2]);
			switch (c2)
			{
			case 'c':
			case 't':
			case 'x':
			{
				char[] array2 = new char[6];
				char c4 = '\0';
				string text = null;
				string text2 = "!\"#$%&'()*+,-./:;<=>?@[\\]_";
				string text3 = null;
				if (c2 == 'c')
				{
					text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
					text3 = "`abcdefghijklmnopqrstuvwxyz{|}~±";
				}
				if (c2 == 't')
				{
					text = " 0123456789abcdefghijklmnopqrstuvwxyz";
					text3 = "`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~±";
				}
				if (c2 == 'x')
				{
					text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ\r*>";
				}
				do
				{
					char c5 = s[num2++];
					if ((c5 & 0x80) != 0)
					{
						if (c2 == 'x')
						{
							return false;
						}
						c5 = (char)(c5 & 0x7F);
						array2[(uint)c4++] = '\u0001';
						array2[(uint)c4++] = '\u001e';
					}
					char c6 = ((text.IndexOf(c5) != -1) ? text[text.IndexOf(c5)] : '\0');
					if (c6 != 0)
					{
						array2[(uint)c4++] = (char)((text.IndexOf(c6) + 3) % 40);
					}
					else
					{
						if (c2 == 'x')
						{
							return false;
						}
						if (c5 < ' ')
						{
							array2[(uint)c4++] = '\0';
							array2[(uint)c4++] = c5;
						}
						else
						{
							c6 = ((text2.IndexOf(c5) != -1) ? ((char)text2.IndexOf(c5)) : '\0');
							if (c6 != 0)
							{
								array2[(uint)c4++] = '\u0001';
								array2[(uint)c4++] = c6;
							}
							else
							{
								c6 = ((text3.IndexOf(c5) != -1) ? ((char)text3.IndexOf(c5)) : '\0');
								if (c6 == '\0')
								{
									return false;
								}
								array2[(uint)c4++] = '\u0002';
								array2[(uint)c4++] = c6;
							}
						}
					}
					if (c4 == '\u0002' && num + 2 == targetLength && num2 == sourceLength)
					{
						array2[(uint)c4++] = '\0';
					}
					while (c4 >= '\u0003')
					{
						int num4 = array2[0] * 1600 + array2[1] * 40 + array2[2] + 1;
						if (c != c2)
						{
							if (c == 'c' || c == 't' || c == 'x')
							{
								t[num++] = 'þ';
							}
							else if (c == 'x')
							{
								t[num++] = '|';
							}
							if (c2 == 'c')
							{
								t[num++] = 'æ';
							}
							if (c2 == 't')
							{
								t[num++] = 'ï';
							}
							if (c2 == 'x')
							{
								t[num++] = 'î';
							}
							c = c2;
						}
						t[num++] = (char)(num4 >> 8);
						t[num++] = (char)(num4 & 0xFF);
						c4 = (char)(c4 - 3);
						array2[0] = array2[3];
						array2[1] = array2[4];
						array2[2] = array2[5];
					}
				}
				while (c4 != 0 && num2 < sourceLength);
				break;
			}
			case 'e':
			{
				char[] array = new char[4];
				char c3 = '\0';
				if (c != c2)
				{
					t[num++] = 'þ';
					c = 'a';
				}
				while (num2 < sourceLength && char.ToLower(encoding[num2]) == 'e' && c3 < '\u0004')
				{
					array[(uint)c3++] = s[num2++];
				}
				if (c3 < '\u0004')
				{
					array[(uint)c3++] = '\u001f';
					c = 'a';
				}
				t[num] = (char)((s[0] & 0x3F) << 2);
				t[num++] |= (char)(ushort)((s[1] & 0x30) >> 4);
				t[num] = (char)((s[1] & 0xF) << 4);
				if (c3 == '\u0002')
				{
					num++;
					break;
				}
				t[num++] |= (char)(ushort)((s[2] & 0x3C) >> 2);
				t[num] = (char)((s[2] & 3) << 6);
				t[num++] |= (char)(ushort)(s[3] & 0x3F);
				break;
			}
			case 'a':
				if (c != c2)
				{
					if (c == 'c' || c == 't' || c == 'x')
					{
						t[num++] = 'þ';
					}
					else
					{
						t[num++] = '|';
					}
				}
				c = 'a';
				if (sourceLength - num2 >= 2 && char.IsDigit(s[num2]) && char.IsDigit(s[num2 + 1]))
				{
					t[num++] = (char)((s[num2] - 48) * 10 + s[num2 + 1] - 48 + 130);
					num2 += 2;
				}
				else if (s[num2] > '\u007f')
				{
					t[num++] = 'ë';
					t[num++] = (char)(s[num2++] - 127);
				}
				else
				{
					t[num++] = (char)(s[num2++] + 1);
				}
				break;
			case 'b':
			{
				int num3 = 0;
				if (encoding != null)
				{
					for (int i = num2; i < sourceLength && char.ToLower(encoding[i]) == 'b'; i++)
					{
						num3++;
					}
				}
				t[num++] = 'ç';
				if (num3 < 250)
				{
					t[num] = (char)State255(num3, num);
					num++;
				}
				else
				{
					t[num] = (char)State255(249 + num3 / 250, num);
					num++;
					t[num] = (char)State255(num3 % 250, num);
					num++;
				}
				while (num3-- != 0 && num < targetLength)
				{
					t[num] = (char)State255(s[num2++], num);
					num++;
				}
				c = 'a';
				break;
			}
			}
		}
		if (len != 0)
		{
			len = num;
		}
		if (num < targetLength && c != 'a')
		{
			if (c == 'c' || c == 'x' || c == 't')
			{
				t[num++] = 'þ';
			}
			else
			{
				t[num++] = '|';
			}
		}
		if (num < targetLength)
		{
			t[num++] = '\u0081';
		}
		while (num < targetLength)
		{
			int num5 = 129 + (num + 1) * 149 % 253 + 1;
			if (num5 > 254)
			{
				num5 -= 254;
			}
			t[num++] = (char)num5;
		}
		if (num > targetLength || num2 < sourceLength)
		{
			return false;
		}
		return true;
	}

	private int State255(int value, int position)
	{
		return (value + (position + 1) * 149 % 255 + 1) % 256;
	}

	private void Ecc200Placement(ref int[] array, int NR, int NC)
	{
		int i;
		int j;
		for (i = 0; i < NR; i++)
		{
			for (j = 0; j < NC; j++)
			{
				array[i * NC + j] = 0;
			}
		}
		int num = 1;
		i = 4;
		j = 0;
		do
		{
			if (i == NR && j == 0)
			{
				Ecc200PlacementCornerA(ref array, NR, NC, num++);
			}
			if (i == NR - 2 && j == 0 && NC % 4 != 0)
			{
				Ecc200PlacementCornerB(ref array, NR, NC, num++);
			}
			if (i == NR - 2 && j == 0 && NC % 8 == 4)
			{
				Ecc200PlacementCornerC(ref array, NR, NC, num++);
			}
			if (i == NR + 4 && j == 2 && NC % 8 == 0)
			{
				Ecc200PlacementCornerD(ref array, NR, NC, num++);
			}
			do
			{
				if (i < NR && j >= 0 && array[i * NC + j] == 0)
				{
					Ecc200PlacementBlock(ref array, NR, NC, i, j, num++);
				}
				i -= 2;
				j += 2;
			}
			while (i >= 0 && j < NC);
			i++;
			j += 3;
			do
			{
				if (i >= 0 && j < NC && array[i * NC + j] == 0)
				{
					Ecc200PlacementBlock(ref array, NR, NC, i, j, num++);
				}
				i += 2;
				j -= 2;
			}
			while (i < NR && j >= 0);
			i += 3;
			j++;
		}
		while (i < NR || j < NC);
		if (array[NR * NC - 1] == 0)
		{
			array[NR * NC - 1] = (array[NR * NC - NC - 2] = 1);
		}
	}

	private void Ecc200PlacementBit(ref int[] array, int NR, int NC, int r, int c, int p, int b)
	{
		if (r < 0)
		{
			r += NR;
			c += 4 - (NR + 4) % 8;
		}
		if (c < 0)
		{
			c += NC;
			r += 4 - (NC + 4) % 8;
		}
		array[r * NC + c] = (p << 3) + b;
	}

	private void Ecc200PlacementBlock(ref int[] array, int NR, int NC, int r, int c, int p)
	{
		Ecc200PlacementBit(ref array, NR, NC, r - 2, c - 2, p, 7);
		Ecc200PlacementBit(ref array, NR, NC, r - 2, c - 1, p, 6);
		Ecc200PlacementBit(ref array, NR, NC, r - 1, c - 2, p, 5);
		Ecc200PlacementBit(ref array, NR, NC, r - 1, c - 1, p, 4);
		Ecc200PlacementBit(ref array, NR, NC, r - 1, c, p, 3);
		Ecc200PlacementBit(ref array, NR, NC, r, c - 2, p, 2);
		Ecc200PlacementBit(ref array, NR, NC, r, c - 1, p, 1);
		Ecc200PlacementBit(ref array, NR, NC, r, c, p, 0);
	}

	private void Ecc200PlacementCornerA(ref int[] array, int NR, int NC, int p)
	{
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 7);
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, 1, p, 6);
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, 2, p, 5);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
		Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 2);
		Ecc200PlacementBit(ref array, NR, NC, 2, NC - 1, p, 1);
		Ecc200PlacementBit(ref array, NR, NC, 3, NC - 1, p, 0);
	}

	private void Ecc200PlacementCornerB(ref int[] array, int NR, int NC, int p)
	{
		Ecc200PlacementBit(ref array, NR, NC, NR - 3, 0, p, 7);
		Ecc200PlacementBit(ref array, NR, NC, NR - 2, 0, p, 6);
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 5);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 4, p, 4);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 3, p, 3);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 2);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 1);
		Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 0);
	}

	private void Ecc200PlacementCornerC(ref int[] array, int NR, int NC, int p)
	{
		Ecc200PlacementBit(ref array, NR, NC, NR - 3, 0, p, 7);
		Ecc200PlacementBit(ref array, NR, NC, NR - 2, 0, p, 6);
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 5);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
		Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 2);
		Ecc200PlacementBit(ref array, NR, NC, 2, NC - 1, p, 1);
		Ecc200PlacementBit(ref array, NR, NC, 3, NC - 1, p, 0);
	}

	private void Ecc200PlacementCornerD(ref int[] array, int NR, int NC, int p)
	{
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 7);
		Ecc200PlacementBit(ref array, NR, NC, NR - 1, NC - 1, p, 6);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 3, p, 5);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
		Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
		Ecc200PlacementBit(ref array, NR, NC, 1, NC - 3, p, 2);
		Ecc200PlacementBit(ref array, NR, NC, 1, NC - 2, p, 1);
		Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 0);
	}

	private void Ecc200(char[] binary, int bytes, int datablock, int rsblock)
	{
		int num = (bytes + 2) / datablock;
		InitGalois(301);
		InitReedSolomon(rsblock, 1);
		for (int i = 0; i < num; i++)
		{
			int[] array = new int[256];
			int[] result = new int[256];
			int length = 0;
			for (int j = i; j < bytes; j += num)
			{
				array[length++] = binary[j];
			}
			EncodeReedSolomon(length, array, ref result);
			length = rsblock - 1;
			for (int j = i; j < rsblock * num; j += num)
			{
				binary[bytes + j] = (char)result[length--];
			}
		}
	}

	public static void InitGalois(int poly)
	{
		if (log != null)
		{
			log = null;
			alog = null;
			rspoly = null;
		}
		int num = 1;
		int num2 = 0;
		while (num <= poly)
		{
			num2++;
			num <<= 1;
		}
		num >>= 1;
		num2--;
		gfpoly = poly;
		symsize = num2;
		logmod = (1 << num2) - 1;
		log = new int[logmod + 1];
		alog = new int[logmod];
		int num3 = 1;
		for (int i = 0; i < logmod; i++)
		{
			alog[i] = num3;
			log[num3] = i;
			num3 <<= 1;
			if ((num3 & num) != 0)
			{
				num3 ^= poly;
			}
		}
	}

	public static void InitReedSolomon(int nsym, int index)
	{
		if (rspoly != null)
		{
			rspoly = null;
		}
		rspoly = new int[nsym + 1];
		rlen = nsym;
		rspoly[0] = 1;
		for (int i = 1; i <= nsym; i++)
		{
			rspoly[i] = 1;
			for (int num = i - 1; num > 0; num--)
			{
				if (rspoly[num] != 0)
				{
					rspoly[num] = alog[(log[rspoly[num]] + index) % logmod];
				}
				rspoly[num] ^= rspoly[num - 1];
			}
			rspoly[0] = alog[(log[rspoly[0]] + index) % logmod];
			index++;
		}
	}

	public void EncodeReedSolomon(int length, int[] data, ref int[] result)
	{
		for (int i = 0; i < rlen; i++)
		{
			result[i] = 0;
		}
		for (int i = 0; i < length; i++)
		{
			int num = result[rlen - 1] ^ data[i];
			for (int num2 = rlen - 1; num2 > 0; num2--)
			{
				if (num != 0 && rspoly[num2] != 0)
				{
					result[num2] = result[num2 - 1] ^ alog[(log[num] + log[rspoly[num2]]) % logmod];
				}
				else
				{
					result[num2] = result[num2 - 1];
				}
			}
			if (num != 0 && rspoly[0] != 0)
			{
				result[0] = alog[(log[num] + log[rspoly[0]]) % logmod];
			}
			else
			{
				result[0] = 0;
			}
		}
	}

	public XImage CreateImage(char[] code, int size)
	{
		return CreateImage(code, size, size, 10);
	}

	public XImage CreateImage(char[] code, int rows, int columns)
	{
		return CreateImage(code, rows, columns, 10);
	}

	public XImage CreateImage(char[] code, int rows, int columns, int pixelsize)
	{
		return null;
	}
}
