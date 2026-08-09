using devDept.Geometry;

namespace devDept.Serialization;

public class PlaneEquation_V6Surrogate : Vector3D_V6Surrogate
{
	public double D;

	public PlaneEquation_V6Surrogate(PlaneEquation pe)
		: base(pe)
	{
	}

	protected override Vector2D ConvertToObject()
	{
		return new PlaneEquation(X, Y, Z, D);
	}

	protected override void CopyDataFromObject(Vector2D vector)
	{
		PlaneEquation planeEquation = vector as PlaneEquation;
		D = planeEquation.D;
		base.CopyDataFromObject(vector);
	}
}
