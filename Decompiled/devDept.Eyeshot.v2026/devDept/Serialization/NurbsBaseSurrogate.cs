using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public abstract class NurbsBaseSurrogate : EntitySurrogate
{
	public Point3D[] Vertices;

	public int p;

	public double[] U;

	public NurbsBaseSurrogate(NurbsBase nurbsBase)
		: base(nurbsBase)
	{
	}

	protected internal abstract int GetP();

	protected internal abstract double[] GetU();

	protected override void CopyDataToObject(Entity entity)
	{
		entity._vertices = Vertices;
		if (entity is NurbsBase nurbsBase)
		{
			nurbsBase._0023_003DzB68dg9Q_003D = GetP();
			nurbsBase._0023_003DziP9fFuA_003D = GetU();
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Vertices = entity.Vertices;
		if (entity is NurbsBase nurbsBase)
		{
			p = nurbsBase._0023_003DzB68dg9Q_003D;
			U = nurbsBase._0023_003DziP9fFuA_003D;
		}
		base.CopyDataFromObject(entity);
	}
}
