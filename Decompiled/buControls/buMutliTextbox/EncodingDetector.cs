using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ns27;

namespace buMutliTextbox;

public static class EncodingDetector
{
	public static Encoding DetectTextFileEncoding(string InputFilename)
	{
		using FileStream inputFileStream = File.OpenRead(InputFilename);
		return DetectTextFileEncoding(inputFileStream, 65536L);
	}

	public static Encoding DetectTextFileEncoding(FileStream InputFileStream, long HeuristicSampleSize)
	{
		bool HasBOM = false;
		return DetectTextFileEncoding(InputFileStream, 65536L, out HasBOM);
	}

	public static Encoding DetectTextFileEncoding(FileStream InputFileStream, long HeuristicSampleSize, out bool HasBOM)
	{
		Encoding encoding = null;
		long position = InputFileStream.Position;
		InputFileStream.Position = 0L;
		byte[] array = new byte[(InputFileStream.Length <= 4L) ? InputFileStream.Length : 4L];
		InputFileStream.Read(array, 0, array.Length);
		encoding = DetectBOMBytes(array);
		if (encoding == null)
		{
			byte[] array2 = new byte[(HeuristicSampleSize <= InputFileStream.Length) ? HeuristicSampleSize : InputFileStream.Length];
			Array.Copy(array, array2, array.Length);
			if (InputFileStream.Length > array.Length)
			{
				InputFileStream.Read(array2, array.Length, array2.Length - array.Length);
			}
			InputFileStream.Position = position;
			encoding = DetectUnicodeInByteSampleByHeuristics(array2);
			HasBOM = false;
			return encoding;
		}
		InputFileStream.Position = position;
		HasBOM = true;
		return encoding;
	}

	public static Encoding DetectBOMBytes(byte[] BOMBytes)
	{
		if (BOMBytes.Length >= 2)
		{
			if (BOMBytes[0] != byte.MaxValue || BOMBytes[1] != 254 || (BOMBytes.Length >= 4 && BOMBytes[2] == 0 && BOMBytes[3] == 0))
			{
				if (BOMBytes[0] != 254 || BOMBytes[1] != byte.MaxValue)
				{
					if (BOMBytes.Length >= 3)
					{
						if (BOMBytes[0] != 239 || BOMBytes[1] != 187 || BOMBytes[2] != 191)
						{
							if (BOMBytes[0] != 43 || BOMBytes[1] != 47 || BOMBytes[2] != 118)
							{
								if (BOMBytes.Length >= 4)
								{
									if (BOMBytes[0] != byte.MaxValue || BOMBytes[1] != 254 || BOMBytes[2] != 0 || BOMBytes[3] != 0)
									{
										if (BOMBytes[0] != 0 || BOMBytes[1] != 0 || BOMBytes[2] != 254 || BOMBytes[3] != byte.MaxValue)
										{
											return null;
										}
										return Encoding.GetEncoding(12001);
									}
									return Encoding.UTF32;
								}
								return null;
							}
							return Encoding.UTF7;
						}
						return Encoding.UTF8;
					}
					return null;
				}
				return Encoding.BigEndianUnicode;
			}
			return Encoding.Unicode;
		}
		return null;
	}

	public static Encoding DetectUnicodeInByteSampleByHeuristics(byte[] SampleBytes)
	{
		long num = 0L;
		long num2 = 0L;
		long num3 = 0L;
		long num4 = 0L;
		long num5 = 0L;
		long num6 = 0L;
		int num7 = 0;
		for (; num6 < SampleBytes.Length; num6++)
		{
			if (SampleBytes[num6] == 0)
			{
				if (num6 % 2L != 0L)
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			if (Class76.smethod_49(SampleBytes[num6]))
			{
				num5++;
			}
			if (num7 != 0)
			{
				num7--;
				continue;
			}
			int num8 = Class76.smethod_598(num6, SampleBytes);
			if (num8 > 0)
			{
				num3++;
				num4 += num8;
				num7 = num8 - 1;
			}
		}
		if ((double)num2 * 2.0 / (double)SampleBytes.Length >= 0.2 || !((double)num * 2.0 / (double)SampleBytes.Length > 0.6))
		{
			if ((double)num * 2.0 / (double)SampleBytes.Length >= 0.2 || !((double)num2 * 2.0 / (double)SampleBytes.Length > 0.6))
			{
				string input = Encoding.ASCII.GetString(SampleBytes);
				Regex regex = new Regex("\\A([\\x09\\x0A\\x0D\\x20-\\x7E]|[\\xC2-\\xDF][\\x80-\\xBF]|\\xE0[\\xA0-\\xBF][\\x80-\\xBF]|[\\xE1-\\xEC\\xEE\\xEF][\\x80-\\xBF]{2}|\\xED[\\x80-\\x9F][\\x80-\\xBF]|\\xF0[\\x90-\\xBF][\\x80-\\xBF]{2}|[\\xF1-\\xF3][\\x80-\\xBF]{3}|\\xF4[\\x80-\\x8F][\\x80-\\xBF]{2})*\\z");
				if (!regex.IsMatch(input) || (double)num3 * 500000.0 / (double)SampleBytes.Length < 1.0 || (SampleBytes.Length - num4 != 0L && !((double)num5 * 1.0 / (double)(SampleBytes.Length - num4) >= 0.8)))
				{
					return null;
				}
				return Encoding.UTF8;
			}
			return Encoding.BigEndianUnicode;
		}
		return Encoding.Unicode;
	}
}
