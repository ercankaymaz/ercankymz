using System;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

[Serializable]
public abstract class AttributeBase : Text
{
	public virtual bool Invisible { get; set; }

	public bool Constant { get; set; }

	public bool Verify { get; set; }

	public bool Preset { get; set; }

	public bool NormalMode => !Invisible;

	public AttributeBase(double x, double y, double z, string text, double height)
		: base(x, y, z, text, height)
	{
	}

	public AttributeBase(Point3D insPoint, string text, double height)
		: base(insPoint, text, height)
	{
	}

	public AttributeBase(Plane pln, Point3D insPoint, string text, double height)
		: base(pln, insPoint, text, height)
	{
	}

	protected AttributeBase(AttributeBase another)
		: base(another)
	{
		Invisible = another.Invisible;
		Constant = another.Constant;
		Verify = another.Verify;
		Preset = another.Preset;
	}

	protected AttributeBase(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Invisible = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956004));
		Constant = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955988));
		Verify = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955969));
		Preset = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955984));
	}

	protected override void Update(PlanarEntity another)
	{
		base.Update(another);
		AttributeBase attributeBase = (AttributeBase)another;
		Invisible = attributeBase.Invisible;
		Constant = attributeBase.Constant;
		Verify = attributeBase.Verify;
		Preset = attributeBase.Preset;
		base.Billboard = attributeBase.Billboard;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956004), Invisible);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955988), Constant);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955969), Verify);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955984), Preset);
	}

	internal void _0023_003DzsQAoLomWIpW0(Attribute _0023_003Dz7mUUyLk_003D)
	{
		string textString = TextString;
		Update(_0023_003Dz7mUUyLk_003D);
		TextString = textString;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnitsType.Unitless, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955963) + Constant);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955949) + Invisible);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955906) + NormalMode);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955638) + Preset);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955622) + Verify);
		return stringBuilder.ToString();
	}
}
