using devDept.Geometry;

namespace devDept.Serialization;

public class PlaneSurrogate : Surrogate<Plane>
{
	public Point3D Origin;

	public Vector3D AxisX;

	public Vector3D AxisY;

	public PlaneSurrogate(Plane plane)
		: base(plane)
	{
	}

	protected override Plane ConvertToObject()
	{
		return new Plane(Origin, AxisX, AxisY);
	}

	protected override void CopyDataToObject(Plane obj)
	{
	}

	protected override void CopyDataFromObject(Plane plane)
	{
		Origin = plane.Origin;
		AxisX = plane.AxisX;
		AxisY = plane.AxisY;
	}

	public static implicit operator Plane(PlaneSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator PlaneSurrogate(Plane source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate();
		}
		return null;
	}
}
