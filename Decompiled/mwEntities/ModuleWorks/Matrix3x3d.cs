namespace ModuleWorks;

public sealed class Matrix3x3d
{
	public double[] values = new double[9];

	public double this[int row, int col]
	{
		get
		{
			return values[row * 3 + col];
		}
		set
		{
			values[row * 3 + col] = value;
		}
	}

	public Matrix3x3d()
	{
		values[0] = 1.0;
		values[4] = 1.0;
		values[8] = 1.0;
	}

	public static Matrix3x3d Convert(TransformationMatrixManaged matrix)
	{
		Matrix3x3d matrix3x3d = new Matrix3x3d();
		float[] data = matrix.GetData();
		double[] array = matrix3x3d.values;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i * 3 + j] = data[i * 4 + j];
			}
		}
		return matrix3x3d;
	}
}
