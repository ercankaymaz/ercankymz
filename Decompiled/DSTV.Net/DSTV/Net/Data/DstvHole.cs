using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Data;

public record DstvHole : LocatedElement
{
	public double Depth { get; }

	public double Diameter { get; }

	protected DstvHole(string flCode, double xCoord, double yCoord, double diam, double depth)
		: base(flCode, xCoord, yCoord)
	{
		Diameter = diam;
		Depth = depth;
	}

	public static DstvElement CreateHole(string holeNote)
	{
		string[] dataVector = DstvElement.GetDataVector(holeNote, FineSplitter.Instance);
		dataVector[0] = dataVector[0].Trim();
		dataVector = DstvElement.CorrectSplits(dataVector, skipFirst: true);
		if (!DstvElement.ValidateFlange(dataVector[0]))
		{
			throw new DstvParseException("Illegal flange code signature in BO data line");
		}
		if (dataVector.Length < 4)
		{
			throw new DstvParseException("Illegal data vector format (BO): too short");
		}
		double xCoord = double.Parse(dataVector[1], Constants.ParserCultureInfo);
		double yCoord = double.Parse(dataVector[2], Constants.ParserCultureInfo);
		double diam = double.Parse(dataVector[3], Constants.ParserCultureInfo);
		double depth = 0.0;
		if (dataVector.Length > 4)
		{
			depth = double.Parse(dataVector[4], Constants.ParserCultureInfo);
		}
		int num = dataVector.Length;
		if ((uint)(num - 4) <= 1u)
		{
			return new DstvHole(dataVector[0], xCoord, yCoord, diam, depth);
		}
		if (dataVector.Length == 8)
		{
			double slotLen = double.Parse(dataVector[5], Constants.ParserCultureInfo);
			double slotWidth = double.Parse(dataVector[6], Constants.ParserCultureInfo);
			double slotAng = double.Parse(dataVector[7], Constants.ParserCultureInfo);
			return new DstvSlot(dataVector[0], xCoord, yCoord, diam, depth, slotLen, slotWidth, slotAng);
		}
		throw new DstvParseException("Illegal data vector format (BO): length not equals 5 or 8");
	}

	public override string ToString()
	{
		return $"DStVHole : flCode='{base.FlCode}', xCoord={base.XCoord}, yCoord={base.YCoord}, diam={Diameter}, depth={Depth}";
	}

	public override string ToSvg()
	{
		return $"<circle cx=\"{base.XCoord:F}\" cy=\"{base.YCoord:F}\" r=\"{Diameter / 2.0:F}\" fill=\"white\" />";
	}
}
