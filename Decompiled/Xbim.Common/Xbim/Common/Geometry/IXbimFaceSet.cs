using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IXbimFaceSet : IEnumerable<IXbimFace>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimFace First { get; }
}
