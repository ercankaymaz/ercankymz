using devDept.Geometry;

namespace devDept.Serialization;

public class IndexTriangleSurrogate : IndexLineSurrogate
{
	public int V3;

	public IndexTriangleSurrogate(IndexTriangle indexTriangle)
		: base(indexTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new IndexTriangle(V1, V2, V3);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		IndexTriangle indexTriangle = indexLine as IndexTriangle;
		V3 = indexTriangle.V3;
		base.CopyDataFromObject(indexLine);
	}
}
