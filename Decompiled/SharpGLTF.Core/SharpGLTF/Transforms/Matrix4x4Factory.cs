using System;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Transforms;

public static class Matrix4x4Factory
{
	[Flags]
	public enum MatrixCheck
	{
		None = 0,
		Finite = 1,
		NonZero = 2,
		Identity = 4,
		IdentityColumn4 = 8,
		Invertible = 0x10,
		Decomposable = 0x20,
		PositiveDeterminant = 0x40,
		LocalTransform = 0x3A,
		WorldTransform = 0x1A,
		InverseBindMatrix = 0x1A
	}

	private static MatrixCheck _Validate(in Matrix4x4 matrix, MatrixCheck check, float tolerance = 0f)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		if (!matrix._IsFinite())
		{
			return MatrixCheck.Finite;
		}
		Matrix4x4 val2 = default(Matrix4x4);
		if (check.HasFlag(MatrixCheck.NonZero))
		{
			Matrix4x4 val = matrix;
			val2 = default(Matrix4x4);
			if (val == val2)
			{
				return MatrixCheck.NonZero;
			}
		}
		if (check.HasFlag(MatrixCheck.Identity) && matrix != Matrix4x4.Identity)
		{
			return MatrixCheck.Identity;
		}
		if (check.HasFlag(MatrixCheck.IdentityColumn4))
		{
			if (matrix.M14 != 0f)
			{
				return MatrixCheck.IdentityColumn4;
			}
			if (matrix.M24 != 0f)
			{
				return MatrixCheck.IdentityColumn4;
			}
			if (matrix.M34 != 0f)
			{
				return MatrixCheck.IdentityColumn4;
			}
			if (tolerance == 0f)
			{
				if (matrix.M44 != 1f)
				{
					return MatrixCheck.IdentityColumn4;
				}
			}
			else if (Math.Abs(matrix.M44 - 1f) > tolerance)
			{
				return MatrixCheck.IdentityColumn4;
			}
		}
		if (check.HasFlag(MatrixCheck.Invertible) && !Matrix4x4.Invert(matrix, ref val2))
		{
			return MatrixCheck.Invertible;
		}
		Vector3 val3 = default(Vector3);
		Quaternion val4 = default(Quaternion);
		Vector3 val5 = default(Vector3);
		if (check.HasFlag(MatrixCheck.Decomposable) && !Matrix4x4.Decompose(matrix, ref val3, ref val4, ref val5))
		{
			return MatrixCheck.Decomposable;
		}
		if (check.HasFlag(MatrixCheck.PositiveDeterminant))
		{
			val2 = matrix;
			if (((Matrix4x4)(ref val2)).GetDeterminant() <= 0f)
			{
				return MatrixCheck.PositiveDeterminant;
			}
		}
		return MatrixCheck.None;
	}

	public static bool IsValid(in Matrix4x4 matrix, MatrixCheck check, float tolerance = 0f)
	{
		return _Validate(in matrix, check, tolerance) == MatrixCheck.None;
	}

	[DebuggerStepThrough]
	public static void GuardMatrix(string argName, Matrix4x4 matrix, MatrixCheck check, float tolerance = 0f)
	{
		MatrixCheck matrixCheck = _Validate(in matrix, check, tolerance);
		if (matrixCheck != MatrixCheck.None)
		{
			throw new ArgumentException($"Invalid Matrix. Fail: {matrixCheck}", argName);
		}
	}

	public static Matrix4x4 CreateFromRows(Vector3 rowX, Vector3 rowY, Vector3 rowZ)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		return new Matrix4x4(rowX.X, rowX.Y, rowX.Z, 0f, rowY.X, rowY.Y, rowY.Z, 0f, rowZ.X, rowZ.Y, rowZ.Z, 0f, 0f, 0f, 0f, 1f);
	}

	public static Matrix4x4 CreateFromRows(Vector3 rowX, Vector3 rowY, Vector3 rowZ, Vector3 translation)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		return new Matrix4x4(rowX.X, rowX.Y, rowX.Z, 0f, rowY.X, rowY.Y, rowY.Z, 0f, rowZ.X, rowZ.Y, rowZ.Z, 0f, translation.X, translation.Y, translation.Z, 1f);
	}

	public static Matrix4x4 CreateFrom(Matrix4x4? transform, Vector3? scale, Quaternion? rotation, Vector3? translation)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (transform.HasValue)
		{
			return transform.Value;
		}
		return new AffineTransform(scale, rotation, translation).Matrix;
	}

	public static Matrix4x4 LocalToWorld(in Matrix4x4 parentWorld, in Matrix4x4 childLocal)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		GuardMatrix("parentWorld", parentWorld, MatrixCheck.WorldTransform);
		GuardMatrix("childLocal", childLocal, MatrixCheck.LocalTransform);
		return childLocal * parentWorld;
	}

	public static Matrix4x4 WorldToLocal(in Matrix4x4 parentWorld, in Matrix4x4 childWorld)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		GuardMatrix("parentWorld", parentWorld, MatrixCheck.WorldTransform);
		GuardMatrix("childWorld", childWorld, MatrixCheck.WorldTransform);
		return childWorld * parentWorld.Inverse();
	}

	public static void NormalizeMatrix(ref Matrix4x4 xform)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(xform.M11, xform.M12, xform.M13);
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))._002Ector(xform.M21, xform.M22, xform.M23);
		Vector3 val3 = default(Vector3);
		((Vector3)(ref val3))._002Ector(xform.M31, xform.M32, xform.M33);
		float num = ((Vector3)(ref val)).Length();
		float num2 = ((Vector3)(ref val2)).Length();
		float num3 = ((Vector3)(ref val3)).Length();
		val /= num;
		val2 /= num2;
		val3 /= num3;
		float num4 = Math.Abs(Vector3.Dot(val, val2));
		float num5 = Math.Abs(Vector3.Dot(val, val3));
		float num6 = Math.Abs(Vector3.Dot(val2, val3));
		float num7 = num4 + num5;
		float num8 = num4 + num6;
		float num9 = num5 + num6;
		if (num7 < num8 && num7 < num9)
		{
			if (num8 < num9)
			{
				val3 = Vector3.Cross(val, val2);
				val2 = Vector3.Cross(val3, val);
			}
			else
			{
				val2 = Vector3.Cross(val3, val);
				val3 = Vector3.Cross(val, val2);
			}
		}
		else if (num8 < num7 && num8 < num9)
		{
			if (num7 < num9)
			{
				val3 = Vector3.Cross(val, val2);
				val = Vector3.Cross(val2, val3);
			}
			else
			{
				val = Vector3.Cross(val2, val3);
				val3 = Vector3.Cross(val, val2);
			}
		}
		else if (num7 < num8)
		{
			val2 = Vector3.Cross(val3, val);
			val = Vector3.Cross(val2, val3);
		}
		else
		{
			val = Vector3.Cross(val2, val3);
			val2 = Vector3.Cross(val3, val);
		}
		val *= num;
		val2 *= num2;
		val3 *= num3;
		xform.M11 = val.X;
		xform.M12 = val.Y;
		xform.M13 = val.Z;
		xform.M21 = val2.X;
		xform.M22 = val2.Y;
		xform.M23 = val2.Z;
		xform.M31 = val3.X;
		xform.M32 = val3.Y;
		xform.M33 = val3.Z;
	}
}
