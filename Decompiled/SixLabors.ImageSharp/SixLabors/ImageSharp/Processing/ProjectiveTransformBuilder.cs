using System;
using System.Collections.Generic;
using System.Numerics;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace SixLabors.ImageSharp.Processing;

public class ProjectiveTransformBuilder
{
	private readonly List<Func<Size, Matrix4x4>> transformMatrixFactories = new List<Func<Size, Matrix4x4>>();

	public TransformSpace TransformSpace { get; }

	public ProjectiveTransformBuilder()
		: this(TransformSpace.Pixel)
	{
	}

	public ProjectiveTransformBuilder(TransformSpace transformSpace)
	{
		TransformSpace = transformSpace;
	}

	public ProjectiveTransformBuilder PrependTaper(TaperSide side, TaperCorner corner, float fraction)
	{
		return Prepend((Size size) => TransformUtils.CreateTaperMatrix(size, side, corner, fraction));
	}

	public ProjectiveTransformBuilder AppendTaper(TaperSide side, TaperCorner corner, float fraction)
	{
		return Append((Size size) => TransformUtils.CreateTaperMatrix(size, side, corner, fraction));
	}

	public ProjectiveTransformBuilder PrependRotationDegrees(float degrees)
	{
		return PrependRotationRadians(GeometryUtilities.DegreeToRadian(degrees));
	}

	public ProjectiveTransformBuilder PrependRotationRadians(float radians)
	{
		return Prepend((Size size) => new Matrix4x4(TransformUtils.CreateRotationTransformMatrixRadians(radians, size, TransformSpace)));
	}

	internal ProjectiveTransformBuilder PrependRotationDegrees(float degrees, Vector2 origin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return PrependRotationRadians(GeometryUtilities.DegreeToRadian(degrees), origin);
	}

