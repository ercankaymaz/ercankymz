using devDept.Geometry;

namespace devDept.Serialization;

public class Polygon2DSurrogate : Surrogate<Polygon2D>
{
	public Point2D Min;

	public Point2D Max;

	public Point2D[] Points;

	public Polygon2DSurrogate(Polygon2D polygon2D)
		: base(polygon2D)
	{
	}

	protected override Polygon2D ConvertToObject()
	{
		Polygon2D polygon2D = new Polygon2D(Points);
		CopyDataToObject(polygon2D);
		return polygon2D;
	}

	protected override void CopyDataToObject(Polygon2D entity)
	{
		entity.Min = Min;
		entity.Max = Max;
	}

	protected override void CopyDataFromObject(Polygon2D entity)
	{
		Points = entity.Points;
		Min = entity.Min;
		Max = entity.Max;
	}

	public static implicit operator Polygon2D(Polygon2DSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Polygon2DSurrogate(Polygon2D source)
	{
		return source?.ConvertToSurrogate();
	}
}
