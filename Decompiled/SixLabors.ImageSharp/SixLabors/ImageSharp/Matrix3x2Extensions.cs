using System.Numerics;

namespace SixLabors.ImageSharp;

public static class Matrix3x2Extensions
{
	public static Matrix3x2 CreateTranslation(PointF position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateTranslation((Vector2)position);
	}

	public static Matrix3x2 CreateScale(float xScale, float yScale, PointF centerPoint)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateScale(xScale, yScale, (Vector2)centerPoint);
	}

	public static Matrix3x2 CreateScale(SizeF scales)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateScale((Vector2)scales);
	}

	public static Matrix3x2 CreateScale(SizeF scales, PointF centerPoint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateScale((Vector2)scales, (Vector2)centerPoint);
	}

	public static Matrix3x2 CreateScale(float scale, PointF centerPoint)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateScale(scale, (Vector2)centerPoint);
	}

	public static Matrix3x2 CreateSkewDegrees(float degreesX, float degreesY)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateSkew(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY));
	}

	public static Matrix3x2 CreateSkew(float radiansX, float radiansY, PointF centerPoint)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateSkew(radiansX, radiansY, (Vector2)centerPoint);
	}

	public static Matrix3x2 CreateSkewDegrees(float degreesX, float degreesY, PointF centerPoint)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateSkew(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY), (Vector2)centerPoint);
	}

	public static Matrix3x2 CreateRotationDegrees(float degrees)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateRotation(GeometryUtilities.DegreeToRadian(degrees));
	}

	public static Matrix3x2 CreateRotation(float radians, PointF centerPoint)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateRotation(radians, (Vector2)centerPoint);
	}

	public static Matrix3x2 CreateRotationDegrees(float degrees, PointF centerPoint)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Matrix3x2.CreateRotation(GeometryUtilities.DegreeToRadian(degrees), (Vector2)centerPoint);
	}
}
