using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Processing.Processors.Transforms;

internal static class TransformUtils
{
	public static bool IsDegenerate(Matrix3x2 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (!IsNaN(matrix))
		{
			return IsZero(((Matrix3x2)(ref matrix)).GetDeterminant());
		}
		return true;
	}

	public static bool IsDegenerate(Matrix4x4 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (!IsNaN(matrix))
		{
			return IsZero(((Matrix4x4)(ref matrix)).GetDeterminant());
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsZero(float a)
	{
		if (a > 0f - Constants.EpsilonSquared)
		{
			return a < Constants.EpsilonSquared;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNaN(Matrix3x2 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (!float.IsNaN(matrix.M11) && !float.IsNaN(matrix.M12) && !float.IsNaN(matrix.M21) && !float.IsNaN(matrix.M22) && !float.IsNaN(matrix.M31))
		{
			return float.IsNaN(matrix.M32);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNaN(Matrix4x4 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		if (!float.IsNaN(matrix.M11) && !float.IsNaN(matrix.M12) && !float.IsNaN(matrix.M13) && !float.IsNaN(matrix.M14) && !float.IsNaN(matrix.M21) && !float.IsNaN(matrix.M22) && !float.IsNaN(matrix.M23) && !float.IsNaN(matrix.M24) && !float.IsNaN(matrix.M31) && !float.IsNaN(matrix.M32) && !float.IsNaN(matrix.M33) && !float.IsNaN(matrix.M34) && !float.IsNaN(matrix.M41) && !float.IsNaN(matrix.M42) && !float.IsNaN(matrix.M43))
		{
			return float.IsNaN(matrix.M44);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 ProjectiveTransform2D(float x, float y, Matrix4x4 matrix)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = Vector4.Transform(new Vector4(x, y, 0f, 1f), matrix);
		return new Vector2(val.X, val.Y) / MathF.Max(val.W, 1E-07f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix3x2 CreateRotationTransformMatrixDegrees(float degrees, Size size, TransformSpace transformSpace)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return CreateRotationTransformMatrixRadians(GeometryUtilities.DegreeToRadian(degrees), size, transformSpace);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix3x2 CreateRotationTransformMatrixRadians(float radians, Size size, TransformSpace transformSpace)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return CreateCenteredTransformMatrix(Matrix3x2Extensions.CreateRotation(radians, PointF.Empty), size, transformSpace);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix3x2 CreateSkewTransformMatrixDegrees(float degreesX, float degreesY, Size size, TransformSpace transformSpace)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return CreateSkewTransformMatrixRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY), size, transformSpace);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix3x2 CreateSkewTransformMatrixRadians(float radiansX, float radiansY, Size size, TransformSpace transformSpace)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return CreateCenteredTransformMatrix(Matrix3x2Extensions.CreateSkew(radiansX, radiansY, PointF.Empty), size, transformSpace);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix3x2 CreateCenteredTransformMatrix(Matrix3x2 matrix, Size size, TransformSpace transformSpace)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		Size unboundedTransformedSize = GetUnboundedTransformedSize(matrix, size, transformSpace);
		Matrix3x2 val = default(Matrix3x2);
		Matrix3x2.Invert(matrix, ref val);
		float num = ((transformSpace == TransformSpace.Pixel) ? 1f : 0f);
		Matrix3x2 val2 = Matrix3x2.CreateTranslation(new Vector2(0f - ((float)unboundedTransformedSize.Width - num), 0f - ((float)unboundedTransformedSize.Height - num)) * 0.5f);
		Matrix3x2 val3 = Matrix3x2.CreateTranslation(new Vector2((float)size.Width - num, (float)size.Height - num) * 0.5f);
		Matrix3x2 result = default(Matrix3x2);
		Matrix3x2.Invert(val2 * val * val3, ref result);
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix4x4 CreateTaperMatrix(Size size, TaperSide side, TaperCorner corner, float fraction)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 identity = Matrix4x4.Identity;
		switch (side)
		{
		case TaperSide.Left:
			identity.M11 = fraction;
			identity.M22 = fraction;
			identity.M14 = (fraction - 1f) / (float)size.Width;
			switch (corner)
			{
			case TaperCorner.LeftOrTop:
				identity.M12 = (float)size.Height * identity.M14;
				identity.M42 = (float)size.Height * (1f - fraction);
				break;
			case TaperCorner.Both:
				identity.M12 = (float)size.Height * 0.5f * identity.M14;
				identity.M42 = (float)size.Height * (1f - fraction) / 2f;
				break;
			}
			break;
		case TaperSide.Top:
			identity.M11 = fraction;
			identity.M22 = fraction;
			identity.M24 = (fraction - 1f) / (float)size.Height;
			switch (corner)
			{
			case TaperCorner.LeftOrTop:
				identity.M21 = (float)size.Width * identity.M24;
				identity.M41 = (float)size.Width * (1f - fraction);
				break;
			case TaperCorner.Both:
				identity.M21 = (float)size.Width * 0.5f * identity.M24;
				identity.M41 = (float)size.Width * (1f - fraction) * 0.5f;
				break;
			}
			break;
		case TaperSide.Right:
			identity.M11 = 1f / fraction;
			identity.M14 = (1f - fraction) / ((float)size.Width * fraction);
			switch (corner)
			{
			case TaperCorner.LeftOrTop:
				identity.M12 = (float)size.Height * identity.M14;
				break;
			case TaperCorner.Both:
				identity.M12 = (float)size.Height * 0.5f * identity.M14;
				break;
			}
			break;
		case TaperSide.Bottom:
			identity.M22 = 1f / fraction;
			identity.M24 = (1f - fraction) / ((float)size.Height * fraction);
			switch (corner)
			{
			case TaperCorner.LeftOrTop:
				identity.M21 = (float)size.Width * identity.M24;
				break;
			case TaperCorner.Both:
				identity.M21 = (float)size.Width * 0.5f * identity.M24;
				break;
			}
			break;
		}
		return identity;
	}

	public static Size GetTransformedSize(Matrix3x2 matrix, Size size, TransformSpace transformSpace)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return GetTransformedSize(matrix, size, transformSpace, constrain: true);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Size GetTransformedSize(Matrix4x4 matrix, Size size)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		Guard.IsTrue(size.Width > 0 && size.Height > 0, "size", "Source size dimensions cannot be 0!");
		if (((Matrix4x4)(ref matrix)).Equals(default(Matrix4x4)) || ((Matrix4x4)(ref matrix)).Equals(Matrix4x4.Identity))
		{
			return size;
		}
		bool num = matrix.M34 == 0f && matrix.M44 == 1f && matrix.M14 == 0f && matrix.M24 == 0f;
		Vector2 val = new Vector2(matrix.M11, matrix.M21);
		float width = 1f / ((Vector2)(ref val)).Length();
		val = new Vector2(matrix.M12, matrix.M22);
		float height = 1f / ((Vector2)(ref val)).Length();
		SizeF sizeF = (num ? new SizeF(width, height) : SizeF.Empty);
		if (TryGetTransformedRectangle(new RectangleF(Point.Empty, size - sizeF), matrix, out var bounds))
		{
			return Size.Ceiling(ConstrainSize(bounds) + sizeF);
		}
		return size;
	}

	private static Size GetUnboundedTransformedSize(Matrix3x2 matrix, Size size, TransformSpace transformSpace)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return GetTransformedSize(matrix, size, transformSpace, constrain: false);
	}

	private static Size GetTransformedSize(Matrix3x2 matrix, Size size, TransformSpace transformSpace, bool constrain)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		Guard.IsTrue(size.Width > 0 && size.Height > 0, "size", "Source size dimensions cannot be 0!");
		if (((Matrix3x2)(ref matrix)).Equals(default(Matrix3x2)) || ((Matrix3x2)(ref matrix)).Equals(Matrix3x2.Identity))
		{
			return size;
		}
		SizeF sizeF = SizeF.Empty;
		if (transformSpace == TransformSpace.Pixel)
		{
			Vector2 val = new Vector2(matrix.M11, matrix.M21);
			float width = 1f / ((Vector2)(ref val)).Length();
			val = new Vector2(matrix.M12, matrix.M22);
			float height = 1f / ((Vector2)(ref val)).Length();
			sizeF = new SizeF(width, height);
		}
		if (TryGetTransformedRectangle(new RectangleF(Point.Empty, size - sizeF), matrix, out var bounds))
		{
			return Size.Ceiling((constrain ? ConstrainSize(bounds) : bounds.Size) + sizeF);
		}
		return size;
	}

	private static bool TryGetTransformedRectangle(RectangleF rectangle, Matrix3x2 matrix, out Rectangle bounds)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		if (!rectangle.Equals(default(RectangleF)))
		{
			Matrix3x2 identity = Matrix3x2.Identity;
			if (!((Matrix3x2)(ref identity)).Equals(matrix))
			{
				Vector2 tl = Vector2.Transform(new Vector2(rectangle.Left, rectangle.Top), matrix);
				Vector2 tr = Vector2.Transform(new Vector2(rectangle.Right, rectangle.Top), matrix);
				Vector2 bl = Vector2.Transform(new Vector2(rectangle.Left, rectangle.Bottom), matrix);
				Vector2 br = Vector2.Transform(new Vector2(rectangle.Right, rectangle.Bottom), matrix);
				bounds = GetBoundingRectangle(tl, tr, bl, br);
				return true;
			}
		}
		bounds = default(Rectangle);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryGetTransformedRectangle(RectangleF rectangle, Matrix4x4 matrix, out Rectangle bounds)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (!rectangle.Equals(default(RectangleF)))
		{
			Matrix4x4 identity = Matrix4x4.Identity;
			if (!((Matrix4x4)(ref identity)).Equals(matrix))
			{
				Vector2 tl = ProjectiveTransform2D(rectangle.Left, rectangle.Top, matrix);
				Vector2 tr = ProjectiveTransform2D(rectangle.Right, rectangle.Top, matrix);
				Vector2 bl = ProjectiveTransform2D(rectangle.Left, rectangle.Bottom, matrix);
				Vector2 br = ProjectiveTransform2D(rectangle.Right, rectangle.Bottom, matrix);
				bounds = GetBoundingRectangle(tl, tr, bl, br);
				return true;
			}
		}
		bounds = default(Rectangle);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Size ConstrainSize(Rectangle rectangle)
	{
		int num = ((rectangle.Top < 0) ? rectangle.Bottom : Math.Max(rectangle.Height, rectangle.Bottom));
		int num2 = ((rectangle.Left < 0) ? rectangle.Right : Math.Max(rectangle.Width, rectangle.Right));
		if (num <= 0)
		{
			num = rectangle.Height;
		}
		if (num2 <= 0)
		{
			num2 = rectangle.Width;
		}
		return new Size(num2, num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Rectangle GetBoundingRectangle(Vector2 tl, Vector2 tr, Vector2 bl, Vector2 br)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		float num = MathF.Min(tl.X, MathF.Min(tr.X, MathF.Min(bl.X, br.X)));
		float num2 = MathF.Min(tl.Y, MathF.Min(tr.Y, MathF.Min(bl.Y, br.Y)));
		float num3 = MathF.Max(tl.X, MathF.Max(tr.X, MathF.Max(bl.X, br.X)));
		return Rectangle.FromLTRB(bottom: (int)Math.Ceiling(MathF.Max(tl.Y, MathF.Max(tr.Y, MathF.Max(bl.Y, br.Y)))), left: (int)Math.Floor(num), top: (int)Math.Floor(num2), right: (int)Math.Ceiling(num3));
	}
}
