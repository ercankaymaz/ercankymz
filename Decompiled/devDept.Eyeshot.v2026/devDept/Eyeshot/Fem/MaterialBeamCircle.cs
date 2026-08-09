using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamCircle : MaterialBeam
{
	public double Radius;

	internal MaterialBeamCircle(string _0023_003DzS_00246o7tc_003D, Color _0023_003DzAin4TLD5K0aX, double _0023_003DzXwofP_4n6Lm0, double _0023_003Dzhbqvb2ebra9h, double _0023_003DzK0GapdI_003D, double _0023_003DzWT1C51duPPDt, double _0023_003DzpxN6oMLFeo5cgeUIgu_0024hoiw_003D, params double[] _0023_003DzBlBnvuA_003D)
		: base(_0023_003DzS_00246o7tc_003D, _0023_003DzAin4TLD5K0aX, _0023_003DzXwofP_4n6Lm0, _0023_003Dzhbqvb2ebra9h, _0023_003DzK0GapdI_003D, _0023_003DzWT1C51duPPDt, _0023_003DzpxN6oMLFeo5cgeUIgu_0024hoiw_003D)
	{
		Radius = _0023_003DzBlBnvuA_003D[0];
		_0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(_0023_003DzBlBnvuA_003D);
	}

	public MaterialBeamCircle(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double radius)
		: this(name, diffuse, young, poisson, yield, density, coeffOfThermExp, new double[1] { radius })
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamCircle(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double radius)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, radius)
	{
	}

	internal MaterialBeamCircle(Material _0023_003DzKPUTl6c_003D, params double[] _0023_003DzBlBnvuA_003D)
		: base(_0023_003DzKPUTl6c_003D.Name, _0023_003DzKPUTl6c_003D.Diffuse, _0023_003DzKPUTl6c_003D.Young, _0023_003DzKPUTl6c_003D.Poisson, _0023_003DzKPUTl6c_003D.YieldStrength, _0023_003DzKPUTl6c_003D.Density, _0023_003DzKPUTl6c_003D.CoeffOfThermalExp)
	{
		Radius = _0023_003DzBlBnvuA_003D[0];
		_0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(_0023_003DzBlBnvuA_003D);
	}

	public MaterialBeamCircle(Material mat, double radius)
		: this(mat, new double[1] { radius })
	{
	}

	protected MaterialBeamCircle(MaterialBeamCircle another)
		: base(another)
	{
		Radius = another.Radius;
	}

	protected MaterialBeamCircle(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
	}

	internal virtual void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double[] _0023_003DzBlBnvuA_003D)
	{
		double num = _0023_003DzBlBnvuA_003D[0];
		double num2 = num * num;
		double num3 = num2 * num2;
		double num4 = Math.PI;
		base.SectionArea = num4 * num2;
		double iv = (base.Iw = num4 * num3 / 4.0);
		base.Iv = iv;
		base.TorsionK = num4 * num3 / 2.0;
		base._0023_003DzTrLVFlqX2Sem = num;
	}

	public override object Clone()
	{
		return new MaterialBeamCircle(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), Radius);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamCircleSurrogate(this);
	}

	public override void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		double radius = ((MaterialBeamCircle)el.Material).Radius;
		int num = Utility.NumberOfSegments(radius, Math.PI / 2.0, deviation);
		if (num < 3)
		{
			num = 3;
		}
		int num2 = num * 4;
		Plane plane = new Plane(no1, v, w);
		double num3 = Math.PI * 2.0 / (double)num2;
		Point3D[] array = new Point3D[num2 + 1];
		for (int i = 0; i < num2 + 1; i++)
		{
			double num4 = (double)i * num3;
			double num5 = Math.Cos(num4);
			double num6 = Math.Sin(num4);
			array[i] = plane.PointAt(new Point2D(num5 * radius, num6 * radius));
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
		Point3D[] array = new Point3D[beamVerts.Length];
		Point3D[] array2 = new Point3D[beamVerts.Length];
		for (int i = 0; i < beamVerts.Length; i++)
		{
			array[i] = (Point3D)beamVerts[i].Clone();
			if (al != null)
			{
				array[i].TransformBy(al);
			}
			array2[i] = array[i] + vector3D;
		}
		if (withColors)
		{
			context.SetColorWireframe(base.Diffuse);
		}
		if (drawStartSection)
		{
			int num = array.Length - 1;
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, num * 3, min, max, plotValue0, colors, texCoords);
			}
			Vector3D vector3D2 = -1.0 * uNew;
			for (int j = 0; j < num; j++)
			{
				Point3D point3D = array[j];
				Point3D point3D2 = array[j + 1];
				normals.AddRange(new Vector3D[3] { vector3D2, vector3D2, vector3D2 });
				pts.AddRange(new Point3D[3] { point3D2, point3D, no1New });
			}
		}
		if (drawEndSection)
		{
			int num2 = array.Length - 1;
			if (withColors)
			{
				_0023_003Dzzis3pwQ_003D(solved, num2 * 3, min, max, plotValue1, colors, texCoords);
			}
			for (int k = 0; k < array2.Length - 1; k++)
			{
				Point3D point3D3 = array2[k];
				Point3D point3D4 = array2[k + 1];
				normals.AddRange(new Vector3D[3] { uNew, uNew, uNew });
				pts.AddRange(new Point3D[3]
				{
					point3D3,
					point3D4,
					no1New + vector3D
				});
			}
		}
		for (int l = 0; l < array.Length - 1; l++)
		{
			Point3D point3D5 = array[l];
			Point3D point3D6 = array[l + 1];
			Point3D point3D7 = array2[l];
			Point3D point3D8 = array2[l + 1];
			Vector3D vector3D3 = new Vector3D(no1New, point3D5);
			Vector3D vector3D4 = new Vector3D(no1New, point3D6);
			Vector3D vector3D5 = new Vector3D(no1New + vector3D, point3D7);
			Vector3D vector3D6 = new Vector3D(no1New + vector3D, point3D8);
			vector3D3.Normalize();
			vector3D4.Normalize();
			vector3D5.Normalize();
			vector3D6.Normalize();
			normals.AddRange(new Vector3D[6] { vector3D3, vector3D4, vector3D5, vector3D6, vector3D5, vector3D4 });
			if (withColors)
			{
				_0023_003DzLepolz9HC2MvTfWolvtZDJw_003D(solved, min, max, plotValue0, plotValue1, colors, texCoords);
			}
			pts.AddRange(new Point3D[6] { point3D5, point3D6, point3D7, point3D8, point3D7, point3D6 });
		}
	}
}
