using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Data;

public record DstvBend : DstvElement
{
	private readonly double _bendingAngle;

	private readonly double _bendingRadius;

	private readonly double _finishX;

	private readonly double _finishY;

	private readonly double _originX;

	private readonly double _originY;

	private DstvBend(double originX, double originY, double finishX, double finishY, double bendingAngle, double bendingRadius)
	{
		_originX = originX;
		_originY = originY;
		_finishX = finishX;
		_finishY = finishY;
		_bendingAngle = bendingAngle;
		_bendingRadius = bendingRadius;
	}

	public static DstvBend CreateBend(string bendDataLine)
	{
		string[] array = DstvElement.CorrectSplits(DstvElement.GetDataVector(bendDataLine, FineSplitter.Instance));
		if (array.Length < 6)
		{
			throw new DstvParseException("Illegal data vector format (KA): too short");
		}
		double originX = double.Parse(array[0], Constants.ParserCultureInfo);
		double originY = double.Parse(array[1], Constants.ParserCultureInfo);
		double finishX = double.Parse(array[2], Constants.ParserCultureInfo);
		double finishY = double.Parse(array[3], Constants.ParserCultureInfo);
		double bendingAngle = double.Parse(array[4], Constants.ParserCultureInfo);
		double bendingRadius = double.Parse(array[5], Constants.ParserCultureInfo);
		return new DstvBend(originX, originY, finishX, finishY, bendingAngle, bendingRadius);
	}

	public override string ToString()
	{
		return $"DstvBend{{originX={_originX}, originY={_originY}, finishX={_finishX} , finishY={_finishY}, bendingAngle={_bendingAngle}, bendingRadius={_bendingRadius}'}}";
	}
}
