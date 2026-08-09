using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamT : MaterialBeamI
{
	public MaterialBeamT(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double flange, double web)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, flange, web)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamT(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double flange, double web)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, flange, web)
	{
	}

	public MaterialBeamT(Material mat, double width, double height, double flange, double web)
		: base(mat, width, height, flange, web)
	{
	}

	protected MaterialBeamT(MaterialBeamT another)
		: base(another)
	{
	}

	protected MaterialBeamT(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal override void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double[] _0023_003DzBlBnvuA_003D)
	{
		double num = _0023_003DzBlBnvuA_003D[0];
		double num2 = _0023_003DzBlBnvuA_003D[1];
		double num3 = _0023_003DzBlBnvuA_003D[2];
		double num4 = _0023_003DzBlBnvuA_003D[3];
		double num5 = num2 - num3;
		double num6 = num;
		base.SectionArea = num6 * num3 + num5 * num4;
		double num7 = num5 * num5;
		double num8 = num3 / 2.0;
		double num9 = ((num5 + num8) * num3 * num6 + num7 * num4 / 2.0) / base.SectionArea;
		double num10 = num6 * num6 * num6;
		double num11 = num7 * num5;
		double num12 = num4 * num4 * num4;
		double num13 = num3 * num3 * num3;
		base.Iv = (num12 * num5 - 2.0 * num10 * num3) / 12.0;
		base.Iw = num11 * num4 / 12.0 + num13 * num6 / 12.0 + num3 * num6 * (num5 + num8 - num9) * (num5 + num8 - num9) + num4 * num5 * (num9 - num5 / 2.0) * (num9 - num5 / 2.0);
		double val = Math.Max(num2 - num9, num9);
		base._0023_003DzTrLVFlqX2Sem = Math.Max(val, num / 2.0);
	}

	public override object Clone()
	{
		return new MaterialBeamT(this);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamTSurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		MaterialBeamT materialBeamT = (MaterialBeamT)el.Material;
		double flange = materialBeamT.Flange;
		double num = materialBeamT.Height - flange;
		double width = materialBeamT.Width;
		double num2 = num * num;
		double num3 = width * flange + num * materialBeamT.Web;
		double num4 = flange / 2.0;
		double num5 = materialBeamT.Web / 2.0;
		double num6 = width / 2.0;
		double num7 = ((num + num4) * flange * width + num2 * num5) / num3;
		Point3D[] array = new Point3D[8];
		Point3D point3D = no1 - v * num7;
		Point3D point3D2 = point3D - w * num6;
		array[0] = point3D2 + v * materialBeamT.Height;
		array[1] = array[0] + w * width;
		array[7] = array[0] - v * flange;
		array[2] = array[1] - v * flange;
		array[5] = point3D - w * num5;
		array[4] = point3D + w * num5;
		array[6] = array[5] + v * num;
		array[3] = array[4] + v * num;
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
		Point3D point3D3 = (Point3D)beamVerts[7].Clone();
		Point3D point3D4 = (Point3D)beamVerts[2].Clone();
		Point3D point3D5 = (Point3D)beamVerts[5].Clone();
		Point3D point3D6 = (Point3D)beamVerts[4].Clone();
		Point3D point3D7 = (Point3D)beamVerts[6].Clone();
		Point3D point3D8 = (Point3D)beamVerts[3].Clone();
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
		if (withColors)
		{
			context.SetColorWireframe(base.Diffuse);
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
			pts.AddRange(new Point3D[18]
			{
				point3D5, point3D6, point3D8, point3D5, point3D8, point3D7, point3D, point3D3, point3D7, point3D,
				point3D7, point3D8, point3D, point3D8, point3D4, point3D, point3D4, point3D2
			});
		}
		Vector3D vector3D2 = uNew * beamLen;
		Point3D point3D9 = point3D + vector3D2;
		Point3D point3D10 = point3D2 + vector3D2;
		Point3D point3D11 = point3D3 + vector3D2;
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
			Vector3D item = uNew;
			for (int j = 0; j < 18; j++)
			{
				normals.Add(item);
			}
			pts.AddRange(new Point3D[18]
			{
				point3D13, point3D15, point3D16, point3D13, point3D14, point3D15, point3D9, point3D14, point3D11, point3D9,
				point3D15, point3D14, point3D9, point3D12, point3D15, point3D9, point3D10, point3D12
			});
		}
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D10, point3D9, point3D, point3D, point3D2, point3D10 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D16, point3D15, point3D6, point3D8, point3D6, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D14, point3D13, point3D5, point3D5, point3D7, point3D14 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D15, point3D12, point3D4, point3D4, point3D8, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D12, point3D10, point3D4, point3D2, point3D4, point3D10 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D9, point3D11, point3D3, point3D3, point3D, point3D9 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D11, point3D14, point3D3, point3D7, point3D3, point3D14 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D13, point3D16, point3D5, point3D6, point3D5, point3D16 }, withColors);
	}
}
