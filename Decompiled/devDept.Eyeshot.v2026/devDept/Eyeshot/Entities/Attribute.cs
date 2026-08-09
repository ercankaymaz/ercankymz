using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Attribute : AttributeBase
{
	public string Prompt { get; set; }

	public string Tag
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public string Value { get; set; }

	public override bool Invisible { get; set; }

	public Attribute(Plane pln, Point3D insPoint, string tag, string value, double height)
		: base(pln, insPoint, tag, height)
	{
		Value = value;
		Prompt = string.Empty;
	}

	public Attribute(Point3D insPoint, string tag, string value, double height)
		: base(insPoint, tag, height)
	{
		Value = value;
		Prompt = string.Empty;
	}

	public Attribute(double x, double y, double z, string tag, string value, double height)
		: base(x, y, z, tag, height)
	{
		Value = value;
		Prompt = string.Empty;
	}

	protected Attribute(Attribute another)
		: base(another)
	{
		Value = another.Value;
		Prompt = another.Prompt;
	}

	protected internal Attribute(AttributeSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Plane.Origin, surrogate.TextString, surrogate.Value, surrogate.Height)
	{
	}

	protected Attribute(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Prompt = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955837));
		Value = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820));
	}

	public override object Clone()
	{
		return new Attribute(this);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new AttributeSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955837), Prompt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820), Value);
	}

	protected internal override void Draw(DrawParams data)
	{
		if (!IsHidden(data.Parents, data.viewportInternal.parent))
		{
			base.Draw(data);
		}
	}

	internal bool IsHidden(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, IWorkspaceInternal _0023_003DzFM3KC0w_003D)
	{
		if (_0023_003Dzq5nwX2I_003D.Count > 0 && _0023_003DzFM3KC0w_003D.BlockReferenceForObjectManipulator != _0023_003Dzq5nwX2I_003D.Peek())
		{
			return !(_0023_003Dzq5nwX2I_003D.Peek() is ParentBlockReference);
		}
		return false;
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		if (!IsHidden(data.Parents, data.viewportInternal.parent))
		{
			base.DrawForSelection(data);
		}
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		if (data.Parents.Count <= 0)
		{
			base.DrawForShadow(data);
		}
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		if (data.Parents.Count <= 0)
		{
			base.DrawDirection(data);
		}
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		if (data.Parents.Count <= 0)
		{
			base.DrawVertices(data);
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnitsType.Unitless, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955800) + Tag);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955779) + Value);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956020) + Prompt);
		return stringBuilder.ToString();
	}
}
