namespace Xbim.Common.Geometry;

public struct XbimShapeGeometryHandle(short contextHandle, int shapeLabel, int referenceCount)
{
	private readonly short _contextHandle = contextHandle;

	private readonly int _shapeLabel = shapeLabel;

	private readonly int _referenceCount = referenceCount;

	public short Context => _contextHandle;

	public int ShapeLabel => _shapeLabel;

	public int ReferenceCount => _referenceCount;
}
