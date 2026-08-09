using devDept.Geometry;

namespace devDept.Serialization;

public class Segment2DSurrogate : Surrogate<Segment2D>
{
	public Point2D P0;

	public Point2D P1;

	public Segment2DSurrogate(Segment2D segment2D)
		: base(segment2D)
	{
	}

	protected override Segment2D ConvertToObject()
	{
		return new Segment2D(P0, P1);
	}

	protected override void CopyDataToObject(Segment2D obj)
	{
	}

	protected override void CopyDataFromObject(Segment2D s)
	{
		P0 = s.P0;
		P1 = s.P1;
	}

	public static implicit operator Segment2D(Segment2DSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Segment2DSurrogate(Segment2D source)
	{
		return source?.ConvertToSurrogate();
	}
}
