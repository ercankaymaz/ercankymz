using System;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.IO.Templates;

internal class CadDimensionTemplate : CadEntityTemplate
{
	public class DimensionPlaceholder : Dimension
	{
		public override ObjectType ObjectType => ObjectType.INVALID;

		public override double Measurement { get; }

		public DimensionPlaceholder()
			: base(DimensionType.Linear)
		{
		}

		public override BoundingBox GetBoundingBox()
		{
			throw new InvalidOperationException();
		}

		public override void ApplyTransform(Transform transform)
		{
			throw new NotImplementedException();
		}

		public override void UpdateBlock()
		{
			throw new NotImplementedException();
		}
	}

	public ulong? StyleHandle { get; set; }

	public ulong? BlockHandle { get; set; }

	public string BlockName { get; set; }

	public string StyleName { get; set; }

	public CadDimensionTemplate()
		: base(new DimensionPlaceholder())
	{
	}

	public CadDimensionTemplate(Dimension dimension)
		: base(dimension)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		Dimension dimension = base.CadObject as Dimension;
		if (getTableReference<DimensionStyle>(builder, StyleHandle, StyleName, out var reference))
		{
			dimension.Style = reference;
		}
		if (getTableReference<BlockRecord>(builder, BlockHandle, BlockName, out var reference2))
		{
			dimension.Block = reference2;
		}
	}

	public void SetDimensionFlags(DimensionType flags)
	{
		(base.CadObject as Dimension).Flags = flags;
	}

	public void SetDimensionObject(Dimension dimension)
	{
		dimension.Handle = base.CadObject.Handle;
		dimension.Owner = base.CadObject.Owner;
		dimension.XDictionary = base.CadObject.XDictionary;
		dimension.Color = base.CadObject.Color;
		dimension.LineWeight = base.CadObject.LineWeight;
		dimension.LineTypeScale = base.CadObject.LineTypeScale;
		dimension.IsInvisible = base.CadObject.IsInvisible;
		dimension.Transparency = base.CadObject.Transparency;
		Dimension dimension2 = base.CadObject as Dimension;
		dimension.Version = dimension2.Version;
		dimension.DefinitionPoint = dimension2.DefinitionPoint;
		dimension.TextMiddlePoint = dimension2.TextMiddlePoint;
		dimension.InsertionPoint = dimension2.InsertionPoint;
		dimension.Normal = dimension2.Normal;
		dimension.IsTextUserDefinedLocation = dimension2.IsTextUserDefinedLocation;
		dimension.AttachmentPoint = dimension2.AttachmentPoint;
		dimension.LineSpacingStyle = dimension2.LineSpacingStyle;
		dimension.LineSpacingFactor = dimension2.LineSpacingFactor;
		dimension.Text = dimension2.Text;
		dimension.TextRotation = dimension2.TextRotation;
		dimension.HorizontalDirection = dimension2.HorizontalDirection;
		dimension.Flags = dimension2.Flags;
		if (base.CadObject is DimensionAligned dimensionAligned && dimension is DimensionLinear dimensionLinear)
		{
			dimensionLinear.FirstPoint = dimensionAligned.FirstPoint;
			dimensionLinear.SecondPoint = dimensionAligned.SecondPoint;
			dimensionLinear.ExtLineRotation = dimensionAligned.ExtLineRotation;
		}
		base.CadObject = dimension;
	}
}
