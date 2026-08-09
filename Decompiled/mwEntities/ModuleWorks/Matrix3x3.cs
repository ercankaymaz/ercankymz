namespace ModuleWorks;

public sealed class Matrix3x3
{
	public float[] values = new float[9];

	public float this[int row, int col]
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

	public Matrix3x3()
	{
		values[0] = 1f;
		values[4] = 1f;
		values[8] = 1f;
	}

	public static Matrix3x3 Convert(TransformationMatrixManaged matrix)
	{
		Matrix3x3 matrix3x = new Matrix3x3();
		float[] data = matrix.GetData();
		float[] array = matrix3x.values;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i * 3 + j] = data[i * 4 + j];
			}
		}
		return matrix3x;
	}
}
