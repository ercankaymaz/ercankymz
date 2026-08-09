using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

public interface IText : IEntity, IHandledCadObject, IGeometricEntity
{
	double Height { get; set; }

	string Value { get; set; }

	TextStyle Style { get; set; }

	XYZ InsertPoint { get; set; }

	XYZ AlignmentPoint { get; set; }

	double Rotation { get; }
}