	internal ProjectiveTransformBuilder PrependRotationRadians(float radians, Vector2 origin)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix4x4.CreateRotationZ(radians, new Vector3(origin, 0f)));
	}

	public ProjectiveTransformBuilder AppendRotationDegrees(float degrees)
	{
		return AppendRotationRadians(GeometryUtilities.DegreeToRadian(degrees));
	}

	public ProjectiveTransformBuilder AppendRotationRadians(float radians)
	{
		return Append((Size size) => new Matrix4x4(TransformUtils.CreateRotationTransformMatrixRadians(radians, size, TransformSpace)));
	}

	internal ProjectiveTransformBuilder AppendRotationDegrees(float degrees, Vector2 origin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return AppendRotationRadians(GeometryUtilities.DegreeToRadian(degrees), origin);
	}

	internal ProjectiveTransformBuilder AppendRotationRadians(float radians, Vector2 origin)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix4x4.CreateRotationZ(radians, new Vector3(origin, 0f)));
	}

	public ProjectiveTransformBuilder PrependScale(float scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix4x4.CreateScale(scale));
	}

	public ProjectiveTransformBuilder PrependScale(SizeF scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependScale((Vector2)scale);
	}

	public ProjectiveTransformBuilder PrependScale(Vector2 scales)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix4x4.CreateScale(new Vector3(scales, 1f)));
	}

	public ProjectiveTransformBuilder AppendScale(float scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix4x4.CreateScale(scale));
	}

	public ProjectiveTransformBuilder AppendScale(SizeF scales)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendScale((Vector2)scales);
	}

	public ProjectiveTransformBuilder AppendScale(Vector2 scales)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix4x4.CreateScale(new Vector3(scales, 1f)));
	}

	internal ProjectiveTransformBuilder PrependSkewDegrees(float degreesX, float degreesY)
	{
		return PrependSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY));
	}

	public ProjectiveTransformBuilder PrependSkewRadians(float radiansX, float radiansY)
	{
		return Prepend((Size size) => new Matrix4x4(TransformUtils.CreateSkewTransformMatrixRadians(radiansX, radiansY, size, TransformSpace)));
	}

	public ProjectiveTransformBuilder PrependSkewDegrees(float degreesX, float degreesY, Vector2 origin)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return PrependSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY), origin);
	}

	public ProjectiveTransformBuilder PrependSkewRadians(float radiansX, float radiansY, Vector2 origin)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(new Matrix4x4(Matrix3x2.CreateSkew(radiansX, radiansY, origin)));
	}

	internal ProjectiveTransformBuilder AppendSkewDegrees(float degreesX, float degreesY)
	{
		return AppendSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY));
	}

	public ProjectiveTransformBuilder AppendSkewRadians(float radiansX, float radiansY)
	{
		return Append((Size size) => new Matrix4x4(TransformUtils.CreateSkewTransformMatrixRadians(radiansX, radiansY, size, TransformSpace)));
	}

	public ProjectiveTransformBuilder AppendSkewDegrees(float degreesX, float degreesY, Vector2 origin)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return AppendSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY), origin);
	}

	public ProjectiveTransformBuilder AppendSkewRadians(float radiansX, float radiansY, Vector2 origin)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(new Matrix4x4(Matrix3x2.CreateSkew(radiansX, radiansY, origin)));
	}

	public ProjectiveTransformBuilder PrependTranslation(PointF position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependTranslation((Vector2)position);
	}

	public ProjectiveTransformBuilder PrependTranslation(Vector2 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix4x4.CreateTranslation(new Vector3(position, 0f)));
	}

	public ProjectiveTransformBuilder AppendTranslation(PointF position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendTranslation((Vector2)position);
	}

	public ProjectiveTransformBuilder AppendTranslation(Vector2 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix4x4.CreateTranslation(new Vector3(position, 0f)));
	}

	public ProjectiveTransformBuilder PrependMatrix(Matrix4x4 matrix)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		CheckDegenerate(matrix);
		return Prepend((Size _) => matrix);
	}

	public ProjectiveTransformBuilder AppendMatrix(Matrix4x4 matrix)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		CheckDegenerate(matrix);
		return Append((Size _) => matrix);
	}

	public Matrix4x4 BuildMatrix(Size sourceSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return BuildMatrix(new Rectangle(Point.Empty, sourceSize));
	}

	public Matrix4x4 BuildMatrix(Rectangle sourceRectangle)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		Guard.MustBeGreaterThan(sourceRectangle.Width, 0, "sourceRectangle");
		Guard.MustBeGreaterThan(sourceRectangle.Height, 0, "sourceRectangle");
		Matrix4x4 val = Matrix4x4.CreateTranslation(new Vector3((Vector2)(-sourceRectangle.Location), 0f));
		Size size = sourceRectangle.Size;
		foreach (Func<Size, Matrix4x4> transformMatrixFactory in transformMatrixFactories)
		{
			val *= transformMatrixFactory(size);
		}
		CheckDegenerate(val);
		return val;
	}

	public Size GetTransformedSize(Rectangle sourceRectangle)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		Size size = sourceRectangle.Size;
		Matrix4x4 val = Matrix4x4.CreateTranslation(new Vector3((Vector2)(-sourceRectangle.Location), 0f));
		foreach (Func<Size, Matrix4x4> transformMatrixFactory in transformMatrixFactories)
		{
			val *= transformMatrixFactory(size);
			CheckDegenerate(val);
		}
		return TransformUtils.GetTransformedSize(val, size);
	}

	private static void CheckDegenerate(Matrix4x4 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (TransformUtils.IsDegenerate(matrix))
		{
			throw new DegenerateTransformException("Matrix is degenerate. Check input values.");
		}
	}

	private ProjectiveTransformBuilder Prepend(Func<Size, Matrix4x4> transformFactory)
	{
		transformMatrixFactories.Insert(0, transformFactory);
		return this;
	}

	private ProjectiveTransformBuilder Append(Func<Size, Matrix4x4> transformFactory)
	{
		transformMatrixFactories.Add(transformFactory);
		return this;
	}
}
