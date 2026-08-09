using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Ghost : Entity
{
	public override Point3D[] Vertices
	{
		get
		{
			return base.Vertices;
		}
		set
		{
			_vertices = new Point3D[0];
		}
	}

	public string Description { get; set; }

	public Ghost(string description = null)
		: base(entityNatureType.None)
	{
		_vertices = new Point3D[0];
		Description = description;
	}

	protected Ghost(Ghost another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = another.Vertices;
		Description = another.Description;
	}

	protected internal Ghost(GhostSurrogate surrogate)
		: this(surrogate.Description)
	{
	}

	protected Ghost(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Description = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019));
	}

	public override object Clone()
	{
		return new Ghost(this);
	}

	public override object CloneWithTessellation()
	{
		return new Ghost(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, null, materials));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970011) + Description);
		return stringBuilder.ToString();
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		return false;
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	protected internal override void Draw(DrawParams data)
	{
	}

	public override void Regen(RegenParams data)
	{
		Vertices = Array.Empty<Point3D>();
		base.Regen(data);
		regenMode = regenType.NotNeeded;
	}

	public override void Compile(CompileParams data)
	{
		regenMode = regenType.NotNeeded;
	}

	internal override bool AvoidSmallSizeCulling()
	{
		return true;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new GhostSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), Description);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		return new Point3D[0];
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		throw new NotImplementedException();
	}
}
