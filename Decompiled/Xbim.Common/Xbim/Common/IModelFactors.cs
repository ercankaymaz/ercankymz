namespace Xbim.Common;

public interface IModelFactors
{
	int ProfileDefLevelOfDetail { get; set; }

	int SimplifyFaceCountThreshHold { get; set; }

	double ShortestEdgeLength { get; set; }

	double PrecisionBoolean { get; set; }

	double PrecisionBooleanMax { get; set; }

	double DeflectionTolerance { get; set; }

	double AngleToRadiansConversionFactor { get; }

	double LengthToMetresConversionFactor { get; }

	double VertexPointDiameter { get; }

	int MaxBRepSewFaceCount { get; set; }

	double Precision { get; set; }

	double PrecisionMax { get; set; }

	int Rounding { get; }

	double OneMetre { get; }

	double OneMilliMetre { get; }

	double DeflectionAngle { get; set; }

	double OneFoot { get; }

	double OneInch { get; }

	double OneKilometer { get; }

	double OneMeter { get; }

	double OneMile { get; }

	double OneMilliMeter { get; }

	int GetGeometryFloatHash(float number);

	int GetGeometryDoubleHash(double number);

	void Initialise(double angleToRadiansConversionFactor, double lengthToMetresConversionFactor, double defaultPrecision);

	bool ApplyWorkAround(string name);
}
