using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamI : MaterialBeamRect
{
	public double Flange;

	public double Web;

	public MaterialBeamI(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double flange, double web)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, flange, web)
	{
		Flange = flange;
		Web = web;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamI(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height, double flange, double web)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, width, height, flange, web)
	{
	}

	public MaterialBeamI(Material mat, double width, double height, double flange, double web)
		: base(mat, width, height, flange, web)
	{
		Flange = flange;
		Web = web;
	}

	protected MaterialBeamI(MaterialBeamI another)
		: base(another)
	{
		Flange = another.Flange;
		Web = another.Web;
	}

	protected MaterialBeamI(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Flange = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984935));
		Web = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950855));
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
		double num7 = num6 * num6 * num6;
		double num8 = num5 * num5 * num5;
		double num9 = num4 * num4 * num4;
		double num10 = num3 * num3 * num3;
		base.Iv = (num9 * num5 + 2.0 * num7 * num3) / 12.0;
		base.Iw = num8 * num4 / 12.0 + 2.0 * (num10 * num6 / 12.0 + num3 * num6 * (num5 + num3) * (num5 + num3) / 4.0);
		base.TorsionK = (2.0 * num7 * num3 + num9 * num5) / 3.0;
		double _0023_003DzPzO_0024GUk_003D = (base._0023_003DzTrLVFlqX2Sem = Math.Max(num / 2.0, num2 / 2.0));
		base._0023_003DzTrLVFlqX2Sem = _0023_003DzPzO_0024GUk_003D;
	}

	public override object Clone()
	{
		return new MaterialBeamI(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984935), Flange);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950855), Web);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamISurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		MaterialBeamI materialBeamI = (MaterialBeamI)el.Material;
		double num = materialBeamI.Height / 2.0;
		double num2 = materialBeamI.Width / 2.0;
		double num3 = materialBeamI.Height - 2.0 * materialBeamI.Flange;
		double num4 = num3 / 2.0;
		double num5 = materialBeamI.Web / 2.0;
		Point3D[] array = new Point3D[12];
		Point3D point3D = no1 - v * num;
		array[0] = point3D - w * num2;
		array[5] = array[0] + v * 2.0 * num;
		array[6] = array[5] + w * 2.0 * num2;
		array[11] = array[6] - v * 2.0 * num;
		Point3D point3D2 = no1 - v * num4;
		array[1] = point3D2 - w * num2;
		array[4] = array[1] + v * num3;
		array[7] = array[4] + w * 2.0 * num2;
		array[10] = array[7] - v * num3;
		array[2] = point3D2 - w * num5;
		array[3] = array[2] + v * num3;
		array[8] = array[3] + w * 2.0 * num5;
		array[9] = array[8] - v * num3;
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
		Point3D point3D2 = (Point3D)beamVerts[5].Clone();
		Point3D point3D3 = (Point3D)beamVerts[6].Clone();
		Point3D point3D4 = (Point3D)beamVerts[11].Clone();
		Point3D point3D5 = (Point3D)beamVerts[1].Clone();
		Point3D point3D6 = (Point3D)beamVerts[4].Clone();
		Point3D point3D7 = (Point3D)beamVerts[7].Clone();
		Point3D point3D8 = (Point3D)beamVerts[10].Clone();
		Point3D point3D9 = (Point3D)beamVerts[2].Clone();
		Point3D point3D10 = (Point3D)beamVerts[3].Clone();
		Point3D point3D11 = (Point3D)beamVerts[8].Clone();
		Point3D point3D12 = (Point3D)beamVerts[9].Clone();
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
			point3D9.TransformBy(al);
			point3D10.TransformBy(al);
			point3D11.TransformBy(al);
			point3D12.TransformBy(al);
		}
		if (withColors)
		{
			context.SetColorWireframe(base.Diffuse);
		}
		if (drawStartSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 30, min, max, plotValue0, colors, texCoords);
			}
			Vector3D vector3D2 = -1.0 * uNew;
			normals.AddRange(new Vector3D[30]
			{
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2
			});
			pts.AddRange(new Point3D[30]
			{
				point3D, point3D9, point3D5, point3D, point3D12, point3D9, point3D, point3D8, point3D12, point3D,
				point3D4, point3D8, point3D9, point3D12, point3D11, point3D9, point3D11, point3D10, point3D2, point3D6,
				point3D10, point3D2, point3D10, point3D11, point3D2, point3D11, point3D7, point3D2, point3D7, point3D3
			});
		}
		Vector3D vector3D3 = uNew * beamLen;
		Point3D point3D13 = point3D + vector3D3;
		Point3D point3D14 = point3D2 + vector3D3;
		Point3D point3D15 = point3D3 + vector3D3;
		Point3D point3D16 = point3D4 + vector3D3;
		Point3D point3D17 = point3D5 + vector3D3;
		Point3D point3D18 = point3D6 + vector3D3;
		Point3D point3D19 = point3D7 + vector3D3;
		Point3D point3D20 = point3D8 + vector3D3;
		Point3D point3D21 = point3D9 + vector3D3;
		Point3D point3D22 = point3D10 + vector3D3;
		Point3D point3D23 = point3D11 + vector3D3;
		Point3D point3D24 = point3D12 + vector3D3;
		if (drawEndSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 30, min, max, plotValue1, colors, texCoords);
			}
			Vector3D vector3D2 = uNew;
			normals.AddRange(new Vector3D[30]
			{
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2,
				vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2
			});
			pts.AddRange(new Point3D[30]
			{
				point3D13, point3D17, point3D21, point3D13, point3D21, point3D24, point3D13, point3D24, point3D20, point3D13,
				point3D20, point3D16, point3D21, point3D23, point3D24, point3D21, point3D22, point3D23, point3D14, point3D22,
				point3D18, point3D14, point3D23, point3D22, point3D14, point3D19, point3D23, point3D14, point3D15, point3D19
			});
		}
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D15, point3D14, point3D2, point3D2, point3D3, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D16, point3D20, point3D8, point3D8, point3D4, point3D16 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D20, point3D24, point3D8, point3D12, point3D8, point3D24 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D17, point3D13, point3D5, point3D, point3D5, point3D13 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D21, point3D17, point3D5, point3D5, point3D9, point3D21 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D24, point3D23, point3D12, point3D11, point3D12, point3D23 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D22, point3D21, point3D9, point3D9, point3D10, point3D22 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D23, point3D19, point3D7, point3D7, point3D11, point3D23 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D19, point3D15, point3D7, point3D3, point3D7, point3D15 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D14, point3D18, point3D6, point3D6, point3D2, point3D14 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D18, point3D22, point3D6, point3D10, point3D6, point3D22 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D13, point3D16, point3D, point3D4, point3D, point3D16 }, withColors);
	}
}
