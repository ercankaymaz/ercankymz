using System;
using System.Text.RegularExpressions;
using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Data;

public record DstvContourPoint(string FlCode, double XCoord, double YCoord, bool IsNotch, double Radius) : LocatedElement(FlCode, XCoord, YCoord)
{
	public static DstvContourPoint CreatePoint(string dstvElement)
	{
		string[] dataVector = DstvElement.GetDataVector(dstvElement, FineSplitter.Instance);
		string flCode = "x";
		dataVector[0] = dataVector[0].Trim();
		int num = 1;
		if (DstvElement.ValidateFlange(dataVector[0]))
		{
			flCode = dataVector[0];
			num++;
		}
		bool isNotch = IsNotchPoint(dataVector[num]);
		dataVector = DstvElement.CorrectSplits(dataVector);
		double xCoord = double.Parse(dataVector[0], Constants.ParserCultureInfo);
		double yCoord = double.Parse(dataVector[1], Constants.ParserCultureInfo);
		double radius = double.Parse(dataVector[2], Constants.ParserCultureInfo);
		if (dataVector.Length <= 4)
		{
			return new DstvContourPoint(flCode, xCoord, yCoord, isNotch, radius);
		}
		if (dataVector.Length == 5)
		{
			double num2 = double.Parse(dataVector[3], Constants.ParserCultureInfo);
			double num3 = double.Parse(dataVector[4], Constants.ParserCultureInfo);
			if (num2 == 0.0 && num3 == 0.0)
			{
				return new DstvContourPoint(flCode, xCoord, yCoord, isNotch, radius);
			}
			return new DstvSkewedPoint(flCode, xCoord, yCoord, isNotch, radius, num2, num3, 0.0, 0.0);
		}
		if (dataVector.Length == 7)
		{
			double num2 = double.Parse(dataVector[4], Constants.ParserCultureInfo);
			double secondAngle = double.Parse(dataVector[6], Constants.ParserCultureInfo);
			double num3 = double.Parse(dataVector[5], Constants.ParserCultureInfo);
			if (num2 == 0.0 && num3 == 0.0)
			{
				return new DstvContourPoint(flCode, xCoord, yCoord, isNotch, radius);
			}
			return new DstvSkewedPoint(flCode, xCoord, yCoord, isNotch, radius, num2, num3, secondAngle, 0.0);
		}
		if (dataVector.Length == 8)
		{
			double num2 = double.Parse(dataVector[4], Constants.ParserCultureInfo);
			double num3 = double.Parse(dataVector[5], Constants.ParserCultureInfo);
			double num4 = double.Parse(dataVector[6], Constants.ParserCultureInfo);
			double num5 = double.Parse(dataVector[7], Constants.ParserCultureInfo);
			if (num2 == 0.0 && num3 == 0.0 && num4 == 0.0 && num5 == 0.0)
			{
				return new DstvContourPoint(flCode, xCoord, yCoord, isNotch, radius);
			}
			return new DstvSkewedPoint(flCode, xCoord, yCoord, isNotch, radius, num2, num3, num4, num5);
		}
		throw new DstvParseException("Illegal data vector format (AK/IK)");
	}

	private static bool IsNotchPoint(string yCoordValue)
	{
		string pattern = "[.\\d-]+" + "[wt]";
		return Regex.IsMatch(yCoordValue, pattern, RegexOptions.None, TimeSpan.FromSeconds(1.0));
	}

	public override string ToString()
	{
		return $"DStVContourPoint : radius={Radius}, flCode='{base.FlCode}', xCoord={base.XCoord}, yCoord={base.YCoord}";
	}
}
