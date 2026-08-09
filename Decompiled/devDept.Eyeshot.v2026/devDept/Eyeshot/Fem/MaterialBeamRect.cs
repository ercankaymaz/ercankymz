using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamRect : MaterialBeam
{
	public double Width;

	public double Height;

	internal MaterialBeamRect(string _0023_003DzS_00246o7tc_003D, Color _0023_003DzAin4TLD5K0aX, double _0023_003DzXwofP_4n6Lm0, double _0023_003Dzhbqvb2ebra9h, double _0023_003DzK0GapdI_003D, double _0023_003DzWT1C51duPPDt, double _0023_003DzpxN6oMLFeo5cgeUIgu_0024hoiw_003D, params double[] _0023_003DzBlBnvuA_003D)
		: base(_0023_003DzS_00246o7tc_003D, _0023_003DzAin4TLD5K0aX, _0023_003DzXwofP_4n6Lm0, _0023_003Dzhbqvb2ebra9h, _0023_003DzK0GapdI_003D, _0023_003DzWT1C51duPPDt, _0023_003DzpxN6oMLFeo5cgeUIgu_0024hoiw_003D)
	{
		Width = _0023_003DzBlBnvuA_003D[0];
		Height = _0023_003DzBlBnvuA_003D[1];
		_0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(_0023_003DzBlBnvuA_003D);
	}

	public MaterialBeamRect(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height)
		: this(name, diffuse, young, poisson, yield, density, coeffOfThermExp, new double[2] { width, height })
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamRect(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double width, double height)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, width, height)
	{
	}

	internal MaterialBeamRect(Material _0023_003DzKPUTl6c_003D, params double[] _0023_003DzBlBnvuA_003D)
		: base(_0023_003DzKPUTl6c_003D.Name, _0023_003DzKPUTl6c_003D.Diffuse, _0023_003DzKPUTl6c_003D.Young, _0023_003DzKPUTl6c_003D.Poisson, _0023_003DzKPUTl6c_003D.YieldStrength, _0023_003DzKPUTl6c_003D.Density, _0023_003DzKPUTl6c_003D.CoeffOfThermalExp)
	{
		Width = _0023_003DzBlBnvuA_003D[0];
		Height = _0023_003DzBlBnvuA_003D[1];
		_0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(_0023_003DzBlBnvuA_003D);
	}

	public MaterialBeamRect(Material mat, double width, double height)
		: this(mat.Name, mat.Diffuse, mat.Young, mat.Poisson, mat.YieldStrength, mat.Density, mat.CoeffOfThermalExp, new double[2] { width, height })
	{
	}

	protected MaterialBeamRect(MaterialBeamRect another)
		: base(another)
	{
		Width = another.Width;
		Height = another.Height;
	}

	protected MaterialBeamRect(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Width = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266));
		Height = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246));
	}

	internal virtual void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double[] _0023_003DzBlBnvuA_003D)
	{
		double num = _0023_003DzBlBnvuA_003D[0];
		double num2 = _0023_003DzBlBnvuA_003D[1];
		base.SectionArea = num * num2;
		double num3 = num * num * num;
		double num4 = num2 * num2 * num2;
		base.Iv = num3 * num2 / 12.0;
		base.Iw = num * num4 / 12.0;
		if (num > num2)
		{
			_0023_003DzApD2OvpJj2S340hL7A_003D_003D(num, num2, num4);
			base._0023_003DzTrLVFlqX2Sem = num / 2.0;
		}
		else
		{
			_0023_003DzApD2OvpJj2S340hL7A_003D_003D(num2, num, num3);
			base._0023_003DzTrLVFlqX2Sem = num2 / 2.0;
		}
	}

	private void _0023_003DzApD2OvpJj2S340hL7A_003D_003D(double _0023_003DzvoOpbV3xa9Bt, double _0023_003DzksP39KRNmW9x, double _0023_003Dz1zBDtbs_003D)
	{
		base.TorsionK = _0023_003DzvoOpbV3xa9Bt * _0023_003Dz1zBDtbs_003D * (1.0 / 3.0 - 0.21 * _0023_003DzksP39KRNmW9x / _0023_003DzvoOpbV3xa9Bt * (1.0 - _0023_003Dz1zBDtbs_003D * _0023_003DzksP39KRNmW9x / (12.0 * _0023_003DzvoOpbV3xa9Bt)));
	}

	public override object Clone()
	{
		return new MaterialBeamRect(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266), Width);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246), Height);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamRectSurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		double num = ((MaterialBeamRect)el.Material).Height / 2.0;
		double num2 = ((MaterialBeamRect)el.Material).Width / 2.0;
		Point3D[] array = new Point3D[4];
		Point3D point3D = no1 - v * num;
		array[0] = point3D - w * num2;
		array[1] = array[0] + v * 2.0 * num;
		array[2] = array[1] + w * 2.0 * num2;
		array[3] = array[2] - v * 2.0 * num;
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
		if (al != null)
		{
			point3D.TransformBy(al);
			point3D2.TransformBy(al);
			point3D3.TransformBy(al);
			point3D4.TransformBy(al);
		}
		if (withColors)
		{
			context.SetColorWireframe(base.Diffuse);
		}
		if (drawStartSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 6, min, max, plotValue0, colors, texCoords);
			}
			Vector3D vector3D2 = -1.0 * uNew;
			normals.AddRange(new Vector3D[6] { vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2 });
			pts.AddRange(new Point3D[6] { point3D, point3D3, point3D2, point3D, point3D4, point3D3 });
		}
		Vector3D vector3D3 = uNew * beamLen;
		Point3D point3D5 = point3D + vector3D3;
		Point3D point3D6 = point3D2 + vector3D3;
		Point3D point3D7 = point3D3 + vector3D3;
		Point3D point3D8 = point3D4 + vector3D3;
		if (drawEndSection)
		{
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, 6, min, max, plotValue1, colors, texCoords);
			}
			Vector3D vector3D2 = uNew;
			normals.AddRange(new Vector3D[6] { vector3D2, vector3D2, vector3D2, vector3D2, vector3D2, vector3D2 });
			pts.AddRange(new Point3D[6] { point3D5, point3D6, point3D7, point3D5, point3D7, point3D8 });
		}
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D7, point3D6, point3D2, point3D2, point3D3, point3D7 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D8, point3D7, point3D3, point3D3, point3D4, point3D8 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D5, point3D8, point3D, point3D4, point3D, point3D8 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D6, point3D5, point3D, point3D, point3D2, point3D6 }, withColors);
	}
}
