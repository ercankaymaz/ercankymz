using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class PlanarEntity : Entity, IMateable
{
	private Plane _plane;

	private double _symbolSize = 1.0;

	private bool extraLine;

	public Plane Plane
	{
		get
		{
			return _plane;
		}
		set
		{
			_plane = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double SymbolSize
	{
		get
		{
			return _symbolSize;
		}
		set
		{
			_symbolSize = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	protected PlanarEntity()
		: base(entityNatureType.Wire)
	{
		_plane = Plane.XY;
	}

	public PlanarEntity(Plane pln)
		: base(entityNatureType.Wire)
	{
		_plane = pln;
	}

	protected internal PlanarEntity(PlanarEntitySurrogate surrogate)
		: this(surrogate._0023_003DzNY5YUv279_SW(), surrogate.SymbolSize)
	{
	}

	internal PlanarEntity(GPlanarEntity _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Plane)
	{
	}

	protected PlanarEntity(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_plane = (Plane)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), typeof(Plane));
		_symbolSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971858));
	}

	public PlanarEntity(Plane pln, double symbolSize)
		: this(pln)
	{
		_symbolSize = symbolSize;
	}

	protected PlanarEntity(PlanarEntity another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_plane = (Plane)another._plane.Clone();
		_symbolSize = another._symbolSize;
	}

	public override object Clone()
	{
		return new PlanarEntity(this);
	}

	public override object CloneWithTessellation()
	{
		return new PlanarEntity(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void TransformBy(Transformation xform)
	{
		_plane.TransformBy(xform);
		base.TransformBy(xform);
	}

	public virtual Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(amount * _plane.AxisZ, deviation, meshNature);
	}

	public virtual T ExtrudeAsMesh<T>(double amount, double deviation, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(amount * _plane.AxisZ, deviation, meshNature);
	}

	public virtual Solid ExtrudeAsSolid(double amount, double deviation)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount * _plane.AxisZ, deviation);
	}

	public virtual T ExtrudeAsSolid<T>(double amount, double deviation) where T : Solid, new()
	{
		if (this is ICurve)
		{
			return _0023_003DzMMwu2nWS_6dkgi9W6QajAfo_003D<T>(amount * _plane.AxisZ, deviation);
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974825) + GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974807));
	}

	public virtual Surface ExtrudeAsSurface(double amount)
	{
		if (this is ICurve)
		{
			return ((ICurve)this).ExtrudeAsSurface(amount * _plane.AxisZ.X, amount * _plane.AxisZ.Y, amount * _plane.AxisZ.Z)[0];
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974825) + GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974807));
	}

	public virtual Brep ExtrudeAsBrep(double amount, double tolerance = 0.001)
	{
		if (this is ICurve _0023_003Dz_SqBXz8_003D)
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(_0023_003Dz_SqBXz8_003D, null, Plane.AxisZ * amount, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974825) + GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974807));
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, null, materials));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974772) + _plane);
		return stringBuilder.ToString();
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (_plane.IsValid(log))
		{
			return base.IsValid(log);
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new PlanarEntitySurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), _plane);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971858), _symbolSize);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[1] { Plane.Origin };
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromAnalyticSurf(new PlanarSurf(Plane), parents);
	}

	protected virtual void Update(PlanarEntity another)
	{
		_plane = (Plane)another._plane.Clone();
		_symbolSize = another._symbolSize;
		Color = another.Color;
		ColorMethod = another.ColorMethod;
		LayerName = another.LayerName;
		LineTypeMethod = another.LineTypeMethod;
		LineTypeName = another.LineTypeName;
		LineTypeScale = another.LineTypeScale;
		LineWeight = another.LineWeight;
		LineWeightMethod = another.LineWeightMethod;
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	public override void Regen(RegenParams data)
	{
		_vertices = new Point3D[5];
		_vertices[0] = new Point3D(0.0, 0.0, 0.0);
		_vertices[1] = new Point3D(_symbolSize, 0.0, 0.0);
		_vertices[2] = new Point3D(_symbolSize, _symbolSize, 0.0);
		_vertices[3] = new Point3D(0.0, _symbolSize, 0.0);
		_vertices[4] = new Point3D(0.0, 0.0, _symbolSize / 10.0);
		Transformation transformation = new Transformation(Plane.Origin, Plane.AxisX, Plane.AxisY, Plane.AxisZ);
		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] = transformation * _vertices[i];
		}
		base.Regen(data);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		DrawEntity(data.RenderContext, null);
	}

	protected internal override void Draw(DrawParams data)
	{
		base.Draw(data);
		if (data.RenderContext.IsDirect3D && extraLine)
		{
			drawData.DrawBuffer(data.RenderContext, 1);
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		context.DrawLineLoop(_vertices, 0, 4);
		context.DrawLines(new Point3D[2]
		{
			_vertices[0],
			_vertices[4]
		});
		extraLine = true;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D obj = new _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(Plane.Origin, Plane.Equation, (float)_symbolSize, ColorMethod == colorMethodType.byEntity, LayerName, Color);
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}
}
