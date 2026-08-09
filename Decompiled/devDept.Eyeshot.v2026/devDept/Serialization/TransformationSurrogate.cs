using devDept.Geometry;

namespace devDept.Serialization;

public class TransformationSurrogate : Surrogate<Transformation>
{
	public ProtoArray<double> Matrix;

	public TransformationSurrogate(Transformation transformation)
		: base(transformation)
	{
	}

	protected override Transformation ConvertToObject()
	{
		return new Transformation(Matrix.ToArray() as double[,]);
	}

	protected override void CopyDataToObject(Transformation obj)
	{
	}

	protected override void CopyDataFromObject(Transformation t)
	{
		Matrix = t.Matrix.ToProtoArray<double>();
	}

	public static implicit operator Transformation(TransformationSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator TransformationSurrogate(Transformation source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate();
		}
		return null;
	}
}
