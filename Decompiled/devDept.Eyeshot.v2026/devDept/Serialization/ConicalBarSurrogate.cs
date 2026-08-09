using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class ConicalBarSurrogate : BarSurrogate
{
	public double TopRadius;

	internal Vector3D[] Normals;

	public ConicalBarSurrogate(ConicalBar conicalBar)
		: base(conicalBar)
	{
	}

	protected override Entity ConvertToObject()
	{
		ConicalBar conicalBar = new ConicalBar(this);
		CopyDataToObject(conicalBar);
		return conicalBar;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		(entity as ConicalBar).Normals = Normals;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		ConicalBar conicalBar = entity as ConicalBar;
		TopRadius = conicalBar.TopRadius;
		Normals = conicalBar.Normals;
		base.CopyDataFromObject(entity);
	}
}
