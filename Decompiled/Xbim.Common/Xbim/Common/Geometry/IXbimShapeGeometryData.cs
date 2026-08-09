namespace Xbim.Common.Geometry;

public interface IXbimShapeGeometryData
{
	int ShapeLabel { get; set; }

	int IfcShapeLabel { get; set; }

	int GeometryHash { get; set; }

	int Cost { get; }

	int ReferenceCount { get; set; }

	byte LOD { get; set; }

	byte Format { get; set; }

	byte[] BoundingBox { get; set; }

	byte[] ShapeDataCompressed { get; set; }

	byte[] ShapeData { get; set; }

	IVector3D LocalShapeDisplacement { get; }
}
