using devDept.Geometry;

namespace devDept.Serialization;

public class Segment3DSurrogate : Surrogate<Segment3D>
{
	public Point3D P0;

	public Point3D P1;

	public Segment3DSurrogate(Segment3D segment3D)
		: base(segment3D)
	{
	}

	protected override Segment3D ConvertToObject()
	{
		return new Segment3D(P0, P1);
	}

	protected override void CopyDataToObject(Segment3D obj)
	{
	}

	protected override void CopyDataFromObject(Segment3D s)
	{
		P0 = s.P0;
		P1 = s.P1;
	}

	public static implicit operator Segment3D(Segment3DSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Segment3DSurrogate(Segment3D source)
	{
		return source?.ConvertToSurrogate();
	}
}
