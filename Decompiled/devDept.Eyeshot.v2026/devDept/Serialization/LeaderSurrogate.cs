using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class LeaderSurrogate : EntitySurrogate
{
	public Plane Plane;

	public Point3D[] Vertices;

	public byte Arrowhead;

	public double ArrowheadSize;

	public double Scale;

	public bool ShowArrowHead;

	internal Point2D Start2D;

	internal double Angle;

	public LeaderSurrogate(Leader leader)
		: base(leader)
	{
	}

	protected override Entity ConvertToObject()
	{
		Leader leader = new Leader(this);
		CopyDataToObject(leader);
		return leader;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Leader obj = entity as Leader;
		obj.Arrowhead = (arrowheadType)Arrowhead;
		obj.ArrowheadSize = ArrowheadSize;
		obj.Scale = Scale;
		obj.ShowArrowHead = ShowArrowHead;
		obj.Start2D = Start2D;
		obj.Angle = Angle;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Leader leader = entity as Leader;
		Plane = leader.Plane;
		Vertices = leader.Vertices;
		Arrowhead = (byte)leader.Arrowhead;
		ArrowheadSize = leader.ArrowheadSize;
		Scale = leader.Scale;
		ShowArrowHead = leader.ShowArrowHead;
		Start2D = leader.Start2D;
		Angle = leader.Angle;
		base.CopyDataFromObject(entity);
	}
}
