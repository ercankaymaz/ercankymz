using System;
using System.Drawing;
using System.IO;
using System.Text;
using Zen.Barcode.Properties;

namespace Zen.Barcode;

public class CodeQrBarcodeDraw : BarcodeDraw
{
	private class QRCodeEncoder
	{
		public class QRCodeUtility
		{
			public static bool IsUnicode(string value)
			{
				byte[] characters = AsciiStringToByteArray(value);
				byte[] characters2 = UnicodeStringToByteArray(value);
				string text = FromASCIIByteArray(characters);
				string text2 = FromUnicodeByteArray(characters2);
				if (text != text2)
				{
					return true;
				}
				return false;
			}

			public static bool IsUnicode(byte[] byteData)
			{
				string str = FromASCIIByteArray(byteData);
				string str2 = FromUnicodeByteArray(byteData);
				byte[] array = AsciiStringToByteArray(str);
				byte[] array2 = UnicodeStringToByteArray(str2);
				if (array[0] != array2[0])
				{
					return true;
				}
				return false;
			}

			public static string FromASCIIByteArray(byte[] characters)
			{
				ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
				return aSCIIEncoding.GetString(characters);
			}

			public static string FromUnicodeByteArray(byte[] characters)
			{
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				return unicodeEncoding.GetString(characters);
			}

			public static byte[] AsciiStringToByteArray(string str)
			{
				ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
				return aSCIIEncoding.GetBytes(str);
			}

			public static byte[] UnicodeStringToByteArray(string str)
			{
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				return unicodeEncoding.GetBytes(str);
			}
		}

		public class SystemUtils
		{
			public static int ReadInput(Stream sourceStream, sbyte[] target, int start, int count)
			{
				if (target.Length == 0)
				{
					return 0;
				}
				byte[] array = new byte[target.Length];
				int num = sourceStream.Read(array, start, count);
				if (num == 0)
				{
					return -1;
				}
				for (int i = start; i < start + num; i++)
				{
					target[i] = (sbyte)array[i];
				}
				return num;
			}

			public static int ReadInput(TextReader sourceTextReader, short[] target, int start, int count)
			{
				if (target.Length == 0)
				{
					return 0;
				}
				char[] array = new char[target.Length];
				int num = sourceTextReader.Read(array, start, count);
				if (num == 0)
				{
					return -1;
				}
				for (int i = start; i < start + num; i++)
				{
					target[i] = (short)array[i];
				}
				return num;
			}

			public static void WriteStackTrace(Exception throwable, TextWriter stream)
			{
				stream.Write(throwable.StackTrace);
				stream.Flush();
			}

			public static int URShift(int number, int bits)
			{
				if (number >= 0)
				{
					return number >> bits;
				}
				return (number >> bits) + (2 << ~bits);
			}

			public static int URShift(int number, long bits)
			{
				return URShift(number, (int)bits);
			}

			public static long URShift(long number, int bits)
			{
				if (number >= 0)
				{
					return number >> bits;
				}
				return (number >> bits) + (2L << ~bits);
			}

			public static long URShift(long number, long bits)
			{
				return URShift(number, (int)bits);
			}

			public static byte[] ToByteArray(sbyte[] sbyteArray)
			{
				byte[] array = null;
				if (sbyteArray != null)
				{
					array = new byte[sbyteArray.Length];
					for (int i = 0; i < sbyteArray.Length; i++)
					{
						array[i] = (byte)sbyteArray[i];
					}
				}
				return array;
			}

			public static byte[] ToByteArray(string sourceString)
			{
				return Encoding.UTF8.GetBytes(sourceString);
			}

			public static byte[] ToByteArray(object[] tempObjectArray)
			{
				byte[] array = null;
				if (tempObjectArray != null)
				{
					array = new byte[tempObjectArray.Length];
					for (int i = 0; i < tempObjectArray.Length; i++)
					{
						array[i] = (byte)tempObjectArray[i];
					}
				}
				return array;
			}

