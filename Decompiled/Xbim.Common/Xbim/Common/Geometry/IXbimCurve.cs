using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimCurve : IXbimGeometryObject, IDisposable
{
	double Length { get; }

	XbimPoint3D Start { get; }

	XbimPoint3D End { get; }

	bool IsClosed { get; }

	bool Is3D { get; }

	string ToBRep { get; }

	IEnumerable<XbimPoint3D> Intersections(IXbimCurve intersector, double tolerance, ILogger logger = null);

	double GetParameter(XbimPoint3D point, double tolerance);

	XbimPoint3D GetPoint(double parameter);
}
