using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Serialization;

public class HatchPatternLineSurrogate : Surrogate<HatchPatternLine>
{
	public double Angle;

	public Point2D Origin;

	public double DeltaX;

	public double DeltaY;

	public float[] Pattern;

	public HatchPatternLineSurrogate(HatchPatternLine hatchPatternLine)
		: base(hatchPatternLine)
	{
	}

	protected override HatchPatternLine ConvertToObject()
	{
		if (Pattern == null)
		{
			Pattern = new float[0];
		}
		HatchPatternLine hatchPatternLine = new HatchPatternLine(this);
		CopyDataToObject(hatchPatternLine);
		return hatchPatternLine;
	}

	protected override void CopyDataToObject(HatchPatternLine hatchPatternLine)
	{
	}

	protected override void CopyDataFromObject(HatchPatternLine hatchPatternLine)
	{
		Angle = hatchPatternLine.Angle;
		Origin = hatchPatternLine.Origin;
		DeltaX = hatchPatternLine.DeltaX;
		DeltaY = hatchPatternLine.DeltaY;
		Pattern = hatchPatternLine.Pattern;
	}

	public static implicit operator HatchPatternLine(HatchPatternLineSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator HatchPatternLineSurrogate(HatchPatternLine source)
	{
		return source?.ConvertToSurrogate();
	}
}
