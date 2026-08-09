using ACadSharp.Attributes;
using ACadSharp.Tables;

namespace ACadSharp.Entities;

[DxfSubClass(null, true)]
public abstract class AttributeBase : TextEntity
{
	private string _tag = string.Empty;

	[DxfCodeValue(new int[] { 74 })]
	public override TextVerticalAlignmentType VerticalAlignment { get; set; }

	[DxfCodeValue(new int[] { 280 })]
	public byte Version { get; set; }

	[DxfCodeValue(new int[] { 2 })]
	public string Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	[DxfCodeValue(new int[] { 70 })]
	public AttributeFlags Flags { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public AttributeType AttributeType { get; set; } = AttributeType.SingleLine;

	public bool IsReallyLocked { get; set; }

	public MText MText { get; set; }

	public AttributeBase()
	{
	}

	protected void matchAttributeProperties(AttributeBase src)
	{
		src.MatchProperties(this);
		base.Thickness = src.Thickness;
		base.InsertPoint = src.InsertPoint;
		base.Height = src.Height;
		base.Value = src.Value;
		base.Rotation = src.Rotation;
		base.WidthFactor = src.WidthFactor;
		base.ObliqueAngle = src.ObliqueAngle;
		base.Style = (TextStyle)src.Style.Clone();
		base.Mirror = src.Mirror;
		base.HorizontalAlignment = src.HorizontalAlignment;
		base.AlignmentPoint = src.AlignmentPoint;
		base.Normal = src.Normal;
		VerticalAlignment = src.VerticalAlignment;
		Version = src.Version;
		Tag = src.Tag;
		Flags = src.Flags;
		AttributeType = src.AttributeType;
		IsReallyLocked = src.IsReallyLocked;
	}
}
