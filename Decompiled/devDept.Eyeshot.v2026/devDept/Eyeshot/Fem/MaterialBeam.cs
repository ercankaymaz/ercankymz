using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeam : Material
{
	[CompilerGenerated]
	private double _003CMaxHalfSection_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static int _0023_003Dz5KguOoA_003D = 1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double SectionArea { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double Iv { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double Iw { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double TorsionK { get; set; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal double _0023_003DzTrLVFlqX2Sem
	{
		get
		{
			return _003CMaxHalfSection_003Ek__BackingField;
		}
		set
		{
			_003CMaxHalfSection_003Ek__BackingField = value;
		}
	}

	public MaterialBeam(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double beamSectionArea, double beamIv, double beamIw, double beamTorsionK)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp)
	{
		SectionArea = beamSectionArea;
		Iv = beamIv;
		Iw = beamIw;
		TorsionK = beamTorsionK;
		_0023_003DzTrLVFlqX2Sem = Math.Sqrt(beamSectionArea) / 2.0;
	}

	public MaterialBeam(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double beamSectionArea, double beamIw)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp)
	{
		SectionArea = beamSectionArea;
		Iw = beamIw;
		_0023_003DzTrLVFlqX2Sem = Math.Sqrt(beamSectionArea) / 2.0;
	}

	public MaterialBeam(Material material, double beamSectionArea, double beamIv, double beamIw, double beamTorsionK)
		: base(material.Name, material.Diffuse, material.Young, material.Poisson, material.YieldStrength, material.Density, material.CoeffOfThermalExp)
	{
		SectionArea = beamSectionArea;
		Iv = beamIv;
		Iw = beamIw;
		TorsionK = beamTorsionK;
		_0023_003DzTrLVFlqX2Sem = Math.Sqrt(beamSectionArea) / 2.0;
	}

	public MaterialBeam(Material material, double beamSectionArea, double beamIw)
		: base(material.Name, material.Diffuse, material.Young, material.Poisson, material.YieldStrength, material.Density, material.CoeffOfThermalExp)
	{
		SectionArea = beamSectionArea;
		Iw = beamIw;
		_0023_003DzTrLVFlqX2Sem = Math.Sqrt(beamSectionArea) / 2.0;
	}

	protected MaterialBeam(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp)
	{
	}

	protected MaterialBeam(MaterialBeam another)
		: base((Material)another)
	{
		SectionArea = another.SectionArea;
		Iv = another.Iv;
		Iw = another.Iw;
		TorsionK = another.TorsionK;
		_0023_003DzTrLVFlqX2Sem = another._0023_003DzTrLVFlqX2Sem;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeam(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double beamSectionArea, double beamIv, double beamIw, double beamTorsionK)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), _0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, beamSectionArea, beamIv, beamIw, beamTorsionK)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeam(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double beamSectionArea, double beamIw)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), _0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, beamSectionArea, beamIw)
	{
	}

	protected MaterialBeam(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		SectionArea = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984781));
		Iv = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984767));
		Iw = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984746));
		TorsionK = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984721));
		_0023_003DzTrLVFlqX2Sem = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984706));
	}

	public override object Clone()
	{
		return new MaterialBeam(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984781), SectionArea);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984767), Iv);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984746), Iw);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984721), TorsionK);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984706), _0023_003DzTrLVFlqX2Sem);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamSurrogate(this);
	}

	public virtual void ComputeBeamVertices(Element el, Vector3D v, Vector3D w, Node no1, double deviation)
	{
		double num = Math.Sqrt(((MaterialBeam)el.Material).SectionArea);
		double num2 = num / 2.0;
		Point3D[] array = new Point3D[4];
		Point3D point3D = no1 - v * num2;
		array[0] = point3D - w * num2;
		array[1] = array[0] + v * num;
		array[2] = array[1] + w * num;
		array[3] = array[2] - v * num;
		if (el is Beam)
		{
			((Beam)el).beamVerts = array;
		}
		else
		{
			((Beam2D)el).beamVerts = array;
		}
	}

	public virtual void DrawBeam(RenderContextBase context, Point3D[] beamVerts, Point3D no1New, Vector3D wNew, double beamLen, Vector3D uNew, Transformation al, double min, double max, double plotValue0, double plotValue1, bool solved, Color[] colorTable, bool drawStartSection, bool drawEndSection, List<Point3D> pts, List<Vector3D> normals, List<Color> colors, List<float> texCoords, bool withColors)
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
		if (drawStartSection)
		{
			AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * uNew, new Point3D[6] { point3D, point3D3, point3D2, point3D, point3D4, point3D3 }, withColors);
		}
		Point3D point3D5 = point3D + uNew * beamLen;
		Point3D point3D6 = point3D2 + uNew * beamLen;
		Point3D point3D7 = point3D3 + uNew * beamLen;
		Point3D point3D8 = point3D4 + uNew * beamLen;
		if (drawEndSection)
		{
			AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, uNew, new Point3D[6] { point3D5, point3D6, point3D7, point3D5, point3D7, point3D8 }, withColors);
		}
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, vector3D, new Point3D[6] { point3D7, point3D6, point3D2, point3D2, point3D3, point3D7 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, wNew, new Point3D[6] { point3D8, point3D7, point3D3, point3D3, point3D4, point3D8 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * vector3D, new Point3D[6] { point3D5, point3D8, point3D, point3D4, point3D, point3D8 }, withColors);
		AddFaceData(min, max, plotValue0, plotValue1, solved, colorTable, pts, normals, colors, texCoords, -1.0 * wNew, new Point3D[6] { point3D6, point3D5, point3D, point3D, point3D2, point3D6 }, withColors);
	}

	protected void AddFaceData(double min, double max, double plotValue0, double plotValue1, bool solved, Color[] colorTable, List<Point3D> pts, List<Vector3D> normals, List<Color> colors, List<float> texCoords, Vector3D normal, Point3D[] triangleVertices, bool withColors)
	{
		normals.AddRange(new Vector3D[6] { normal, normal, normal, normal, normal, normal });
		pts.AddRange(triangleVertices);
		if (withColors)
		{
			_0023_003DzLepolz9HC2MvTfWolvtZDJw_003D(solved, min, max, plotValue1, plotValue0, colors, texCoords);
		}
	}

	internal void _0023_003DzLepolz9HC2MvTfWolvtZDJw_003D(bool _0023_003DzpXqcGaz7sKJt, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003Dz8cTkCe0_003D, double _0023_003Dz84KsKCc_003D, List<Color> _0023_003DzZQ2HyLn4R0pl, List<float> _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D)
	{
		if (_0023_003DzpXqcGaz7sKJt)
		{
			float item = Utility._0023_003DzbV1eOjg_003D(_0023_003Dz8cTkCe0_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			float item2 = Utility._0023_003DzbV1eOjg_003D(_0023_003Dz84KsKCc_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item);
			_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item);
			_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item2);
			_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item2);
			_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item2);
			_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item);
		}
		else
		{
			_0023_003Dzwil_4tM_003D(6, base.Diffuse, _0023_003DzZQ2HyLn4R0pl);
		}
	}

	private static void _0023_003Dzwil_4tM_003D(int _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D, Color _0023_003Dz1MMYB1g_003D, List<Color> _0023_003DzZQ2HyLn4R0pl)
	{
		for (int i = 0; i < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; i++)
		{
			_0023_003DzZQ2HyLn4R0pl.Add(_0023_003Dz1MMYB1g_003D);
		}
	}

	internal void _0023_003Dzzis3pwQ_003D(bool _0023_003DzpXqcGaz7sKJt, int _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003Dzk89lWgt0TAin, List<Color> _0023_003DzZQ2HyLn4R0pl, List<float> _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D)
	{
		if (_0023_003DzpXqcGaz7sKJt)
		{
			float item = Utility._0023_003DzbV1eOjg_003D(_0023_003Dzk89lWgt0TAin, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			for (int i = 0; i < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; i++)
			{
				_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(item);
			}
		}
		else
		{
			_0023_003Dzwil_4tM_003D(_0023_003DzcuodTXZMEy5xbKmohQ_003D_003D, base.Diffuse, _0023_003DzZQ2HyLn4R0pl);
		}
	}
}
