using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class JointSurrogate : EntitySurrogate
{
	public Point3D Position;

	public double Radius;

	public byte SubdivisionLevel;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public JointSurrogate(Joint joint)
		: base(joint)
	{
	}

	protected override Entity ConvertToObject()
	{
		Joint joint = new Joint(this);
		CopyDataToObject(joint);
		return joint;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Joint obj = entity as Joint;
		obj.Vertices = Vertices;
		obj._0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(Triangles);
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Joint joint = entity as Joint;
		Position = joint.Position;
		Radius = joint.Radius;
		SubdivisionLevel = joint.SubdivisionLevel;
		Vertices = joint.Vertices;
		Triangles = joint.Triangles;
		base.CopyDataFromObject(entity);
	}
}
