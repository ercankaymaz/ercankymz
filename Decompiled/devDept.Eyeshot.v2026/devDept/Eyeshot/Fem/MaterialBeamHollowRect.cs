using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamHollowRect : MaterialBeamRect
{
	public double Thickness;

	public MaterialBeamHollowRect(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double thickness)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, thickness)
	{
		Thickness = thickness;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamHollowRect(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double thickness)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, thickness)
	{
	}

	public MaterialBeamHollowRect(Material mat, double width, double height, double thickness)
		: base(mat, width, height, thickness)
	{
		Thickness = thickness;
	}

	protected MaterialBeamHollowRect(MaterialBeamHollowRect another)
		: base(another)
	{
		Thickness = another.Thickness;
	}

	protected MaterialBeamHollowRect(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Thickness = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955685));
	}

	internal override void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double[] _0023_003DzBlBnvuA_003D)
	{
		double num = _0023_003DzBlBnvuA_003D[0];
		double num2 = _0023_003DzBlBnvuA_003D[1];
		double num3 = _0023_003DzBlBnvuA_003D[2];
		double num4 = 2.0 * num3;
		double num5 = num - num4;
		double num6 = num2 - num4;
		base.SectionArea = num * num2 - num5 * num6;
		double num7 = num * num * num;
		double num8 = num2 * num2 * num2;
		double num9 = num5 * num5 * num5;
		double num10 = num6 * num6 * num6;
		base.Iv = num7 * num2 / 12.0 - num9 * num6 / 12.0;
		base.Iw = num * num8 / 12.0 - num5 * num10 / 12.0;
		double num11 = Math.Min(num, num2);
		double num12 = Math.Max(num, num2);
		base._0023_003DzTrLVFlqX2Sem = num12 / 2.0;
		double num13 = num12 - num3;
		double num14 = num13 * num13;
		double num15 = num11 - num3;
		double num16 = num15 * num15;
		base.TorsionK = num4 * num3 * num14 * num16 / (num12 * num3 + num11 * num3 - num4 * num3);
	}

	public override object Clone()
	{
		return new MaterialBeamHollowRect(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955685), Thickness);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamHollowRectSurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		double num = ((MaterialBeamHollowRect)el.Material).Height / 2.0;
		double num2 = ((MaterialBeamHollowRect)el.Material).Width / 2.0;
		double thickness = ((MaterialBeamHollowRect)el.Material).Thickness;
		double num3 = num - thickness;
		double num4 = num2 - thickness;
		Point3D[] array = new Point3D[8];
		Point3D point3D = no1 - v * num;
		array[0] = point3D - w * num2;
		array[1] = array[0] + v * 2.0 * num;
		array[2] = array[1] + w * 2.0 * num2;
		array[3] = array[2] - v * 2.0 * num;
		Point3D point3D2 = no1 - v * num3;
		array[4] = point3D2 - w * num4;
		array[5] = array[4] + v * 2.0 * num3;
		array[6] = array[5] + w * 2.0 * num4;
		array[7] = array[6] - v * 2.0 * num3;
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
		Vector3D vector3D = Vector3D.Cross(wNew, uNew);
		Point3D point3D = (Point3D)beamVerts[0].Clone();
		Point3D point3D2 = (Point3D)beamVerts[1].Clone();
		Point3D point3D3 = (Point3D)beamVerts[2].Clone();
		Point3D point3D4 = (Point3D)beamVerts[3].Clone();
		Point3D point3D5 = (Point3D)beamVerts[4].Clone();
		Point3D point3D6 = (Point3D)beamVerts[5].Clone();
		Point3D point3D7 = (Point3D)beamVerts[6].Clone();
		Point3D point3D8 = (Point3D)beamVerts[7].Clone();
		if (al != null)
		{
			point3D.TransformBy(al);
			point3D2.TransformBy(al);
			point3D3.TransformBy(al);
			point3D4.TransformBy(al);
			point3D5.TransformBy(al);
			point3D6.TransformBy(al);
			point3D7.TransformBy(al);
			point3D8.TransformBy(al);
		}
		if (withColors)
		{
			context.SetColorWireframe(base.Diffuse);
		}
		if (drawStartSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 24, min, max, plotValue0, colors, texCoords);
			}
			Vector3D vector3D2 = -1.0 * uNew;
			normals.AddRange(new Vector3D[24]
			{
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2
			});
			pts.AddRange(new Point3D[24]
			{
				point3D, point3D6, point3D2, point3D, point3D5, point3D6, point3D, point3D8, point3D5, point3D,
				point3D4, point3D8, point3D4, point3D3, point3D8, point3D8, point3D3, point3D7, point3D7, point3D3,
				point3D6, point3D6, point3D3, point3D2
			});
		}
		Vector3D vector3D3 = uNew * beamLen;
		Point3D point3D9 = point3D + vector3D3;
		Point3D point3D10 = point3D2 + vector3D3;
		Point3D point3D11 = point3D3 + vector3D3;
		Point3D point3D12 = point3D4 + vector3D3;
		Point3D point3D13 = point3D5 + vector3D3;
		Point3D point3D14 = point3D6 + vector3D3;
		Point3D point3D15 = point3D7 + vector3D3;
		Point3D point3D16 = point3D8 + vector3D3;
		if (drawEndSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 24, min, max, plotValue1, colors, texCoords);
			}
			Vector3D vector3D2 = uNew;
			normals.AddRange(new Vector3D[24]
			{
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2
			});
			pts.AddRange(new Point3D[24]
			{
				point3D9, point3D10, point3D14, point3D9, point3D14, point3D13, point3D9, point3D13, point3D16, point3D9,
				point3D16, point3D12, point3D12, point3D16, point3D11, point3D16, point3D15, point3D11, point3D15, point3D14,
				point3D11, point3D14, point3D10, point3D11
			});
		}
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D11, point3D10, point3D2, point3D2, point3D3, point3D11 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D12, point3D11, point3D3, point3D3, point3D4, point3D12 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D9, point3D12, point3D, point3D4, point3D, point3D12 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D10, point3D9, point3D, point3D, point3D2, point3D10 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D14, point3D15, point3D6, point3D7, point3D6, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D15, point3D16, point3D7, point3D8, point3D7, point3D16 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D16, point3D13, point3D5, point3D5, point3D8, point3D16 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D13, point3D14, point3D5, point3D6, point3D5, point3D14 }, withColors);
	}
}
