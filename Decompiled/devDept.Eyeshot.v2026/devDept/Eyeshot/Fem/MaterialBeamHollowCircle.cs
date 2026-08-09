using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamHollowCircle : MaterialBeamCircle
{
	public double InnerRadius;

	public MaterialBeamHollowCircle(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double radius, double thickness)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp, radius, radius - thickness)
	{
		InnerRadius = radius - thickness;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamHollowCircle(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double radius, double thickness)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, radius, thickness)
	{
	}

	public MaterialBeamHollowCircle(Material mat, double radius, double innerRadius)
		: base(mat, radius, innerRadius)
	{
		InnerRadius = innerRadius;
	}

	protected MaterialBeamHollowCircle(MaterialBeamHollowCircle another)
		: base(another)
	{
		InnerRadius = another.InnerRadius;
	}

	protected MaterialBeamHollowCircle(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		InnerRadius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984949));
	}

	internal override void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double[] _0023_003DzBlBnvuA_003D)
	{
		double num = _0023_003DzBlBnvuA_003D[0];
		double num2 = _0023_003DzBlBnvuA_003D[1];
		double num3 = num * num;
		double num4 = num3 * num3;
		double num5 = num2 * num2;
		double num6 = num5 * num5;
		double num7 = Math.PI;
		base.SectionArea = num7 * num3;
		double iv = (base.Iw = num7 * (num4 - num6) / 4.0);
		base.Iv = iv;
		base.TorsionK = num7 * (num4 - num6) / 2.0;
		base._0023_003DzTrLVFlqX2Sem = num;
	}

	public override object Clone()
	{
		return new MaterialBeamHollowCircle(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984949), InnerRadius);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamHollowCircleSurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		MaterialBeamHollowCircle obj = (MaterialBeamHollowCircle)el.Material;
		double radius = obj.Radius;
		double innerRadius = obj.InnerRadius;
		int num = Utility.NumberOfSegments(radius, Math.PI / 2.0, deviation);
		if (num < 3)
		{
			num = 3;
		}
		int num2 = num * 4;
		Plane plane = new Plane(no1, v, w);
		double num3 = Math.PI * 2.0 / (double)num2;
		Point3D[] array = new Point3D[(num2 + 1) * 2];
		for (int i = 0; i < num2 + 1; i++)
		{
			double num4 = (double)i * num3;
			double num5 = Math.Cos(num4);
			double num6 = Math.Sin(num4);
			array[i] = plane.PointAt(new Point2D(num5 * radius, num6 * radius));
			array[i + num2 + 1] = plane.PointAt(new Point2D(num5 * innerRadius, num6 * innerRadius));
		}
		if (el is Beam)
		{
			((Beam)el).beamVerts = array;
		}
		else
		{
			((Beam2D)el).beamVerts = array;
		}
	}

	public override void DrawBeam(RenderContextBase context, Point3D[] beamVerts, Point3D no1New, Vector3D wNew, double beamLen, Vector3D uNew, Transformation al, double min, double max, double plotValue0, double plotValue1, bool solved, Color[] colorTable, bool drawStartSection, bool drawEndSection, List<Point3D> pts, List<Vector3D> normals, List<Color> colors, List<float> texCoords, bool withColors)
	{
		Vector3D vector3D = uNew * beamLen;
		int num = beamVerts.Length / 2;
		Point3D[] array = new Point3D[num];
		Point3D[] array2 = new Point3D[num];
		Point3D[] array3 = new Point3D[num];
		Point3D[] array4 = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (Point3D)beamVerts[i].Clone();
			if (al != null)
			{
				array[i].TransformBy(al);
			}
			array2[i] = array[i] + vector3D;
			array3[i] = (Point3D)beamVerts[i + num].Clone();
			if (al != null)
			{
				array3[i].TransformBy(al);
			}
			array4[i] = array3[i] + vector3D;
		}
		array[num - 1] = (Point3D)array[0].Clone();
		array2[num - 1] = (Point3D)array2[0].Clone();
		array3[num - 1] = (Point3D)array3[0].Clone();
		array4[num - 1] = (Point3D)array4[0].Clone();
		if (withColors)
		{
			context.SetColorWireframe(base.Diffuse);
		}
		if (drawStartSection)
		{
			int num2 = array.Length - 1;
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, num2 * 6, min, max, plotValue0, colors, texCoords);
			}
			Vector3D vector3D2 = -1.0 * uNew;
			for (int j = 0; j < num2; j++)
			{
				Point3D point3D = array[j];
				Point3D point3D2 = array[j + 1];
				Point3D point3D3 = array3[j];
				Point3D point3D4 = array3[j + 1];
				normals.AddRange(new Vector3D[6] { vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2 });
				pts.AddRange(new Point3D[6] { point3D2, point3D, point3D3, point3D2, point3D3, point3D4 });
			}
		}
		if (drawEndSection)
		{
			int num3 = array2.Length - 1;
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, num3 * 6, min, max, plotValue1, colors, texCoords);
			}
			for (int k = 0; k < num3; k++)
			{
				Point3D point3D5 = array2[k];
				Point3D point3D6 = array2[k + 1];
				Point3D point3D7 = array4[k];
				Point3D point3D8 = array4[k + 1];
				normals.AddRange(new Vector3D[6] { uNew, uNew, uNew, uNew, uNew, uNew });
				pts.AddRange(new Point3D[6] { point3D6, point3D7, point3D5, point3D6, point3D8, point3D7 });
			}
		}
		for (int l = 0; l < array.Length - 1; l++)
		{
			Point3D point3D9 = array[l];
			Point3D point3D10 = array[l + 1];
			Point3D point3D11 = array3[l];
			Point3D point3D12 = array3[l + 1];
			Point3D point3D13 = array2[l];
			Point3D point3D14 = array2[l + 1];
			Point3D point3D15 = array4[l];
			Point3D point3D16 = array4[l + 1];
			Vector3D vector3D3 = new Vector3D(no1New, point3D9);
			Vector3D vector3D4 = new Vector3D(no1New, point3D10);
			Vector3D vector3D5 = new Vector3D(no1New + vector3D, point3D13);
			Vector3D vector3D6 = new Vector3D(no1New + vector3D, point3D14);
			vector3D3.Normalize();
			vector3D4.Normalize();
			vector3D5.Normalize();
			vector3D6.Normalize();
			Vector3D vector3D7 = (Vector3D)vector3D3.Clone() * -1.0;
			Vector3D vector3D8 = (Vector3D)vector3D4.Clone() * -1.0;
			Vector3D vector3D9 = (Vector3D)vector3D5.Clone() * -1.0;
			Vector3D vector3D10 = (Vector3D)vector3D6.Clone() * -1.0;
			normals.AddRange(new Vector3D[6] { vector3D3, vector3D4, vector3D5, vector3D6, vector3D5, vector3D4 });
			if (withColors)
			{
				_0023_003DzLepolz9HC2MvTfWolvtZDJw_003D(solved, min, max, plotValue0, plotValue1, colors, texCoords);
			}
			pts.AddRange(new Point3D[6] { point3D9, point3D10, point3D13, point3D14, point3D13, point3D10 });
			normals.AddRange(new Vector3D[6] { vector3D8, vector3D7, vector3D9, vector3D9, vector3D10, vector3D8 });
			if (withColors)
			{
				_0023_003DzLepolz9HC2MvTfWolvtZDJw_003D(solved, min, max, plotValue0, plotValue1, colors, texCoords);
			}
			pts.AddRange(new Point3D[6] { point3D12, point3D11, point3D15, point3D15, point3D16, point3D12 });
		}
	}
}
