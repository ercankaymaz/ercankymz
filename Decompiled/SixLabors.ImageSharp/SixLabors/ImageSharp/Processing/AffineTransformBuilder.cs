using System;
using System.Collections.Generic;
using System.Numerics;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace SixLabors.ImageSharp.Processing;

public class AffineTransformBuilder
{
	private readonly List<Func<Size, Matrix3x2>> transformMatrixFactories = new List<Func<Size, Matrix3x2>>();

	public TransformSpace TransformSpace { get; }

	public AffineTransformBuilder()
		: this(TransformSpace.Pixel)
	{
	}

	public AffineTransformBuilder(TransformSpace transformSpace)
	{
		TransformSpace = transformSpace;
	}

	public AffineTransformBuilder PrependRotationDegrees(float degrees)
	{
		return PrependRotationRadians(GeometryUtilities.DegreeToRadian(degrees));
	}

	public AffineTransformBuilder PrependRotationRadians(float radians)
	{
		return Prepend((Size size) => TransformUtils.CreateRotationTransformMatrixRadians(radians, size, TransformSpace));
	}

	public AffineTransformBuilder PrependRotationDegrees(float degrees, Vector2 origin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return PrependRotationRadians(GeometryUtilities.DegreeToRadian(degrees), origin);
	}

	public AffineTransformBuilder PrependRotationRadians(float radians, Vector2 origin)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix3x2.CreateRotation(radians, origin));
	}

	public AffineTransformBuilder AppendRotationDegrees(float degrees)
	{
		return AppendRotationRadians(GeometryUtilities.DegreeToRadian(degrees));
	}

	public AffineTransformBuilder AppendRotationRadians(float radians)
	{
		return Append((Size size) => TransformUtils.CreateRotationTransformMatrixRadians(radians, size, TransformSpace));
	}

	public AffineTransformBuilder AppendRotationDegrees(float degrees, Vector2 origin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return AppendRotationRadians(GeometryUtilities.DegreeToRadian(degrees), origin);
	}

	public AffineTransformBuilder AppendRotationRadians(float radians, Vector2 origin)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix3x2.CreateRotation(radians, origin));
	}

	public AffineTransformBuilder PrependScale(float scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix3x2.CreateScale(scale));
	}

	public AffineTransformBuilder PrependScale(SizeF scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependScale((Vector2)scale);
	}

	public AffineTransformBuilder PrependScale(Vector2 scales)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix3x2.CreateScale(scales));
	}

	public AffineTransformBuilder AppendScale(float scale)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix3x2.CreateScale(scale));
	}

	public AffineTransformBuilder AppendScale(SizeF scales)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendScale((Vector2)scales);
	}

	public AffineTransformBuilder AppendScale(Vector2 scales)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix3x2.CreateScale(scales));
	}

	public AffineTransformBuilder PrependSkewDegrees(float degreesX, float degreesY)
	{
		return PrependSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY));
	}

	public AffineTransformBuilder PrependSkewRadians(float radiansX, float radiansY)
	{
		return Prepend((Size size) => TransformUtils.CreateSkewTransformMatrixRadians(radiansX, radiansY, size, TransformSpace));
	}

	public AffineTransformBuilder PrependSkewDegrees(float degreesX, float degreesY, Vector2 origin)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return PrependSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY), origin);
	}

	public AffineTransformBuilder PrependSkewRadians(float radiansX, float radiansY, Vector2 origin)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix3x2.CreateSkew(radiansX, radiansY, origin));
	}

	public AffineTransformBuilder AppendSkewDegrees(float degreesX, float degreesY)
	{
		return AppendSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY));
	}

	public AffineTransformBuilder AppendSkewRadians(float radiansX, float radiansY)
	{
		return Append((Size size) => TransformUtils.CreateSkewTransformMatrixRadians(radiansX, radiansY, size, TransformSpace));
	}

	public AffineTransformBuilder AppendSkewDegrees(float degreesX, float degreesY, Vector2 origin)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return AppendSkewRadians(GeometryUtilities.DegreeToRadian(degreesX), GeometryUtilities.DegreeToRadian(degreesY), origin);
	}

	public AffineTransformBuilder AppendSkewRadians(float radiansX, float radiansY, Vector2 origin)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix3x2.CreateSkew(radiansX, radiansY, origin));
	}

	public AffineTransformBuilder PrependTranslation(PointF position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependTranslation((Vector2)position);
	}

	public AffineTransformBuilder PrependTranslation(Vector2 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return PrependMatrix(Matrix3x2.CreateTranslation(position));
	}

	public AffineTransformBuilder AppendTranslation(PointF position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendTranslation((Vector2)position);
	}

	public AffineTransformBuilder AppendTranslation(Vector2 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return AppendMatrix(Matrix3x2.CreateTranslation(position));
	}

	public AffineTransformBuilder PrependMatrix(Matrix3x2 matrix)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		CheckDegenerate(matrix);
		return Prepend((Size _) => matrix);
	}

	public AffineTransformBuilder AppendMatrix(Matrix3x2 matrix)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		CheckDegenerate(matrix);
		return Append((Size _) => matrix);
	}

	public Matrix3x2 BuildMatrix(Size sourceSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return BuildMatrix(new Rectangle(Point.Empty, sourceSize));
	}

	public Matrix3x2 BuildMatrix(Rectangle sourceRectangle)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		Guard.MustBeGreaterThan(sourceRectangle.Width, 0, "sourceRectangle");
		Guard.MustBeGreaterThan(sourceRectangle.Height, 0, "sourceRectangle");
		Matrix3x2 val = Matrix3x2.CreateTranslation((Vector2)(-sourceRectangle.Location));
		Size size = sourceRectangle.Size;
		foreach (Func<Size, Matrix3x2> transformMatrixFactory in transformMatrixFactories)
		{
			val *= transformMatrixFactory(size);
		}
		CheckDegenerate(val);
		return val;
	}

	public Size GetTransformedSize(Rectangle sourceRectangle)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		Size size = sourceRectangle.Size;
		Matrix3x2 val = Matrix3x2.CreateTranslation((Vector2)(-sourceRectangle.Location));
		foreach (Func<Size, Matrix3x2> transformMatrixFactory in transformMatrixFactories)
		{
			val *= transformMatrixFactory(size);
			CheckDegenerate(val);
		}
		return TransformUtils.GetTransformedSize(val, size, TransformSpace);
	}

	private static void CheckDegenerate(Matrix3x2 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (TransformUtils.IsDegenerate(matrix))
		{
			throw new DegenerateTransformException("Matrix is degenerate. Check input values.");
		}
	}

	private AffineTransformBuilder Prepend(Func<Size, Matrix3x2> transformFactory)
	{
		transformMatrixFactories.Insert(0, transformFactory);
		return this;
	}

	private AffineTransformBuilder Append(Func<Size, Matrix3x2> transformFactory)
	{
		transformMatrixFactories.Add(transformFactory);
		return this;
	}
}
