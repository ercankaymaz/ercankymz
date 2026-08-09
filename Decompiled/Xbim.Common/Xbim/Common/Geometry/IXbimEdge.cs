using System;

namespace Xbim.Common.Geometry;

public interface IXbimEdge : IXbimGeometryObject, IDisposable, IEquatable<IXbimEdge>
{
	IXbimVertex EdgeStart { get; }

	IXbimVertex EdgeEnd { get; }

	IXbimCurve EdgeGeometry { get; }

	double Length { get; }

	string ToBRep { get; }
}
