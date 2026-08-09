using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class SectionLineSurrogate : TextSurrogate
{
	public bool ShowArrowHead;

	public double ArrowHeadSize;

	public Point3D EndPoint;

	public SectionLineSurrogate(SectionLine sLine)
		: base(sLine)
	{
	}

	protected override Entity ConvertToObject()
	{
		SectionLine sectionLine = new SectionLine(this);
		CopyDataToObject(sectionLine);
		return sectionLine;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		SectionLine obj = (SectionLine)entity;
		obj.ShowArrowHead = ShowArrowHead;
		obj.ArrowHeadSize = ArrowHeadSize;
		obj.EndPoint = EndPoint;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		SectionLine sectionLine = (SectionLine)entity;
		ShowArrowHead = sectionLine.ShowArrowHead;
		ArrowHeadSize = sectionLine.ArrowHeadSize;
		EndPoint = sectionLine.EndPoint;
		base.CopyDataFromObject(entity);
	}
}
