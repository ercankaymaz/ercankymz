using System.Collections.Generic;
using CSMath;

namespace ACadSharp.Entities;

public interface IPolyline : IEntity, IHandledCadObject, IGeometricEntity
{
	bool IsClosed { get; set; }

	double Elevation { get; set; }

	XYZ Normal { get; set; }

	double Thickness { get; set; }

	IEnumerable<IVertex> Vertices { get; }
}
