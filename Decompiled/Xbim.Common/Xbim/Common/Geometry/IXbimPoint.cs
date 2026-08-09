using System;

namespace Xbim.Common.Geometry;

public interface IXbimPoint : IXbimGeometryObject, IDisposable, IEquatable<IXbimPoint>
{
	double X { get; }

	double Y { get; }

	double Z { get; }

	XbimPoint3D Point { get; }

	double Tolerance { get; }
}
