using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamC : MaterialBeamI
{
	public MaterialBeamC(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double flange, double web)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, flange, web)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamC(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double flange, double web)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, flange, web)
	{
	}

	public MaterialBeamC(Material mat, double width, double height, double flange, double web)
		: base(mat, width, height, flange, web)
	{
	}

	protected MaterialBeamC(MaterialBeamC another)
		: base(another)
	{
	}

	protected MaterialBeamC(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal override void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double[] _0023_003DzBlBnvuA_003D)
	{
		double num = _0023_003DzBlBnvuA_003D[0];
		double num2 = _0023_003DzBlBnvuA_003D[1];
		double num3 = _0023_003DzBlBnvuA_003D[2];
		double num4 = _0023_003DzBlBnvuA_003D[3];
		double num5 = num2 - 2.0 * num3;
		double num6 = num;
		base.SectionArea = 2.0 * num6 * num3 + num5 * num4;
		double num7 = num6 * num6;
		double num8 = num4 * num4;
		double num9 = (2.0 * num3 * num7 / 2.0 + num8 * num5 / 2.0) / base.SectionArea;
		double num10 = num7 * num6;
		double num11 = num5 * num5 * num5;
		double num12 = num8 * num4;
		double num13 = num3 * num3 * num3;
		base.Iv = num11 * num4 / 12.0 + 2.0 * (num13 * num6 / 12.0 + num3 * num6 * (num5 + num3) * (num5 + num3) / 4.0);
		base.Iw = num12 * num5 / 12.0 + num4 * num5 * (num9 - num4 / 2.0) * (num9 - num4 / 2.0) + 2.0 * num10 * num3 / 12.0 + 2.0 * num6 * num3 * (num9 - num6 / 2.0) * (num9 - num6 / 2.0);
		double val = Math.Max(num - num9, num9);
		base._0023_003DzTrLVFlqX2Sem = Math.Max(val, num2 / 2.0);
	}

	public override object Clone()
	{
		return new MaterialBeamC(this);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamCSurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		MaterialBeamC materialBeamC = (MaterialBeamC)el.Material;
		double flange = materialBeamC.Flange;
		double num = materialBeamC.Height - 2.0 * flange;
		double width = materialBeamC.Width;
		double web = materialBeamC.Web;
		double num2 = 2.0 * width * flange + num * web;
		double num3 = width * width;
		double num4 = web * web;
		double num5 = (2.0 * flange * num3 / 2.0 + num4 * num / 2.0) / num2;
		double num6 = materialBeamC.Height / 2.0;
		Point3D[] array = new Point3D[8];
		Point3D point3D = no1 - v * num5;
		array[0] = point3D - w * num6;
		array[1] = array[0] + v * width;
		array[6] = array[1] + w * materialBeamC.Height;
		array[7] = array[6] - v * width;
		array[3] = array[0] + v * web + w * flange;
		array[4] = array[7] + v * web - w * flange;
		array[2] = array[1] + w * flange;
		array[5] = array[6] - w * flange;
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
		Point3D point3D3 = (Point3D)beamVerts[6].Clone();
		Point3D point3D4 = (Point3D)beamVerts[7].Clone();
		Point3D point3D5 = (Point3D)beamVerts[3].Clone();
		Point3D point3D6 = (Point3D)beamVerts[4].Clone();
		Point3D point3D7 = (Point3D)beamVerts[2].Clone();
		Point3D point3D8 = (Point3D)beamVerts[5].Clone();
		if (al != null)
		{
			point3D.TransformBy(al);
			point3D2.TransformBy(al);
			point3D3.TransformBy(al);
			point3D4.TransformBy(al);
			point3D5.TransformBy(al);
			point3D7.TransformBy(al);
			point3D8.TransformBy(al);
			point3D6.TransformBy(al);
		}
		if (drawStartSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 18, min, max, plotValue0, colors, texCoords);
			}
			Vector3D item = -1.0 * uNew;
			for (int i = 0; i < 18; i++)
			{
				normals.Add(item);
			}
			pts.Add(point3D6);
			pts.Add(point3D5);
			pts.Add(point3D);
			pts.Add(point3D);
			pts.Add(point3D4);
			pts.Add(point3D6);
			pts.Add(point3D);
			pts.Add(point3D5);
			pts.Add(point3D2);
			pts.Add(point3D2);
			pts.Add(point3D5);
			pts.Add(point3D7);
			pts.Add(point3D4);
			pts.Add(point3D3);
			pts.Add(point3D6);
			pts.Add(point3D3);
			pts.Add(point3D8);
			pts.Add(point3D6);
		}
		Vector3D vector3D2 = uNew * beamLen;
		Point3D point3D9 = point3D2 + vector3D2;
		Point3D point3D10 = point3D3 + vector3D2;
		Point3D point3D11 = point3D + vector3D2;
		Point3D point3D12 = point3D4 + vector3D2;
		Point3D point3D13 = point3D5 + vector3D2;
		Point3D point3D14 = point3D7 + vector3D2;
		Point3D point3D15 = point3D8 + vector3D2;
		Point3D point3D16 = point3D6 + vector3D2;
		if (drawEndSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 18, min, max, plotValue1, colors, texCoords);
			}
			for (int j = 0; j < 18; j++)
			{
				normals.Add(uNew);
			}
			pts.AddRange(new Point3D[18]
			{
				point3D16, point3D11, point3D13, point3D11, point3D16, point3D12, point3D11, point3D9, point3D13, point3D9,
				point3D14, point3D13, point3D12, point3D16, point3D10, point3D10, point3D16, point3D15
			});
		}
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D10, point3D15, point3D3, point3D8, point3D3, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D12, point3D10, point3D4, point3D3, point3D4, point3D10 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D15, point3D16, point3D6, point3D6, point3D8, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D11, point3D12, point3D4, point3D4, point3D, point3D11 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D16, point3D13, point3D6, point3D5, point3D6, point3D13 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D14, point3D9, point3D7, point3D2, point3D7, point3D9 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D13, point3D14, point3D7, point3D7, point3D5, point3D13 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D9, point3D11, point3D2, point3D, point3D2, point3D11 }, withColors);
	}
}
