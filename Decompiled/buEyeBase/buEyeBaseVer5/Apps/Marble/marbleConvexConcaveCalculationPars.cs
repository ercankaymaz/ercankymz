using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

public class marbleConvexConcaveCalculationPars
{
	public bool isConvex = false;

	public bool isInside = false;

	public bool isInsideSecond = false;

	public bool ReverseThetaCalculation = false;

	public bool FirstCornerCalculated = false;

	public double MinLength = 100.0;

	public double ConvexLength = 0.0;

	public double ConcaveLength = 0.0;

	public double ConvexMinRadius = 100.0;

	public double Depth = 0.0;

	public int EntityIndex = -1;

	public int EntitySubIndex = -1;

	public ClockDirectionType ClockDir = ClockDirectionType.CCW;

	public marbleConvexConcaveCalculationPars()
	{
	}

	public marbleConvexConcaveCalculationPars(bool isconvex, bool reverseThetaCalculation, double convexLength, double concaveLength)
	{
		isConvex = isconvex;
		ReverseThetaCalculation = reverseThetaCalculation;
		ConvexLength = convexLength;
		ConcaveLength = concaveLength;
	}

	public marbleConvexConcaveCalculationPars(marbleConvexConcaveCalculationPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "isConvex: " + isConvex + " - ConvexExtraLength: " + ConvexLength + " - ConcaveExtraLength: " + ConcaveLength;
	}
}
