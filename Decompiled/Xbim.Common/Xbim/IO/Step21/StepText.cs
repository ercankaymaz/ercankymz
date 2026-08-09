using System;
using System.Globalization;
using System.Text;

namespace Xbim.IO.Step21;

public static class StepText
{
	private enum WriteState
	{
		Normal,
		TwoBytes,
		FourBytes
	}

	internal static readonly CultureInfo DoubleCulture = new CultureInfo("en-US", useUserOverride: false);

	public static double ToDouble(this string val)
	{
		switch (val)
		{
		case "-1.#INF":
			return double.NegativeInfinity;
		case "1.#INF":
			return double.PositiveInfinity;
		case "-1.#IND":
			return double.NaN;
		default:
		{
			if (double.TryParse(val, NumberStyles.Any, DoubleCulture, out var result))
			{
				return result;
			}
			return double.NaN;
		}
		}
	}

	public static string ToPart21(this string source)
	{
		if (string.IsNullOrEmpty(source))
		{
			return "";
		}
		WriteState fromState = WriteState.Normal;
		StringBuilder stringBuilder = new StringBuilder(source.Length * 2);
		for (int i = 0; i < source.Length; i++)
		{
			int num;
			try
			{
				num = char.ConvertToUtf32(source, i);
			}
			catch (Exception)
			{
				num = 63;
			}
			if (num > 65535)
			{
				fromState = SetMode(WriteState.FourBytes, fromState, stringBuilder);
				stringBuilder.AppendFormat("{0:X8}", num);
				i++;
				continue;
			}
			if (num > 255)
			{
				fromState = SetMode(WriteState.TwoBytes, fromState, stringBuilder);
				stringBuilder.AppendFormat("{0:X4}", num);
				continue;
			}
			fromState = SetMode(WriteState.Normal, fromState, stringBuilder);
			if (num > 126 || num < 32)
			{
				stringBuilder.AppendFormat("\\X\\{0:X2}", num);
			}
			else if ((ushort)num == 39)
			{
				stringBuilder.Append("''");
			}
			else if ((ushort)num == 92)
			{
				stringBuilder.Append("\\\\");
			}
			else
			{
				stringBuilder.Append((char)num);
			}
		}
		SetMode(WriteState.Normal, fromState, stringBuilder);
		return stringBuilder.ToString();
	}

	private static WriteState SetMode(WriteState newState, WriteState fromState, StringBuilder sb)
	{
		if (newState == fromState)
		{
			return newState;
		}
		if (fromState != WriteState.Normal)
		{
			sb.Append("\\X0\\");
		}
		switch (newState)
		{
		case WriteState.TwoBytes:
			sb.Append("\\X2\\");
			break;
		case WriteState.FourBytes:
			sb.Append("\\X4\\");
			break;
		}
		return newState;
	}
}
