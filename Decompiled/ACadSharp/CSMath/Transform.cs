using System;

namespace CSMath;

public class Transform
{
	private Matrix4 _matrix;

	private XYZ _rotation = XYZ.Zero;

	private XYZ _scale = new XYZ(1.0, 1.0, 1.0);

	private XYZ _translation = XYZ.Zero;

	public XYZ EulerRotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			_rotation = value;
			updateMatrix();
		}
	}

	public Matrix4 Matrix => _matrix;

	public Quaternion Quaternion => Quaternion.CreateFromYawPitchRoll(_rotation);

	public XYZ Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			if (value.X == 0.0 || value.Y == 0.0 || value.Z == 0.0)
			{
				throw new ArgumentException("Scale value cannot be 0");
			}
			_scale = value;
			updateMatrix();
		}
	}

	public XYZ Translation
	{
		get
		{
			return _translation;
		}
		set
		{
			_translation = value;
			updateMatrix();
		}
	}

	public Transform()
	{
		Translation = XYZ.Zero;
		EulerRotation = XYZ.Zero;
		Scale = new XYZ(1.0, 1.0, 1.0);
	}

	public Transform(XYZ translation, XYZ scale, XYZ rotation)
		: this()
	{
		Translation = translation;
		Scale = scale;
		EulerRotation = rotation;
	}

	public Transform(Matrix4 matrix)
	{
		_matrix = matrix;
		TryDecompose(out var translation, out var scaling, out var rotation);
		_translation = translation;
		_scale = scaling;
		_rotation = rotation.ToEulerAngles();
	}

	public static Transform CreateRotation(XYZ angles)
	{
		return new Transform(Matrix4.CreateRotationMatrix(angles));
	}

	public static Transform CreateRotation(XYZ axis, double angle)
	{
		return new Transform(Matrix4.CreateFromAxisAngle(axis, angle));
	}

	public static Transform CreateScaling(XYZ scale)
	{
		return new Transform(Matrix4.CreateScale(scale));
	}

	public static Transform CreateScaling(XYZ scale, XYZ origin)
	{
		return new Transform(Matrix4.CreateScale(scale, origin));
	}

	public static Transform CreateTranslation(XYZ translation)
	{
		return new Transform(translation, new XYZ(1.0, 1.0, 1.0), XYZ.Zero);
	}

	public XYZ ApplyRotation(XYZ xyz)
	{
		return CreateRotation(_rotation).ApplyTransform(xyz);
	}

	public XYZ ApplyScale(XYZ xyz)
	{
		return CreateScaling(_scale).ApplyTransform(xyz);
	}

	public XYZ ApplyTransform(XYZ xyz, bool roundZero = true)
	{
		XYZ xYZ = _matrix * xyz;
		if (roundZero)
		{
			return xYZ.RoundZero();
		}
		return xYZ;
	}

	public XYZ ApplyTranslation(XYZ xyz)
	{
		return xyz + Translation;
	}

	public bool TryDecompose(out XYZ translation, out XYZ scaling, out Quaternion rotation)
	{
		Matrix4 matrix = _matrix;
		translation = default(XYZ);
		scaling = default(XYZ);
		rotation = default(Quaternion);
		XYZ xYZ = default(XYZ);
		if (matrix.M33 == 0.0)
		{
			return false;
		}
		Matrix4 matrix2 = matrix;
		matrix2.M03 = 0.0;
		matrix2.M13 = 0.0;
		matrix2.M23 = 0.0;
		matrix2.M33 = 1.0;
		if (matrix2.GetDeterminant() == 0.0)
		{
			return false;
		}
		if (matrix.M03 != 0.0 || matrix.M13 != 0.0 || matrix.M23 != 0.0)
		{
			if (!Matrix4.Inverse(matrix, out var _))
			{
				return false;
			}
			matrix.M03 = (matrix.M13 = (matrix.M23 = 0.0));
			matrix.M33 = 1.0;
		}
		translation.X = matrix.M30;
		matrix.M30 = 0.0;
		translation.Y = matrix.M31;
		matrix.M31 = 0.0;
		translation.Z = matrix.M32;
		matrix.M32 = 0.0;
		XYZ[] array = new XYZ[3]
		{
			new XYZ(matrix.M00, matrix.M01, matrix.M02),
			new XYZ(matrix.M10, matrix.M11, matrix.M12),
			new XYZ(matrix.M20, matrix.M21, matrix.M22)
		};
		scaling.X = array[0].GetLength();
		array[0] = array[0].Normalize();
		xYZ.X = array[0].Dot(array[1]);
		array[1] = array[1] * 1.0 + array[0] * (0.0 - xYZ.X);
		scaling.Y = array[1].GetLength();
		array[1] = array[1].Normalize();
		xYZ.Y = array[0].Dot(array[2]);
		array[2] = array[2] * 1.0 + array[0] * (0.0 - xYZ.Y);
		xYZ.Z = array[1].Dot(array[2]);
		array[2] = array[2] * 1.0 + array[1] * (0.0 - xYZ.Z);
		scaling.Z = array[2].GetLength();
		array[2] = array[2].Normalize();
		XYZ right = XYZ.Cross(array[1], array[2]);
		if (array[0].Dot(right) < 0.0)
		{
			for (int i = 0; i < 3; i++)
			{
				scaling.X *= -1.0;
				array[i].X *= -1.0;
				array[i].Y *= -1.0;
				array[i].Z *= -1.0;
			}
		}
		double num = array[0].X + array[1].Y + array[2].Z + 1.0;
		double num3;
		double num4;
		double num5;
		double w;
		if (num > 0.0)
		{
			double num2 = 0.5 / Math.Sqrt(num);
			num3 = (array[2].Y - array[1].Z) * num2;
			num4 = (array[0].Z - array[2].X) * num2;
			num5 = (array[1].X - array[0].Y) * num2;
			w = 0.25 / num2;
		}
		else if (array[0].X > array[1].Y && array[0].X > array[2].Z)
		{
			double num6 = Math.Sqrt(1.0 + array[0].X - array[1].Y - array[2].Z) * 2.0;
			num3 = 0.25 * num6;
			num4 = (array[0].Y + array[1].X) / num6;
			num5 = (array[0].Z + array[2].X) / num6;
			w = (array[2].Y - array[1].Z) / num6;
		}
		else if (array[1].Y > array[2].Z)
		{
			double num7 = Math.Sqrt(1.0 + array[1].Y - array[0].X - array[2].Z) * 2.0;
			num3 = (array[0].Y + array[1].X) / num7;
			num4 = 0.25 * num7;
			num5 = (array[1].Z + array[2].Y) / num7;
			w = (array[0].Z - array[2].X) / num7;
		}
		else
		{
			double num8 = Math.Sqrt(1.0 + array[2].Z - array[0].X - array[1].Y) * 2.0;
			num3 = (array[0].Z + array[2].X) / num8;
			num4 = (array[1].Z + array[2].Y) / num8;
			num5 = 0.25 * num8;
			w = (array[1].X - array[0].Y) / num8;
		}
		rotation.X = 0.0 - num3;
		rotation.Y = 0.0 - num4;
		rotation.Z = 0.0 - num5;
		rotation.W = w;
		return true;
	}

	private void updateMatrix()
	{
		Matrix4 matrix = Matrix4.CreateTranslation(_translation);
		Matrix4 matrix2 = Matrix4.CreateFromQuaternion(Quaternion);
		Matrix4 matrix3 = Matrix4.CreateScale(_scale);
		_matrix = matrix * matrix2 * matrix3;
	}
}
