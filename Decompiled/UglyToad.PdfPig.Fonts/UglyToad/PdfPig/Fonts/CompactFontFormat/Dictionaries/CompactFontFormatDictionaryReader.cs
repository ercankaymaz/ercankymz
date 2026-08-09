using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

internal abstract class CompactFontFormatDictionaryReader<TResult, TBuilder>
{
	protected readonly struct Operand
	{
		public int? Int { get; }

		public double Double { get; }

		public Operand(int integer)
		{
			Int = integer;
			Double = integer;
		}

		public Operand(double d)
		{
			Int = null;
			Double = d;
		}
	}

	protected readonly struct OperandKey
	{
		public byte Byte0 { get; }

		public byte? Byte1 { get; }

		public OperandKey(byte byte0)
		{
			Byte0 = byte0;
			Byte1 = null;
		}

		public OperandKey(byte byte0, byte byte1)
		{
			Byte0 = byte0;
			Byte1 = byte1;
		}
	}

	private readonly List<Operand> operands = new List<Operand>();

	public abstract TResult Read(CompactFontFormatData data, ReadOnlySpan<string> stringIndex);

	protected TBuilder ReadDictionary(TBuilder builder, CompactFontFormatData data, ReadOnlySpan<string> stringIndex)
	{
		while (data.CanRead())
		{
			operands.Clear();
			int num = 0;
			byte b;
			while (true)
			{
				num++;
				if (num > 256)
				{
					throw new InvalidOperationException("Got caught in an infinite loop trying to read a CFF dictionary.");
				}
				b = data.ReadByte();
				if (b <= 21)
				{
					break;
				}
				if (b == 28)
				{
					int integer = (data.ReadByte() << 8) | data.ReadByte();
					operands.Add(new Operand(integer));
					continue;
				}
				if (b == 29)
				{
					int integer2 = (data.ReadByte() << 24) | (data.ReadByte() << 16) | (data.ReadByte() << 8) | data.ReadByte();
					operands.Add(new Operand(integer2));
					continue;
				}
				if (b == 30)
				{
					double d = ReadRealNumber(data);
					operands.Add(new Operand(d));
					continue;
				}
				if (b >= 32 && b <= 246)
				{
					int integer3 = b - 139;
					operands.Add(new Operand(integer3));
					continue;
				}
				if (b >= 247 && b <= 250)
				{
					int integer4 = (b - 247) * 256 + data.ReadByte() + 108;
					operands.Add(new Operand(integer4));
					continue;
				}
				if (b >= 251 && b <= 254)
				{
					int integer5 = -(b - 251) * 256 - data.ReadByte() - 108;
					operands.Add(new Operand(integer5));
					continue;
				}
				throw new InvalidOperationException($"The first dictionary byte was not in the range 29 - 254. Got {b}.");
			}
			OperandKey operandKey = ((b == 12) ? new OperandKey(b, data.ReadByte()) : new OperandKey(b));
			ApplyOperation(builder, operands, operandKey, stringIndex);
		}
		return builder;
	}

	private static double ReadRealNumber(CompactFontFormatData data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		while (!flag)
		{
			byte num = data.ReadByte();
			int num2 = num / 16;
			int num3 = num % 16;
			for (int i = 0; i < 2; i++)
			{
				int num4 = ((i == 0) ? num2 : num3);
				switch (num4)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
					stringBuilder.Append(num4);
					flag2 = false;
					break;
				case 10:
					stringBuilder.Append('.');
					break;
				case 11:
					if (!flag3)
					{
						stringBuilder.Append('E');
						flag2 = true;
						flag3 = true;
					}
					break;
				case 12:
					if (!flag3)
					{
						stringBuilder.Append("E-");
						flag2 = true;
						flag3 = true;
					}
					break;
				case 14:
					stringBuilder.Append('-');
					break;
				case 15:
					flag = true;
					break;
				default:
					throw new InvalidOperationException($"Did not expect nibble value: {num4}.");
				case 13:
					break;
				}
			}
		}
		if (flag2)
		{
			stringBuilder.Append('0');
		}
		if (stringBuilder.Length == 0)
		{
			return 0.0;
		}
		if (!flag3)
		{
			return double.Parse(stringBuilder.ToString(), CultureInfo.InvariantCulture);
		}
		return double.Parse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
	}

	protected abstract void ApplyOperation(TBuilder builder, List<Operand> operands, OperandKey operandKey, ReadOnlySpan<string> stringIndex);

	protected static string GetString(List<Operand> operands, ReadOnlySpan<string> stringIndex)
	{
		if (operands.Count == 0)
		{
			throw new InvalidOperationException("Cannot read a string from an empty operands array.");
		}
		if (!operands[0].Int.HasValue)
		{
			throw new InvalidOperationException($"The first operand for reading a string was not an integer. Got: {operands[0].Double}");
		}
		int value = operands[0].Int.Value;
		if (value >= 0 && value <= 390)
		{
			return CompactFontFormatStandardStrings.GetName(value);
		}
		int num = value - 391;
		if (num >= 0 && num < stringIndex.Length)
		{
			return stringIndex[num];
		}
		return $"SID{value}";
	}

	protected static PdfRectangle GetBoundingBox(List<Operand> operands)
	{
		if (operands.Count != 4)
		{
			return default(PdfRectangle);
		}
		return new PdfRectangle(operands[0].Double, operands[1].Double, operands[2].Double, operands[3].Double);
	}

	protected static double[] ToArray(List<Operand> operands)
	{
		double[] array = new double[operands.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = operands[i].Double;
		}
		return array;
	}

	protected static int GetIntOrDefault(List<Operand> operands, int defaultValue = 0)
	{
		if (operands.Count == 0)
		{
			return defaultValue;
		}
		Operand operand = operands[0];
		if (operand.Int.HasValue)
		{
			return operand.Int.Value;
		}
		return defaultValue;
	}

	protected static int[] ReadDeltaToIntArray(List<Operand> operands)
	{
		int[] array = new int[operands.Count];
		if (operands.Count == 0)
		{
			return array;
		}
		array[0] = (int)operands[0].Double;
		for (int i = 1; i < operands.Count; i++)
		{
			int num = array[i - 1];
			double num2 = operands[i].Double;
			array[i] = (int)((double)num + num2);
		}
		return array;
	}

	protected static double[] ReadDeltaToArray(List<Operand> operands)
	{
		double[] array = new double[operands.Count];
		if (operands.Count == 0)
		{
			return array;
		}
		array[0] = operands[0].Double;
		for (int i = 1; i < operands.Count; i++)
		{
			double num = array[i - 1];
			double num2 = operands[i].Double;
			array[i] = num + num2;
		}
		return array;
	}
}
