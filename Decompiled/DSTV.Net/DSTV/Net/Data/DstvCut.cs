using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Data;

public record DstvCut : DstvElement
{
	private readonly double _normVecX;

	private readonly double _normVecY;

	private readonly double _normVecZ;

	private readonly double _spPointX;

	private readonly double _spPointY;

	private readonly double _spPointZ;

	private DstvCut(double spPointX, double spPointY, double spPointZ, double normVecX, double normVecY, double normVecZ)
	{
		_spPointX = spPointX;
		_spPointY = spPointY;
		_spPointZ = spPointZ;
		_normVecX = normVecX;
		_normVecY = normVecY;
		_normVecZ = normVecZ;
	}

	public static DstvCut CreateCut(string dataLine)
	{
		string[] array = DstvElement.CorrectSplits(DstvElement.GetDataVector(dataLine, FineSplitter.Instance));
		if (array.Length < 6)
		{
			throw new DstvParseException("Illegal data vector format (SC): too short");
		}
		double spPointX = double.Parse(array[0], Constants.ParserCultureInfo);
		double spPointY = double.Parse(array[1], Constants.ParserCultureInfo);
		double spPointZ = double.Parse(array[2], Constants.ParserCultureInfo);
		double normVecX = double.Parse(array[3], Constants.ParserCultureInfo);
		double normVecY = double.Parse(array[4], Constants.ParserCultureInfo);
		double normVecZ = double.Parse(array[5], Constants.ParserCultureInfo);
		return new DstvCut(spPointX, spPointY, spPointZ, normVecX, normVecY, normVecZ);
	}

	public override string ToString()
	{
		return $"DstvCut: spPointX={_spPointX}, spPointY={_spPointY}, spPointZ={_spPointZ}, normVecX={_normVecX}, normVecY={_normVecY}, normVecZ={_normVecZ}";
	}
}
