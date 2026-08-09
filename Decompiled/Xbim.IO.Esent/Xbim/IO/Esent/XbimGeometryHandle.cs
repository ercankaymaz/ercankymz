using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

public struct XbimGeometryHandle
{
	public int GeometryLabel;

	public int SurfaceStyleLabel;

	public int ProductLabel;

	public short ExpressTypeId;

	public XbimGeometryType GeometryType;

	public int? GeometryHashCode;

	public XbimSurfaceStyle SurfaceStyle => new XbimSurfaceStyle(ExpressTypeId, SurfaceStyleLabel);

	public XbimGeometryHandle(int geometryLabel, XbimGeometryType geometryType, int productLabel, short expressTypeId, int surfaceStyleLabel, int? geometryHashCode)
	{
		GeometryLabel = geometryLabel;
		SurfaceStyleLabel = surfaceStyleLabel;
		ProductLabel = productLabel;
		ExpressTypeId = expressTypeId;
		GeometryType = geometryType;
		GeometryHashCode = geometryHashCode;
	}

	public XbimGeometryHandle(int geometryLabel, XbimGeometryType geometryType, int productLabel, short expressTypeId, int surfaceStyleLabel)
	{
		this = new XbimGeometryHandle(geometryLabel, geometryType, productLabel, expressTypeId, surfaceStyleLabel, null);
	}

	public XbimGeometryHandle(int geometryLabel)
	{
		GeometryLabel = geometryLabel;
		GeometryType = XbimGeometryType.Undefined;
		SurfaceStyleLabel = 0;
		ProductLabel = 0;
		ExpressTypeId = 0;
		GeometryHashCode = null;
	}
}
