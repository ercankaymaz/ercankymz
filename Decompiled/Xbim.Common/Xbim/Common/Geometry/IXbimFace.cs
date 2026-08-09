using System;

namespace Xbim.Common.Geometry;

public interface IXbimFace : IXbimGeometryObject, IDisposable, IEquatable<IXbimFace>
{
	IXbimWire OuterBound { get; }

	IXbimWireSet InnerBounds { get; }

	double Area { get; }

	double Perimeter { get; }

	XbimVector3D Normal { get; }

	bool IsPlanar { get; }

	string ToBRep { get; }

	XbimPoint3D Location { get; }

	void SaveAsBrep(string fileName);
}
