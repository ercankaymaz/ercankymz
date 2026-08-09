using System;

namespace Xbim.Common.Geometry;

public interface IXbimOrientedEdge : IXbimGeometryObject, IDisposable
{
	IXbimEdge EdgeElement { get; }

	bool SameSense { get; }

	IXbimVertex EdgeStart { get; }

	IXbimVertex EdgeEnd { get; }
}
