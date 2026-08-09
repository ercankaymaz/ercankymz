namespace ModuleWorks;

public sealed class Matrix4x4d
{
	public double[] values = new double[16];

	public double this[int row, int col]
	{
		get
		{
			return values[row * 4 + col];
		}
		set
		{
			values[row * 4 + col] = value;
		}
	}

	public Matrix4x4d()
	{
		values[0] = 1.0;
		values[5] = 1.0;
		values[10] = 1.0;
		values[15] = 1.0;
	}

	public static Matrix4x4d Convert(TransformationMatrixManagedD matrix)
	{
		Matrix4x4d matrix4x4d = new Matrix4x4d();
		double[] data = matrix.GetData();
		double[] array = matrix4x4d.values;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i * 4 + j] = data[i * 4 + j];
			}
		}
		return matrix4x4d;
	}
}
