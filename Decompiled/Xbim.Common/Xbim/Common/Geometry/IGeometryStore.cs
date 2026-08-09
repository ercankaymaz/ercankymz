using System;

namespace Xbim.Common.Geometry;

public interface IGeometryStore : IDisposable
{
	bool IsEmpty { get; }

	IGeometryStoreInitialiser BeginInit();

	IGeometryStoreReader BeginRead();
}
