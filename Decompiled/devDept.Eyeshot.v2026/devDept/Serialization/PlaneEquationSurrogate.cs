using devDept.Geometry;

namespace devDept.Serialization;

public class PlaneEquationSurrogate : Vector3DSurrogate
{
	public double D;

	public PlaneEquationSurrogate(PlaneEquation pe)
		: base(pe)
	{
	}

	protected override Vector2D ConvertToObject()
	{
		return new PlaneEquation(X, Y, Z, D);
	}

	protected override void CopyDataFromObject(Vector2D vector)
	{
		PlaneEquation planeEquation = (PlaneEquation)vector;
		D = planeEquation.D;
		base.CopyDataFromObject(vector);
	}
}
