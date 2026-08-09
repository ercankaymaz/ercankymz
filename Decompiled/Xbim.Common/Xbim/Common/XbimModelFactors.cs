using System;
using System.Collections.Generic;

namespace Xbim.Common;

public class XbimModelFactors : IModelFactors
{
	private HashSet<string> _workArounds = new HashSet<string>();

	private int _significantOrder;

	public int ProfileDefLevelOfDetail { get; set; }

	public int SimplifyFaceCountThreshHold { get; set; }

	public double ShortestEdgeLength { get; set; }

	public double PrecisionBoolean { get; set; }

	public double PrecisionBooleanMax { get; set; }

	public double DeflectionTolerance { get; set; }

	public double AngleToRadiansConversionFactor { get; private set; }

	public double LengthToMetresConversionFactor { get; private set; }

	public double VertexPointDiameter { get; private set; }

	public int MaxBRepSewFaceCount { get; set; }

	public double Precision { get; set; }

	public double PrecisionMax { get; set; }

	public int Rounding { get; private set; }

	public double OneMetre { get; private set; }

	public double OneMilliMetre { get; private set; }

	public double DeflectionAngle { get; set; }

	public double OneFoot { get; private set; }

	public double OneInch { get; private set; }

	public double OneKilometer { get; private set; }

	public double OneMeter { get; private set; }

	public double OneMile { get; private set; }

	public double OneMilliMeter { get; private set; }

	public bool ApplyWorkAround(string workAroundName)
	{
		return _workArounds.Contains(workAroundName);
	}

	public void AddWorkAround(string workAroundName)
	{
		_workArounds.Add(workAroundName);
	}

	public int GetGeometryFloatHash(float number)
	{
		return Math.Round(number, _significantOrder).GetHashCode();
	}

	public int GetGeometryDoubleHash(double number)
	{
		return Math.Round(number, _significantOrder).GetHashCode();
	}

	public XbimModelFactors(double angToRads, double lenToMeter, double precision)
	{
		Initialise(angToRads, lenToMeter, precision);
	}

	public void Initialise(double angToRads, double lenToMeter, double defaultPrecision)
	{
		ProfileDefLevelOfDetail = 0;
		SimplifyFaceCountThreshHold = 1000;
		AngleToRadiansConversionFactor = angToRads;
		LengthToMetresConversionFactor = lenToMeter;
		double oneMeter = (OneMetre = 1.0 / lenToMeter);
		OneMeter = oneMeter;
		oneMeter = (OneMilliMetre = OneMeter / 1000.0);
		OneMilliMeter = oneMeter;
		OneKilometer = OneMeter * 1000.0;
		OneFoot = OneMeter / 3.2808;
		OneInch = OneMeter / 39.37;
		OneMile = OneMeter * 1609.344;
		DeflectionTolerance = OneMilliMetre * 5.0;
		DeflectionAngle = 0.5;
		VertexPointDiameter = OneMilliMetre * 10.0;
		Precision = defaultPrecision;
		PrecisionMax = Math.Max(OneMilliMetre / 10.0, Precision * 100.0);
		MaxBRepSewFaceCount = 0;
		PrecisionBoolean = Math.Max(Precision, OneMilliMetre / 10.0);
		PrecisionBooleanMax = Math.Max(OneMilliMetre * 100.0, Precision * 100.0);
		Rounding = Math.Abs((int)Math.Log10(Precision * 100.0));
		double num3 = Math.Floor(Math.Log10(Math.Abs(OneMilliMetre / 10.0)));
		_significantOrder = ((!(num3 > 0.0)) ? ((int)Math.Abs(num3)) : 0);
		ShortestEdgeLength = 10.0 * OneMilliMetre;
	}
}
