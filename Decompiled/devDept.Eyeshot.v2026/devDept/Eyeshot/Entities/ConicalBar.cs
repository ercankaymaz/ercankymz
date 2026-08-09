using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class ConicalBar : Bar
{
	private double _topRadius;

	internal Vector3D[] Normals;

	public double BaseRadius
	{
		get
		{
			return base.Radius;
		}
		set
		{
			base.Radius = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double TopRadius
	{
		get
		{
			return _topRadius;
		}
		set
		{
			_topRadius = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public ConicalBar(double x1, double y1, double z1, double x2, double y2, double z2, double baseRadius, double topRadius, int slices)
		: base(x1, y1, z1, x2, y2, z2, baseRadius, slices)
	{
		_topRadius = topRadius;
	}

	public ConicalBar(Point3D start, Point3D end, double baseRadius, double topRadius, int slices)
		: base(start, end, baseRadius, slices)
	{
		_topRadius = topRadius;
	}

	protected ConicalBar(ConicalBar another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_topRadius = another._topRadius;
		if (keepTessellation)
		{
			Normals = Utility._0023_003DzuKHw7_00241xg_0024SB(another.Normals);
		}
	}

	protected internal ConicalBar(ConicalBarSurrogate surrogate)
		: this(surrogate.StartPoint, surrogate.EndPoint, surrogate.Radius, surrogate.TopRadius, surrogate.Slices)
	{
	}

	protected ConicalBar(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_topRadius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963797));
	}

	public override object Clone()
	{
		return new ConicalBar(this);
	}

	public override object CloneWithTessellation()
	{
		return new ConicalBar(this, RegenMode != regenType.RegenAndCompile);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		data.RenderContext.Draw(drawData);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		float[] array = new float[base.Slices * 12];
		double normalLength = GetNormalLength();
		int num = 0;
		for (int i = 0; i < base.Slices; i++)
		{
			Point3D point3D = _vertices[i];
			Vector3D vector3D = Normals[i];
			vector3D.Normalize();
			array[num++] = (float)point3D.X;
			array[num++] = (float)point3D.Y;
			array[num++] = (float)point3D.Z;
			array[num++] = (float)(point3D.X + vector3D.X * normalLength);
			array[num++] = (float)(point3D.Y + vector3D.Y * normalLength);
			array[num++] = (float)(point3D.Z + vector3D.Z * normalLength);
			point3D = _vertices[i + base.Slices];
			array[num++] = (float)point3D.X;
			array[num++] = (float)point3D.Y;
			array[num++] = (float)point3D.Z;
			array[num++] = (float)(point3D.X + vector3D.X * normalLength);
			array[num++] = (float)(point3D.Y + vector3D.Y * normalLength);
			array[num++] = (float)(point3D.Z + vector3D.Z * normalLength);
		}
		data.RenderContext.DrawLines(array);
	}

	public override void Regen(RegenParams data)
	{
		if (base.Slices < 3)
		{
			base.Slices = 3;
		}
		_vertices = new Point3D[base.Slices * 2];
		Normals = new Vector3D[base.Slices];
		Vector3D vector3D = Vector3D.Subtract(end, start);
		double length = vector3D.Length;
		double a = Math.Atan2(0.0 - (_topRadius - base.Radius), length);
		for (int i = 0; i < base.Slices; i++)
		{
			double num = (double)(i * 2) * Math.PI / (double)base.Slices;
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			Normals[i] = new Vector3D(Math.Tan(a), num2, num3);
			_vertices[i] = new Point3D(0.0, num2 * base.Radius, num3 * base.Radius);
		}
		for (int j = 0; j < base.Slices; j++)
		{
			double num4 = (double)(j * 2) * Math.PI / (double)base.Slices;
			double num5 = Math.Cos(num4);
			double num6 = Math.Sin(num4);
			_vertices[j + base.Slices] = new Point3D(length, num5 * _topRadius, num6 * _topRadius);
		}
		base.Triangles = new IndexTriangle[base.Slices * 2];
		int num7 = 0;
		for (int k = 0; k < base.Slices; k++)
		{
			if (k + 1 < base.Slices)
			{
				base.Triangles[num7] = new IndexTriangle(k, k + 1, k + base.Slices + 1);
			}
			else
			{
				base.Triangles[num7] = new IndexTriangle(k, 0, base.Slices);
			}
			if (k + base.Slices + 1 < base.Slices * 2)
			{
				base.Triangles[num7 + 1] = new IndexTriangle(k, k + base.Slices + 1, k + base.Slices);
			}
			else
			{
				base.Triangles[num7 + 1] = new IndexTriangle(k, base.Slices, k + base.Slices);
			}
			num7 += 2;
		}
		Transformation orientationTransformation = Utility.GetOrientationTransformation(start, vector3D);
		for (int l = 0; l < base.Slices; l++)
		{
			_vertices[l] = orientationTransformation * _vertices[l];
			_vertices[base.Slices + l] = orientationTransformation * _vertices[base.Slices + l];
		}
		if (Matrix.Inverse4(orientationTransformation.Matrix, out var inverse))
		{
			double[,] a2 = Matrix.Transpose(inverse);
			for (int m = 0; m < base.Slices; m++)
			{
				double[] b = new double[4]
				{
					Normals[m].X,
					Normals[m].Y,
					Normals[m].Z,
					1.0
				};
				double[] array = Matrix.Multiply4x(a2, b);
				Normals[m] = new Vector3D(array[0], array[1], array[2]);
			}
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		double scaleFactor = Math.Abs(xform.ScaleFactorX);
		Plane pl = new Plane(new Vector3D(base.StartPoint, base.EndPoint));
		if (xform.IsScaleFactorUniform() || xform.IsScaleFactorUniformForPlanar(pl, ref scaleFactor))
		{
			_topRadius *= scaleFactor;
		}
		if (Normals != null)
		{
			Utility.TransformNormals(xform, Normals);
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		Point3D[] array = new Point3D[4 * base.Slices];
		Vector3D[] array2 = new Vector3D[4 * base.Slices];
		int num = 0;
		for (int i = 0; i < base.Slices; i++)
		{
			array[num] = _vertices[i + base.Slices];
			array2[num] = Normals[i];
			num++;
			array[num] = _vertices[i];
			array2[num] = Normals[i];
			num++;
			if (i + 1 + base.Slices < base.Slices * 2)
			{
				array[num] = _vertices[i + 1 + base.Slices];
				array2[num] = Normals[i + 1];
			}
			else
			{
				array[num] = _vertices[base.Slices];
				array2[num] = Normals[0];
			}
			num++;
			if (i + 1 < base.Slices)
			{
				array[num] = _vertices[i + 1];
				array2[num] = Normals[i + 1];
			}
			else
			{
				array[num] = _vertices[0];
				array2[num] = Normals[0];
			}
			num++;
		}
		context.DrawQuadStrip(array, array2);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new ConicalBarSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Normals != null)
		{
			return Normals.Length != 0;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963797), _topRadius);
	}
}
