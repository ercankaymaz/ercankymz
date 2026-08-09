namespace Xbim.Common.Geometry;

public interface IXbimShapeInstanceData
{
	int InstanceLabel { get; set; }

	short IfcTypeId { get; set; }

	int IfcProductLabel { get; set; }

	int StyleLabel { get; set; }

	int ShapeGeometryLabel { get; set; }

	int RepresentationContext { get; set; }

	byte RepresentationType { get; set; }

	byte[] Transformation { get; set; }

	byte[] BoundingBox { get; set; }
}