			public static sbyte[] ToSByteArray(byte[] byteArray)
			{
				sbyte[] array = null;
				if (byteArray != null)
				{
					array = new sbyte[byteArray.Length];
					for (int i = 0; i < byteArray.Length; i++)
					{
						array[i] = (sbyte)byteArray[i];
					}
				}
				return array;
			}

			public static char[] ToCharArray(sbyte[] sByteArray)
			{
				return Encoding.UTF8.GetChars(ToByteArray(sByteArray));
			}

			public static char[] ToCharArray(byte[] byteArray)
			{
				return Encoding.UTF8.GetChars(byteArray);
			}
		}

		private QrErrorCorrection _errorCorrect;

		private QrEncodeMode _encodeMode;

		private int _version;

		private int _structureAppendN;

		private int _structureAppendM;

		private int _structureAppendParity;

		private int _scale;

		private Color _backgroundColor;

		private Color _foregroundColor;

		public QrErrorCorrection ErrorCorrect
		{
			get
			{
				return _errorCorrect;
			}
			set
			{
				_errorCorrect = value;
			}
		}

		public int Version
		{
			get
			{
				return _version;
			}
			set
			{
				if (value >= 0 && value <= 40)
				{
					_version = value;
				}
			}
		}

		public QrEncodeMode EncodeMode
		{
			get
			{
				return _encodeMode;
			}
			set
			{
				_encodeMode = value;
			}
		}

