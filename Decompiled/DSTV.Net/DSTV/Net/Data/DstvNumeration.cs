using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Data;

public record DstvNumeration : LocatedElement
{
	private readonly double _angle;

	private readonly double _letterHeight;

	private readonly string _text;

	private DstvNumeration(string flCode, double xCoord, double yCoord, double angle, double letterHeight, string text)
		: base(flCode, xCoord, yCoord)
	{
		_angle = angle;
		_letterHeight = letterHeight;
		_text = text;
	}

	public static DstvNumeration CreateNumeration(string dstvLine)
	{
		string[] dataVector = DstvElement.GetDataVector(dstvLine, FineSplitter.Instance);
		string flCode = "x";
		if (DstvElement.ValidateFlange(dataVector[1]))
		{
			flCode = dataVector[1];
		}
		dataVector = DstvElement.CorrectSplits(dataVector, skipFirst: false, skipLast: true);
		if (dataVector.Length < 5)
		{
			throw new DstvParseException("Illegal data-vector length (SI) - too short");
		}
		double xCoord = double.Parse(dataVector[0], Constants.ParserCultureInfo);
		double yCoord = double.Parse(dataVector[1], Constants.ParserCultureInfo);
		double angle = double.Parse(dataVector[2], Constants.ParserCultureInfo);
		double letterHeight = double.Parse(dataVector[3], Constants.ParserCultureInfo);
		return new DstvNumeration(flCode, xCoord, yCoord, angle, letterHeight, dataVector[4]);
	}

	public override string ToString()
	{
		return $"Numeration: FlCode={base.FlCode}, XCoord={base.XCoord}, YCoord={base.YCoord}, Angle={_angle}, LetterHeight {_letterHeight}, Text : {_text}";
	}
}
