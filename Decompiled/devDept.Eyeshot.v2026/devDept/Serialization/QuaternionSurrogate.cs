using devDept.Geometry;

namespace devDept.Serialization;

public class QuaternionSurrogate : Surrogate<Quaternion>
{
	public double X;

	public double Y;

	public double Z;

	public double W;

	public QuaternionSurrogate(Quaternion quaternion)
		: base(quaternion)
	{
	}

	protected override Quaternion ConvertToObject()
	{
		return new Quaternion(X, Y, Z, W);
	}

	protected override void CopyDataToObject(Quaternion quaternion)
	{
	}

	protected override void CopyDataFromObject(Quaternion quaternion)
	{
		X = quaternion.X;
		Y = quaternion.Y;
		Z = quaternion.Z;
		W = quaternion.W;
	}

	public static implicit operator Quaternion(QuaternionSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator QuaternionSurrogate(Quaternion source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate();
		}
		return null;
	}
}
