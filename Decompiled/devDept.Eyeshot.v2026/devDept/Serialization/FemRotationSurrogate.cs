using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

internal class FemRotationSurrogate : Surrogate<Rotation>
{
	public ProtoArray<double> Matrix;

	public FemRotationSurrogate(Rotation rotation)
		: base(rotation)
	{
	}

	protected override Rotation ConvertToObject()
	{
		return new Rotation(Matrix.ToArray() as double[,]);
	}

	protected override void CopyDataToObject(Rotation obj)
	{
	}

	protected override void CopyDataFromObject(Rotation rotation)
	{
		Matrix = rotation.Matrix.ToProtoArray<double>();
	}

	public static implicit operator Rotation(FemRotationSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator FemRotationSurrogate(Rotation source)
	{
		return source?.ConvertToSurrogate();
	}
}