		public int Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return _backgroundColor;
			}
			set
			{
				_backgroundColor = value;
			}
		}

		public Color ForegroundColor
		{
			get
			{
				return _foregroundColor;
			}
			set
			{
				_foregroundColor = value;
			}
		}

		public QRCodeEncoder()
		{
			_errorCorrect = QrErrorCorrection.M;
			_encodeMode = QrEncodeMode.Byte;
			_version = 7;
			_structureAppendN = 0;
			_structureAppendM = 0;
			_structureAppendParity = 0;
			_scale = 4;
			_backgroundColor = Color.White;
			_foregroundColor = Color.Black;
		}

		public virtual void SetStructureAppend(int m, int n, int p)
		{
			if (n > 1 && n <= 16 && m > 0 && m <= 16 && p >= 0 && p <= 255)
			{
				_structureAppendM = m;
				_structureAppendN = n;
				_structureAppendParity = p;
			}
		}

		public virtual int CalculateStructureAppendParity(sbyte[] originaldata)
		{
			int i = 0;
			int num = 0;
			int num2 = originaldata.Length;
			if (num2 > 1)
			{
				num = 0;
				for (; i < num2; i++)
				{
					num ^= originaldata[i] & 0xFF;
				}
			}
			else
			{
				num = -1;
			}
			return num;
		}

		public virtual bool[][] CalculateQrCode(byte[] qrcodeData)
		{
			int num = 0;
			int num2 = qrcodeData.Length;
			int[] array = new int[num2 + 32];
			sbyte[] array2 = new sbyte[num2 + 32];
			if (num2 <= 0)
			{
				bool[][] array3 = new bool[1][];
				bool[] array4 = new bool[1];
				array3[0] = array4;
				return array3;
			}
			if (_structureAppendN > 1)
			{
				array[0] = 3;
				array2[0] = 4;
				array[1] = _structureAppendM - 1;
				array2[1] = 4;
				array[2] = _structureAppendN - 1;
				array2[2] = 4;
				array[3] = _structureAppendParity;
				array2[3] = 8;
				num = 4;
			}
			array2[num] = 4;
			int[] array5;
			int num3;
			switch (_encodeMode)
			{
			case QrEncodeMode.AlphaNumeric:
			{
				array5 = new int[41]
				{
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 4, 4, 4,
					4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
					4
				};
				array[num] = 2;
				num++;
				array[num] = num2;
				array2[num] = 9;
				num3 = num;
				num++;
				for (int k = 0; k < num2; k++)
				{
					char c = (char)qrcodeData[k];
					sbyte b = 0;
					if (c >= '0' && c < ':')
					{
						b = (sbyte)(c - 48);
					}
					else if (c >= 'A' && c < '[')
					{
						b = (sbyte)(c - 55);
					}
					else
					{
						if (c == ' ')
						{
							b = 36;
						}
						if (c == '$')
						{
							b = 37;
						}
						if (c == '%')
						{
							b = 38;
						}
						if (c == '*')
						{
							b = 39;
						}
						if (c == '+')
						{
							b = 40;
						}
						if (c == '-')
						{
							b = 41;
						}
						if (c == '.')
						{
							b = 42;
						}
						if (c == '/')
						{
							b = 43;
						}
						if (c == ':')
						{
							b = 44;
						}
					}
					if (k % 2 == 0)
					{
						array[num] = b;
						array2[num] = 6;
						continue;
					}
					array[num] = array[num] * 45 + b;
					array2[num] = 11;
					if (k < num2 - 1)
					{
						num++;
					}
				}
				num++;
				break;
			}
			case QrEncodeMode.Numeric:
			{
				array5 = new int[41]
				{
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 4, 4, 4,
					4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
					4
				};
				array[num] = 1;
				num++;
				array[num] = num2;
				array2[num] = 10;
				num3 = num;
				num++;
				for (int j = 0; j < num2; j++)
				{
					if (j % 3 == 0)
					{
						array[num] = qrcodeData[j] - 48;
						array2[num] = 4;
						continue;
					}
					array[num] = array[num] * 10 + (qrcodeData[j] - 48);
					if (j % 3 == 1)
					{
						array2[num] = 7;
						continue;
					}
					array2[num] = 10;
					if (j < num2 - 1)
					{
						num++;
					}
				}
				num++;
				break;
			}
			default:
			{
				array5 = new int[41]
				{
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
					8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
					8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
					8
				};
				array[num] = 4;
				num++;
				array[num] = num2;
				array2[num] = 8;
				num3 = num;
				num++;
				for (int i = 0; i < num2; i++)
				{
					array[i + num] = qrcodeData[i] & 0xFF;
					array2[i + num] = 8;
				}
				num += num2;
				break;
			}
			}
			int num4 = 0;
			for (int l = 0; l < num; l++)
			{
				num4 += array2[l];
			}
			sbyte b2 = (sbyte)_errorCorrect;
			int[][] array6 = new int[4][]
			{
				new int[41]
				{
					0, 128, 224, 352, 512, 688, 864, 992, 1232, 1456,
					1728, 2032, 2320, 2672, 2920, 3320, 3624, 4056, 4504, 5016,
					5352, 5712, 6256, 6880, 7312, 8000, 8496, 9024, 9544, 10136,
					10984, 11640, 12328, 13048, 13800, 14496, 15312, 15936, 16816, 17728,
					18672
				},
				new int[41]
				{
					0, 152, 272, 440, 640, 864, 1088, 1248, 1552, 1856,
					2192, 2592, 2960, 3424, 3688, 4184, 4712, 5176, 5768, 6360,
					6888, 7456, 8048, 8752, 9392, 10208, 10960, 11744, 12248, 13048,
					13880, 14744, 15640, 16568, 17528, 18448, 19472, 20528, 21616, 22496,
					23648
				},
				new int[41]
				{
					0, 72, 128, 208, 288, 368, 480, 528, 688, 800,
					976, 1120, 1264, 1440, 1576, 1784, 2024, 2264, 2504, 2728,
					3080, 3248, 3536, 3712, 4112, 4304, 4768, 5024, 5288, 5608,
					5960, 6344, 6760, 7208, 7688, 7888, 8432, 8768, 9136, 9776,
					10208
				},
				new int[41]
				{
					0, 104, 176, 272, 384, 496, 608, 704, 880, 1056,
					1232, 1440, 1648, 1952, 2088, 2360, 2600, 2936, 3176, 3560,
					3880, 4096, 4544, 4912, 5312, 5744, 6032, 6464, 6968, 7288,
					7880, 8264, 8920, 9368, 9848, 10288, 10832, 11408, 12016, 12656,
					13328
				}
			};
			int num5 = 0;
			if (_version == 0)
			{
				_version = 1;
				for (int m = 1; m <= 40; m++)
				{
					if (array6[b2][m] >= num4 + array5[_version])
					{
						num5 = array6[b2][m];
						break;
					}
					_version++;
				}
			}
			else
			{
				num5 = array6[b2][_version];
			}
			num4 += array5[_version];
			array2[num3] = (sbyte)(array2[num3] + array5[_version]);
			int[] array7 = new int[41]
			{
				0, 26, 44, 70, 100, 134, 172, 196, 242, 292,
				346, 404, 466, 532, 581, 655, 733, 815, 901, 991,
				1085, 1156, 1258, 1364, 1474, 1588, 1706, 1828, 1921, 2051,
				2185, 2323, 2465, 2611, 2761, 2876, 3034, 3196, 3362, 3532,
				3706
			};
			int num6 = array7[_version];
			int[] array8 = new int[41]
			{
				0, 0, 7, 7, 7, 7, 7, 0, 0, 0,
				0, 0, 0, 0, 3, 3, 3, 3, 3, 3,
				3, 4, 4, 4, 4, 4, 4, 4, 3, 3,
				3, 3, 3, 3, 3, 0, 0, 0, 0, 0,
				0
			};
			int num7 = array8[_version] + (num6 << 3);
			sbyte[] array9 = new sbyte[num7];
			sbyte[] array10 = new sbyte[num7];
			sbyte[] array11 = new sbyte[num7];
			sbyte[] array12 = new sbyte[15];
			sbyte[] array13 = new sbyte[15];
			sbyte[] array14 = new sbyte[1];
			sbyte[] array15 = new sbyte[128];
			try
			{
				string name = "qrv" + Convert.ToString(_version) + "_" + Convert.ToString(b2);
				using Stream stream = new MemoryStream((byte[])Resources.ResourceManager.GetObject(name), writable: false);
				using BufferedStream sourceStream = new BufferedStream(stream);
				SystemUtils.ReadInput(sourceStream, array9, 0, array9.Length);
				SystemUtils.ReadInput(sourceStream, array10, 0, array10.Length);
				SystemUtils.ReadInput(sourceStream, array11, 0, array11.Length);
				SystemUtils.ReadInput(sourceStream, array12, 0, array12.Length);
				SystemUtils.ReadInput(sourceStream, array13, 0, array13.Length);
				SystemUtils.ReadInput(sourceStream, array14, 0, array14.Length);
				SystemUtils.ReadInput(sourceStream, array15, 0, array15.Length);
			}
			catch (Exception throwable)
			{
				SystemUtils.WriteStackTrace(throwable, Console.Error);
			}
			sbyte b3 = 1;
			for (byte b4 = 1; b4 < 128; b4++)
			{
				if (array15[b4] == 0)
				{
					b3 = (sbyte)b4;
					break;
				}
			}
			sbyte[] array16 = new sbyte[b3];
			Array.Copy(array15, 0, array16, 0, (byte)b3);
			sbyte[] array17 = new sbyte[15]
			{
				0, 1, 2, 3, 4, 5, 7, 8, 8, 8,
				8, 8, 8, 8, 8
			};
			sbyte[] array18 = new sbyte[15]
			{
				8, 8, 8, 8, 8, 8, 8, 8, 7, 5,
				4, 3, 2, 1, 0
			};
			int maxDataCodewords = num5 >> 3;
			int num8 = 4 * _version + 17;
			int num9 = num8 * num8;
			sbyte[] array19 = new sbyte[num9 + num8];
			try
			{
				string name2 = "qrvfr" + Convert.ToString(_version);
				Stream stream2 = new MemoryStream((byte[])Resources.ResourceManager.GetObject(name2), writable: false);
				BufferedStream bufferedStream = new BufferedStream(stream2);
				SystemUtils.ReadInput(bufferedStream, array19, 0, array19.Length);
				bufferedStream.Close();
				stream2.Close();
			}
			catch (Exception throwable2)
			{
				SystemUtils.WriteStackTrace(throwable2, Console.Error);
			}
			if (num4 <= num5 - 4)
			{
				array[num] = 0;
				array2[num] = 4;
			}
			else if (num4 < num5)
			{
				array[num] = 0;
				array2[num] = (sbyte)(num5 - num4);
			}
			else if (num4 > num5)
			{
				Console.Out.WriteLine("overflow");
			}
			sbyte[] codewords = divideDataBy8Bits(array, array2, maxDataCodewords);
			sbyte[] array20 = calculateRSECC(codewords, array14[0], array16, maxDataCodewords, num6);
			sbyte[][] array21 = new sbyte[num8][];
			for (int n = 0; n < num8; n++)
			{
				array21[n] = new sbyte[num8];
			}
			for (int num10 = 0; num10 < num8; num10++)
			{
				for (int num11 = 0; num11 < num8; num11++)
				{
					array21[num11][num10] = 0;
				}
			}
			for (int num12 = 0; num12 < num6; num12++)
			{
				sbyte b5 = array20[num12];
				for (int num13 = 7; num13 >= 0; num13--)
				{
					int num14 = num12 * 8 + num13;
					array21[array9[num14] & 0xFF][array10[num14] & 0xFF] = (sbyte)((255 * (b5 & 1)) ^ array11[num14]);
					b5 = (sbyte)SystemUtils.URShift(b5 & 0xFF, 1);
				}
			}
			for (int num15 = array8[_version]; num15 > 0; num15--)
			{
				int num16 = num15 + num6 * 8 - 1;
				array21[array9[num16] & 0xFF][array10[num16] & 0xFF] = (sbyte)(0xFF ^ array11[num16]);
			}
			sbyte b6 = selectMask(array21, array8[_version] + num6 * 8);
			sbyte b7 = (sbyte)(1 << (int)b6);
			sbyte b8 = (sbyte)((sbyte)(b2 << 3) | b6);
			string[] array22 = new string[32]
			{
				"101010000010010", "101000100100101", "101111001111100", "101101101001011", "100010111111001", "100000011001110", "100111110010111", "100101010100000", "111011111000100", "111001011110011",
				"111110110101010", "111100010011101", "110011000101111", "110001100011000", "110110001000001", "110100101110110", "001011010001001", "001001110111110", "001110011100111", "001100111010000",
				"000011101100010", "000001001010101", "000110100001100", "000100000111011", "011010101011111", "011000001101000", "011111100110001", "011101000000110", "010010010110100", "010000110000011",
				"010111011011010", "010101111101101"
			};
			for (int num17 = 0; num17 < 15; num17++)
			{
				sbyte b9 = sbyte.Parse(array22[b8].Substring(num17, num17 + 1 - num17));
				array21[array17[num17] & 0xFF][array18[num17] & 0xFF] = (sbyte)(b9 * 255);
				array21[array12[num17] & 0xFF][array13[num17] & 0xFF] = (sbyte)(b9 * 255);
			}
			bool[][] array23 = new bool[num8][];
			for (int num18 = 0; num18 < num8; num18++)
			{
				array23[num18] = new bool[num8];
			}
			int num19 = 0;
			for (int num20 = 0; num20 < num8; num20++)
			{
				for (int num21 = 0; num21 < num8; num21++)
				{
					if ((array21[num21][num20] & b7) != 0 || array19[num19] == 49)
					{
						array23[num21][num20] = true;
					}
					else
					{
						array23[num21][num20] = false;
					}
					num19++;
				}
				num19++;
			}
			return array23;
		}

		private static sbyte[] divideDataBy8Bits(int[] data, sbyte[] bits, int maxDataCodewords)
		{
			int num = bits.Length;
			int num2 = 0;
			int num3 = 8;
			int num4 = 0;
			_ = data.Length;
			for (int i = 0; i < num; i++)
			{
				num4 += bits[i];
			}
			int num5 = (num4 - 1) / 8 + 1;
			sbyte[] array = new sbyte[maxDataCodewords];
			for (int j = 0; j < num5; j++)
			{
				array[j] = 0;
			}
			for (int k = 0; k < num; k++)
			{
				int num6 = data[k];
				int num7 = bits[k];
				bool flag = true;
				if (num7 == 0)
				{
					break;
				}
				while (flag)
				{
					if (num3 > num7)
					{
						array[num2] = (sbyte)((array[num2] << num7) | num6);
						num3 -= num7;
						flag = false;
						continue;
					}
					num7 -= num3;
					array[num2] = (sbyte)((array[num2] << num3) | (num6 >> num7));
					if (num7 == 0)
					{
						flag = false;
					}
					else
					{
						num6 &= (1 << num7) - 1;
						flag = true;
					}
					num2++;
					num3 = 8;
				}
			}
			if (num3 != 8)
			{
				array[num2] = (sbyte)(array[num2] << num3);
			}
			else
			{
				num2--;
			}
			if (num2 < maxDataCodewords - 1)
			{
				bool flag = true;
				while (num2 < maxDataCodewords - 1)
				{
					num2++;
					if (flag)
					{
						array[num2] = -20;
					}
					else
					{
						array[num2] = 17;
					}
					flag = !flag;
				}
			}
			return array;
		}

		private static sbyte[] calculateRSECC(sbyte[] codewords, sbyte rsEccCodewords, sbyte[] rsBlockOrder, int maxDataCodewords, int maxCodewords)
		{
			sbyte[][] array = new sbyte[256][];
			for (int i = 0; i < 256; i++)
			{
				array[i] = new sbyte[rsEccCodewords];
			}
			try
			{
				string name = "rsc" + rsEccCodewords;
				using Stream stream = new MemoryStream((byte[])Resources.ResourceManager.GetObject(name), writable: false);
				using BufferedStream sourceStream = new BufferedStream(stream);
				for (int j = 0; j < 256; j++)
				{
					SystemUtils.ReadInput(sourceStream, array[j], 0, array[j].Length);
				}
			}
			catch (Exception throwable)
			{
				SystemUtils.WriteStackTrace(throwable, Console.Error);
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			sbyte[][] array2 = new sbyte[rsBlockOrder.Length][];
			sbyte[] array3 = new sbyte[maxCodewords];
			Array.Copy(codewords, 0, array3, 0, codewords.Length);
			for (num = 0; num < rsBlockOrder.Length; num++)
			{
				array2[num] = new sbyte[(rsBlockOrder[num] & 0xFF) - rsEccCodewords];
			}
			for (num = 0; num < maxDataCodewords; num++)
			{
				array2[num3][num2] = codewords[num];
				num2++;
				if (num2 >= (rsBlockOrder[num3] & 0xFF) - rsEccCodewords)
				{
					num2 = 0;
					num3++;
				}
			}
			for (num3 = 0; num3 < rsBlockOrder.Length; num3++)
			{
				sbyte[] array4 = new sbyte[array2[num3].Length];
				array2[num3].CopyTo(array4, 0);
				int num4 = rsBlockOrder[num3] & 0xFF;
				int num5 = num4 - rsEccCodewords;
				for (num2 = num5; num2 > 0; num2--)
				{
					sbyte b = array4[0];
					if (b != 0)
					{
						sbyte[] array5 = new sbyte[array4.Length - 1];
						Array.Copy(array4, 1, array5, 0, array4.Length - 1);
						sbyte[] xb = array[b & 0xFF];
						array4 = calculateByteArrayBits(array5, xb, "xor");
					}
					else if (rsEccCodewords < array4.Length)
					{
						sbyte[] array6 = new sbyte[array4.Length - 1];
						Array.Copy(array4, 1, array6, 0, array4.Length - 1);
						array4 = new sbyte[array6.Length];
						array6.CopyTo(array4, 0);
					}
					else
					{
						sbyte[] array7 = new sbyte[rsEccCodewords];
						Array.Copy(array4, 1, array7, 0, array4.Length - 1);
						array7[rsEccCodewords - 1] = 0;
						array4 = new sbyte[array7.Length];
						array7.CopyTo(array4, 0);
					}
				}
				Array.Copy(array4, 0, array3, codewords.Length + num3 * rsEccCodewords, (byte)rsEccCodewords);
			}
			return array3;
		}

		private static sbyte[] calculateByteArrayBits(sbyte[] xa, sbyte[] xb, string ind)
		{
			sbyte[] array;
			sbyte[] array2;
			if (xa.Length > xb.Length)
			{
				array = new sbyte[xa.Length];
				xa.CopyTo(array, 0);
				array2 = new sbyte[xb.Length];
				xb.CopyTo(array2, 0);
			}
			else
			{
				array = new sbyte[xb.Length];
				xb.CopyTo(array, 0);
				array2 = new sbyte[xa.Length];
				xa.CopyTo(array2, 0);
			}
			int num = array.Length;
			int num2 = array2.Length;
			sbyte[] array3 = new sbyte[num];
			for (int i = 0; i < num; i++)
			{
				if (i < num2)
				{
					if ((object)ind == "xor")
					{
						array3[i] = (sbyte)(array[i] ^ array2[i]);
					}
					else
					{
						array3[i] = (sbyte)(array[i] | array2[i]);
					}
				}
				else
				{
					array3[i] = array[i];
				}
			}
			return array3;
		}

		private static sbyte selectMask(sbyte[][] matrixContent, int maxCodewordsBitWithRemain)
		{
			int num = matrixContent.Length;
			int[] array = new int[8];
			int[] array2 = array;
			int[] array3 = new int[8];
			int[] array4 = array3;
			int[] array5 = new int[8];
			int[] array6 = array5;
			int[] array7 = new int[8];
			int[] array8 = array7;
			int num2 = 0;
			int num3 = 0;
			int[] array9 = new int[8];
			int[] array10 = array9;
			for (int i = 0; i < num; i++)
			{
				int[] array11 = new int[8];
				int[] array12 = array11;
				int[] array13 = new int[8];
				int[] array14 = array13;
				bool[] array15 = new bool[8];
				bool[] array16 = array15;
				bool[] array17 = new bool[8];
				bool[] array18 = array17;
				for (int j = 0; j < num; j++)
				{
					if (j > 0 && i > 0)
					{
						num2 = matrixContent[j][i] & matrixContent[j - 1][i] & matrixContent[j][i - 1] & matrixContent[j - 1][i - 1] & 0xFF;
						num3 = (matrixContent[j][i] & 0xFF) | (matrixContent[j - 1][i] & 0xFF) | (matrixContent[j][i - 1] & 0xFF) | (matrixContent[j - 1][i - 1] & 0xFF);
					}
					for (int k = 0; k < 8; k++)
					{
						array12[k] = ((array12[k] & 0x3F) << 1) | (SystemUtils.URShift(matrixContent[j][i] & 0xFF, k) & 1);
						array14[k] = ((array14[k] & 0x3F) << 1) | (SystemUtils.URShift(matrixContent[i][j] & 0xFF, k) & 1);
						if ((matrixContent[j][i] & (1 << k)) != 0)
						{
							array10[k]++;
						}
						if (array12[k] == 93)
						{
							array6[k] += 40;
						}
						if (array14[k] == 93)
						{
							array6[k] += 40;
						}
						if (j > 0 && i > 0)
						{
							if ((num2 & 1) != 0 || (num3 & 1) == 0)
							{
								array4[k] += 3;
							}
							num2 >>= 1;
							num3 >>= 1;
						}
						if ((array12[k] & 0x1F) == 0 || (array12[k] & 0x1F) == 31)
						{
							if (j > 3)
							{
								if (array16[k])
								{
									array2[k]++;
								}
								else
								{
									array2[k] += 3;
									array16[k] = true;
								}
							}
						}
						else
						{
							array16[k] = false;
						}
						if ((array14[k] & 0x1F) == 0 || (array14[k] & 0x1F) == 31)
						{
							if (j > 3)
							{
								if (array18[k])
								{
									array2[k]++;
									continue;
								}
								array2[k] += 3;
								array18[k] = true;
							}
						}
						else
						{
							array18[k] = false;
						}
					}
				}
			}
			int num4 = 0;
			sbyte result = 0;
			int[] array19 = new int[21]
			{
				90, 80, 70, 60, 50, 40, 30, 20, 10, 0,
				0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
				90
			};
			for (int l = 0; l < 8; l++)
			{
				array8[l] = array19[20 * array10[l] / maxCodewordsBitWithRemain];
				int num5 = array2[l] + array4[l] + array6[l] + array8[l];
				if (num5 < num4 || l == 0)
				{
					result = (sbyte)l;
					num4 = num5;
				}
			}
			return result;
		}

		public virtual Bitmap Encode(string content, Encoding encoding)
		{
			bool[][] array = CalculateQrCode(encoding.GetBytes(content));
			SolidBrush solidBrush = new SolidBrush(_backgroundColor);
			Bitmap bitmap = new Bitmap(array.Length * _scale + 1, array.Length * _scale + 1);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(solidBrush, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			solidBrush.Color = _foregroundColor;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j][i])
					{
						graphics.FillRectangle(solidBrush, j * _scale, i * _scale, _scale, _scale);
					}
				}
			}
			return bitmap;
		}

		public virtual Bitmap Encode(string content)
		{
			if (QRCodeUtility.IsUnicode(content))
			{
				return Encode(content, Encoding.Unicode);
			}
			return Encode(content, Encoding.ASCII);
		}
	}

	public sealed override Image Draw(string text, BarcodeMetrics metrics)
	{
		return DrawQr(text, (BarcodeMetricsQr)metrics);
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
		BarcodeMetricsQr barcodeMetricsQr = new BarcodeMetricsQr();
		barcodeMetricsQr.Scale = qRCodeEncoder.Scale;
		barcodeMetricsQr.Version = qRCodeEncoder.Version;
		barcodeMetricsQr.EncodeMode = qRCodeEncoder.EncodeMode;
		barcodeMetricsQr.ErrorCorrection = qRCodeEncoder.ErrorCorrect;
		return barcodeMetricsQr;
	}

	public override BarcodeMetrics GetPrintMetrics(Size desiredBarcodeDimensions, Size printResolution, int barcodeCharLength)
	{
		return GetDefaultMetrics(30);
	}

	protected virtual Image DrawQr(string text, BarcodeMetricsQr metrics)
	{
		QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
		qRCodeEncoder.Scale = metrics.Scale;
		qRCodeEncoder.Version = metrics.Version;
		qRCodeEncoder.EncodeMode = metrics.EncodeMode;
		qRCodeEncoder.ErrorCorrect = metrics.ErrorCorrection;
		QRCodeEncoder qRCodeEncoder2 = qRCodeEncoder;
		return qRCodeEncoder2.Encode(text);
	}
}
