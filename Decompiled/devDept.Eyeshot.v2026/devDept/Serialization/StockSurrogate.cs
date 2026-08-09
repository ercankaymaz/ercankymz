using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

namespace devDept.Serialization;

public class StockSurrogate : RegionSurrogate
{
	public Interval RangeZ;

	public Vector3D[] Normals;

	public StockSurrogate(Stock st)
		: base(st)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateMeshOrGhostEntity(Vertices, Triangles, typeof(Stock));
		}
		Stock stock = new Stock(this);
		CopyDataToObject(stock);
		return stock;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Stock stock)
		{
			stock.RangeZ = RangeZ;
			stock._0023_003DzGCLU9Ejbtici1iGNzQ_003D_003D(Normals);
		}
		else if (entity is Mesh mesh)
		{
			mesh.Normals = Normals;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Stock stock = (Stock)entity;
		RangeZ = stock.RangeZ;
		Normals = stock.Normals;
		base.CopyDataFromObject(entity);
	}
}
