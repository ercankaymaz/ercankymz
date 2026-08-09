using devDept.Geometry;

namespace devDept.Serialization;

internal class GLineSurrogate : GEntitySurrogate
{
	public Point3D StartPoint;

	public Point3D EndPoint;

	public GLineSurrogate(GLine gLine)
		: base(gLine)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GLine gLine = new GLine();
		CopyDataToObject(gLine);
		return gLine;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		GLine obj = (GLine)gEntity;
		obj.StartPoint = StartPoint;
		obj.EndPoint = EndPoint;
		base.CopyDataToObject(gEntity);
	}
}
