using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class BalloonSurrogate : TextSurrogate
{
	public Point3D AnchorPoint;

	public byte Style;

	public bool ShowArrowHead;

	public int Size;

	public double Scale;

	public byte ArrowHead;

	public double ArrowHeadSize;

	public BalloonSurrogate(Balloon balloon)
		: base(balloon)
	{
	}

	protected override Entity ConvertToObject()
	{
		Balloon balloon = new Balloon(this);
		CopyDataToObject(balloon);
		return balloon;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Balloon obj = entity as Balloon;
		obj.ArrowHead = (arrowheadType)ArrowHead;
		obj.ArrowHeadSize = ArrowHeadSize;
		obj.Scale = Scale;
		obj.ShowArrowHead = ShowArrowHead;
		obj.Size = Size;
		obj.Style = (Balloon.balloonStyleType)Style;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Balloon balloon = entity as Balloon;
		AnchorPoint = balloon.AnchorPoint;
		Style = (byte)balloon.Style;
		ShowArrowHead = balloon.ShowArrowHead;
		Size = balloon.Size;
		Scale = balloon.Scale;
		ArrowHead = (byte)balloon.ArrowHead;
		ArrowHeadSize = balloon.ArrowHeadSize;
		base.CopyDataFromObject(entity);
	}
}
