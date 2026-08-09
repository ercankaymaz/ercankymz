using System;

namespace Xbim.Common.Geometry;

internal interface IXbimSurface : IXbimGeometryObject, IDisposable
{
	double Area { get; }

	double Perimeter { get; }

	string ToBRep { get; }
}
