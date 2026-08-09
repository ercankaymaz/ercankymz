using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class LinearEntity : Entity, IMateable
{
	private double _symbolSize = 1.0;

	private Point3D _position;

	private Vector3D _direction;

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

	public Point3D Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Vector3D Direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = (Vector3D)value.Clone();
			_direction.Normalize();
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public LinearEntity(double x, double y, double z, double i, double j, double k, double symbolSize)
		: base(entityNatureType.Wire)
	{
		_position = new Point3D(x, y, z);
		_direction = new Vector3D(i, j, k);
		_direction.Normalize();
		_symbolSize = symbolSize;
	}

	public LinearEntity(Point3D position, Vector3D direction, double symbolSize)
		: base(entityNatureType.Wire)
	{
		_position = position;
		_direction = (Vector3D)direction.Clone();
		_direction.Normalize();
		_symbolSize = symbolSize;
	}

	protected LinearEntity(LinearEntity another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_position = (Point3D)another._position.Clone();
		_direction = (Vector3D)another._direction.Clone();
		_symbolSize = another._symbolSize;
	}

	protected internal LinearEntity(LinearEntitySurrogate surrogate)
		: this(surrogate.Position, surrogate.Direction, surrogate.SymbolSize)
	{
		_0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D();
	}

	protected LinearEntity(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_position = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953933), typeof(Point3D));
		_direction = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953730), typeof(Vector3D));
		_symbolSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971858));
	}

	public override object Clone()
	{
		return new LinearEntity(this);
	}

	public override object CloneWithTessellation()
	{
		return new LinearEntity(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Regen(RegenParams data)
	{
		_0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D();
		base.Regen(data);
	}

	internal void _0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D()
	{
		_vertices = new Point3D[2]
		{
			(Point3D)_position.Clone(),
			_0023_003DzA3LanHchFjw4()
		};
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2]
			{
				_position,
				_0023_003DzA3LanHchFjw4()
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		Point3D[] array = EstimateBoundingBox(null, null);
		verticesCoords = new float[6]
		{
			(float)array[0].X,
			(float)array[0].Y,
			(float)array[0].Z,
			(float)array[1].X,
			(float)array[1].Y,
			(float)array[1].Z
		};
		return true;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971148) + _position);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971844) + _direction);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new LinearEntitySurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953933), _position);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953730), _direction);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971858), _symbolSize);
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		if (!Direction.IsZero)
		{
			Utility.DrawArrowOnView(data, _direction, _0023_003DzA3LanHchFjw4());
		}
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	protected internal override void Draw(DrawParams data)
	{
		data.RenderContext.SetLineStipple(4, 32742, null);
		data.RenderContext.EnableLineStipple(enable: true);
		data.RenderContext.DrawBufferedLine(_vertices[0], _vertices[1]);
		data.RenderContext.EnableLineStipple(enable: false);
	}

	public override void TransformBy(Transformation xform)
	{
		_position.TransformBy(xform);
		_direction.TransformBy(xform);
		_direction.Normalize();
		base.TransformBy(xform);
	}

	private Point3D _0023_003DzA3LanHchFjw4()
	{
		return _position + _direction * _symbolSize;
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromICurve(new Line(Position, Position + Direction), parents);
	}
}
