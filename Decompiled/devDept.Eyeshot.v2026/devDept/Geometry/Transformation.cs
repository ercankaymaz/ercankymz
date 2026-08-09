using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class Transformation : ISerializable, ICloneable
{
	private double[,] matrix = new double[4, 4];

	public double MaxAbsScaleFactor => Math.Max(Math.Max(Math.Abs(ScaleFactorX), Math.Abs(ScaleFactorY)), Math.Abs(ScaleFactorZ));

	public double this[int m, int n]
	{
		get
		{
			return matrix[m, n];
		}
		set
		{
			matrix[m, n] = value;
		}
	}

	public bool IsTranslation
	{
		get
		{
			if (matrix[0, 0] == 1.0 && matrix[1, 1] == 1.0 && matrix[2, 2] == 1.0 && matrix[3, 3] == 1.0 && matrix[0, 1] == 0.0 && matrix[0, 2] == 0.0 && matrix[1, 0] == 0.0 && matrix[2, 0] == 0.0 && matrix[1, 2] == 0.0 && matrix[2, 1] == 0.0 && matrix[3, 0] == 0.0 && matrix[3, 1] == 0.0)
			{
				return matrix[3, 2] == 0.0;
			}
			return false;
		}
	}

	public bool HasScaling
	{
		get
		{
			Vector3D vector3D = new Vector3D(matrix[0, 0], matrix[1, 0], matrix[2, 0]);
			Vector3D vector3D2 = new Vector3D(matrix[0, 1], matrix[1, 1], matrix[2, 1]);
			Vector3D vector3D3 = new Vector3D(matrix[0, 2], matrix[1, 2], matrix[2, 2]);
			double num = devDept.Geometry.Matrix.Determinant3(matrix);
			if (Utility.Compare(1E-12, vector3D.LengthSquared, 1.0) == 0 && Utility.Compare(1E-12, vector3D2.LengthSquared, 1.0) == 0 && Utility.Compare(1E-12, vector3D3.LengthSquared, 1.0) == 0)
			{
				return num < 0.0;
			}
			return true;
		}
	}

	public bool HasRotation
	{
		get
		{
			if (double.IsNaN(matrix[0, 0]) || double.IsNaN(matrix[1, 1]) || double.IsNaN(matrix[2, 2]))
			{
				return false;
			}
			if (Utility.Compare(1E-12, matrix[1, 0], 0.0) == 0 && Utility.Compare(1E-12, matrix[2, 0], 0.0) == 0 && Utility.Compare(1E-12, matrix[2, 1], 0.0) == 0 && Utility.Compare(1E-12, matrix[0, 1], 0.0) == 0 && Utility.Compare(1E-12, matrix[0, 2], 0.0) == 0 && Utility.Compare(1E-12, matrix[1, 2], 0.0) == 0 && Math.Sign(matrix[0, 0]) == Math.Sign(matrix[1, 1]))
			{
				return Math.Sign(matrix[0, 0]) != Math.Sign(matrix[2, 2]);
			}
			return true;
		}
	}

	public double[,] Matrix
	{
		get
		{
			return matrix;
		}
		set
		{
			Array.Copy(value, matrix, 16);
		}
	}

	public double[] MatrixAsVectorByRow => new double[16]
	{
		matrix[0, 0],
		matrix[0, 1],
		matrix[0, 2],
		matrix[0, 3],
		matrix[1, 0],
		matrix[1, 1],
		matrix[1, 2],
		matrix[1, 3],
		matrix[2, 0],
		matrix[2, 1],
		matrix[2, 2],
		matrix[2, 3],
		matrix[3, 0],
		matrix[3, 1],
		matrix[3, 2],
		matrix[3, 3]
	};

	public double[] MatrixAsVectorByColumn => new double[16]
	{
		matrix[0, 0],
		matrix[1, 0],
		matrix[2, 0],
		matrix[3, 0],
		matrix[0, 1],
		matrix[1, 1],
		matrix[2, 1],
		matrix[3, 1],
		matrix[0, 2],
		matrix[1, 2],
		matrix[2, 2],
		matrix[3, 2],
		matrix[0, 3],
		matrix[1, 3],
		matrix[2, 3],
		matrix[3, 3]
	};

	public float[] MatrixAsVectorFloatByColumn
	{
		get
		{
			float[] array = new float[16];
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					array[num++] = (float)matrix[j, i];
				}
			}
			return array;
		}
	}

	public double ScaleFactorX
	{
		get
		{
			double num = matrix[0, 0];
			double num2 = matrix[1, 0];
			double num3 = matrix[2, 0];
			double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
			if (devDept.Geometry.Matrix.Determinant3(matrix) < 0.0)
			{
				return 0.0 - num4;
			}
			return num4;
		}
	}

	public double ScaleFactorY
	{
		get
		{
			double num = matrix[0, 1];
			double num2 = matrix[1, 1];
			double num3 = matrix[2, 1];
			double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
			if (devDept.Geometry.Matrix.Determinant3(matrix) < 0.0)
			{
				return 0.0 - num4;
			}
			return num4;
		}
	}

	public double ScaleFactorZ
	{
		get
		{
			double num = matrix[0, 2];
			double num2 = matrix[1, 2];
			double num3 = matrix[2, 2];
			double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
			if (devDept.Geometry.Matrix.Determinant3(matrix) < 0.0)
			{
				return 0.0 - num4;
			}
			return num4;
		}
	}

	public bool HasReflection => devDept.Geometry.Matrix.Determinant3(Matrix) < 0.0;

	public bool HasTranslation
	{
		get
		{
			if (matrix[0, 3] == 0.0 && matrix[1, 3] == 0.0)
			{
				return matrix[2, 3] != 0.0;
			}
			return true;
		}
	}

	public Transformation()
	{
		matrix[3, 3] = 1.0;
	}

	[DebuggerStepThrough]
	public Transformation(double d)
	{
		matrix[0, 0] = (matrix[1, 1] = (matrix[2, 2] = d));
		matrix[3, 3] = 1.0;
	}

	public Transformation(double[,] m)
	{
		Array.Copy(m, matrix, 16);
	}

	public Transformation(double[] m, bool byRow = true)
	{
		if (byRow)
		{
			matrix[0, 0] = m[0];
			matrix[0, 1] = m[1];
			matrix[0, 2] = m[2];
			matrix[0, 3] = m[3];
			matrix[1, 0] = m[4];
			matrix[1, 1] = m[5];
			matrix[1, 2] = m[6];
			matrix[1, 3] = m[7];
			matrix[2, 0] = m[8];
			matrix[2, 1] = m[9];
			matrix[2, 2] = m[10];
			matrix[2, 3] = m[11];
			matrix[3, 0] = m[12];
			matrix[3, 1] = m[13];
			matrix[3, 2] = m[14];
			matrix[3, 3] = m[15];
		}
		else
		{
			matrix[0, 0] = m[0];
			matrix[0, 1] = m[4];
			matrix[0, 2] = m[8];
			matrix[0, 3] = m[12];
			matrix[1, 0] = m[1];
			matrix[1, 1] = m[5];
			matrix[1, 2] = m[9];
			matrix[1, 3] = m[13];
			matrix[2, 0] = m[2];
			matrix[2, 1] = m[6];
			matrix[2, 2] = m[10];
			matrix[2, 3] = m[14];
			matrix[3, 0] = m[3];
			matrix[3, 1] = m[7];
			matrix[3, 2] = m[11];
			matrix[3, 3] = m[15];
		}
	}

	public Transformation(Point3D P, Vector3D X, Vector3D Y, Vector3D Z)
	{
		matrix[0, 0] = X.X;
		matrix[1, 0] = X.Y;
		matrix[2, 0] = X.Z;
		matrix[3, 0] = 0.0;
		matrix[0, 1] = Y.X;
		matrix[1, 1] = Y.Y;
		matrix[2, 1] = Y.Z;
		matrix[3, 1] = 0.0;
		matrix[0, 2] = Z.X;
		matrix[1, 2] = Z.Y;
		matrix[2, 2] = Z.Z;
		matrix[3, 2] = 0.0;
		matrix[0, 3] = P.X;
		matrix[1, 3] = P.Y;
		matrix[2, 3] = P.Z;
		matrix[3, 3] = 1.0;
	}

	protected Transformation(Transformation another)
	{
		Array.Copy(another.matrix, matrix, 16);
	}

	protected Transformation(SerializationInfo info, StreamingContext context)
	{
		matrix = (double[,])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659721), typeof(double[,]));
	}

	public bool IsIdentity(double zeroTolerance)
	{
		if (Math.Abs(1.0 - matrix[0, 0]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[0, 1]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[0, 2]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[0, 3]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[1, 0]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(1.0 - matrix[1, 1]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[1, 2]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[1, 3]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[2, 0]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[2, 1]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(1.0 - matrix[2, 2]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[2, 3]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[3, 0]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[3, 1]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(matrix[3, 2]) > zeroTolerance)
		{
			return false;
		}
		if (Math.Abs(1.0 - matrix[3, 3]) > zeroTolerance)
		{
			return false;
		}
		return true;
	}

	public bool IsIdentity()
	{
		if (matrix[0, 0] != 1.0)
		{
			return false;
		}
		if (matrix[0, 1] != 0.0)
		{
			return false;
		}
		if (matrix[0, 2] != 0.0)
		{
			return false;
		}
		if (matrix[0, 3] != 0.0)
		{
			return false;
		}
		if (matrix[1, 0] != 0.0)
		{
			return false;
		}
		if (matrix[1, 1] != 1.0)
		{
			return false;
		}
		if (matrix[1, 2] != 0.0)
		{
			return false;
		}
		if (matrix[1, 3] != 0.0)
		{
			return false;
		}
		if (matrix[2, 0] != 0.0)
		{
			return false;
		}
		if (matrix[2, 1] != 0.0)
		{
			return false;
		}
		if (matrix[2, 2] != 1.0)
		{
			return false;
		}
		if (matrix[2, 3] != 0.0)
		{
			return false;
		}
		if (matrix[3, 0] != 0.0)
		{
			return false;
		}
		if (matrix[3, 1] != 0.0)
		{
			return false;
		}
		if (matrix[3, 2] != 0.0)
		{
			return false;
		}
		if (matrix[3, 3] != 1.0)
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return new Transformation(this);
	}

	protected bool Equals(Transformation other)
	{
		return MatrixAsVectorByRow.SequenceEqual(other.MatrixAsVectorByRow);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Transformation))
		{
			return false;
		}
		return Equals((Transformation)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		double[] matrixAsVectorByRow = MatrixAsVectorByRow;
		foreach (double num2 in matrixAsVectorByRow)
		{
			num = num * 31 + num2.GetHashCode();
		}
		return num;
	}

	public static bool operator ==(Transformation left, Transformation right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Transformation left, Transformation right)
	{
		return !object.Equals(left, right);
	}

	public void Zero()
	{
		matrix = new double[4, 4];
	}

	public void Identity()
	{
		matrix = new double[4, 4];
		matrix[0, 0] = (matrix[1, 1] = (matrix[2, 2] = (matrix[3, 3] = 1.0)));
	}

	public void Diagonal(double d)
	{
		matrix = new double[4, 4];
		matrix[0, 0] = (matrix[1, 1] = (matrix[2, 2] = (matrix[3, 3] = d)));
	}

	public void Scaling(double sx, double sy, double sz = 1.0)
	{
		matrix = new double[4, 4];
		matrix[0, 0] = sx;
		matrix[1, 1] = sy;
		matrix[2, 2] = sz;
		matrix[3, 3] = 1.0;
	}

	public void Scaling(Vector3D sv)
	{
		matrix = new double[4, 4];
		matrix[0, 0] = sv.X;
		matrix[1, 1] = sv.Y;
		matrix[2, 2] = sv.Z;
		matrix[3, 3] = 1.0;
	}

	public void Scaling(Point3D fixedPoint, double scaleFactor)
	{
		if (fixedPoint.X == 0.0 && fixedPoint.Y == 0.0 && fixedPoint.Z == 0.0)
		{
			Scaling(scaleFactor, scaleFactor, scaleFactor);
			return;
		}
		Transformation transformation = new Transformation();
		Transformation transformation2 = new Transformation();
		Transformation transformation3 = new Transformation();
		transformation.Translation(Vector3D.Subtract(Point3D.Origin, fixedPoint));
		transformation2.Scaling(scaleFactor, scaleFactor, scaleFactor);
		transformation3.Translation(Vector3D.Subtract(fixedPoint, Point3D.Origin));
		matrix = (transformation3 * transformation2 * transformation).matrix;
	}

	public void Scaling(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
	{
		if (fixedPoint.X == 0.0 && fixedPoint.Y == 0.0 && fixedPoint.Z == 0.0)
		{
			Scaling(sx, sy, sz);
			return;
		}
		Transformation transformation = new Transformation();
		Transformation transformation2 = new Transformation();
		Transformation transformation3 = new Transformation();
		transformation.Translation(Vector3D.Subtract(Point3D.Origin, fixedPoint));
		transformation2.Scaling(sx, sy, sz);
		transformation3.Translation(Vector3D.Subtract(fixedPoint, Point3D.Origin));
		matrix = (transformation3 * transformation2 * transformation).matrix;
	}

	public void Translation(double dx, double dy, double dz = 0.0)
	{
		Identity();
		matrix[0, 3] = dx;
		matrix[1, 3] = dy;
		matrix[2, 3] = dz;
		matrix[3, 3] = 1.0;
	}

	public void Translation(Vector3D v)
	{
		Identity();
		matrix[0, 3] = v.X;
		matrix[1, 3] = v.Y;
		matrix[2, 3] = v.Z;
		matrix[3, 3] = 1.0;
	}

	public void PlanarProjection(Plane plane)
	{
		double[] array = new double[3]
		{
			plane.AxisX.X,
			plane.AxisX.Y,
			plane.AxisX.Z
		};
		double[] array2 = new double[3]
		{
			plane.AxisY.X,
			plane.AxisY.Y,
			plane.AxisY.Z
		};
		double[] array3 = new double[3]
		{
			plane.Origin.X,
			plane.Origin.Y,
			plane.Origin.Z
		};
		double[] array4 = new double[3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				matrix[i, j] = array[i] * array[j] + array2[i] * array2[j];
			}
			array4[i] = matrix[i, 0] * array3[0] + matrix[i, 1] * array3[1] + matrix[i, 2] * array3[2];
		}
		for (int k = 0; k < 3; k++)
		{
			matrix[3, k] = 0.0;
			matrix[k, 3] = array3[k] - array4[k];
		}
		matrix[3, 3] = 1.0;
	}

	public double[] ActOnLeft(double x, double y, double z, double w)
	{
		return new double[4]
		{
			matrix[0, 0] * x + matrix[0, 1] * y + matrix[0, 2] * z + matrix[0, 3] * w,
			matrix[1, 0] * x + matrix[1, 1] * y + matrix[1, 2] * z + matrix[1, 3] * w,
			matrix[2, 0] * x + matrix[2, 1] * y + matrix[2, 2] * z + matrix[2, 3] * w,
			matrix[3, 0] * x + matrix[3, 1] * y + matrix[3, 2] * z + matrix[3, 3] * w
		};
	}

	public double[] ActOnLeftOne(double x, double y, double z)
	{
		return new double[3]
		{
			matrix[0, 0] * x + matrix[0, 1] * y + matrix[0, 2] * z + matrix[0, 3],
			matrix[1, 0] * x + matrix[1, 1] * y + matrix[1, 2] * z + matrix[1, 3],
			matrix[2, 0] * x + matrix[2, 1] * y + matrix[2, 2] * z + matrix[2, 3]
		};
	}

	public double[] ActOnLeftZero(double x, double y, double z)
	{
		return new double[3]
		{
			matrix[0, 0] * x + matrix[0, 1] * y + matrix[0, 2] * z,
			matrix[1, 0] * x + matrix[1, 1] * y + matrix[1, 2] * z,
			matrix[2, 0] * x + matrix[2, 1] * y + matrix[2, 2] * z
		};
	}

	private double[] _0023_003DzrlepOWUJ4Swp(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, double _0023_003DzAvn2b38_003D)
	{
		return new double[4]
		{
			matrix[0, 0] * _0023_003DzBJFJHwk_003D + matrix[1, 0] * _0023_003Dz40R7bAU_003D + matrix[2, 0] * _0023_003DzId5C3LA_003D + matrix[3, 0] * _0023_003DzAvn2b38_003D,
			matrix[0, 1] * _0023_003DzBJFJHwk_003D + matrix[1, 1] * _0023_003Dz40R7bAU_003D + matrix[2, 1] * _0023_003DzId5C3LA_003D + matrix[3, 1] * _0023_003DzAvn2b38_003D,
			matrix[0, 2] * _0023_003DzBJFJHwk_003D + matrix[1, 2] * _0023_003Dz40R7bAU_003D + matrix[2, 2] * _0023_003DzId5C3LA_003D + matrix[3, 2] * _0023_003DzAvn2b38_003D,
			matrix[0, 3] * _0023_003DzBJFJHwk_003D + matrix[1, 3] * _0023_003Dz40R7bAU_003D + matrix[2, 3] * _0023_003DzId5C3LA_003D + matrix[3, 3] * _0023_003DzAvn2b38_003D
		};
	}

	public static float[] ActOnLeftOne(float x, float y, float z, float[,] m)
	{
		return new float[3]
		{
			m[0, 0] * x + m[0, 1] * y + m[0, 2] * z + m[0, 3],
			m[1, 0] * x + m[1, 1] * y + m[1, 2] * z + m[1, 3],
			m[2, 0] * x + m[2, 1] * y + m[2, 2] * z + m[2, 3]
		};
	}

	public static float[] ActOnLeftZero(float x, float y, float z, float[,] m)
	{
		return new float[3]
		{
			m[0, 0] * x + m[0, 1] * y + m[0, 2] * z,
			m[1, 0] * x + m[1, 1] * y + m[1, 2] * z,
			m[2, 0] * x + m[2, 1] * y + m[2, 2] * z
		};
	}

	public float[,] GetFloatMatrix()
	{
		return new float[4, 4]
		{
			{
				(float)matrix[0, 0],
				(float)matrix[0, 1],
				(float)matrix[0, 2],
				(float)matrix[0, 3]
			},
			{
				(float)matrix[1, 0],
				(float)matrix[1, 1],
				(float)matrix[1, 2],
				(float)matrix[1, 3]
			},
			{
				(float)matrix[2, 0],
				(float)matrix[2, 1],
				(float)matrix[2, 2],
				(float)matrix[2, 3]
			},
			{
				(float)matrix[3, 0],
				(float)matrix[3, 1],
				(float)matrix[3, 2],
				(float)matrix[3, 3]
			}
		};
	}

	public static Point2D operator *(Transformation t, Point2D p)
	{
		double[] array = t.ActOnLeft(p.X, p.Y, 0.0, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		return new Point2D(num * array[0], num * array[1]);
	}

	public static Point3D operator *(Transformation t, Point3D p)
	{
		double[] array = t.ActOnLeft(p.X, p.Y, p.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		return new Point3D(num * array[0], num * array[1], num * array[2]);
	}

	public static PointRGB operator *(Transformation t, PointRGB p)
	{
		double[] array = t.ActOnLeft(p.X, p.Y, p.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		return new PointRGB(num * array[0], num * array[1], num * array[2], p.R, p.G, p.B);
	}

	public static Point4D operator *(Transformation t, Point4D h)
	{
		double[] array = t.ActOnLeft(h.X, h.Y, h.Z, h.W);
		return new Point4D(array[0], array[1], array[2], array[3]);
	}

	public static Vector2D operator *(Transformation t, Vector2D v)
	{
		double[] array = t.ActOnLeft(v.X, v.Y, 0.0, 0.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		return new Vector2D(num * array[0], num * array[1]);
	}

	public static Vector3D operator *(Transformation t, Vector3D v)
	{
		double[] array = t.ActOnLeft(v.X, v.Y, v.Z, 0.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		return new Vector3D(num * array[0], num * array[1], num * array[2]);
	}

	public void Transpose()
	{
		Utility.Swap(ref matrix[0, 1], ref matrix[1, 0]);
		Utility.Swap(ref matrix[0, 2], ref matrix[2, 0]);
		Utility.Swap(ref matrix[0, 3], ref matrix[3, 0]);
		Utility.Swap(ref matrix[1, 2], ref matrix[2, 1]);
		Utility.Swap(ref matrix[1, 3], ref matrix[3, 1]);
		Utility.Swap(ref matrix[2, 3], ref matrix[3, 2]);
	}

	public void Invert()
	{
		double[,] array = new double[4, 4];
		Array.Copy(matrix, array, 16);
		matrix = devDept.Geometry.Matrix.Inverse4(array);
	}

	public void Rotation(double angleInRadians, Vector3D axis)
	{
		_0023_003DzGvMngiE_003D(Math.Sin(angleInRadians), Math.Cos(angleInRadians), axis, Point3D.Origin);
	}

	public void Rotation(double angleInRadians, Point3D axisStart, Point3D axisEnd)
	{
		_0023_003DzGvMngiE_003D(Math.Sin(angleInRadians), Math.Cos(angleInRadians), Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public void Rotation(double angleInRadians, Vector3D axis, Point3D center)
	{
		_0023_003DzGvMngiE_003D(Math.Sin(angleInRadians), Math.Cos(angleInRadians), axis, center);
	}

	public void Rotation(Vector3D startDir, Vector3D endDir, Point3D center)
	{
		Vector3D vector3D = (Vector3D)startDir.Clone();
		vector3D.Normalize();
		Vector3D vector3D2 = (Vector3D)endDir.Clone();
		vector3D2.Normalize();
		double num = vector3D * vector3D2;
		Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
		double num2 = vector3D3.Length;
		vector3D3.Normalize();
		if (0.0 == num2)
		{
			vector3D3.PerpendicularTo(vector3D);
			vector3D3.Normalize();
			num2 = 0.0;
			num = ((num < 0.0) ? (-1.0) : 1.0);
		}
		_0023_003DzGvMngiE_003D(num2, num, vector3D3, center);
	}

	internal void _0023_003DzGvMngiE_003D(double _0023_003DzbeIS31pPf7Rr, double _0023_003Dz4LluidiVoAR7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		Identity();
		if (Math.Abs(_0023_003DzbeIS31pPf7Rr) >= 0.9999999850988388 && Math.Abs(_0023_003Dz4LluidiVoAR7) <= 1.490116119385E-08)
		{
			_0023_003Dz4LluidiVoAR7 = 0.0;
			_0023_003DzbeIS31pPf7Rr = ((!(_0023_003DzbeIS31pPf7Rr < 0.0)) ? 1.0 : (-1.0));
		}
		else if (Math.Abs(_0023_003Dz4LluidiVoAR7) >= 0.9999999850988388 && Math.Abs(_0023_003DzbeIS31pPf7Rr) <= 1.490116119385E-08)
		{
			_0023_003DzbeIS31pPf7Rr = 0.0;
			_0023_003Dz4LluidiVoAR7 = ((!(_0023_003Dz4LluidiVoAR7 < 0.0)) ? 1.0 : (-1.0));
		}
		else if (Math.Abs(_0023_003Dz4LluidiVoAR7 * _0023_003Dz4LluidiVoAR7 + _0023_003DzbeIS31pPf7Rr * _0023_003DzbeIS31pPf7Rr - 1.0) > 1.490116119385E-08)
		{
			Vector2D vector2D = new Vector2D(_0023_003Dz4LluidiVoAR7, _0023_003DzbeIS31pPf7Rr);
			vector2D.Normalize();
			_0023_003Dz4LluidiVoAR7 = vector2D.X;
			_0023_003DzbeIS31pPf7Rr = vector2D.Y;
		}
		else
		{
			if (_0023_003Dz4LluidiVoAR7 > 1.0)
			{
				_0023_003Dz4LluidiVoAR7 = 1.0;
			}
			else if (_0023_003Dz4LluidiVoAR7 < -1.0)
			{
				_0023_003Dz4LluidiVoAR7 = -1.0;
			}
			if (_0023_003DzbeIS31pPf7Rr > 1.0)
			{
				_0023_003DzbeIS31pPf7Rr = 1.0;
			}
			else if (_0023_003DzbeIS31pPf7Rr < -1.0)
			{
				_0023_003DzbeIS31pPf7Rr = -1.0;
			}
		}
		if (_0023_003DzbeIS31pPf7Rr != 0.0 || _0023_003Dz4LluidiVoAR7 != 1.0)
		{
			double num = 1.0 - _0023_003Dz4LluidiVoAR7;
			Vector3D vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
			if (Math.Abs(vector3D.LengthSquared - 1.0) > 2.220446049250313E-16)
			{
				vector3D.Normalize();
			}
			matrix[0, 0] = vector3D.X * vector3D.X * num + _0023_003Dz4LluidiVoAR7;
			matrix[0, 1] = vector3D.X * vector3D.Y * num - vector3D.Z * _0023_003DzbeIS31pPf7Rr;
			matrix[0, 2] = vector3D.X * vector3D.Z * num + vector3D.Y * _0023_003DzbeIS31pPf7Rr;
			matrix[1, 0] = vector3D.Y * vector3D.X * num + vector3D.Z * _0023_003DzbeIS31pPf7Rr;
			matrix[1, 1] = vector3D.Y * vector3D.Y * num + _0023_003Dz4LluidiVoAR7;
			matrix[1, 2] = vector3D.Y * vector3D.Z * num - vector3D.X * _0023_003DzbeIS31pPf7Rr;
			matrix[2, 0] = vector3D.Z * vector3D.X * num - vector3D.Y * _0023_003DzbeIS31pPf7Rr;
			matrix[2, 1] = vector3D.Z * vector3D.Y * num + vector3D.X * _0023_003DzbeIS31pPf7Rr;
			matrix[2, 2] = vector3D.Z * vector3D.Z * num + _0023_003Dz4LluidiVoAR7;
			if (_0023_003DzbUvT9Pc_003D.X != 0.0 || _0023_003DzbUvT9Pc_003D.Y != 0.0 || _0023_003DzbUvT9Pc_003D.Z != 0.0)
			{
				matrix[0, 3] = 0.0 - ((matrix[0, 0] - 1.0) * _0023_003DzbUvT9Pc_003D.X + matrix[0, 1] * _0023_003DzbUvT9Pc_003D.Y + matrix[0, 2] * _0023_003DzbUvT9Pc_003D.Z);
				matrix[1, 3] = 0.0 - (matrix[1, 0] * _0023_003DzbUvT9Pc_003D.X + (matrix[1, 1] - 1.0) * _0023_003DzbUvT9Pc_003D.Y + matrix[1, 2] * _0023_003DzbUvT9Pc_003D.Z);
				matrix[2, 3] = 0.0 - (matrix[2, 0] * _0023_003DzbUvT9Pc_003D.X + matrix[2, 1] * _0023_003DzbUvT9Pc_003D.Y + (matrix[2, 2] - 1.0) * _0023_003DzbUvT9Pc_003D.Z);
			}
			matrix[3, 0] = (matrix[3, 1] = (matrix[3, 2] = 0.0));
			matrix[3, 3] = 1.0;
		}
	}

	public void Rotation(Vector3D X0, Vector3D Y0, Vector3D Z0, Vector3D X1, Vector3D Y1, Vector3D Z1)
	{
		Transformation transformation = new Transformation();
		transformation[0, 0] = X0.X;
		transformation[0, 1] = X0.Y;
		transformation[0, 2] = X0.Z;
		transformation[1, 0] = Y0.X;
		transformation[1, 1] = Y0.Y;
		transformation[1, 2] = Y0.Z;
		transformation[2, 0] = Z0.X;
		transformation[2, 1] = Z0.Y;
		transformation[2, 2] = Z0.Z;
		transformation[3, 3] = 1.0;
		Transformation transformation2 = new Transformation();
		transformation2[0, 0] = X1.X;
		transformation2[0, 1] = Y1.X;
		transformation2[0, 2] = Z1.X;
		transformation2[1, 0] = X1.Y;
		transformation2[1, 1] = Y1.Y;
		transformation2[1, 2] = Z1.Y;
		transformation2[2, 0] = X1.Z;
		transformation2[2, 1] = Y1.Z;
		transformation2[2, 2] = Z1.Z;
		transformation2[3, 3] = 1.0;
		matrix = (transformation2 * transformation).matrix;
	}

	public void Rotation(Plane plane0, Plane plane1)
	{
		Rotation(plane0.Origin, plane0.AxisX, plane0.AxisY, plane0.AxisZ, plane1.Origin, plane1.AxisX, plane1.AxisY, plane1.AxisZ);
	}

	public void Rotation(Point3D P0, Vector3D X0, Vector3D Y0, Vector3D Z0, Point3D P1, Vector3D X1, Vector3D Y1, Vector3D Z1)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(0.0 - P0.X, 0.0 - P0.Y, 0.0 - P0.Z);
		Transformation transformation2 = new Transformation();
		transformation2.Rotation(X0, Y0, Z0, X1, Y1, Z1);
		Transformation transformation3 = new Transformation();
		transformation3.Translation(P1.X, P1.Y, P1.Z);
		matrix = (transformation3 * transformation2 * transformation).matrix;
	}

	public void Reflection(Plane pln)
	{
		Reflection(pln.Origin, pln.AxisZ);
	}

	public void Reflection(Point3D P, Vector3D N)
	{
		Vector3D vector3D = (Vector3D)N.Clone();
		vector3D.Normalize();
		Vector3D vector3D2 = 2.0 * (vector3D.X * P.X + vector3D.Y * P.Y + vector3D.Z * P.Z) * vector3D;
		matrix[0, 0] = 1.0 - 2.0 * vector3D.X * vector3D.X;
		matrix[0, 1] = -2.0 * vector3D.X * vector3D.Y;
		matrix[0, 2] = -2.0 * vector3D.X * vector3D.Z;
		matrix[0, 3] = vector3D2.X;
		matrix[1, 0] = -2.0 * vector3D.Y * vector3D.X;
		matrix[1, 1] = 1.0 - 2.0 * vector3D.Y * vector3D.Y;
		matrix[1, 2] = -2.0 * vector3D.Y * vector3D.Z;
		matrix[1, 3] = vector3D2.Y;
		matrix[2, 0] = -2.0 * vector3D.Z * vector3D.X;
		matrix[2, 1] = -2.0 * vector3D.Z * vector3D.Y;
		matrix[2, 2] = 1.0 - 2.0 * vector3D.Z * vector3D.Z;
		matrix[2, 3] = vector3D2.Z;
		matrix[3, 0] = 0.0;
		matrix[3, 1] = 0.0;
		matrix[3, 2] = 0.0;
		matrix[3, 3] = 1.0;
	}

	public static Transformation operator *(Transformation left, Transformation right)
	{
		Transformation transformation = new Transformation();
		double[,] array = transformation.matrix;
		array[0, 0] = left.matrix[0, 0] * right.matrix[0, 0] + left.matrix[0, 1] * right.matrix[1, 0] + left.matrix[0, 2] * right.matrix[2, 0] + left.matrix[0, 3] * right.matrix[3, 0];
		array[0, 1] = left.matrix[0, 0] * right.matrix[0, 1] + left.matrix[0, 1] * right.matrix[1, 1] + left.matrix[0, 2] * right.matrix[2, 1] + left.matrix[0, 3] * right.matrix[3, 1];
		array[0, 2] = left.matrix[0, 0] * right.matrix[0, 2] + left.matrix[0, 1] * right.matrix[1, 2] + left.matrix[0, 2] * right.matrix[2, 2] + left.matrix[0, 3] * right.matrix[3, 2];
		array[0, 3] = left.matrix[0, 0] * right.matrix[0, 3] + left.matrix[0, 1] * right.matrix[1, 3] + left.matrix[0, 2] * right.matrix[2, 3] + left.matrix[0, 3] * right.matrix[3, 3];
		array[1, 0] = left.matrix[1, 0] * right.matrix[0, 0] + left.matrix[1, 1] * right.matrix[1, 0] + left.matrix[1, 2] * right.matrix[2, 0] + left.matrix[1, 3] * right.matrix[3, 0];
		array[1, 1] = left.matrix[1, 0] * right.matrix[0, 1] + left.matrix[1, 1] * right.matrix[1, 1] + left.matrix[1, 2] * right.matrix[2, 1] + left.matrix[1, 3] * right.matrix[3, 1];
		array[1, 2] = left.matrix[1, 0] * right.matrix[0, 2] + left.matrix[1, 1] * right.matrix[1, 2] + left.matrix[1, 2] * right.matrix[2, 2] + left.matrix[1, 3] * right.matrix[3, 2];
		array[1, 3] = left.matrix[1, 0] * right.matrix[0, 3] + left.matrix[1, 1] * right.matrix[1, 3] + left.matrix[1, 2] * right.matrix[2, 3] + left.matrix[1, 3] * right.matrix[3, 3];
		array[2, 0] = left.matrix[2, 0] * right.matrix[0, 0] + left.matrix[2, 1] * right.matrix[1, 0] + left.matrix[2, 2] * right.matrix[2, 0] + left.matrix[2, 3] * right.matrix[3, 0];
		array[2, 1] = left.matrix[2, 0] * right.matrix[0, 1] + left.matrix[2, 1] * right.matrix[1, 1] + left.matrix[2, 2] * right.matrix[2, 1] + left.matrix[2, 3] * right.matrix[3, 1];
		array[2, 2] = left.matrix[2, 0] * right.matrix[0, 2] + left.matrix[2, 1] * right.matrix[1, 2] + left.matrix[2, 2] * right.matrix[2, 2] + left.matrix[2, 3] * right.matrix[3, 2];
		array[2, 3] = left.matrix[2, 0] * right.matrix[0, 3] + left.matrix[2, 1] * right.matrix[1, 3] + left.matrix[2, 2] * right.matrix[2, 3] + left.matrix[2, 3] * right.matrix[3, 3];
		array[3, 0] = left.matrix[3, 0] * right.matrix[0, 0] + left.matrix[3, 1] * right.matrix[1, 0] + left.matrix[3, 2] * right.matrix[2, 0] + left.matrix[3, 3] * right.matrix[3, 0];
		array[3, 1] = left.matrix[3, 0] * right.matrix[0, 1] + left.matrix[3, 1] * right.matrix[1, 1] + left.matrix[3, 2] * right.matrix[2, 1] + left.matrix[3, 3] * right.matrix[3, 1];
		array[3, 2] = left.matrix[3, 0] * right.matrix[0, 2] + left.matrix[3, 1] * right.matrix[1, 2] + left.matrix[3, 2] * right.matrix[2, 2] + left.matrix[3, 3] * right.matrix[3, 2];
		array[3, 3] = left.matrix[3, 0] * right.matrix[0, 3] + left.matrix[3, 1] * right.matrix[1, 3] + left.matrix[3, 2] * right.matrix[2, 3] + left.matrix[3, 3] * right.matrix[3, 3];
		return transformation;
	}

	public static Transformation operator +(Transformation left, Transformation right)
	{
		return new Transformation
		{
			[0, 0] = left[0, 0] + right[0, 0],
			[0, 1] = left[0, 1] + right[0, 1],
			[0, 2] = left[0, 2] + right[0, 2],
			[0, 3] = left[0, 3] + right[0, 3],
			[1, 0] = left[1, 0] + right[1, 0],
			[1, 1] = left[1, 1] + right[1, 1],
			[1, 2] = left[1, 2] + right[1, 2],
			[1, 3] = left[1, 3] + right[1, 3],
			[2, 0] = left[2, 0] + right[2, 0],
			[2, 1] = left[2, 1] + right[2, 1],
			[2, 2] = left[2, 2] + right[2, 2],
			[2, 3] = left[2, 3] + right[2, 3],
			[3, 0] = left[3, 0] + right[3, 0],
			[3, 1] = left[3, 1] + right[3, 1],
			[3, 2] = left[3, 2] + right[3, 2],
			[3, 3] = left[3, 3] + right[3, 3]
		};
	}

	public static Transformation operator -(Transformation left, Transformation right)
	{
		return new Transformation
		{
			[0, 0] = left[0, 0] - right[0, 0],
			[0, 1] = left[0, 1] - right[0, 1],
			[0, 2] = left[0, 2] - right[0, 2],
			[0, 3] = left[0, 3] - right[0, 3],
			[1, 0] = left[1, 0] - right[1, 0],
			[1, 1] = left[1, 1] - right[1, 1],
			[1, 2] = left[1, 2] - right[1, 2],
			[1, 3] = left[1, 3] - right[1, 3],
			[2, 0] = left[2, 0] - right[2, 0],
			[2, 1] = left[2, 1] - right[2, 1],
			[2, 2] = left[2, 2] - right[2, 2],
			[2, 3] = left[2, 3] - right[2, 3],
			[3, 0] = left[3, 0] - right[3, 0],
			[3, 1] = left[3, 1] - right[3, 1],
			[3, 2] = left[3, 2] - right[3, 2],
			[3, 3] = left[3, 3] - right[3, 3]
		};
	}

	public bool ChangeBasis(Plane initial, Plane final)
	{
		return ChangeBasis(initial.Origin, initial.AxisX, initial.AxisY, initial.AxisZ, final.Origin, final.AxisX, final.AxisY, final.AxisZ);
	}

	public bool ChangeBasis(Vector3D X0, Vector3D Y0, Vector3D Z0, Vector3D X1, Vector3D Y1, Vector3D Z1)
	{
		Zero();
		matrix[3, 3] = 1.0;
		double num = X1 * Y1;
		double num2 = X1 * Z1;
		double num3 = Y1 * Z1;
		double[,] array = new double[3, 6]
		{
			{
				X1 * X1,
				num,
				num2,
				X1 * X0,
				X1 * Y0,
				X1 * Z0
			},
			{
				num,
				Y1 * Y1,
				num3,
				Y1 * X0,
				Y1 * Y0,
				Y1 * Z0
			},
			{
				num2,
				num3,
				Z1 * Z1,
				Z1 * X0,
				Z1 * Y0,
				Z1 * Z0
			}
		};
		int num4 = ((!(array[0, 0] >= array[1, 1])) ? 1 : 0);
		if (array[2, 2] > array[num4, num4])
		{
			num4 = 2;
		}
		int num5 = (num4 + 1) % 3;
		int num6 = (num5 + 1) % 3;
		if (array[num4, num4] == 0.0)
		{
			return false;
		}
		double num7 = 1.0 / array[num4, num4];
		array[num4, 0] *= num7;
		array[num4, 1] *= num7;
		array[num4, 2] *= num7;
		array[num4, 3] *= num7;
		array[num4, 4] *= num7;
		array[num4, 5] *= num7;
		array[num4, num4] = 1.0;
		if (array[num5, num4] != 0.0)
		{
			num7 = 0.0 - array[num5, num4];
			array[num5, 0] += num7 * array[num4, 0];
			array[num5, 1] += num7 * array[num4, 1];
			array[num5, 2] += num7 * array[num4, 2];
			array[num5, 3] += num7 * array[num4, 3];
			array[num5, 4] += num7 * array[num4, 4];
			array[num5, 5] += num7 * array[num4, 5];
			array[num5, num4] = 0.0;
		}
		if (array[num6, num4] != 0.0)
		{
			num7 = 0.0 - array[num6, num4];
			array[num6, 0] += num7 * array[num4, 0];
			array[num6, 1] += num7 * array[num4, 1];
			array[num6, 2] += num7 * array[num4, 2];
			array[num6, 3] += num7 * array[num4, 3];
			array[num6, 4] += num7 * array[num4, 4];
			array[num6, 5] += num7 * array[num4, 5];
			array[num6, num4] = 0.0;
		}
		if (Math.Abs(array[num5, num5]) < Math.Abs(array[num6, num6]))
		{
			int num8 = num5;
			num5 = num6;
			num6 = num8;
		}
		if (array[num5, num5] == 0.0)
		{
			return false;
		}
		num7 = 1.0 / array[num5, num5];
		array[num5, 0] *= num7;
		array[num5, 1] *= num7;
		array[num5, 2] *= num7;
		array[num5, 3] *= num7;
		array[num5, 4] *= num7;
		array[num5, 5] *= num7;
		array[num5, num5] = 1.0;
		if (array[num4, num5] != 0.0)
		{
			num7 = 0.0 - array[num4, num5];
			array[num4, 0] += num7 * array[num5, 0];
			array[num4, 1] += num7 * array[num5, 1];
			array[num4, 2] += num7 * array[num5, 2];
			array[num4, 3] += num7 * array[num5, 3];
			array[num4, 4] += num7 * array[num5, 4];
			array[num4, 5] += num7 * array[num5, 5];
			array[num4, num5] = 0.0;
		}
		if (array[num6, num5] != 0.0)
		{
			num7 = 0.0 - array[num6, num5];
			array[num6, 0] += num7 * array[num5, 0];
			array[num6, 1] += num7 * array[num5, 1];
			array[num6, 2] += num7 * array[num5, 2];
			array[num6, 3] += num7 * array[num5, 3];
			array[num6, 4] += num7 * array[num5, 4];
			array[num6, 5] += num7 * array[num5, 5];
			array[num6, num5] = 0.0;
		}
		if (array[num6, num6] == 0.0)
		{
			return false;
		}
		num7 = 1.0 / array[num6, num6];
		array[num6, 0] *= num7;
		array[num6, 1] *= num7;
		array[num6, 2] *= num7;
		array[num6, 3] *= num7;
		array[num6, 4] *= num7;
		array[num6, 5] *= num7;
		array[num6, num6] = 1.0;
		if (array[num4, num6] != 0.0)
		{
			num7 = 0.0 - array[num4, num6];
			array[num4, 0] += num7 * array[num6, 0];
			array[num4, 1] += num7 * array[num6, 1];
			array[num4, 2] += num7 * array[num6, 2];
			array[num4, 3] += num7 * array[num6, 3];
			array[num4, 4] += num7 * array[num6, 4];
			array[num4, 5] += num7 * array[num6, 5];
			array[num4, num6] = 0.0;
		}
		if (array[num5, num6] != 0.0)
		{
			num7 = 0.0 - array[num5, num6];
			array[num5, 0] += num7 * array[num6, 0];
			array[num5, 1] += num7 * array[num6, 1];
			array[num5, 2] += num7 * array[num6, 2];
			array[num5, 3] += num7 * array[num6, 3];
			array[num5, 4] += num7 * array[num6, 4];
			array[num5, 5] += num7 * array[num6, 5];
			array[num5, num6] = 0.0;
		}
		matrix[0, 0] = array[0, 3];
		matrix[0, 1] = array[0, 4];
		matrix[0, 2] = array[0, 5];
		matrix[1, 0] = array[1, 3];
		matrix[1, 1] = array[1, 4];
		matrix[1, 2] = array[1, 5];
		matrix[2, 0] = array[2, 3];
		matrix[2, 1] = array[2, 4];
		matrix[2, 2] = array[2, 5];
		return true;
	}

	public bool ChangeBasis(Point3D P0, Vector3D X0, Vector3D Y0, Vector3D Z0, Point3D P1, Vector3D X1, Vector3D Y1, Vector3D Z1)
	{
		Transformation transformation = new Transformation(P0, X0, Y0, Z0);
		Transformation transformation2 = new Transformation();
		transformation2.Translation(0.0 - P1.X, 0.0 - P1.Y, 0.0 - P1.Z);
		Transformation transformation3 = new Transformation();
		bool result = transformation3.ChangeBasis(Vector3D.AxisX, Vector3D.AxisY, Vector3D.AxisZ, X1, Y1, Z1);
		matrix = (transformation3 * transformation2 * transformation).matrix;
		return result;
	}

	public static void AutocadOCS(Vector3D normal, out Vector3D xAxis, out Vector3D yAxis)
	{
		Vector3D vector3D = (Vector3D)normal.Clone();
		vector3D.Normalize();
		Vector3D a = new Vector3D(0.0, 1.0, 0.0);
		Vector3D a2 = new Vector3D(0.0, 0.0, 1.0);
		if (Math.Abs(vector3D.X) < 1.0 / 64.0 && Math.Abs(vector3D.Y) < 1.0 / 64.0)
		{
			xAxis = Vector3D.Cross(a, vector3D);
		}
		else
		{
			xAxis = Vector3D.Cross(a2, vector3D);
		}
		xAxis.Normalize();
		yAxis = Vector3D.Cross(vector3D, xAxis);
		yAxis.Normalize();
	}

	private double[][,] _0023_003DzQmdlWHNyrix8EDLP3AqN4O0_003D()
	{
		if (Utility.Compare(1E-12, devDept.Geometry.Matrix.Determinant4(matrix), 0.0) == 0)
		{
			return new double[3][,];
		}
		double[][,] array = new double[3][,];
		double[,] obj = new double[4, 4]
		{
			{ 1.0, 0.0, 0.0, 0.0 },
			{ 0.0, 1.0, 0.0, 0.0 },
			{ 0.0, 0.0, 1.0, 0.0 },
			{ 0.0, 0.0, 0.0, 1.0 }
		};
		obj[0, 3] = matrix[0, 3];
		obj[1, 3] = matrix[1, 3];
		obj[2, 3] = matrix[2, 3];
		array[0] = obj;
		double[,] array2 = new double[3, 3]
		{
			{
				matrix[0, 0],
				matrix[0, 1],
				matrix[0, 2]
			},
			{
				matrix[1, 0],
				matrix[1, 1],
				matrix[1, 2]
			},
			{
				matrix[2, 0],
				matrix[2, 1],
				matrix[2, 2]
			}
		};
		_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2 = new _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz((double[,])devDept.Geometry.Matrix.Multiply3x3(devDept.Geometry.Matrix.Transpose(array2), array2).Clone(), _0023_003Dzz1zRqomK9jtILG1k2Q_003D_003D: true, _0023_003DzuWbYKRJA_cXR: true);
		double[,] array3 = (double[,])_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DziqPmecX6waT2d26HKbXnPEE_003D().Clone();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array3[i, j] /= Math.Sqrt(_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DzMSUJVwizKGcggd0NSj1eFPw_003D()[j]);
			}
		}
		array3 = devDept.Geometry.Matrix.Multiply3x3(array3, devDept.Geometry.Matrix.Transpose(_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DziqPmecX6waT2d26HKbXnPEE_003D()));
		double[,] array4 = devDept.Geometry.Matrix.Multiply3x3(array2, array3);
		double[,] array5 = devDept.Geometry.Matrix.Multiply3x3(devDept.Geometry.Matrix.Transpose(array4), array2);
		if (devDept.Geometry.Matrix.Determinant3(array4) < 0.0)
		{
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					array5[k, l] *= -1.0;
					array4[k, l] *= -1.0;
				}
			}
		}
		array[1] = new double[4, 4]
		{
			{
				array4[0, 0],
				array4[0, 1],
				array4[0, 2],
				0.0
			},
			{
				array4[1, 0],
				array4[1, 1],
				array4[1, 2],
				0.0
			},
			{
				array4[2, 0],
				array4[2, 1],
				array4[2, 2],
				0.0
			},
			{ 0.0, 0.0, 0.0, 1.0 }
		};
		array[2] = new double[4, 4]
		{
			{
				array5[0, 0],
				array5[0, 1],
				array5[0, 2],
				0.0
			},
			{
				array5[1, 0],
				array5[1, 1],
				array5[1, 2],
				0.0
			},
			{
				array5[2, 0],
				array5[2, 1],
				array5[2, 2],
				0.0
			},
			{ 0.0, 0.0, 0.0, 1.0 }
		};
		return array;
	}

	public bool GetRotationAngles(out double a, out double b, out double c)
	{
		a = 0.0;
		b = 0.0;
		c = 0.0;
		double[,] array = _0023_003DzQmdlWHNyrix8EDLP3AqN4O0_003D()[1];
		if (array == null)
		{
			return false;
		}
		b = 0.0 - Math.Asin(array[2, 0]);
		double num = Math.Cos(b);
		if (Utility.Compare(1E-12, num, 0.0) != 0)
		{
			a = Math.Atan2(array[2, 1] / num, array[2, 2] / num);
			c = Math.Atan2(array[1, 0] / num, array[0, 0] / num);
		}
		else if (array[2, 0] < 0.0)
		{
			b = Math.PI / 2.0;
			a = Math.Atan2(array[0, 1], array[0, 2]);
		}
		else
		{
			b = -Math.PI / 2.0;
			a = Math.Atan2(0.0 - array[0, 1], 0.0 - array[0, 2]);
		}
		return true;
	}

	public Vector3D GetTranslationVector()
	{
		return new Vector3D(matrix[0, 3], matrix[1, 3], matrix[2, 3]);
	}

	public void GetFrame(out Point3D origin, out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		origin = new Point3D(matrix[0, 3], matrix[1, 3], matrix[2, 3]);
		axisX = new Vector3D(matrix[0, 0], matrix[1, 0], matrix[2, 0]);
		axisY = new Vector3D(matrix[0, 1], matrix[1, 1], matrix[2, 1]);
		axisZ = new Vector3D(matrix[0, 2], matrix[1, 2], matrix[2, 2]);
	}

	public bool IsScaleFactorUniform()
	{
		double num = Math.Abs(ScaleFactorX);
		double num2 = Math.Abs(ScaleFactorY);
		double num3 = Math.Abs(ScaleFactorZ);
		if (Math.Abs(num - num2) < Utility._0023_003DzheSR8QM7q9ya)
		{
			return Math.Abs(num2 - num3) < Utility._0023_003DzheSR8QM7q9ya;
		}
		return false;
	}

	public bool IsScaleFactorUniformForPlanar(Plane pl, ref double scaleFactor)
	{
		double num = Math.Abs(ScaleFactorX);
		double num2 = Math.Abs(ScaleFactorY);
		double num3 = Math.Abs(ScaleFactorZ);
		if (Vector3D.AreParallel(pl.AxisZ, Vector3D.AxisZ))
		{
			return Math.Abs(num - num2) < Utility._0023_003DzheSR8QM7q9ya;
		}
		if (Vector3D.AreParallel(pl.AxisZ, Vector3D.AxisY))
		{
			return Math.Abs(num - num3) < Utility._0023_003DzheSR8QM7q9ya;
		}
		if (Vector3D.AreParallel(pl.AxisZ, Vector3D.AxisX))
		{
			scaleFactor = ScaleFactorY;
			return Math.Abs(num3 - num2) < Utility._0023_003DzheSR8QM7q9ya;
		}
		return false;
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[0, 0]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[0, 1]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[0, 2]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660459), matrix[0, 3]));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[1, 0]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[1, 1]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[1, 2]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660459), matrix[1, 3]));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[2, 0]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[2, 1]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[2, 2]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660459), matrix[2, 3]));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[3, 0]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[3, 1]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660472), matrix[3, 2]));
		stringBuilder.Append(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660459), matrix[3, 3]));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660445), matrix[0, 3], matrix[1, 3], matrix[2, 3]));
		GetRotationAngles(out var a, out var b, out var c);
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660394), Utility.RadToDeg(a), Utility.RadToDeg(b), Utility.RadToDeg(c)));
		return stringBuilder.ToString();
	}

	public virtual TransformationSurrogate ConvertToSurrogate()
	{
		return new TransformationSurrogate(this);
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659721), matrix);
	}

	public bool EqualScaleFactors()
	{
		double scaleFactorX = ScaleFactorX;
		double scaleFactorY = ScaleFactorY;
		if (Utility.AreEqual(scaleFactorX, scaleFactorY, Math.Max(Math.Abs(scaleFactorX), Math.Abs(scaleFactorY))))
		{
			double scaleFactorZ = ScaleFactorZ;
			return Utility.AreEqual(scaleFactorY, scaleFactorZ, Math.Max(Math.Abs(scaleFactorY), Math.Abs(scaleFactorZ)));
		}
		return false;
	}

	public Transformation GetTransformationForNormals()
	{
		Transformation transformation = new Transformation(this);
		transformation.Matrix[0, 3] = (transformation.Matrix[1, 3] = (transformation.Matrix[2, 3] = 0.0));
		transformation.Invert();
		transformation.Transpose();
		return transformation;
	}

	public static Transformation CreateIdentity()
	{
		Transformation transformation = new Transformation(1.0);
		transformation.Identity();
		return transformation;
	}

	public static Transformation CreateTranslation(double dx, double dy, double dz = 0.0)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(dx, dy, dz);
		return transformation;
	}

	public static Transformation CreateTranslation(Vector3D d)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(d);
		return transformation;
	}

	public static Transformation CreateTranslation(Vector2D d)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(d.X, d.Y);
		return transformation;
	}

	public static Transformation CreateRotation(double angleInRadians, Vector3D axis)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(angleInRadians, axis);
		return transformation;
	}

	public static Transformation CreateRotation(double angleInRadians, Vector3D axis, Point3D center)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(angleInRadians, axis, center);
		return transformation;
	}

	public static Transformation CreateRotation(double angleInRadians, Point3D axisStart, Point3D axisEnd)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(angleInRadians, axisStart, axisEnd);
		return transformation;
	}

	public static Transformation CreateScaling(double factor)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(factor, factor, factor);
		return transformation;
	}

	public static Transformation CreateScaling(double sx, double sy, double sz = 1.0)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(sx, sy, sz);
		return transformation;
	}

	public static Transformation CreateScaling(Vector3D sv)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(sv);
		return transformation;
	}

	public static Transformation CreateScaling(Vector2D sv)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(sv.X, sv.Y);
		return transformation;
	}

	public static Transformation CreateScaling(Point3D fixedPoint, double factor)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(fixedPoint, factor);
		return transformation;
	}

	public static Transformation CreateScaling(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(fixedPoint, sx, sy, sz);
		return transformation;
	}

	public static Transformation CreateReflection(Plane pln)
	{
		Transformation transformation = new Transformation();
		transformation.Reflection(pln);
		return transformation;
	}

	public static Transformation CreateAlignment(Plane from, Plane to)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(from, to);
		return transformation;
	}
}
