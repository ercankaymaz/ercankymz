using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class FastMeshSurrogate : EntitySurrogate
{
	public float[] PointArray;

	public int[] TriangleArray;

	public float[] NormalArray;

	public byte[] ColorArray;

	public float[] TextureCoordsArray;

	public bool Dynamic;

	public FastMeshSurrogate(FastMesh fm)
		: base(fm)
	{
	}

	protected override Entity ConvertToObject()
	{
		FastMesh fastMesh = new FastMesh(this);
		CopyDataToObject(fastMesh);
		return fastMesh;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		FastMesh obj = (FastMesh)entity;
		obj.ColorArray = ColorArray;
		obj.TextureCoordsArray = TextureCoordsArray;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		FastMesh fastMesh = (FastMesh)entity;
		PointArray = fastMesh.PointArray;
		TriangleArray = fastMesh.TriangleArray;
		NormalArray = fastMesh.NormalArray;
		ColorArray = fastMesh.ColorArray;
		TextureCoordsArray = fastMesh.TextureCoordsArray;
		Dynamic = fastMesh.Dynamic;
		base.CopyDataFromObject(entity);
	}
}
